using Bookstore.common.data.entities;
using Npgsql;
using System.Collections.Generic;


namespace Bookstore.common.data.data_sources
{
    public class PostLocalDataSource : LocalDataSource
    {
        public PostLocalDataSource(NpgsqlConnection connection) : base(connection)
        {
        }

        public List<Post> SelectAll()
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select id, title from post";
                },
                (reader) =>
                {
                    return new Post(reader.GetInt32(0), reader.GetString(1));
                }
            );
        }
    }
}
