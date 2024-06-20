using Bookstore.common.data.data_sources;
using Bookstore.common.data.entities;
using Bookstore.common.presentation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bookstore.features.order_catalog
{
    public class OrderCatalogViewModel
    {
        private readonly OrderForWidgetRepository _orderForWidgetRepository;
        private readonly OrderLocalDataSource _orderLocalDS;

        private long _page;
        private int _sizePage;
        private string _currentSearch;
        private DateTime? _currentDateSearch;
        private bool _usingDate;

        private readonly List<OrderForWidget> _currentOrders;

        public bool UsingDate
        {
            get
            {
                return _usingDate;
            }
            set
            {
                if (value == _usingDate) return;
                CurrentDateSearch = null;
                _usingDate = value;
            }
        }
        public DateTime? CurrentDateSearch
        {
            get
            {
                return UsingDate ? _currentDateSearch : null;
            }
            set
            {
                if (value == _currentDateSearch) return;
                Handlers.ConnectionHandler(
                    () =>
                    {
                        if (UsingDate)
                        {
                            Search(CurrentSearch, value);
                        }
                        _currentDateSearch = value;
                    }
                );
            }
        }
        public string CurrentSearch
        {
            get
            {
                return _currentSearch is null ? null : string.Copy(_currentSearch);
            }
            set
            {
                string validSearch = value?.Trim();
                if(validSearch == _currentSearch) return;
                Handlers.ConnectionHandler(
                    () =>
                    {
                        Search(validSearch, CurrentDateSearch);
                        _currentSearch = validSearch;
                    }
                );
            }
        }
        public int SizePage
        {
            get
            {
                return _sizePage;
            }
        }
        public long Page
        {
            get
            {
                return _page;
            }
            set
            {
                if(value < 0 || value >= MaxPage) return;
                Handlers.ConnectionHandler(
                    () =>
                    {
                        LoadPage(value, SizePage, CurrentSearch, CurrentDateSearch);
                        _page = value;
                    }
                );
            }
        }
        public long MaxPage { get; private set; }
        public List<OrderForWidget> CurrentOrders
        {
            get
            {
                return new List<OrderForWidget>(_currentOrders);
            }
        }

        public OrderCatalogViewModel(OrderForWidgetRepository orderForWidgetRepository, OrderLocalDataSource orderLocalDataSource)
        {
            _orderForWidgetRepository = orderForWidgetRepository;
            _orderLocalDS = orderLocalDataSource;

            _sizePage = 10;
            _currentDateSearch = DateTime.Now;
            _usingDate = false;
            _currentSearch = default;

            _currentOrders = new List<OrderForWidget>();
        }

        public void Load()
        {
            Handlers.ConnectionHandler(() => Search(CurrentSearch, CurrentDateSearch));
        }

        private void Search(string search, DateTime? date)
        {
            long maxPage = _orderLocalDS.CountPage(SizePage, search, date);
            LoadPage(0, SizePage, search, date);
            _page = 0;
            MaxPage = maxPage;
        }

        private void LoadPage(long page, int sizePage, string search, DateTime? date)
        {
            List<OrderForWidget> orders = _orderForWidgetRepository.SelectAll(page, sizePage, search, date);
            _currentOrders.Clear();
            _currentOrders.AddRange(orders);
        }

        public void Back()
        {
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeBookCatalogScreen());
        }

        public void ChangeOrder(int idOrder)
        {
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeOrderEditorScreen(idOrder));
            //LoadPage(Page, SizePage, CurrentSearch, CurrentDateSearch);
        }
    }
}
