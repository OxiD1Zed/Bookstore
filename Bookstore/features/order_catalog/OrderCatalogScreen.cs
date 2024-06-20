using Bookstore.common.presentation;
using System;
using System.Windows.Forms;

namespace Bookstore.features.order_catalog
{
    public partial class OrderCatalogScreen : UserControl
    {
        private readonly OrderCatalogViewModel _viewModel;

        public OrderCatalogScreen(OrderCatalogViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _viewModel.Back();
        }

        private void DateTimeSearch_ValueChanged(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.CurrentDateSearch = dateTimeSearch.Value;
                    if (_viewModel.UsingDate)
                    {
                        RefreshPage();
                    }
                }
            );
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void TimerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.CurrentSearch = textBoxSearch.Text;
                    RefreshPage();
                }
            );
        }

        private void RefreshLinkPages()
        {
            flowLayoutPages.Controls.Clear();
            flowLayoutPages.Controls.AddRange(
                ScreenService.GeneratePages(
                    _viewModel.Page, 
                    _viewModel.MaxPage,
                    (newPage) =>
                    {
                        Handlers.ViewHandler(
                            () =>
                            {
                                _viewModel.Page = newPage;
                                RefreshPage();
                            }
                        );
                    }
                )
            );
        }

        private void RefreshPage()
        {
            RefreshLinkPages();
            RefreshOrders();
        }

        private void RefreshOrders()
        {
            OrderWidget[] orderWidgets = new OrderWidget[_viewModel.CurrentOrders.Count];
            for(int i = 0; i < orderWidgets.Length; i++)
            {
                OrderWidget orderWidget = new OrderWidget()
                {
                    Order = _viewModel.CurrentOrders[i],
                };
                orderWidget.ButtonChangeOrderClick += (sender, e) =>
                {
                    _viewModel.ChangeOrder(orderWidget.Order.Id);
                    RefreshPage();
                    
                };
                orderWidget.Size = ScreenService.GetValidSizeWidget(orderWidget, flowLayoutOrders);

                orderWidgets[i] = orderWidget;
            }

            flowLayoutOrders.Controls.Clear();
            flowLayoutOrders.Controls.AddRange(orderWidgets);
        }

        private void FlowLayoutOrders_SizeChanged(object sender, EventArgs e)
        {
            ScreenService.FlowLayout_ChangeSize(sender, e);
        }

        private void CheckDate_CheckedChanged(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.UsingDate = checkDate.Checked;
                    RefreshPage();
                }
            );
        }

        private void OrderCatalogScreen_Load(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.Load();
                    RefreshPage();
                }
            );
        }
    }
}
