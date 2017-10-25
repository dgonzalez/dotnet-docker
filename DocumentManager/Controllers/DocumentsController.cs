using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using DocumentManager.Controllers.Domain;
using Pomelo.Data.MySql;
using System.Data;
using Microsoft.Extensions.Logging;

namespace DocumentManager.Controllers
{

    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        private ILogger _logger;
        public DocumentsController(ILogger<DocumentsController> logger) {
            this._logger = logger;
        }

        // GET api/documents
        [HttpGet]
        public ArrayList Get()
        {
            string connectionString = @"server=35.195.19.66;" +
                 @"uid=root;" +
                 @"pwd=root;" +
                 @"database=documents_db;";
            IDbConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            ArrayList results = new ArrayList();
            _logger.LogWarning("I am a warning");
            try {
                IDbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT title, page_count FROM documents;";

                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    results.Add(new Document((string)reader["title"], (int)reader["page_count"]));
                }    
            } finally {
                connection.Close();    
            }
            return results;
        }
    }
}
