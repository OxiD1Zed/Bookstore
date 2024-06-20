using Bookstore.common.data.data_sources;
using Bookstore.common.data.services;
using Bookstore.common.domain;
using Bookstore.features.auth;
using Bookstore.features.book_catalog;
using Bookstore.features.book_editor;
using Bookstore.features.order_catalog;
using Bookstore.features.order_editor;
using Npgsql;

namespace Bookstore
{
    internal class DI
    {
        private readonly NpgsqlConnection _connection;
        private UserService _userService;

        internal DI(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        internal BookLocalDataSource CreateBookLocalDS() => new BookLocalDataSource(_connection);

        internal OrderBookLocalDataSource CreateOrderBookLocalDS() => new OrderBookLocalDataSource(_connection);

        internal OrderLocalDataSource CreateOrderLocalDS() => new OrderLocalDataSource(_connection);

        internal PostLocalDataSource CreatePostLocalDS() => new PostLocalDataSource(_connection);

        internal StateLocalDataSource CreateStateLocalDS() => new StateLocalDataSource(_connection);

        internal UserLocalDataSource CreateUserLocalDS() => new UserLocalDataSource(_connection);

        internal OrderForWidgetRepository CreateOrderForWidgetRepository() => new OrderForWidgetRepository(
            CreateOrderLocalDS(),
            CreateUserLocalDS(),
            CreateStateLocalDS(),
            CreateBookLocalDS(),
            CreateOrderBookLocalDS()
        );

        internal SmtpSendler CreateSmtpSendler() => new SmtpSendler();

        internal OrderBookForWidgetRepository CreateOrderBookForWidgetRepository() => new OrderBookForWidgetRepository(CreateBookLocalDS(), CreateOrderBookLocalDS());

        internal UserService CreateUserService()
        {
            if(_userService is null)
            {
                _userService = new UserService();
            }
            return _userService;
        }

        internal AuthViewModel CreateAuthViewModel() => new AuthViewModel(
            CreateUserLocalDS(),
            CreateUserService()
        );

        internal BookCatalogViewModel CreateBookCatalogViewModel() => new BookCatalogViewModel(CreateBookLocalDS());

        internal OrderCatalogViewModel CreateOrderCatalogViewModel() => new OrderCatalogViewModel(CreateOrderForWidgetRepository(), CreateOrderLocalDS());

        internal BookEditorViewModel CreateBookEditorViewModel(int? idBook) => new BookEditorViewModel(idBook, CreateBookLocalDS());

        internal OrderEditorViewModel CreateOrderEditorViewModel(int? idOrder) => new OrderEditorViewModel(
            idOrder, 
            CreateOrderLocalDS(), 
            CreateStateLocalDS(), 
            CreateOrderBookForWidgetRepository(),
            CreateUserLocalDS(),
            CreateOrderBookLocalDS(),
            CreateBookLocalDS(),
            CreateSmtpSendler()
        );
    }
}
