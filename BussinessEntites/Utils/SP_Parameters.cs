using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Utils
{
    public static class SP_Parameters
    {
        #region --Hotels parameters--
        public const string HotelId = "@Id";
        public const string HotelName = "@HotelName";
        public const string HotelLocation = "@Location";
        public const string Hotel_IsActive = "@IsActive";
        public const string Hotel_InsertedValue = "@InsertedValue";
        public const string Hotel_RowCount = "@UpdatedRows";
        #endregion

        #region--Restaurants parameters--
        public const string RestaurantId = "@Id";
        public const string RestaurantName = "@RestaurantName";
        public const string RestaurantLocation = "@Location";
        public const string Restaurant_IsActive = "@IsActive";
        public const string Restaurant_InsertedValue = "@InsertedId";
        public const string Restaurant_RowCount = "@UpdatedRows";
        #endregion

        #region--Products parameters--
        public const string ProductId = "@ProductId";
        public const string ProductName = "@ProductName";
        public const string ProductPrice = "@Price";
        public const string Product_IsActive = "@IsActive";
        public const string Product_InsertedValue = "@InsertedId";
        public const string Product_RowCount = "@UpdatedRows";
        #endregion

        #region--Midland parameters--
        public const string MidlandItemId = "@Id";
        public const string MidlandItemName = "@Name";
        public const string MidlandItemCity = "@City";
        public const string MidlandItem_IsActive = "@IsActive";
        public const string MidlandItem_InsertedValue = "@InsertedId";
        public const string MidlandItem_RowCount = "@UpdatedRows";
        #endregion

        #region project level logging parameters
        public const string Logging_userName = "@userName";
        public const string Logging_LogLevel = "@LogLevel";
        public const string Logging_MessageTemplate = "@MessageTemplate";
        #endregion

        #region ErrorLog Parameters
        public const string ErrorLog_StatusCode = "@StatusCode";
        public const string ErrorLog_ErrorMessage = "@ErrorMessage";
        public const string ErrorLog_StackTraceError = "@StackTraceError";
        public const string ErrorLog_InnerExceptionError = "@InnerExceptionError";
        public const string ErrorLog_UserName = "@UserName";
        #endregion


        #region -- User Parameters --

        public const string UserId = "@UserId";
        public const string UserName = "@UserName";
        public const string Password = "@Password";
        public const string EmailId = "@EmailId";
        public const string PhoneNumber = "@PhoneNumber";
        public const string Address = "@Address";
        public const string IsActive = "@IsActive";

        #endregion

        #region -- Role Parameters --

        public const string RoleId = "@RoleId";
        public const string RoleName = "@RoleName";

        #endregion

        #region -- UserRole Mapping Parameters --

        public const string UserRole_UserId = "@UserId";
        public const string UserRole_RoleId = "@RoleId";

        #endregion

        #region -- Login Parameters --

        public const string Login_UserName = "@UserName";
        public const string Login_Password = "@Password";

        #endregion

        #region -- Token / Response Related (if used in SP later) --

        public const string StatusCode = "@StatusCode";
        public const string StatusMessage = "@StatusMessage";

        #endregion

        


    }
}
