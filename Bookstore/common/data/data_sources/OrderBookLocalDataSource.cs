using Bookstore.common.data.entities;
using Npgsql;
using System.Collections.Generic;

namespace Bookstore.common.data.data_sources
{
    public class OrderBookLocalDataSource : LocalDataSource
    {
        public OrderBookLocalDataSource(NpgsqlConnection connection) : base(connection) { }

        public List<OrderBook> SelectAllByOrder(int idOrder)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select id_book, quantity from order_book where id_order = @IdOrder";
                    command.Parameters.AddWithValue("@IdOrder", idOrder);
                },
                (reader) =>
                {
                    return new OrderBook(
                        idOrder: idOrder,
                        idBook: reader.GetInt32(0),
                        quantity: reader.GetInt32(1)
                    );
                }
            );
        }

        public void Update(OrderBook orderBook)
        {
            Query(
                (command) =>
                {
                    command.CommandText = "update order_book set quantity = @Quantity where id_order = @IdOrder and id_book = @IdBook";
                    command.Parameters.AddWithValue("@IdOrder", orderBook.IdOrder);
                    command.Parameters.AddWithValue("@IdBook", orderBook.IdBook);
                    command.Parameters.AddWithValue("@Quantity", orderBook.Quantity);
                }
            );
        }

        public void Insert(OrderBook orderBook)
        {
            Query(
                (command) =>
                {
                    command.CommandText = "insert into order_book (id_order, id_book, quantity) values (@IdOrder, @IdBook, @Quantity)";
                    command.Parameters.AddWithValue("@IdOrder", orderBook.IdOrder);
                    command.Parameters.AddWithValue("@IdBook", orderBook.IdBook);
                    command.Parameters.AddWithValue("@Quantity", orderBook.Quantity);
                }
            );
        }

        public void Delete(int idOrder, int idBook)
        {
            Query(
                (command) =>
                {
                    command.CommandText = "delete from order_book where id_order = @IdOrder and id_book = @IdBook";
                    command.Parameters.AddWithValue("@IdOrder", idOrder);
                    command.Parameters.AddWithValue("@IdBook", idBook);
                }
            );
        }
    }
}
