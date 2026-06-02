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
    }
}
