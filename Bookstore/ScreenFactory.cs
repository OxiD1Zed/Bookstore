using Bookstore.features.auth;
using Bookstore.features.book_catalog;
using Bookstore.features.book_editor;
using Bookstore.features.order_catalog;
using Bookstore.features.order_editor;
using Npgsql;

namespace Bookstore
{
    internal class ScreenFactory
    {
        private readonly DI _di;

        internal ScreenFactory()
        {
            _di = new DI(new NpgsqlConnection(Connections.LocalBookStore));
        }

        internal AuthScreen MakeAuthScreen() => new AuthScreen(_di.CreateAuthViewModel()) { Dock = System.Windows.Forms.DockStyle.Fill };

        internal BookCatalogScreen MakeBookCatalogScreen() => new BookCatalogScreen(_di.CreateBookCatalogViewModel()) { Dock = System.Windows.Forms.DockStyle.Fill };

        internal OrderCatalogScreen MakeOrderCatalogScreen() => new OrderCatalogScreen(_di.CreateOrderCatalogViewModel()) { Dock = System.Windows.Forms.DockStyle.Fill };

        internal BookEditorScreen MakeBookEditorScreen(int? idBook) => new BookEditorScreen(_di.CreateBookEditorViewModel(idBook)) { Dock = System.Windows.Forms.DockStyle.Fill };

        internal OrderEditorScreen MakeOrderEditorScreen(int? idOrder) => new OrderEditorScreen(_di.CreateOrderEditorViewModel(idOrder)) { Dock = System.Windows.Forms.DockStyle.Fill };
    }
}
