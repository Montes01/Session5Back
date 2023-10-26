using System.Data.SqlClient;

namespace Session5.DAL
{
    public class Connection
    {
        private static readonly string _ConnectionString = "server=FABRICA1\\SQLEXPRESS;Initial Catalog=Session5;Integrated Security=true";

        public static SqlConnection GetConnection() => new(_ConnectionString);

    }
}
