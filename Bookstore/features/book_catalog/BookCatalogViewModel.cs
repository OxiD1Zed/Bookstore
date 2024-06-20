using Bookstore.common.data.data_sources;
using Bookstore.common.data.entities;
using Bookstore.common.presentation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bookstore.features.book_catalog
{
    public class BookCatalogViewModel
    {
        private readonly BookLocalDataSource _bookLocalDS;

        private int _sizePage;
        private long _page;
        private bool _isDownDirectionSort;
        private string _currentSearch;
        private SortesType _currentSortesType;

        private readonly List<Book> _currentBooks;

        public List<Book> CurrentBooks
        {
            get
            {
                return new List<Book>(_currentBooks);
            }
        }
        public long MaxPage { get; private set; }
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
                if (value < 0 || value >= MaxPage) return;
                Handlers.ConnectionHandler(
                    () =>
                    {
                        LoadPage(value, SizePage, CurrentSearch, CurrentSortesType, IsDownDirectionSort);
                        _page = value;
                    }
                );
            }
        }
        public bool IsDownDirectionSort
        {
            get
            {
                return _isDownDirectionSort;
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
                string _validValue = value?.Trim();
                if (_validValue == _currentSearch) return;
                Handlers.ConnectionHandler(
                    () =>
                    {
                        Search(_validValue, CurrentSortesType, IsDownDirectionSort);
                        _currentSearch = _validValue;
                    }
                );
            }
        }
        public SortesType CurrentSortesType
        {
            get
            {
                return _currentSortesType;
            }
            set
            {
                if(value == _currentSortesType) return;
                Handlers.ConnectionHandler(
                    () =>
                    {
                        Search(CurrentSearch, value, IsDownDirectionSort);
                        _currentSortesType = value;
                    }
                );
            }
        }

        public BookCatalogViewModel(BookLocalDataSource bookLocalDataSource) 
        {
            _bookLocalDS = bookLocalDataSource;

            _currentBooks = new List<Book>();

            _sizePage = 10;
            _isDownDirectionSort = true;
            _currentSearch = default;
            _currentSortesType = SortesType.Author;
        }

        public void Load()
        {
            Handlers.ConnectionHandler(() => Search(CurrentSearch, CurrentSortesType, IsDownDirectionSort));
        }

        public void ExitProfile()
        {
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeAuthScreen());
        }

        private void Search(string search, SortesType sortesType, bool isDownDirectionSort)
        {
            long maxPage = _bookLocalDS.CountPage(SizePage, search);
            LoadPage(0, SizePage, search, sortesType, isDownDirectionSort);
            _page = 0;
            MaxPage = maxPage;
        }

        private void LoadPage(long page, int sizePage, string search, SortesType sortesType, bool isDownDirectionSort)
        {
            List<Book> books = _bookLocalDS.SelectAll(page, sizePage, search, (int)sortesType, isDownDirectionSort);
            _currentBooks.Clear();
            _currentBooks.AddRange(books);
        }

        public void AddBookInOrder(Book book)
        {
            Program.Setting.AddBookInOrder(book, 1);
        }

        public void ChangeDirectionSort()
        {
            Handlers.ConnectionHandler(
                () =>
                {
                    bool newDirection = !IsDownDirectionSort;
                    Search(CurrentSearch, CurrentSortesType, newDirection);
                    _isDownDirectionSort = newDirection;
                }
            );
        }

        public void ShowOrders()
        {
            PermissionChecking();
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeOrderCatalogScreen());
        }

        public void ShowOrder()
        {
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeOrderEditorScreen(null));
            //LoadPage(Page, SizePage, CurrentSearch, CurrentSortesType, IsDownDirectionSort);
        }

        public void OpenBook(int idBook)
        {
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeBookEditorScreen(idBook));
            //LoadPage(Page, SizePage, CurrentSearch, CurrentSortesType, IsDownDirectionSort);   
        }

        public void AddBook()
        {
            PermissionChecking();
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeBookEditorScreen(null));
            //LoadPage(Page, SizePage, CurrentSearch, CurrentSortesType, IsDownDirectionSort);      
        }

        public void RemoveBook(int idBook)
        {
            PermissionChecking();
            Handlers.ConnectionHandler(
                () =>
                {
                    _bookLocalDS.Delete(idBook);
                    LoadPage(Page, SizePage, CurrentSearch, CurrentSortesType, IsDownDirectionSort);
                }
            );
        }

        private void PermissionChecking()
        {
            if (!Program.Setting.IsPermissionEditing) throw new Exception("Вы не можете выполнить данное действие");
        }
    }

    public enum SortesType
    { 
        Author,
        Price
    }
}
