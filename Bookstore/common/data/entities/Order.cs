using System;

namespace Bookstore.common.data.entities
{
    public class Order
    {
        public int Id { get; set; }
        public int IdState { get; set; }
        public int IdUser { get; set; }
        public decimal TotalPrice { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }

        public Order(int id, int idState, int idUser, decimal totalPrice, string comment, DateTime startDate)
        {
            Id = id;
            IdState = idState;
            IdUser = idUser;
            TotalPrice = totalPrice;
            Comment = comment;
            StartDate = startDate;
        }
    }
}
