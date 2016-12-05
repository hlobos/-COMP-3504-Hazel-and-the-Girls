using SQLite;

namespace DogWalkies
{
    public class Dog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfileImage { get; set; }

        public string Breed { get; set; }

        public string Age { get; set; }

        public string Birthdate { get; set; }

        public string Color { get; set; }

        public string Gender { get; set; }

        public string Microchip { get; set; }




        public Dog() { } // must have a default constructor to use SQLite methods 

        public Dog(string firstName, string lastName, byte[] profileImage, string breed, string age, string birthdate, string color, string gender, string microchip)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            Breed = breed;
            Age = age;
            Birthdate = birthdate;
            Color = color;
            Gender = gender;
            Microchip = microchip;
        }

        public override string ToString()
        {
            return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, FirstName, LastName);
        }
    }
}