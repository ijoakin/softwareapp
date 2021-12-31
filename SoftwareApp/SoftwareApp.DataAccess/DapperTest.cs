using Dapper;
using SoftwareApp.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SoftwareApp.DataAccess
{
    public class DapperTest
    {
        private string _connectionString;
        public DapperTest(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Software> GetSoftwaresDapper()
        {
            List<Software> softwares = new List<Software>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                softwares = db.Query<Software>("Select * From Software").AsList();
            }
            return softwares;
        }
    }
}
