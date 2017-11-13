using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqLearningTests
{
    /// <summary>
    /// Demonstrates Linq functionality.
    /// </summary>
    /// <remarks>Some examples taken from Pluralsight Linq class.</remarks>
    [TestClass]
    public class LinqLearningTest
    {
        /// <summary>
        /// Query syntax
        /// </summary>
        [TestMethod]
        public void SimpleQuery()
        {
            var primes = new List<int> { 2, 3, 5, 7, 11, 13, 17 };
            var query = from x in primes
                        where x < 13
                        select x;
            foreach (var prime in query)
            {
                Trace.Write($"prime: {prime}");
            }
        }

        [TestMethod]
        public void SimpleMethodQuery()
        {
            var primes = new List<int> { 2, 3, 5, 7, 11, 13, 17 };
            // Method queries use anonymous methods and are a more concise syntax
            var query = primes.Where(x => x < 13);
            foreach (var prime in query)
            {
                Trace.Write($"prime: {prime}");
            }
        }

        [TestMethod]
        public void OrderAndGroupByQuery()
        {
            // use reflection to get the methods exposed by the double data type
            var query = from method in typeof(double).GetMethods()
                        orderby method.Name
                        group method by method.Name into groups
                        select new { MethodName = groups.Key, NumberOfOverloads = groups.Count() };

            foreach (var prime in query)
            {
                Trace.WriteLine(prime);
            }
        }

        [TestMethod]
        public void AnyAndContainsOperators()
        {
            var listOne = Enumerable.Empty<int>();
            var listTwo = Enumerable.Range(1, 20);

            var listOneEmpty = listOne.Any();
            var listTwoEmpty = listTwo.Any();
            Trace.WriteLine($"List one empty?: {listOneEmpty}, list two empty?: {listTwoEmpty}");

            Trace.WriteLine($"List two has 12?: {listTwo.Contains(12)}, list two has 30?: {listTwo.Contains(30)}");
        }

        [TestMethod]
        public void TakeOperator()
        {
            var bigList = Enumerable.Range(1, 20);
            //Get first 5 values
            var littleList = bigList.Take(5).Select(x => x * 10);
            foreach (int i in littleList)
            {
                Trace.WriteLine(i);
            }
        }

        [TestMethod]
        public void ZipOperator()
        {
            //The zip operator "zippers" two collections together
            string[] stateCodeList = { "AL", "AK", "AZ" };
            string[] stateNameList = { "Alabama", "Alaska", "Arizona" };
            var stateList = stateCodeList.Zip(stateNameList, (code, name) =>
                code + ": " + name);

            foreach (var state in stateList)
            {
                Trace.WriteLine(state);
            }
        }

        [TestMethod]
        public void DictionaryTopNQuery()
        {
            var prices = new Dictionary<int, decimal>
            {
                { 6, 3600M},
                { 19, 500M},
                { 36, 650M},
                { 57, 13525M},
                { 68, 250M},
            };

            var result = from v in prices
                         orderby v.Value descending
                         select v;
            // Limit to top 3
            var topResult = result.Take(3);
            foreach (var price in topResult)
            {
                // Print as local currency
                Trace.WriteLine($"price: {price.Value:c}");
            }
        }

        [TestMethod]
        public void JoinOperator()
        {
            var states = new StateProvince[] {
                new StateProvince("CO", "Colorado"),
                new StateProvince("DC", "District of Columbia"),
                new StateProvince("SK", "Saskatchewan"),
            };

            var addresses = Factory.GetAddresses();

            var addressQuery = from a in addresses
                               join s in states on a.StateProvinceCode equals s.StateProvinceCode

                               select $"{a.Name} of {a.City}, {s.StateProvinceName}";

            foreach (var address in addressQuery)
            {
                Trace.WriteLine(address);
            }
        }

        [TestMethod]
        public void OrderByStaticKey()
        {
            var addresses = Factory.GetAddresses();

            var query = addresses.OrderByDescending(address => address.StateProvinceCode);

            foreach (var address in query)
            {
                Trace.WriteLine($"{address.Name} {address.City} {address.StateProvinceCode}");
            }
        }

        [TestMethod]
        [DataRow("Name")]
        [DataRow("City")]
        public void OrderByDynamicKey(string propertyName)
        {
            var addresses = Factory.GetAddresses();

            var property = typeof(Address).GetProperty(propertyName);
            var query = addresses.OrderBy(address => property.GetValue(address, null));

            foreach (var address in query)
            {
                Trace.WriteLine($"{address.Name} {address.City} {address.StateProvinceCode}");
            }
        }

        [TestMethod]
        public void PredicateStaticKey()
        {
            var addresses = Factory.GetAddresses();

            var query = addresses.Where(address => address.City.Contains("er"));

            foreach (var address in query)
            {
                Trace.WriteLine($"{address.Name} {address.City} {address.StateProvinceCode}");
            }
        }

        [TestMethod]
        public void PredicateDynamicKey()
        {
            var addresses = Factory.GetAddresses();

            var property = typeof(Address).GetProperty("City");
            var query = addresses.Where(address => property.GetValue(address, null).ToString().Contains("er") );

            foreach (var address in query)
            {
                Trace.WriteLine($"{address.Name} {address.City} {address.StateProvinceCode}");
            }
        }
    }
}
