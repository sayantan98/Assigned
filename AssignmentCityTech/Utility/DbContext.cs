using System.Xml.Linq;
using System;

namespace AssignmentCityTech.Utility
{
    internal class DbContext
    {
        protected static String dbServer = "LAPTOP-MJ7R2HTC";
        protected static String dbUId = "LAPTOP-MJ7R2HTC\\admin";
        protected static String dbPwd;
        protected static String dbName = "EmployeeDB";
        protected static String connection = "DATA SOURCE=" + dbServer + ";INITIAL CATALOG=" + dbName + ";USER ID=" + dbUId + ";Integrated Security=true;Connection Timeout = 600000";
        // To make it secure
        private string cName = connection;
        public string CName
        {
            get => cName;
        }
    }
}
