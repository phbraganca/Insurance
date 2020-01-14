using Insurance.Domain.Interfaces;
using Insurance.Domain.Models;
using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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


        private static List<Address> Address = new List<Address>();
        private static List<Customer> Customer = new List<Customer>();
        
        private static List<City> City = new List<City>();
        
        private static List<Country> Country = new List<Country>();
        
        private static List<AdressType> AddressType = new List<AdressType>();
        
        private static List<State> State = new List<State>();
                        
        public void Set(T obj) {
            
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];
            var objList = ReturnObject(nameOfClass);

            if (objList != null)
            {
                var list = (List<T>)objList;
                list.Add(obj);
            }
            
        }

        public void Remove(T obj)
        {
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];

            var objList = ReturnObject(nameOfClass);
            if (objList != null)
            {
                var list = (List<T>)objList;
                var item = FirstOrDefault(obj);
                list.Remove(item);
            }
                        
        }

        public void Update(T obj)
        {
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];
            var objList = ReturnObject(nameOfClass);

            if (objList != null)
            {
                var list = (List<T>)objList;
                var item = this.FirstOrDefault(obj);

                list.Remove(item);
                list.Add(obj);                
            }            
        }
        
        public IList<T> List(T obj)
        {
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];
            var objList = ReturnObject(nameOfClass);
            
            if (objList != null)
            {
                var list = (List<T>)objList;

                return list;
            }
            else
            {
                return null;
            }

        }

        public T FirstOrDefault(T obj)
        {
            var nameOfClass = obj.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];
            var objList = ReturnObject(nameOfClass);

            if (objList != null)
            {
                var list = (List<T>)objList;
                string nameOfProperty = obj.ToString() + "Id";
                nameOfProperty = nameOfProperty.ToString().Split(".")[obj.ToString().Split(".").Count() - 1];

                var propertyInfo = obj.GetType().GetProperty(nameOfProperty);
                var valueFromObject = propertyInfo.GetValue(obj, null);
                
                ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
                Expression property = Expression.Property(parameter, nameOfProperty);
                Expression constant = Expression.Constant(valueFromObject);
                Expression equality = Expression.Equal(property, constant);
                Expression<Func<T, bool>> predicate =
                    Expression.Lambda<Func<T, bool>>(equality, parameter);

                Func<T, bool> compiled = predicate.Compile();

                return list.Where(compiled).FirstOrDefault();
            }
            else
            {
                return null;
            }
            
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


        private object ReturnObject(string nameOfObject)
        {
            if (nameOfObject == "Customer")
            {
                return Customer;
            }
            else
            if (nameOfObject == "Address")
            {
                return Address;
            }
            else
            if (nameOfObject == "City")
            {
                return City;
            }
            else
            if (nameOfObject == "State")
            {
                return State;

            }
            else
            if (nameOfObject == "Country")
            {
                return Country;
            }
            else
            {
                return null;
            }

            


        }
    }
}
