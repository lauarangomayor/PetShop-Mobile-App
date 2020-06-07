﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    public class UserClientModel : PersonModel
    {
        #region Properties
        private OrderModel activeOrder;
        private WishlistModel wishlist;
        private ShoppingCartModel cart;
        private List<OrderModel> orderRecord;
        #endregion

        #region Initialize
        public UserClientModel(ShoppingCartModel cart)
        {
            if (cart == null)
            {
                throw new System.ArgumentException("UserClientModel received a null ShoppingCartModel argument");
            }
            this.cart = cart;
            cart.User = this;
        }
        #endregion

        #region Getters/Setters
        public OrderModel Order
        {
            get { return activeOrder; }
            set { activeOrder = value; OnPropertyChanged(); }
        }
        public WishlistModel Wishlist
        {
            get { return wishlist; }
            set { wishlist = value; OnPropertyChanged(); }
        }
        public ShoppingCartModel Car
        {
            get { return car; }
            set { car = value; OnPropertyChanged(); }
        }
        public List<OrderModel> OrderRecord
        {
            get { return orderRecord; }
            set { orderRecord = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
