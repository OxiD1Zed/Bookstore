using Bookstore.common.data.data_sources;
using Bookstore.common.data.entities;
using System;
using System.Collections.Generic;

namespace Bookstore.features.order_catalog
{
    public class OrderForWidgetRepository
    {
        private readonly OrderLocalDataSource _orderLocalDS;
        private readonly UserLocalDataSource _userLocalDS;
        private readonly StateLocalDataSource _stateLocalDS;
        private readonly OrderBookLocalDataSource _orderBookLocalDS;
        private readonly BookLocalDataSource _bookLocalDS;

        public OrderForWidgetRepository(OrderLocalDataSource orderLocalDS, UserLocalDataSource userLocalDS, StateLocalDataSource stateLocalDS, BookLocalDataSource bookLocalDataSource, OrderBookLocalDataSource orderBookLocalDataSource)
        {
            _orderLocalDS = orderLocalDS;
            _userLocalDS = userLocalDS;
            _stateLocalDS = stateLocalDS;
            _bookLocalDS = bookLocalDataSource;
            _orderBookLocalDS = orderBookLocalDataSource;
        }

        public List<OrderForWidget> SelectAll(long page, int sizePage, string search, DateTime? startDate) 
        {
            List<OrderForWidget> ordersForWidgets = new List<OrderForWidget>();

            List<Order> orders = _orderLocalDS.SelectAll(page, sizePage, search, startDate);
            foreach (Order order in orders)
            {
                User user = _userLocalDS.Select(order.IdUser);
                State state = _stateLocalDS.Select(order.IdState);
                List<OrderBook> ordersBooks = _orderBookLocalDS.SelectAllByOrder(order.Id);
                List<string> stringBooks = new List<string>();
                foreach(OrderBook orderBook in ordersBooks)
                {
                    Book book = _bookLocalDS.Select(orderBook.IdBook);
                    if (book is null) continue;
                    stringBooks.Add(book.Title);
                }
                ordersForWidgets.Add(new OrderForWidget(
                    id: order.Id,
                    loginCLient: user?.Login,
                    comment: order.Comment,
                    startDate: order.StartDate.ToLocalTime().ToString(),
                    state: state?.Title,
                    books: stringBooks
                    )
                );
            }

            return ordersForWidgets;
        }
    }
}
