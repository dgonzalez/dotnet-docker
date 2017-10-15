using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentManager.Controllers.Domain;
using Pomelo.Data.MySql;
using System.Data;

namespace DocumentManager.Controllers
{
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        // GET api/documents
        [HttpGet]
        public ArrayList Get()
        {
            string connectionString = @"server=127.0.0.1;" +
                 @"uid=root;" +
                 @"pwd=root;" +
                 @"database=documents_db;";
            IDbConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            ArrayList results = new ArrayList();
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
