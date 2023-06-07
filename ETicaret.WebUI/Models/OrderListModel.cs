﻿using ETicaret.Entities;

namespace ETicaret.WebUI.Models
{
    public class OrderListModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderState OrderState { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
        public double TotalPrice()
        {
            double kargoUcreti = 29.90;
            if (OrderItems.Sum(x => x.Price * x.Quantity)>500)
            {
                return OrderItems.Sum(x => x.Price * x.Quantity);
            }
            else
            {
                return OrderItems.Sum(x => x.Price * x.Quantity) +kargoUcreti;
            }
           
        }
    }

    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
