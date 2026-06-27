using BussinessEntites.Interfaces;
using BussinessEntites.Interfaces.IRepository;
using BussinessEntites.Models;
using BussinessEntites.Utils;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public HotelsRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<int> AddHotels(Hotels hotel)
        {
            
            using(IDbConnection con = _connectionFactory.HotelsConnectionString())
            {
                DynamicParameters Hotel=new DynamicParameters();
                Hotel.Add(SP_Parameters.HotelName, hotel.HotelName);
                Hotel.Add(SP_Parameters.HotelLocation, hotel.Location);
                Hotel.Add(SP_Parameters.Hotel_IsActive, hotel.IsActive);
                Hotel.Add(SP_Parameters.Hotel_InsertedValue, dbType:DbType.Int32,direction:ParameterDirection.Output);

                await con.ExecuteAsync(SP_Names.AddHotel, Hotel,commandType:CommandType.StoredProcedure);
                int insertedId = Hotel.Get<int>(SP_Parameters.Hotel_InsertedValue);
                return insertedId ;
            }
            
        }

        public async Task<string> DeleteHotelById(int id)
        {
            using (IDbConnection con = _connectionFactory.HotelsConnectionString())
            {
                var parma = new DynamicParameters();
                parma.Add(SP_Parameters.HotelId, id);
                var result = await con.QueryAsync<Hotels>(SP_Names.GetHotelById, parma, commandType: CommandType.StoredProcedure);
                Hotels hotel = result.FirstOrDefault();
                if(hotel == null)
                {
                    return $"Hotel with Id {id} does not exist.";
                }
                else
                {
                    string DeletedData = $"Deleted Hotel: Id={hotel.Id}, Name:{hotel.HotelName}, Location:{hotel.Location}";
                    await con.ExecuteAsync(SP_Names.DeleteHotel, parma, commandType: CommandType.StoredProcedure);
                    return DeletedData;
                }


            }
        }

        
        public async Task<Hotels> GetHotelById(int id)
        {
            using (IDbConnection con = _connectionFactory.HotelsConnectionString())
            {
                DynamicParameters parma = new DynamicParameters();
                parma.Add(SP_Parameters.HotelId, id);
                var result = await con.QueryAsync<Hotels>(SP_Names.GetHotelById, parma, commandType: CommandType.StoredProcedure);
                Hotels hotel = result.FirstOrDefault();

                return hotel;
            }
        }

        public async Task<string> UpdateHotel(Hotels hotel)
        {
            using (IDbConnection con = _connectionFactory.HotelsConnectionString())
            {
                var parma = new DynamicParameters();
                parma.Add(SP_Parameters.HotelId, hotel.Id);
                var result = await con.QueryAsync<Hotels>(SP_Names.GetHotelById, parma, commandType: CommandType.StoredProcedure);
                Hotels pre_hotel = result.FirstOrDefault();
                if (pre_hotel == null)
                {
                    return null;
                }
                else
                {
                    parma.Add(SP_Parameters.HotelName, hotel.HotelName);
                    parma.Add(SP_Parameters.HotelLocation, hotel.Location);
                    parma.Add(SP_Parameters.Hotel_IsActive, hotel.IsActive);
                    parma.Add(SP_Parameters.Hotel_RowCount, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await con.ExecuteAsync(SP_Names.UpdateHotel, parma, commandType: CommandType.StoredProcedure);
                    var insertedrow = parma.Get<int>(SP_Parameters.Hotel_RowCount);
                    return insertedrow > 0 ? $"Hotel with Id {hotel.Id} updated successfully." : $"Failed to update Hotel with Id {hotel.Id}.";

                    
                }
            }
           
        }

        public async Task<List<Hotels>> GetAllHotels()
        {
            using (IDbConnection con = _connectionFactory.HotelsConnectionString())
            {
                var result= await con.QueryAsync<Hotels>(SP_Names.GetAllHotels, commandType: CommandType.StoredProcedure);
                List<Hotels> hotels = result.ToList();
                return hotels;
            }
        }
    }
}
