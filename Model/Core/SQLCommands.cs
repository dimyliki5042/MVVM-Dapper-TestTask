using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace TestTask.Model.Core
{
    public static class SQLCommands
    {
        private static SqlConnection _connection;
        public static List<MainDataModel> Data { get; private set; }

        public static void Start()
        {
            string connectionString = "Server=localhost;Database=testtaskdb;Trusted_Connection=True;";
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static List<MainDataModel> TakeData()
        {
            Start();
            string selectQuery = "select surname, name, patronymic," +
                "(select name from Streets where" +
                    $"(select street_id from Address where abonent_id = Abonents.id) = Streets.id) as {nameof(MainDataModel.Street)}," +
                $"(select house from Address where abonent_id = Abonents.id) as {nameof(MainDataModel.House)}," +
                $"(select homenumber from Numbers where abonent_id = Abonents.id) as {nameof(MainDataModel.HomeNumber)}," +
                $"(select worknumber from Numbers where abonent_id = Abonents.id) as {nameof(MainDataModel.WorkNumber)}," +
                $"(select phonenumber from Numbers where abonent_id = Abonents.id) as {nameof(MainDataModel.PhoneNumber)} from Abonents;";
            Data = _connection.Query<MainDataModel>(selectQuery).ToList();
            return Data;
        }

        public static List<StreetSearchModel> StreetAbonentCount()
        {
            string selectQuery = $"select name as {nameof(StreetSearchModel.Street)}," +
                $"(select count(abonent_id) from Address where street_id = Streets.id) as {nameof(StreetSearchModel.Count)} from Streets;";
            return _connection.Query<StreetSearchModel>(selectQuery).ToList();
        }

        public static void Disconnect()
        {
            if(_connection != null && _connection.State == ConnectionState.Open)
                _connection.Dispose();
        }
    }
}
