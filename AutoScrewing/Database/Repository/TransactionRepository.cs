using AutoScrewing.Database.Models;
using Dapper;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace AutoScrewing.Database.Repository
{
    public class TransactionRepository
    {
        public string CONNECTION_STRING { get; set; } = "";
        public string Table_Name { get; set; } = "as_transaction";
        private LogRepository logRepository = new LogRepository();
        public TransactionRepository()
        {
            CONNECTION_STRING = Settings1.Default.DBCon;
        }
        async Task<NpgsqlConnection> GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();
            return conn;
        }
        public async Task CreateTransaction(TransactionModel model, [CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            LogModel log = new LogModel("SQL", "Transaction Repository", $"Called by `{methodName}` in `{System.IO.Path.GetFileName(filePath)}` at line `{lineNumber}`", "Send");
            log.payload = JsonSerializer.Serialize(model);
            try
            {
                using (var conn = await GetConnection())
                {
                    var transaction = await conn.ExecuteAsync(
                        $@"Insert into {Table_Name}(scan_id,scan_id2,torque,screwingResult,screwingtime,threadcount,laserresult,cameraresult,result,iserror,transactiontime,errordesc,finalresult,tighteningstatus)
                    Values (@Scan_ID,@Scan_ID2,@Torque,@ScrewingResult,@LasertResult,@ScrewingTime,@ThreadCount,@CameraResult,@Result,@IsError,@TransactionTime,@ErrorDesc,@FinalResult,@TighteningStatus)", model);
                    log.result = JsonSerializer.Serialize (transaction);
                    log.status += "-Success";
                }
            }
            catch (Exception e)
            {
                log.result = JsonSerializer.Serialize($"{e.Message} - {e.StackTrace}");
                log.status += "-Failed";
            }
            finally
            {
                await logRepository.RecordLog(log);
            }
        }
        public async Task<List<TransactionModel>> GetTransaction([CallerMemberName] string? methodName = null, [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            LogModel log = new LogModel("SQL", "Transaction Repository", $"Called by `{methodName}` in `{System.IO.Path.GetFileName(filePath)}` at line `{lineNumber}`", "Send");
            try
            {
                using (var conn = await GetConnection())
                {
                    var list = await conn.QueryAsync<TransactionModel>($"Select scan_id,scan_id2,torque,screwingresult,screwingtime,threadcount,laserresult,cameraresult,result,iserror,transactiontime,errordesc,finalresult,tighteningstatus From {Table_Name} order by TransactionTime Desc");
                    log.result = JsonSerializer.Serialize(list);
                    log.status += "-Success";
                    await logRepository.RecordLog(log);
                    return list.ToList();
                }
            }
            catch (Exception e)
            {

                log.result = JsonSerializer.Serialize($"{e.Message} - {e.StackTrace}");
                log.status += "-Failed";
                await logRepository.RecordLog(log);
                return [];
            }
        }
    }
}
