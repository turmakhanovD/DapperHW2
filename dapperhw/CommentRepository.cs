using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace NewsApp.Scripts
{
    public class CommentRepository : IRepository<Comment>
    {
        private DbConnection _connection;

        public CommentRepository()
        {
            var connectionString = @"data source = (LocalDB)\MSSQLLocalDB; initial catalog = database; integrated security = SSPI";

            _connection = new SqlConnection(connectionString);
        }

        public void Add(Comment item)
        {
            var sqlQuery = "insert into comments values(@Id,@Text,@NewsId,@PublishedDate)";
            var result = _connection.Execute(sqlQuery, item);
        }

        public void Delete(Guid id)
        {

            var sqlQuery = "update comments set DeletedTime = Getdate() where id = @Id";
            var result = _connection.Execute(sqlQuery, new { Id = id });
        }

        public List<Comment> GetAll()
        {
            var sqlQuery = "select * from comments";
            var result = _connection.Query<Comment>(sqlQuery).AsList();
            return result;
        }
    }
}
