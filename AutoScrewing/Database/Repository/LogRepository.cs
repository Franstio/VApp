using AutoScrewing.Database.Models;
using Dapper;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AutoScrewing.Database.Repository
{
    public class LogRepository
    {

        public string CONNECTION_STRING { get; set; } = "";
        public string Table_Name = "as_log";
        public LogRepository()
        {
            CONNECTION_STRING = Settings1.Default.DBCon;
        }
        async Task<NpgsqlConnection> GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();
            return conn;
        }
        public async Task RecordLog(LogModel log)
        {
            try
            {
                using (var conn = await GetConnection())
                {
                    log.result = log.result.Replace("\0", "");
                    string query = $"Insert into {Table_Name}(record_time,log_type,source,description,status,payload,result) Values(@record_time,@log_type,@source,@description,@status,@payload,@result);";
                    await conn.ExecuteAsync(query, log);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
            }
        }

        public async Task<IList<LogModel>> GetLog(string type,string? search=null,DateTime? from=null,DateTime? to=null, [CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
//            LogModel log = new LogModel("SQL", "Log Repository", $"Called by `{methodName}` in `{System.IO.Path.GetFileName(filePath)}` at line `{lineNumber}`", "Send");
  //          log.payload = JsonSerializer.Serialize(new { type,search,from,to});
            try
            {
                using (var conn = await GetConnection())
                {
                    SqlBuilder builder = new SqlBuilder();
                    if (!string.IsNullOrEmpty(type))
                        builder.Where("log_type=@type", new { type });
                    if (search != null)
                    {
                        search = $"%{search}%";
                        builder.OrWhere("source like @search", new { search });
                        builder.OrWhere("description like @search", new { search });
                        builder.OrWhere("payload like @search", new { search });
                        builder.OrWhere("status like @search", new { search });
                        builder.OrWhere("result like @search", new { search });
                    }
                    if (from is not null && to is not null)
                        builder.Where("record_time between @from::timestamp and @to::timestamp", new { from = from.Value.ToString("yyyy-MM-dd HH:mm:ss"), to = to.Value.ToString("yyyy-MM-dd HH:mm:ss") });
                    var query = builder.AddTemplate($"select log_id,record_time,log_type,source,description,status,payload,result from {Table_Name} /**where**/ order by record_time desc");
                    var data = await conn.QueryAsync<LogModel>(query.RawSql, query.Parameters);
//                    log.result = JsonSerializer.Serialize(data);
//                    log.status += "-Success";
//                    await RecordLog(log);
                    return data.ToList();
                }
            }
            catch (Exception e)
            {
  //              log.result = JsonSerializer.Serialize($"{e.Message} - {e.StackTrace}");
    //            log.status += "-Failed";
      //          await RecordLog(log);
                return [];
            }

        }
        public async Task<IList<string>> GetLogType([CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
//            LogModel log = new LogModel("SQL", "Log Repository", $"Called by `{methodName}` in `{System.IO.Path.GetFileName(filePath)}` at line `{lineNumber}`", "Send");
            try
            {
                using (var conn = await GetConnection())
                {
                    var query = $"select log_type from {Table_Name} group by log_type";
                    var data = await conn.QueryAsync(query);
                    return data.Select(x=>(string)x.log_type).ToList();
                }
            }
            catch (Exception e)
            {
                return [];
            }

        }
        public async Task ClearLog()
        {
            try
            {
                using (var conn = await GetConnection())
                {
                    await conn.ExecuteAsync("Delete from as_log where transaction");
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }
    }
}
