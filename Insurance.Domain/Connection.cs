using Insurance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Insurance.Domain
{
    public class Connection : IConnection
    {
        string ConnectionString = "";
        SqlConnection con;

        public Connection()
        {

        }

        public SqlConnection GetConnection()
        {
            //if (CheckConnection())
            //{
            //    CreateConnection();
            //}

            return con;
        }

        private void CreateConnection()
        {
            if (CheckConnection())
            {
                con = new SqlConnection(ConnectionString);
                OpenConnection();
            } 
            
        }

        private bool CheckConnection()
        {
            return con == null && con.State == System.Data.ConnectionState.Closed;
        }

        private void OpenConnection()
        {            
            con.Open();
        }
        private void CloseConnection()
        {
            con.Close();
        }

    }
}
