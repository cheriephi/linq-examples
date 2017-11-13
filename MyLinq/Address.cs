using System.Data.Linq.Mapping;

namespace MyLinq
{
    [Table(Name = "Address")]
    public class Address
    {
        //private static int nextAddressKey = 1;

        private int addressKey;
        private string name;
        private string city;
        private string stateProvinceCode;

        //public Address() : this(nextAddressKey, "", "", "") { }
        public Address() : this("", "", "") { }

        //public Address(int addressKey, string name, string city, string stateProvinceCode)
        public Address(string name, string city, string stateProvinceCode)
        {
            //this.addressKey = addressKey;
            this.name = name;
            this.city = city;
            this.stateProvinceCode = stateProvinceCode;
        }

        #region Accessors
        //[Column(IsPrimaryKey = true, Storage = "addressKey")]
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Storage = "addressKey")]
        public int AddressKey { get => addressKey; }

        [Column(Name = "FullName", Storage = "name")]
        public string Name { get => name; set => name = value; }

        [Column(Storage = "city")]
        public string City { get => city; set => city = value; }

        [Column(Name = "StateCode", Storage = "stateProvinceCode")]
        public string StateProvinceCode { get => stateProvinceCode; set => stateProvinceCode = value; }
        #endregion
    }
}
