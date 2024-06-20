using System.Collections.Generic;

namespace Bookstore.features.order_catalog
{
    public class OrderForWidget
    {
        public int Id { get; set; }
        public string LoginCLient { get; set; }
        public string Comment { get; set; }
        public string StartDate { get; set; }
        public string State { get; set; }
        public List<string> Books { get; set; }

        public OrderForWidget(int id, string loginCLient, string comment, string startDate, string state, List<string> books)
        {
            Id = id;
            LoginCLient = loginCLient;
            Comment = comment;
            StartDate = startDate;
            State = state;
            Books = books;
        }
    }
}
