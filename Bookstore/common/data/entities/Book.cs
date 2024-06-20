namespace Bookstore.common.data.entities
{
    public class Book
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public Book(int id, decimal price, int quantityInStock, string author, string title)
        {
            Id = id;
            Price = price;
            QuantityInStock = quantityInStock;
            Author = author;
            Title = title;
        }
    }
}
