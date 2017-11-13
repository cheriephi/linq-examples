using System.Data.Linq;

namespace MyLinq
{
    public class AddressBook : DataContext
    {
        public Table<Address> Addresses;

        public AddressBook(string connection) : base (connection) {}
    }
}
