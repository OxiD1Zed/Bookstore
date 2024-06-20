using System;
using System.Windows.Forms;

namespace Bookstore.features.order_editor
{
    public partial class OrderBookWidget : UserControl
    {
        private OrderBookForWidget _orderBook;

        public OrderBookForWidget OrderBook
        {
            get
            {
                return _orderBook;
            }
            set
            {
                if (value is null) return;
                _orderBook = value;
                bookWidget.Book = _orderBook.Book;
                numericQuantity.Value = _orderBook.Quantity;
            }
        }

        public event EventHandler ButtonRemoveBookClick;
        public event EventHandler QuantityChange;

        public OrderBookWidget()
        {
            InitializeComponent();
        }

        private void ButtonRemoveBook_Click(object sender, EventArgs e)
        {
            ButtonRemoveBookClick?.Invoke(sender, e);
        }

        private void NumericQuantity_ValueChanged(object sender, EventArgs e)
        { 
            QuantityChange?.Invoke(sender, e);
        }
    }
}
