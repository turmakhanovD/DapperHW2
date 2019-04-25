using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;

namespace NewsApp.Scripts
{
    public class NewsRepository : IRepository<News>
    {
        private DbConnection _connection;

        public NewsRepository()
        {
            var connectionString = @"data source = (LocalDB)\MSSQLLocalDB; initial catalog = database; integrated security = SSPI";

            _connection = new SqlConnection(connectionString);
        }
        
        public void Add(News item)
        {
            var sqlQuery = "insert into news values(@Id,@Article,@Text,@PublishedDate)";
            var result = _connection.Execute(sqlQuery, item);
        }
        public void Delete(Guid id)
        {
            var sqlQuery = "update news set DeletedTime = Getdate() where id = @Id";
            var result = _connection.Execute(sqlQuery, new { Id = id });
        }

        public List<Comment> GetComments(News item)
        {
            return item.Comments;
        }

        public List<News> GetAll()
        {
            var sqlQuery = "select * from news";
            var result = _connection.Query<News>(sqlQuery).AsList();
            return result;
        }
        public List<Comment> GetComments(Guid id)
        {
            var sqlQuery = "select * from comments where id = @Id";
            var result = _connection.Query<Comment>(sqlQuery, new { Id = id }).AsList();
            return result;
        }
    }
}
