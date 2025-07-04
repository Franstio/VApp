using AutoScrewing.Database.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoScrewing.Database.Repository
{
    public class ConfigRepository
    {

        public string CONNECTION_STRING { get; set; } = "";
        private LogRepository logRepository = new LogRepository();
        public ConfigRepository()
        {
            CONNECTION_STRING = Settings1.Default.DBCon;
        }

        async Task<NpgsqlConnection> GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();
            return conn;
        }
        private string HashPassword(string password)
        {
            byte[] key = Encoding.UTF8.GetBytes("asjdlnkcnalnaehneuvnq1uf9q91fvbcibnckncknkzxn=13fkanp33922acnae");
            using (var hm = new HMACSHA512(key))
            {
                byte[] enc = Encoding.UTF8.GetBytes(password);
                byte[] buffer = hm.ComputeHash(enc);
                return Convert.ToBase64String(buffer);
            }
        }
        public async Task<UserConfigModel?> LoginAsync(string username,string password, [CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            LogModel log = new LogModel("SQL", "Config Repository", $"Called by `{methodName}` in `{System.IO.Path.GetFileName(filePath)}` at line `{lineNumber}`", "Send");
            log.payload = JsonSerializer.Serialize(new {username=username,password=password});
            try
            {
                using (var conn = await GetConnection())
                {
                    string query = "Select uid,username,password,createdat from as_userconfig where username=@username and password=@password";
                    password = HashPassword(password);
                    var data = await conn.QueryAsync<UserConfigModel>(query,new {username,password});
                    log.result = JsonSerializer.Serialize(data);
                    log.status += "-Success";
                    await logRepository.RecordLog(log);
                    return data.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                log.result = JsonSerializer.Serialize($"{e.Message} - {e.StackTrace}");
                log.status += "-Failed";
                await logRepository.RecordLog(log);
                return null;
            }
        }
        public async Task<int> LogLogin(UserConfigModel user,string action, [CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            LogModel log = new LogModel("SQL", "Config Repository", $"Called by `{methodName}` in `{System.IO.Path.GetFileName(filePath)}` at line `{lineNumber}`", "Send");
            log.payload = JsonSerializer.Serialize(user);
            try
            {
                using (var conn = await GetConnection())
                {
                    string query = "Insert into as_configlog(uid,log_time,action) values(@uid,now(),@action)";
                    var data = await conn.ExecuteAsync(query, new { uid=user.Uid,action});
                    log.result = JsonSerializer.Serialize(data);
                    log.status += "-Success";
                    await logRepository.RecordLog(log);
                    return data;
                }
            }
            catch (Exception e)
            {
                log.result = JsonSerializer.Serialize($"{e.Message} - {e.StackTrace}");
                log.status += "-Failed";
                await logRepository.RecordLog(log);
                return -1;
            }
        }
    }
}
