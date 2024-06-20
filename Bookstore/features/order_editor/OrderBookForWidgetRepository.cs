using Bookstore.common.data.data_sources;
using Bookstore.common.data.entities;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.features.order_editor
{
    public class OrderBookForWidgetRepository
    {
        private readonly BookLocalDataSource _bookLocalDS;
        private readonly OrderBookLocalDataSource _orderBookLocalDS;

        public OrderBookForWidgetRepository(BookLocalDataSource bookLocalDS, OrderBookLocalDataSource orderBookLocalDS)
        {
            _bookLocalDS = bookLocalDS;
            _orderBookLocalDS = orderBookLocalDS;
        }

        public List<OrderBookForWidget> SelectAllByOrder(int idOrder)
        {
            List<OrderBook> orderBooks = _orderBookLocalDS.SelectAllByOrder(idOrder);
            return SelectAllByOrderBooks(orderBooks);
        }

        public List<OrderBookForWidget> SelectAllByOrderBooks(List<OrderBook> orderBooks)
        {
            List<OrderBookForWidget> orderBookForWidgets = new List<OrderBookForWidget>();
            List<int> booksId = new List<int>();
            orderBooks.ForEach(orderBook => booksId.Add(orderBook.IdBook));
            List<Book> books = _bookLocalDS.Select(booksId.ToArray());
            orderBooks.ForEach(
                orderBook => orderBookForWidgets.Add(
                    new OrderBookForWidget(
                        books.Where((b) => b.Id == orderBook.IdBook).FirstOrDefault(), 
                        orderBook.Quantity
                    )
                )
            );

            return orderBookForWidgets;
        }

        public void Update(OrderBookForWidget orderBookForWidget, int idOrder)
        {
            _orderBookLocalDS.Update(new OrderBook(idOrder, orderBookForWidget.Book.Id, orderBookForWidget.Quantity));
        }

        public void Delete(OrderBookForWidget orderBookForWidget, int idOrder)
        {
            _orderBookLocalDS.Delete(idOrder, orderBookForWidget.Book.Id);
        }

        public void Insert(OrderBookForWidget orderBookForWidget, int idOrder)
        {
            _orderBookLocalDS.Insert(new OrderBook(idOrder, orderBookForWidget.Book.Id, orderBookForWidget.Quantity));
        }
    }
}
