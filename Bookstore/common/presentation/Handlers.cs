using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore.common.presentation
{
    internal static class Handlers
    {
        public static void ViewHandler(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ConnectionHandler(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch(NpgsqlException ex)
            {
                throw new NpgsqlException("Не удалось получить ответ");
            }
        }
    }
}
