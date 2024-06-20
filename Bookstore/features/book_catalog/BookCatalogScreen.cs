using Bookstore.common.presentation;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bookstore.features.book_catalog
{
    public partial class BookCatalogScreen : UserControl
    {
        private readonly BookCatalogViewModel _viewModel;

        public BookCatalogScreen(BookCatalogViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            buttonOrders.Enabled = Program.Setting.IsPermissionEditing;
            buttonOrders.Visible = Program.Setting.IsPermissionEditing;
            buttonAddBook.Enabled = Program.Setting.IsPermissionEditing;
            buttonAddBook.Visible = Program.Setting.IsPermissionEditing;
            comboBoxSortes.SelectedIndex = 0;
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void ComboBoxSortes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    if (comboBoxSortes.SelectedIndex == -1) return;
                    _viewModel.CurrentSortesType = (SortesType)comboBoxSortes.SelectedIndex;
                    RefreshPage();
                }
            );
        }

        private void ButtonDirection_Click(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.ChangeDirectionSort();
                    LoadDirectionSort();
                    RefreshPage();
                }
            );
        }

        private void LoadDirectionSort()
        {
            buttonDirection.Text = _viewModel.IsDownDirectionSort ? "↓" : "↑";
        }

        private void ButtonSigout_Click(object sender, EventArgs e)
        {
            _viewModel.ExitProfile();
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

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            _viewModel.ShowOrder();
            RefreshPage();
        }

        private void BookCatalogScreen_Load(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.Load();
                    LoadDirectionSort();
                    RefreshPage();
                }
            );
        }

        private void RefreshPage()
        {
            RefreshLinkPages();
            RefreshBooks();
        }

        private void RefreshBooks()
        {
            BookWidget[] widgets = new BookWidget[_viewModel.CurrentBooks.Count];
            for(int i = 0; i < widgets.Length; i++)
            {
                BookWidget bookWidget = new BookWidget()
                {
                    Book = _viewModel.CurrentBooks[i],
                };
                bookWidget.Size = new Size(flowLayoutBook.Size.Width - flowLayoutBook.Padding.Horizontal - bookWidget.Margin.Horizontal, bookWidget.Size.Height);
                bookWidget.ButtonAddBookInOrderClick += (sender, e) => Handlers.ViewHandler(() => _viewModel.AddBookInOrder(bookWidget.Book));
                bookWidget.ButtonChangeBookClick += (sender, e) => Handlers.ViewHandler(
                    () =>
                    {
                        _viewModel.OpenBook(bookWidget.Book.Id);
                        RefreshPage();
                    }
                );

                widgets[i] = bookWidget;
            }
            flowLayoutBook.Controls.Clear();
            flowLayoutBook.Controls.AddRange(widgets);
        }

        private void RefreshLinkPages()
        {
            flowLayoutPages.Controls.Clear();
            flowLayoutPages.Controls.AddRange(ScreenService.GeneratePages(_viewModel.Page, _viewModel.MaxPage, 
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

        private void FlowLayoutBook_SizeChanged(object sender, EventArgs e)
        {
            ScreenService.FlowLayout_ChangeSize(sender, e);
        }

        private void ButtonOrders_Click(object sender, EventArgs e)
        {
            Handlers.ViewHandler(() => _viewModel.ShowOrders()); 
        }

        private void ButtonAddBook_Click(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.AddBook();
                    RefreshPage();
                }
            );
        }
    }
}
