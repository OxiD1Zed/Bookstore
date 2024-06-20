using System;
using System.Windows.Forms;

namespace Bookstore.features.order_catalog
{
    public partial class OrderWidget : UserControl
    {
        private OrderForWidget _order;

        public OrderForWidget Order
        {
            get
            {
                return _order;
            }
            set
            {
                if (value is null) return;
                _order = value;
                labelBooks.Text = string.Join(", ", _order.Books);
                labelComment.Text = "Комментарий: " + _order.Comment;
                labelLogin.Text = "Заказчик: " + _order.LoginCLient;
                labelId.Text = "ID: " + _order.Id.ToString();
                labelStartDate.Text = "Создание: " + _order.StartDate;
                labelState.Text = "Состояние: " + _order.State;
            }
        }

        public event EventHandler ButtonChangeOrderClick;

        public OrderWidget()
        {
            InitializeComponent();
        }

        private void ButtonChange_Click(object sender, System.EventArgs e)
        {
            ButtonChangeOrderClick?.Invoke(sender, e);
        }
    }
}
