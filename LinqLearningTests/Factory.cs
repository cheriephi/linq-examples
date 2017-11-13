using MyLinq;

namespace LinqLearningTests
{
    class Factory
    {
        internal static Address[] GetAddresses()
        {
            var addresses = new Address[] {
                //    new Address(1, "John Doe", "Boulder", "CO"),
                //    new Address(2, "Brent Leroy", "Dog River", "SK"),
                //    new Address(3, "Michelle Obama", "Washington", "DC"),

                new Address("John Doe", "Boulder", "CO"),
                new Address("Brent Leroy", "Dog River", "SK"),
                new Address("Michelle Obama", "Washington", "DC"),
            };

            return addresses;
        }
    }
}
