using Bookstore.common.data.entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.common.data.data_sources
{
    public class BookLocalDataSource : LocalDataSource
    {
        public BookLocalDataSource(NpgsqlConnection connection) : base(connection) { }

        public List<Book> SelectAll(long page, int sizePage, string search = null, int sortesType = 0, bool isDown = true)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = $"select id, title, price, author, quantity_in_stock from book " +
                    $"where lower(title) like lower('%{search ?? ""}%') " +
                    $"order by {SortesColumn(sortesType)} {DirectionSortes(isDown)} " +
                    $"limit @SizePage Offset @Offset";
                    command.Parameters.AddWithValue("@SizePage", sizePage);
                    command.Parameters.AddWithValue("@Offset", sizePage * page);
                },
                (reader) =>
                {
                    return new Book(
                        id: reader.GetInt32(0),
                        title: reader.GetString(1),
                        price: reader.GetDecimal(2),
                        author: reader.GetString(3),
                        quantityInStock: reader.GetInt32(4)
                    );
                }
            );
        }

        public long CountPage(int sizePage, string search = null)
        {
            return (long)Math.Ceiling(QueryRows(
                (command) =>
                {
                    command.CommandText = "select count(id) from book " +
                    $"where title like '%{search ?? ""}%' ";
                },
                (reader) =>
                {
                    return reader.GetInt64(0);
                }
            ).FirstOrDefault() / (double)sizePage);
        }

        private string SortesColumn(int sortesType)
        {
            string sortes = null;
            switch (sortesType)
            {
                case 1:
                    sortes = "price";
                    break;
                default:
                    sortes = "author";
                    break;
            }

            return sortes;
        }

        private string DirectionSortes(bool isDown)
        {
            return isDown ? "asc" : "desc";
        }

        public Book Select(int id)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select title, price, author, quantity_in_stock from book where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                },
                (reader) =>
                {
                    return new Book(
                        id: id,
                        title: reader.GetString(0),
                        price: reader.GetDecimal(1),
                        author: reader.GetString(2),
                        quantityInStock: reader.GetInt32(3)
                    );
                }
            ).FirstOrDefault();
        }

        public List<Book> Select(params int[] id)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select id, title, price, author, quantity_in_stock from book where id = any(@IdArray)";
                    command.Parameters.AddWithValue("@IdArray", id);
                },
                (reader) =>
                {
                    return new Book(
                        id: reader.GetInt32(0),
                        title: reader.GetString(1),
                        price: reader.GetDecimal(2),
                        author: reader.GetString(3),
                        quantityInStock: reader.GetInt32(4)
                    );
                }
            );
        }

        public int Insert(Book book)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "insert into book (title, price, author, quantity_in_stock) values (@Title, @Price, @Author, @QuantityInStock) returning id";
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Price", book.Price);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@QuantityInStock", book.QuantityInStock);
                },
                (reader) =>
                {
                    return reader.GetInt32(0);
                }).FirstOrDefault();
        }

        public void Update(Book book)
        {
            Query(
                (command) =>
                {
                    command.CommandText = "update book set title = @Title, price = @Price, author = @Author, quantity_in_stock = @QuantityInStock where id = @Id";
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Price", book.Price);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@QuantityInStock", book.QuantityInStock);
                    command.Parameters.AddWithValue("@Id", book.Id);
                }
            );
        }

        public void Delete(int id)
        {
            Query(
                (command) =>
                {
                    command.CommandText = "delete from book where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                }
            );
        }
    }
}
