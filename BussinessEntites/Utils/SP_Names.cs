using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Utils
{
    public static class SP_Names
    {
        #region -- Hotels--
        public const string GetAllHotels = "Usp_GetHotels";
        public const string GetHotelById = "Usp_GetHotelById";
        public const string AddHotel = "Usp_AddHotel";
        public const string UpdateHotel = "Usp_UpdateHotel";
        public const string DeleteHotel = "Usp_DeleteHotel";
        #endregion

        #region --Restaurants--
        public const string AddRestaurant = "Usp_AddRestaurant";
        public const string DeleteRestaurant = "Usp_DeleteRestaurant";
        public const string GetRestaurantById = "Usp_GetRestaurantById";
        public const string UpdateRestaurant = "Usp_UpdateRestaurant";
        public const string GetRestaurants = "Usp_GetRestaurants";
        #endregion
    }
}
