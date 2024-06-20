using Bookstore.common.presentation;
using System;
using System.Windows.Forms;

namespace Bookstore.features.book_editor
{
    public partial class BookEditorScreen : UserControl
    {
        private readonly BookEditorViewModel _viewModel;

        public BookEditorScreen(BookEditorViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            buttonSave.Visible = _viewModel.IsPermissionEditing;
            buttonSave.Enabled = _viewModel.IsPermissionEditing;
            textBoxTitle.Enabled = _viewModel.IsPermissionEditing;
            textBoxAuthor.Enabled = _viewModel.IsPermissionEditing;
            numericPrice.Enabled = _viewModel.IsPermissionEditing;
            numericQuantityInStock.Enabled = _viewModel.IsPermissionEditing;
            numericQuantityInStock.Visible = _viewModel.IsPermissionEditing;
            buttonAddBookInOrder.Enabled = !_viewModel.IsNew;
            buttonAddBookInOrder.Visible = !_viewModel.IsNew;
            numericPrice.Maximum = decimal.MaxValue;
            numericQuantityInStock.Maximum = decimal.MaxValue;
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
                    _viewModel.Save(
                        title: textBoxTitle.Text,
                        author: textBoxAuthor.Text,
                        price: numericPrice.Value,
                        quantityInStock: (int)numericQuantityInStock.Value
                    );
                    _viewModel.Back();
                }
            );
        }

        private void ButtonAddBookInOrder_Click(object sender, EventArgs e)
        {
            _viewModel.AddBookInOrder();
        }

        private void BookEditorScreen_Load(object sender, EventArgs e)
        {
            Handlers.ViewHandler(
                () =>
                {
                    _viewModel.Load();
                    textBoxAuthor.Text = _viewModel.Author;
                    textBoxTitle.Text = _viewModel.Title;
                    numericPrice.Value = _viewModel.Price;
                    numericQuantityInStock.Value = _viewModel.QuantityInStock;
                    labelIDValue.Text = _viewModel.ID.ToString();
                }
            );
        }
    }
}
