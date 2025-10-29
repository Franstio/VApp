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
    public class QtyRepository
    {
        public string CONNECTION_STRING { get; set; } = "";
        public string Table_Name = "as_qty";
        public QtyRepository()
        {
            CONNECTION_STRING = Settings1.Default.DBCon;
        }
        async Task<NpgsqlConnection> GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(CONNECTION_STRING);
            await conn.OpenAsync();
            return conn;
        }

        public async Task<QtyModel?> GetQty()
        {
            using (var conn = await GetConnection())
            {
                string query = $"Select input as Input, pass as Pass, ng as NG from {Table_Name}";
                return await conn.QueryFirstOrDefaultAsync<QtyModel>(query);
                
            }
        }
        public async Task CreateQty()
        {
            using (var conn = await GetConnection())
            {
                string query = $"Insert into {Table_Name}(input,pass,ng) values(0,0,0);";
                await conn.ExecuteAsync(query);
            }
        }
        public async Task SetQty(QtyModel model)
        {
            using (var conn = await GetConnection())
            {
                string query = $"Update {Table_Name} set input={model.Input},pass={model.Pass},ng={model.NG}";
                await conn.ExecuteAsync(query);
            }
        }
    }
}
