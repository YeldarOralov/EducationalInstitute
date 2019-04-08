using System.Configuration;
using System.Data.Common;

namespace EducationalInstitute.DataAccess
{
    public class StudentTableDataAccess
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _providerFactory;

        public StudentTableDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ConnectionString;
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ProviderName);
        }
        public void GetAll()
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                command.CommandText = "select * from Students";
                DbDataAdapter adapter = 
                    DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ProviderName).CreateDataAdapter();
                adapter.SelectCommand = command;
            }
        }
    }
}