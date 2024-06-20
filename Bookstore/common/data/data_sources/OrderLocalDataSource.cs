using Bookstore.common.data.entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.common.data.data_sources
{
    public class OrderLocalDataSource : LocalDataSource
    {
        public OrderLocalDataSource(NpgsqlConnection connection) : base(connection) { }

        public List<Order> SelectAll(long page, int sizePage, string search = null, DateTime? startDate = null)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select o.id, o.id_state, o.id_user, o.total_price, o.comment, o.start_date from \"order\" as o " +
                    "left join \"user\" as u on u.id = o.id_user " +
                    $"where u.login like '%{search}%' ";
                    if (!(startDate is null))
                    {
                        command.CommandText += "and o.start_date >= @StartDate and o.start_date < @StartDate + interval '1' day ";
                        command.Parameters.AddWithValue("@StartDate", startDate.Value.Date);
                    }
                    command.CommandText += $"limit @SizePage Offset @Offset";
                    command.Parameters.AddWithValue("@SizePage", sizePage);
                    command.Parameters.AddWithValue("@Offset", sizePage * page);
                },
                (reader) =>
                {
                    return new Order(
                        id: reader.GetInt32(0),
                        idState: reader.GetInt32(1),
                        idUser: reader.GetInt32(2),
                        totalPrice: reader.GetDecimal(3),
                        comment: reader.GetString(4),
                        startDate: reader.GetDateTime(5)
                    );
                }
            );
        }

        public Order Select(int id)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "select id_state, id_user, total_price, comment, start_date from \"order\" where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                },
                (reader) =>
                {
                    return new Order(
                        id: id,
                        idState: reader.GetInt32(0),
                        idUser: reader.GetInt32(1),
                        totalPrice: reader.GetDecimal(2),
                        comment: reader.GetString(3),
                        startDate: reader.GetDateTime(4)
                    );
                }
            ).FirstOrDefault();
        }

        public int Insert(Order order)
        {
            return QueryRows(
                (command) =>
                {
                    command.CommandText = "insert into \"order\" (id_state, id_user, total_price, comment, start_date) " +
                    "values (@IdState, @IdUser, @TotalPrice, @Comment, @StartDate) returning id";
                    command.Parameters.AddWithValue("@IdState", 1);
                    command.Parameters.AddWithValue("@IdUser", order.IdUser);
                    command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    command.Parameters.AddWithValue("@Comment", order.Comment);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                },
                (reader) =>
                {
                    return reader.GetInt32(0);
                }
            ).FirstOrDefault();
        }

        public void Update(Order order)
        {
            Query(
                (command) =>
                {
                    command.CommandText = "update \"order\" set id_state = @IdState, total_price = @TotalPrice, comment = @Comment where id = @Id";
                    command.Parameters.AddWithValue("@IdState", order.IdState);
                    command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@Comment", order.Comment);
                }
            );
        }

        public long CountPage(int sizePage, string search, DateTime? startDate)
        {
            return (long)Math.Ceiling(QueryRows(
                (command) =>
                {
                    command.CommandText = "select count(o.id) from \"order\" as o left join \"user\" as u on o.id_user = u.id " +
                    $"where u.login like '%{search ?? ""}%' ";
                    if (!(startDate is null))
                    {
                        command.CommandText += "and o.start_date >= @StartDate and o.start_date < @StartDate + interval '1' day";
                        command.Parameters.AddWithValue("@StartDate", startDate);
                    }
                },
                (reader) =>
                {
                    return reader.GetInt64(0);
                }
            ).FirstOrDefault() / (double)sizePage);
        }
    }
}
