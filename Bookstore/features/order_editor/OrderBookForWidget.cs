using Bookstore.common.data.entities;

namespace Bookstore.features.order_editor
{
    public class OrderBookForWidget
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }

        public OrderBookForWidget(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }
    }
}
