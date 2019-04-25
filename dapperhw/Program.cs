using DbUp;
using NewsApp.Scripts;
using System;
using System.Reflection;

namespace NewsApp
{
    class Program
    {
        private static string _connectionString = @"data source =(LocalDB)\MSSQLLocalDB; initial catalog = database; integrated security = SSPI";

        static void Main(string[] args)
        {
            NewsRepository newsRepository = new NewsRepository();
            News news = new News()
            {
                Article = "test",
                Text = "test"
            };

            newsRepository.Add(news);
            DatabaseConnector(_connectionString);
        }

        private static void DatabaseConnector(string _connectionString)
        {
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(_connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception("Ошибка соединения!");
            }
        }
    }
}
