using Bookstore.common.data.entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Bookstore.common.data.data_sources
{
    public class UserLocalDataSource : LocalDataSource
    {
        public UserLocalDataSource(NpgsqlConnection connection) : base(connection) { }

        public List<User> SelectAll(string search = null)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = $"select id, id_post, login from \"user\" where login like '%{search ?? ""}%'";
                },
                (reader) =>
                {
                    return new User(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2)
                    );
                }
            );
        }

        public User Select(string login, string password)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select id, id_post from \"user\" where login = @Login and password = @Password";
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", StringToSHAString(password));
                },
                (reader) =>
                {
                    return new User(
                        id: reader.GetInt32(0),
                        idPost: reader.GetInt32(1),
                        login: login
                        );
                }
            ).FirstOrDefault();
        }

        public User Select(int id)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select id_post, login from \"user\" where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                },
                (reader) =>
                {
                    return new User(id, reader.GetInt32(0), reader.GetString(1));
                }
            ).FirstOrDefault();
        }

        public bool IsRegistration(string login)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select count(id) from \"user\" where login = @Login";
                    command.Parameters.AddWithValue("@Login", login);
                },
                (reader) =>
                {
                    return reader.GetInt64(0);
                }
            ).FirstOrDefault() > 0;
        }

        public int Insert(User user, string password)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "insert into \"user\" (id_post, login, password) values (@IdPost, @Login, @Password) returning id";
                    command.Parameters.AddWithValue("@IdPost", user.IdPost);
                    command.Parameters.AddWithValue("@Login", user.Login);
                    command.Parameters.AddWithValue("@Password", StringToSHAString(password));
                },
                (reader) =>
                {
                    return reader.GetInt32(0);
                }
            ).FirstOrDefault();
        }

        private string StringToSHAString(string str)
        {
            using(SHA256 sha = SHA256.Create())
            {
                return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
            }
        }
    }
}
