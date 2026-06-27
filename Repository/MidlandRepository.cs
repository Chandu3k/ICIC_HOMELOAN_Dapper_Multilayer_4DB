using BussinessEntites.Interfaces;
using BussinessEntites.Interfaces.IRepository;
using BussinessEntites.Models;
using BussinessEntites.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class MidlandRepository : IMidlandRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public MidlandRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddMidlandItemAsync(MidlandItems item)
        {
            using (IDbConnection con = _connectionFactory.MidlandConnectionString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(SP_Parameters.MidlandItemName, item.Name);
                parameters.Add(SP_Parameters.MidlandItemCity, item.City);
                parameters.Add(SP_Parameters.MidlandItem_IsActive, item.IsActive);
                parameters.Add(SP_Parameters.MidlandItem_InsertedValue, dbType: DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteAsync(SP_Names.AddMidlandItem, parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>(SP_Parameters.MidlandItem_InsertedValue);
            }

        }

        public async Task<string> DeleteMidlandItemAsync(int id)
        {
            using (IDbConnection con = _connectionFactory.MidlandConnectionString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(SP_Parameters.MidlandItemId, id);
                var result = await con.QueryAsync<MidlandItems>(SP_Names.GetMidlandItemById, parameters, commandType: CommandType.StoredProcedure);
                if (result != null && result.Count() > 0)
                {
                    await con.ExecuteAsync(SP_Names.DeleteMidlandItem, parameters, commandType: CommandType.StoredProcedure);
                    return "Deleted Successfully";
                }
                else
                {
                    return "Item not found";
                }

            }
        }

        public async Task<List<MidlandItems>> GetMidlandItemAsync()
        {
            using (IDbConnection con = _connectionFactory.MidlandConnectionString())
            {
                var result = (await con.QueryAsync<MidlandItems>(SP_Names.GetMidlandItems, commandType: CommandType.StoredProcedure)).ToList();
                return result;
            }
        }

        public async Task<MidlandItems> GetMidlandItemByIdAsync(int id)
        {
            using (IDbConnection con = _connectionFactory.MidlandConnectionString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(SP_Parameters.MidlandItemId, id);
                var result = (await con.QueryAsync<MidlandItems>(SP_Names.GetMidlandItemById, parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return result;
            }
        }

        public async Task<string> UpdateMidlandItemAsync(MidlandItems item)
        {
            using (IDbConnection con = _connectionFactory.MidlandConnectionString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(SP_Parameters.MidlandItemId, item.Id);
                var existingItem = await con.QueryAsync<MidlandItems>(SP_Names.GetMidlandItemById, parameters, commandType: CommandType.StoredProcedure);
                if (existingItem==null)
                {
                    return "Item not found";
                }
                else
                {
                    parameters.Add(SP_Parameters.MidlandItemName, item.Name);
                    parameters.Add(SP_Parameters.MidlandItemCity, item.City);
                    parameters.Add(SP_Parameters.MidlandItem_IsActive, item.IsActive);
                    parameters.Add(SP_Parameters.MidlandItem_RowCount, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await con.ExecuteAsync(SP_Names.UpdateMidlandItem, parameters, commandType: CommandType.StoredProcedure);
                    var updatedRows = parameters.Get<int>(SP_Parameters.MidlandItem_RowCount);
                    return updatedRows> 0 ? $"Updated Successfully ({updatedRows} rows)" : "Update Failed";
                }
            }
        }
    }}
