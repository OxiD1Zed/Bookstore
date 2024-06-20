using Bookstore.common.data.entities;
using System;
using System.Windows.Forms;

namespace Bookstore.features.book_catalog
{
    public partial class BookWidget : UserControl
    {
        private Book _book;

        public Book Book
        {
            get { return _book; }
            set
            {
                if (value is null) return;
                _book = value;
                labelTitle.Text = _book.Title;
                labelAuthor.Text = _book.Author;
                labelPrice.Text = decimal.Round(_book.Price, 2).ToString() + " руб.";
            }
        }

        public event EventHandler ButtonAddBookInOrderClick;
        public event EventHandler ButtonChangeBookClick;
        public event EventHandler ButtonRemoveBookClick;

        public BookWidget()
        {
            InitializeComponent();
            buttonChangeBook.Visible = Program.Setting.IsPermissionEditing;
            buttonChangeBook.Enabled = Program.Setting.IsPermissionEditing;
            buttonDeleteBook.Visible = Program.Setting.IsPermissionEditing;
            buttonDeleteBook.Enabled = Program.Setting.IsPermissionEditing;
        }

        private void ButtonAddBookInOrder_Click(object sender, EventArgs e)
        {
            ButtonAddBookInOrderClick?.Invoke(sender, e);
        }

        private void ButtonChangeBook_Click(object sender, EventArgs e)
        {
            ButtonChangeBookClick?.Invoke(sender, e);
        }

        private void ButtonDeleteBook_Click(object sender, EventArgs e)
        {
            ButtonRemoveBookClick?.Invoke(sender, e);
        }
    }
}
