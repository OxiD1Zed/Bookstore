using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bookstore.common.data.data_sources
{
    public class LocalDataSource
    {
        private readonly NpgsqlConnection _connection;

        public LocalDataSource(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        // Новые методы работы с запросами
        //private T Query<T>(Action<NpgsqlCommand> setup, Func<NpgsqlCommand, T> query)
        //{
        //    _connection.Open();
        //    T result = default;
        //    Exception exception = null;
        //    try
        //    {
        //        using(NpgsqlCommand command = _connection.CreateCommand())
        //        {
        //            setup.Invoke(command);
        //            result = query.Invoke(command);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        exception = ex;
        //    }
        //    _connection.Close();

        //    if(exception != null) throw exception;
        //    return result;
        //}

        //public int QueryAffectedRows(Action<NpgsqlCommand> setup)
        //{
        //    return Query<int>(
        //        setup,
        //        (command) =>
        //        {
        //            return command.ExecuteNonQuery();
        //        }
        //    );
        //}

        //public List<T> QueryRows<T>(Action<NpgsqlCommand> setup, Func<NpgsqlDataReader, T> converter)
        //{
        //    return Query<List<T>>(
        //        setup,
        //        (command) =>
        //        {
        //            List<T> result = new List<T>();
        //            using(NpgsqlDataReader reader =  command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    result.Add(converter.Invoke(reader));
        //                }
        //            }
        //            return result;
        //        }
        //    );
        //}

        private void QueryHandler(Action<NpgsqlCommand> action, Action<Exception> exHandler = null)
        {
            _connection.Open();
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    action?.Invoke(command);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
#endif
                exHandler?.Invoke(ex);
            }
            _connection.Close();
        }

        protected List<T> QueryRows<T>(Action<NpgsqlCommand> setup, Func<NpgsqlDataReader, T> converter)
        {
            if(setup is null || converter is null) throw new ArgumentNullException("Параметры не должны быть null");
            List<T> list = new List<T>();
            QueryHandler(
                (command) =>
                {
                    setup?.Invoke(command);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(converter(reader));
                        }
                    }
                }
            );

            return list;
        }

        protected int Query(Action<NpgsqlCommand> setup)
        {
            if (setup is null) throw new ArgumentNullException("Параметры не должны быть null");
            int effectedRows = 0;
            QueryHandler(
                (command) =>
                {
                    setup?.Invoke(command);
                    effectedRows = command.ExecuteNonQuery();
                }
            );

            return effectedRows;
        }

        protected static object GetDBValue(object value)
        {
            return value is null ? DBNull.Value : value;
        }
    }
}
