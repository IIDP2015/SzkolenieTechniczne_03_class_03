using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper.Mappers.Internal;
using Dapper;
using SzkolenieTechniczne3.Core.Domain;
using SzkolenieTechniczne3.Core.Repositories;

namespace Szkolenie.Techniczne3.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            User user = null;
            using (IDbConnection dbConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                dbConnection.Open();
                user = dbConnection.Query<User>("SELECT * FROM Users WHERE Id =" + id, new {id}).SingleOrDefault();
            }

            return user;
        }

        public IList<User> GetAll()
        {
            IList<User> user = null;
            using (IDbConnection dbConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                dbConnection.Open();
                user = dbConnection.Query<User>("SELECT * FROM Users").ToList();
            }

            return user;
        }

        public int InsertOrUpdate(User item)
        {
            using (IDbConnection dbConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                dbConnection.Open();
                if (item.Id > 0)
                    return Update(item, dbConnection);
                else
                    return Insert(item, dbConnection);
            }
        }

        private int Insert(User item, IDbConnection dbConnection)
        {
            string sql =
                @"INSERT INTO Users (Name, Surname, Pesel, PhoneNumber, Email, Password) VALUES (@Name, @Surname, @Pesel, @PhoneNumber, @Email, @Password)
                SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = dbConnection.Query<int>(sql, new
            {
                Name = item.Name,
                Surname = item.Surname,
                Pesel = item.Pesel,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
                Password = item.Password
            }).Single();
            return id;
        }

        private int Update(User item, IDbConnection dbConnection)
        {
            const string sql =
                @"UPDATE Users SET Name = @Name, Surename = @Surename, Pesel = @Pesel, PhoneNumber = @PhoneNumber, Email = @Email, Password = @Password WHERE Id = @Id;";

            var affectedRows = dbConnection.Execute(sql, new
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
                Pesel = item.Pesel,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
                Password = item.Password
            });
            return affectedRows;
        }

        public void Remove(int id)
        {
            string sql = "DELETE FROM User WHERE Id = @Id;";
            using (IDbConnection dbConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sql, new {Id = id});
            }
        }
    }
}