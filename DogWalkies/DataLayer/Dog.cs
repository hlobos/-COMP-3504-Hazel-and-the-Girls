using SQLite;

namespace DogWalkies
{
    public class Dog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Dog() { } // must have a default constructor to use SQLite methods 

        public Dog(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, FirstName, LastName);
        }
    }
}