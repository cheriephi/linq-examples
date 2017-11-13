using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinq;
using System.Configuration;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;

namespace LinqLearningTests
{
    [TestClass]
    public class LinqToSqlLearningTest
    {
        [TestMethod]
        public void GetFromDb()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDataSource"].ConnectionString;
            
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var db = new DataContext(connection))
            {
                var addresses = db.GetTable<Address>();

                var query = from address in addresses
                            select address;

                foreach (var address in query)
                {
                    Trace.WriteLine($"{address.Name} {address.City} {address.StateProvinceCode}");
                }
            }
        }

        [TestMethod]
        public void GetFromDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDataSource"].ConnectionString;

            using (var addressBook = new AddressBook(connectionString))
            {
                var addresses = addressBook.Addresses;

                var query = from address in addresses
                            select address;

                foreach (var address in query)
                {
                    Trace.WriteLine($"{address.Name} {address.City} {address.StateProvinceCode}");
                }
            }
        }

        [TestMethod]
        public void UpdateDb()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDataSource"].ConnectionString;

            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var db = new DataContext(connection))
            {
                var query = (from address in db.GetTable<Address>()
                            select address).First();

                query.City = "New York" + System.DateTime.Now.ToString();

                db.SubmitChanges();
            }
        }

        [TestMethod]
        public void UpdateDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDataSource"].ConnectionString;

            using (var addressBook = new AddressBook(connectionString))
            {
                var query = (from address in addressBook.Addresses
                             select address).First();

                query.City = "New York " + System.DateTime.Now.ToString();

                addressBook.SubmitChanges();
            }
        }

        [TestMethod]
        public void InsertDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDataSource"].ConnectionString;

            using (var addressBook = new AddressBook(connectionString))
            {
                var query = from address in addressBook.Addresses
                             select address;

                var newAddress = new Address("Cherie" + System.DateTime.Now.ToString(), "Seattle", "WA");
                addressBook.Addresses.InsertOnSubmit(newAddress);

                addressBook.SubmitChanges();
            }
        }

        [TestMethod]
        public void SyncDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDataSource"].ConnectionString;

            using (var addressBook = new AddressBook(connectionString))
            {
                var query = from address in addressBook.Addresses
                            select address;

                addressBook.SubmitChanges();
            }
        }
    }
}
