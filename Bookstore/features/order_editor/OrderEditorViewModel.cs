using Bookstore.common.data.data_sources;
using Bookstore.common.data.entities;
using Bookstore.common.domain;
using Bookstore.common.presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.features.order_editor
{
    public class OrderEditorViewModel
    {
        private readonly OrderLocalDataSource _orderLocalDS;
        private readonly StateLocalDataSource _stateLocalDS;
        private readonly UserLocalDataSource _userLocalDS;
        private readonly OrderBookLocalDataSource _orderBookLocalDS;
        private readonly BookLocalDataSource _bookLocalDS;
        private readonly OrderBookForWidgetRepository _orderBookForWidgetRepository;
        private readonly SmtpSendler _smtpSendler;

        private readonly int? _idOrder;
        private readonly List<OrderBook> _bufferOrderBooks;
        private readonly List<OrderBookForWidget> _orderBooks;
        private readonly List<OrderBookForWidget> _removeOrderBooks;
        private readonly List<OrderBookForWidget> _updateOrderBooks;
        private readonly List<State> _states;
        private Order _order;
        private string _client;

        public bool IsNew
        {
            get
            {
                return _idOrder is null;
            }
        }
        public int ID
        {
            get
            {
                return _order.Id;
            }
        }
        public State State
        {
            get
            {
                return _states.Where((st) => st.Id == _order.IdState).FirstOrDefault();
            }
        }
        public string Client
        {
            get
            {
                return _client is null ? null : string.Copy(_client);
            }
            private set
            {
                if (value is null) return;
                _client = value;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return _order.TotalPrice;
            }
        }
        public string Comment
        {
            get
            {
                return _order.Comment is null ? null : string.Copy(_order.Comment);
            }
        }
        public DateTime StartDate
        {
            get
            {
                return _order.StartDate.ToLocalTime();
            }
        }
        public List<OrderBookForWidget> OrderBooks
        {
            get
            {
                return new List<OrderBookForWidget>(_orderBooks);
            }
        }
        public List<State> States
        {
            get
            {
                return new List<State>(_states);
            }
        }

        public OrderEditorViewModel(
            int? idOrder, 
            OrderLocalDataSource orderLocalDataSource, 
            StateLocalDataSource stateLocalDataSource, 
            OrderBookForWidgetRepository orderBookForWidgetRepository,
            UserLocalDataSource userLocalDataSource,
            OrderBookLocalDataSource orderBookLocalDataSource,
            BookLocalDataSource bookLocalDataSource,
            SmtpSendler smtpSendler
        )
        {
            _idOrder = idOrder;
            _orderLocalDS = orderLocalDataSource;
            _stateLocalDS = stateLocalDataSource;
            _orderBookForWidgetRepository = orderBookForWidgetRepository;
            _userLocalDS = userLocalDataSource;
            _orderBookLocalDS = orderBookLocalDataSource;
            _bookLocalDS = bookLocalDataSource;
            _smtpSendler = smtpSendler;

            _orderBooks = new List<OrderBookForWidget>();
            _removeOrderBooks = new List<OrderBookForWidget>();
            _updateOrderBooks = new List<OrderBookForWidget>();
            _states = new List<State>();
            _bufferOrderBooks = new List<OrderBook>();
        }

        public void Load()
        {
            Handlers.ConnectionHandler(
                () =>
                {
                    if (_idOrder is null)
                    {
                        _order = new Order(default, 1, Program.Setting.CurrentUser.Id, default, default, DateTime.Now);
                        _bufferOrderBooks.AddRange(Program.Setting.CurrentOrder);
                        _orderBooks.AddRange(_orderBookForWidgetRepository.SelectAllByOrderBooks(Program.Setting.CurrentOrder));
                        _client = Program.Setting.CurrentUser.Login;
                    }
                    else
                    {
                        _order = _orderLocalDS.Select(_idOrder ?? -1);
                        _bufferOrderBooks.AddRange(_orderBookLocalDS.SelectAllByOrder(_idOrder ?? -1));
                        _orderBooks.AddRange(_orderBookForWidgetRepository.SelectAllByOrder(_idOrder ?? -1));
                        User user = _userLocalDS.Select(_order.IdUser);
                        _client = user?.Login;
                    }
                    _order.TotalPrice = CountingTotalPrice(_orderBooks);
                    _states.AddRange(_stateLocalDS.SelectAll());
                }
            );
        }

        public void Back()
        {
            if (IsNew) Program.Navigator.PushRemove(Program.ScreenFactory.MakeBookCatalogScreen());
            else Program.Navigator.PushRemove(Program.ScreenFactory.MakeOrderCatalogScreen());
        }

        public void Save(DateTime startDate, int idState, decimal totalPrice, string comment)
        {
            if (totalPrice < 0) throw new ArgumentException("Некорректные данные");
            if (_orderBooks.Count < 1) throw new ArgumentException("Заказ должен содержать хотя бы один товар");
            Handlers.ConnectionHandler(
                () =>
                {
                    _order.StartDate = startDate;
                    _order.TotalPrice = totalPrice;
                    _order.Comment = comment.Trim();
                    _order.IdState = idState;
                    if (IsNew)
                    {
                        _order.Id = _orderLocalDS.Insert(_order);
                    }
                    else
                    {
                        _orderLocalDS.Update(_order);
                    }
                    foreach(OrderBookForWidget orderBookForWidget in _updateOrderBooks)
                    {
                        _orderBookForWidgetRepository.Update(orderBookForWidget, _order.Id);
                        orderBookForWidget.Book.QuantityInStock -= orderBookForWidget.Quantity - _bufferOrderBooks.Where((ob) => ob.IdBook == orderBookForWidget.Book.Id).First().Quantity;
                        _bookLocalDS.Update(orderBookForWidget.Book);
                    }
                    foreach(OrderBookForWidget orderBookForWidget in _removeOrderBooks)
                    {
                        _orderBookForWidgetRepository.Delete(orderBookForWidget, _order.Id);
                        orderBookForWidget.Book.QuantityInStock += _bufferOrderBooks.Where((ob) => ob.IdBook == orderBookForWidget.Book.Id).First().Quantity;
                    }
                    foreach(OrderBookForWidget orderBookForWidget in _orderBooks)
                    {
                        if (_updateOrderBooks.Contains(orderBookForWidget)) continue;
                        _orderBookForWidgetRepository.Insert(orderBookForWidget, _order.Id);
                        orderBookForWidget.Book.QuantityInStock -= orderBookForWidget.Quantity;
                        _bookLocalDS.Update(orderBookForWidget.Book);
                    }
                    _smtpSendler.Send(
                        "Магазин Bookstore", 
                        $"Ваш заказ от {_order.StartDate.ToLocalTime()} приобрел статус: {State.Title}" +
                        $"\nТовары в заказе: {string.Join(", ", _orderBooks.ConvertAll((ob) => ob.Book.Title + " - " + ob.Quantity))}\n" +
                        (string.IsNullOrWhiteSpace(Comment) ? "" : Comment), 
                        Client
                    );
                }
            );
        }

        public void OrderBookQuantityChange(OrderBookForWidget orderBookForWidget, int quantity)
        {
            bool itsOver = false;
            if (IsNew)
            {
                itsOver = orderBookForWidget.Book.QuantityInStock <= quantity;
            }
            else
            {
                OrderBook orderBook = _bufferOrderBooks.Where((ob) => ob.IdBook == orderBookForWidget.Book.Id).FirstOrDefault();
                itsOver = quantity - orderBook?.Quantity >= quantity;
            }
            if (itsOver) throw new ArgumentException("Данный товар закончился");
            if (!_updateOrderBooks.Contains(orderBookForWidget) && !IsNew)
            {
                _updateOrderBooks.Add(orderBookForWidget);
            }
            orderBookForWidget.Quantity = quantity;
            if(quantity == 0) RemoveOrderBook(orderBookForWidget);
            _order.TotalPrice = CountingTotalPrice(OrderBooks);
        }

        public void RemoveOrderBook(OrderBookForWidget orderBookForWidget)
        {
            _orderBooks.Remove(orderBookForWidget);
            _removeOrderBooks.Add(orderBookForWidget);
        }

        private decimal CountingTotalPrice(List<OrderBookForWidget> orderBookForWidget)
        {
            decimal totalPrice = 0;
            foreach(OrderBookForWidget orderBook in orderBookForWidget)
            {
                totalPrice += orderBook.Book.Price * orderBook.Quantity;
            }
            return totalPrice;
        }
    }
}
