using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaltaStore.Shared;

namespace BaltaStore.Infra.StoreContext.DataContexts
{
    public class BaltaStoreDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BaltaStoreDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            if(Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}