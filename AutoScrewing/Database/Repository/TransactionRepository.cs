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
    public class TransactionRepository
    {
        public string CONNECTION_STRING { get; set; } = "";
        public TransactionRepository()
        {

        }
        async Task<NpgsqlConnection> GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();
            return conn;
        }
        public async Task CreateTransaction(TransactionModel model)
        {
            using (var conn =await GetConnection())
            {
                var transaction = await conn.ExecuteAsync(
                    @"Insert into Transaction(Scan_ID,Torque,ScrewingResult,LaserResult,CameraResult,Result,IsError,TransactionTime)
                    Values (@Scan_ID,@Torque,@ScrewingResult,@LasertResult,@CameraResult,@Result,@IsError,@TransactionTime)", model);
            }
        }
        public async Task<List<TransactionModel>> GetTransaction()
        {
            using (var conn = await GetConnection())
            {
                var list = await conn.QueryAsync<TransactionModel>("Select Scan_ID,Torque,ScrewingResult,LaserResult,CameraResult,Result,IsError,TransactionTime From Transaction order by TransactionTime Desc");
                return list.ToList();
            }
    }
}
