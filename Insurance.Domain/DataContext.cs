using Insurance.Domain.Interfaces;
using Insurance.Domain.Models;
using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Insurance.Domain
{
    public class DataContext<T>  where T : class
    {

        IConnection _connection = null;

        public DataContext(IConnection connection)
        {
            _connection = connection;
        }

        public static IList<Customer> Customer = new List<Customer>();

        public static IList<Address> Address = new List<Address>();

        public static IList<City> City = new List<City>();

        public static IList<Country> Country = new List<Country>();

        public static IList<AdressType> AddressType = new List<AdressType>();

        public static IList<State> State = new List<State>();

        private object[] objs = new object[1];
        
        public void Set(T obj) {
            
            objs[0] = obj;
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];
            dynamic objectName = (object)nameOfClass;

            var method = ((object)nameOfClass).GetType().GetMethod("Add");
            method.Invoke(obj,objs);
            
        }

        public void Remove(T obj)
        {
            IList<T> list = new List<T>();

            list = (List<T>)(object)obj.ToString().GetType();

            list.Remove(obj);
                        
        }

        public void Update(T obj)
        {
            IList<T> list = new List<T>();
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];

            list = (List<T>)(object)nameOfClass.GetType();
            
            var nameOfProperty = obj.ToString()+"Id";
            var propertyInfo = (object)nameOfClass.GetType().GetProperty(nameOfProperty);

            var item = list.Where(x => x.GetType().GetProperty(nameOfProperty) == propertyInfo.GetType().GetProperty(nameOfProperty).GetValue(propertyInfo)).SingleOrDefault();

            list.Remove(item);
            list.Add(obj);
        }
        
        public IList<T> List(T obj)
        {
            IList<T> list = new List<T>();
            
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];

            PropertyInfo oi = typeof(List<T>).GetProperty(nameOfClass);
            Type t = Type.GetType("DataContext");

            t.GetProperty(nameOfClass, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            dynamic objectName = (object)nameOfClass;
            list = (List<T>)(object)nameOfClass.GetType();

            return list;
        }

        public T FirstOrDefault(T obj)
        {
            IList<T> list = new List<T>();

            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];
            list = (List<T>)(object)nameOfClass.GetType();
            
            return list.FirstOrDefault(x => x == obj);
        }

        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, _connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, _connection.GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

    }
}
