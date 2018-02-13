using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ituniver.Calc.DB.Models;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using Ituniver.Calc.DB.Repositories;

namespace Ituniver.Calc.DB.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity
    {
        //todo: вынести в конфиг
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\It-Univer\BlockChainCalculator\Ituniver.Calc.DB\App_Data\CalcDB.mdf;Integrated Security=True";

        //protected string сonnectionString = @"C:\It-Univer\BlockChainCalculator\Ituniver.Calc.DB\App_Data\CalcDB.mdf";

        protected string tableName { get; set; }

        public BaseRepository()
        {
            this.tableName = typeof(T).Name;
        }

        public BaseRepository(string tableName)
        {
            this.tableName = tableName;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public T Find(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            var props = typeof(T).GetProperties();
            var columns = props.Select(p => p.Name);
            var values = new List<string>();

            foreach (var prop in props)
            {
                var value = prop.GetValue(item);
                var str = $"{value}";
                if (value == null)
                {
                    str = "NULL";
                }
                else if (value is string)
                {
                    str = $"N'{value}'";
                }
                else if (value is DateTime)
                {
                    var date = (DateTime)value;
                    str = $"N'{date.ToString(CultureInfo.InvariantCulture)}'";
                }
                else if (value is double)
                {
                    var doubleValue = (double)value;
                    str = $"N'{doubleValue.ToString(CultureInfo.InvariantCulture)}'";
                }
                //todo boolean


                values.Add(str);
            }

            var strColumns = "[" + string.Join("], [", columns) + "]";
            var strValues = string.Join(", ", values);

            var insertQuery = $"INSERT INTO [dbo].[{tableName}] ({strColumns}) VALUES ({strValues})";


            string queryString = item.Id > 0
                ? "UPDATE * FROM [dbo].[History]"
                : insertQuery;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var count = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return ReadData();
        }

        #region Работа с БД

        private IEnumerable<T> ReadData()
        {
            var items = new List<T>();
            string queryString = $"SELECT * FROM [dbo].[{tableName}]";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(ReadSingleRow(reader));
                }

                reader.Close();
            }
            return items;
        }

        private T ReadSingleRow(IDataRecord record)
        {
            var obj = Activator.CreateInstance<T>();
            var tclass = typeof(T);
            var props = tclass.GetProperties();

            foreach (var prop in props)
            {
                var ind = record.GetOrdinal(prop.Name);
                var isnull = record.IsDBNull(ind);
                if (!isnull)
                {
                    var value = record[prop.Name];
                    prop.SetValue(obj, value);
                }
            }
            return obj;

            //var item = new HistoryItem();
            //item.Id = (long)record["id"];
            //item.Operation = (string)record["Operation"];

            //var ind = record.GetOrdinal("Result");
            //var isnull = record.IsDBNull(ind);
            //if (!isnull)
            //{
            //    item.Result = (double?)record["Result"];
            //}
            //else
            //{
            //    item.Result = double.NaN;
            //}
            //item.Args = (string)record["Args"];
            //item.ExecDate = (DateTime)record["ExecDate"];
            //Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
            //return item;
        }

        #endregion
    }
}
