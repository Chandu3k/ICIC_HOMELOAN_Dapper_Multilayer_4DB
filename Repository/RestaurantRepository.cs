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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public RestaurantRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddRestaurant(Restaurant restaurant)
        {
            using (IDbConnection con = _connectionFactory.RestaurantConnectionString())
            {
                DynamicParameters parma = new DynamicParameters();
                parma.Add(SP_Parameters.RestaurantName, restaurant.RestaurantName);
                parma.Add(SP_Parameters.RestaurantLocation, restaurant.Location);
                parma.Add(SP_Parameters.Restaurant_IsActive, restaurant.IsActive);
                parma.Add(SP_Parameters.Restaurant_InsertedValue, dbType: DbType.Int32, direction: ParameterDirection.Output);

                await con.ExecuteAsync(SP_Names.AddRestaurant, parma, commandType: CommandType.StoredProcedure);
                int InsertedId = parma.Get<int>(SP_Parameters.Restaurant_InsertedValue);
                return InsertedId;
            }
        }

        public async Task<string> DeleteRestaurant(int id)
        {
            using (IDbConnection con = _connectionFactory.RestaurantConnectionString())
            {
                var parma = new DynamicParameters();
                parma.Add(SP_Parameters.RestaurantId, id);
                var result = con.QueryAsync<Restaurant>(SP_Names.GetRestaurantById, parma, commandType: CommandType.StoredProcedure).Result;
                Restaurant restaurant = result.FirstOrDefault();
                if (restaurant == null)
                {
                    return ($"Restaurant with Id {id} does not exist.");
                }
                else
                {
                    string DeletedData = $"Deleted Student: Id={restaurant.Id}, Name:{restaurant.RestaurantName}, Location:{restaurant.Location}";
                    await con.ExecuteAsync(SP_Names.DeleteRestaurant, parma, commandType: CommandType.StoredProcedure);
                    return (DeletedData);
                }
            }
        }

        public async Task<List<Restaurant>> GetAllRestaurant()
        {
            using (IDbConnection con = _connectionFactory.RestaurantConnectionString())
            {
                var result = await con.QueryAsync<Restaurant>(SP_Names.GetRestaurants, commandType: CommandType.StoredProcedure);
                List<Restaurant> restaurants = result.ToList();
                return restaurants;
            }
        }

        public async Task<Restaurant> GetRestaurantById(int id)
        {
            using (IDbConnection con = _connectionFactory.RestaurantConnectionString())
            {
                var parma = new DynamicParameters();
                parma.Add(SP_Parameters.RestaurantId, id);
                var result = await con.QueryAsync<Restaurant>(SP_Names.GetRestaurantById, parma, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<string> UpdateRestaurant(Restaurant restaurant)
        {
            using (IDbConnection con = _connectionFactory.RestaurantConnectionString())
            {
                var parma = new DynamicParameters();
                parma.Add(SP_Parameters.RestaurantId, restaurant.Id);
                var result = await con.QueryAsync<Restaurant>(SP_Names.GetRestaurantById, parma, commandType: CommandType.StoredProcedure);
                Restaurant res = result.FirstOrDefault();
                if (res == null)
                {
                    return null;
                }
                else
                {

                    parma.Add(SP_Parameters.RestaurantId, restaurant.Id);
                    parma.Add(SP_Parameters.RestaurantName, restaurant.RestaurantName);
                    parma.Add(SP_Parameters.RestaurantLocation, restaurant.Location);
                    parma.Add(SP_Parameters.Restaurant_IsActive, restaurant.IsActive);
                    parma.Add(SP_Parameters.Restaurant_RowCount, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await con.ExecuteAsync(SP_Names.UpdateRestaurant, parma, commandType: CommandType.StoredProcedure);

                    int insertedRowCount = parma.Get<int>(SP_Parameters.Restaurant_RowCount);
                    if (insertedRowCount > 0)
                    {
                        return $"Restaurant with Id {restaurant.Id} is updated successfully.";
                    }
                    else
                    {
                        return $"Failed to update Restaurant with Id {restaurant.Id}.";
                    }

                }
            }
        }

    }
}
