using Bookstore.common.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    internal static class Program
    {
        private static Form _app;
        internal static ScreenFactory ScreenFactory;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _app = new AppForm();
            ScreenFactory = new ScreenFactory();
            Navigator.Push(ScreenFactory.MakeAuthScreen());
            Application.Run(_app);
        }

        internal static class Navigator
        {
            internal static void Push(UserControl userControl)
            {
                if (userControl is null) return;
                _app.Controls.Add(userControl);
                _app.Controls.SetChildIndex(userControl, 0);
            }

            internal static void Pop()
            {
                if (_app.Controls.Count < 1) return;
                _app.Controls.RemoveAt(0);
            }

            internal static void PushRemove(UserControl userControl)
            {
                if (userControl is null) return;
                _app.Controls.Clear();
                _app.Controls.Add(userControl);
            }
        }

        internal static class Setting
        {
            internal static User CurrentUser;
            internal static List<OrderBook> CurrentOrder;

            internal static bool IsPermissionEditing
            {
                get
                {
                    return CurrentUser.IdPost == 1;
                }
            }

            internal static void AddBookInOrder(Book book, int quantity)
            {
                OrderBook orderBook = CurrentOrder.Where((ob) => ob.IdBook == book.Id).FirstOrDefault();
                if (orderBook?.Quantity + quantity > book.QuantityInStock) throw new Exception("Данная книга закончилась");
                if (orderBook is null)
                {
                    CurrentOrder.Add(new OrderBook(default, book.Id, quantity));
                }
                else
                {
                    orderBook.Quantity += quantity;
                }
            }
        }
    }
}
