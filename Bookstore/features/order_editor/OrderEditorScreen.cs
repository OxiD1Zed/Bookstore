using Bookstore.common.data.entities;
using Bookstore.common.presentation;
using System;
using System.Windows.Forms;

namespace Bookstore.features.order_editor
{
    public partial class OrderEditorScreen : UserControl
    {
        private readonly OrderEditorViewModel _viewModel;

        public OrderEditorScreen(OrderEditorViewModel viewModel)
        {
            InitializeComponent();
            dateTimePickerStartDate.Enabled = Program.Setting.IsPermissionEditing;
            numericTotalPrice.Enabled = Program.Setting.IsPermissionEditing;
            textBoxComment.Enabled = Program.Setting.IsPermissionEditing;
            comboBoxStates.Enabled = Program.Setting.IsPermissionEditing;
            numericTotalPrice.Maximum = decimal.MaxValue;
            _viewModel = viewModel;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _viewModel.Back();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.Save(dateTimePickerStartDate.Value, (comboBoxStates.SelectedItem as State).Id, numericTotalPrice.Value, textBoxComment.Text);
                    _viewModel.Back();
                }
            );
        }

        private void RefreshProducts()
        {
            OrderBookWidget[] orderBookWidgets = new OrderBookWidget[_viewModel.OrderBooks.Count];
            for(int i = 0; i < orderBookWidgets.Length; i++)
            {
                OrderBookWidget orderBookWidget = new OrderBookWidget()
                {
                    OrderBook = _viewModel.OrderBooks[i],
                };
                orderBookWidget.Size = ScreenService.GetValidSizeWidget(orderBookWidget, flowLayoutProducts);
                orderBookWidget.ButtonRemoveBookClick += (sender, e) => 
                {
                    if(MessageBox.Show($"Вы действительно хотите удалить из заказа товар {orderBookWidget.OrderBook.Book.Title}", "Удаление товара из заказа", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        _viewModel.RemoveOrderBook(orderBookWidget.OrderBook);
                        RefreshProducts();
                    }
                };
                orderBookWidget.QuantityChange += (sender, e) =>
                {
                    Handlers.ViewHandler(
                        () =>
                        {
                            int quantity = (int)(sender as NumericUpDown).Value;
                            if (quantity <= 0 && MessageBox.Show("Вы уверены, что хотите удалить товар?", "Удаление товара", MessageBoxButtons.OKCancel) == DialogResult.OK) return;
                            _viewModel.OrderBookQuantityChange(orderBookWidget.OrderBook, quantity);
                        }
                    );
                    numericTotalPrice.Value = _viewModel.TotalPrice;
                    RefreshProducts();
                };

                orderBookWidgets[i] = orderBookWidget;
            }

            flowLayoutProducts.Controls.Clear();
            flowLayoutProducts.Controls.AddRange(orderBookWidgets);
        }

        private void OrderEditorScreen_Load(object sender, EventArgs e)
        {
            Handlers.ConnectionHandler(
                () =>
                {
                    _viewModel.Load();
                    labelIDValue.Text = _viewModel.ID.ToString();
                    dateTimePickerStartDate.Value = _viewModel.StartDate;
                    comboBoxStates.Items.Clear();
                    comboBoxStates.DisplayMember = "Title";
                    comboBoxStates.Items.AddRange(_viewModel.States.ToArray());
                    comboBoxStates.SelectedItem = _viewModel.State;
                    labelClientValue.Text = _viewModel.Client;
                    numericTotalPrice.Value = _viewModel.TotalPrice;
                    textBoxComment.Text = _viewModel.Comment;
                    RefreshProducts();
                }
            );
        }

        private void FlowLayoutProducts_SizeChanged(object sender, EventArgs e)
        {
            ScreenService.FlowLayout_ChangeSize(sender, e);
        }
    }
}
