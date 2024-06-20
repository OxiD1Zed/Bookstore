namespace Bookstore.common.data.entities
{
    public class OrderBook
    {
        public int IdOrder {  get; set; }
        public int IdBook { get; set; }
        public int Quantity { get; set; }

        public OrderBook(int idOrder, int idBook, int quantity)
        {
            IdOrder = idOrder;
            IdBook = idBook;
            Quantity = quantity;
        }
    }
}
