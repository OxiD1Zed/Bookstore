using Bookstore.common.data.entities;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.common.data.data_sources
{
    public class StateLocalDataSource : LocalDataSource
    {
        public StateLocalDataSource(NpgsqlConnection connection) : base(connection) { }

        public List<State> SelectAll()
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select id, title from state";
                },
                (reader) =>
                {
                    return new State(reader.GetInt32(0), reader.GetString(1));
                }
            );
        }

        public State Select(int id)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select title from state where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                },
                (reader) =>
                {
                    return new State(id: id, title: reader.GetString(0));
                }
            ).FirstOrDefault();
        }
    }
}
