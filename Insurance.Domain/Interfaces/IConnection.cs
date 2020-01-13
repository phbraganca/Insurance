using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Insurance.Domain.Interfaces
{
    public interface IConnection
    {
        SqlConnection GetConnection();

    }
}
