using Bookstore.common.data.data_sources;
using Bookstore.common.data.entities;
using Bookstore.common.presentation;
using System;

namespace Bookstore.features.book_editor
{
    public class BookEditorViewModel
    {
        private readonly BookLocalDataSource _bookLocalDS;
        private readonly int? _idBook;
        private Book _currentBook;

        public bool IsPermissionEditing { get; private set; }
        public bool IsNew 
        { 
            get
            {
                return _idBook is null;
            }
        }
        public int ID
        {
            get
            {
                return _currentBook.Id;
            }
        }
        public string Title
        {
            get
            {
                return _currentBook.Title is null ? null : string.Copy(_currentBook.Title);
            }
        }
        public string Author
        {
            get
            {
                return _currentBook.Author is null ? null : string.Copy(_currentBook.Author);
            }
        }
        public decimal Price
        {
            get
            {
                return _currentBook.Price;
            }
        } 
        public int QuantityInStock
        {
            get
            {
                return _currentBook.QuantityInStock;
            }
        }

        public BookEditorViewModel(int? idBook, BookLocalDataSource bookLocalDS)
        {
            _bookLocalDS = bookLocalDS;
            _idBook = idBook;
            IsPermissionEditing = Program.Setting.CurrentUser.IdPost == 1;
        }

        public void Load()
        {
            if (_idBook is null)
            {
                _currentBook = new Book(default, default, default, default, default);
            }
            else
            {
                Handlers.ConnectionHandler(
                    () =>
                    {
                        _currentBook = _bookLocalDS.Select(_idBook ?? -1);
                    }
                );
            }
        }

        public void AddBookInOrder()
        {
            if (IsNew) throw new Exception("Вы не можете выполнить данное действие");
            Program.Setting.AddBookInOrder(_currentBook, 1);
        }

        public void Save(string title, string author, decimal price, int quantityInStock)
        {
            if (!IsPermissionEditing) throw new Exception("Вы не можете выполнить данное действие");
            if (string.IsNullOrWhiteSpace(title) || author is null || price < 0 || quantityInStock < 0) throw new ArgumentException("Некорректные параметры");
            Handlers.ConnectionHandler(
                () =>
                {
                    _currentBook.Title = title;
                    _currentBook.Author = author;
                    _currentBook.Price = price;
                    _currentBook.QuantityInStock = quantityInStock;
                    if(_idBook is null)
                    {
                        _bookLocalDS.Insert(_currentBook);
                    }
                    else
                    {
                        _bookLocalDS.Update(_currentBook);
                    }
                }
            );
        }

        public void Back()
        {
            Program.Navigator.PushRemove(Program.ScreenFactory.MakeBookCatalogScreen());
        }
    }
}
