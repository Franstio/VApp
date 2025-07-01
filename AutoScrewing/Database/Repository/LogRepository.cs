using AutoScrewing.Database.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    log.Result = log.Result.Replace("\0", "");
                    string query = $"Insert into {Table_Name}(record_time,log_type,source,description,status,payload,result) Values(@Record_Time,@Log_Type,@Source,@Description,@Status,@Payload,@Result);";
                    await conn.ExecuteAsync(query, log);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
            }
        }
    }
}
