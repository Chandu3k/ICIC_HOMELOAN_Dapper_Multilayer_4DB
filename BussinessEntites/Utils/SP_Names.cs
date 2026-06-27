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

        #region --Products--
        public const string AddProduct = "Usp_AddProduct";
        public const string GetProducts = "Usp_GetProducts";
        public const string GetProductById = "Usp_GetProductById";
        public const string UpdateProduct = "Usp_UpdateProduct";
        public const string DeleteProduct = "Usp_DeleteProduct";
        #endregion

        #region --Midland--
        public const string AddMidlandItem = "Usp_AddMidlandItem";
        public const string GetMidlandItems = "Usp_GetMidlandItems";
        public const string GetMidlandItemById = "Usp_GetMidlandItemById";
        public const string UpdateMidlandItem = "Usp_UpdateMidlandItem";
        public const string DeleteMidlandItem = "Usp_DeleteMidlandItem";
        #endregion

        #region  Projectlevel Loging
        public const string ProjectLevelLog = "Usp_ProjectLevelLog";
        #endregion

        #region ProjectLevelErrorLog
        public const string ProjectLevelErrorLog = "Usp_AddProjectLevelErrorlog";
        #endregion

        #region TokenBasedAuthentication Stored Procedures

        public static readonly string GetUserRolesInformation = "Usp_GetUserRolesInformation";

        public static readonly string SignIn = "Usp_LoginCheck";

        public static readonly string UserRegistration = "Usp_UserRegistration";

        public static readonly string RoleRegistration = "Usp_RoleRegistration";

        public static readonly string UserRoleRegistration = "Usp_UserRoleRegistration";

        #endregion

    }
}
