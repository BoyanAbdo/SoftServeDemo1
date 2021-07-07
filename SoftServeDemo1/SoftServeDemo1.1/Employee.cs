namespace SoftServeDemo1._1
{

    public class Employee
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public char Gender { get; private set; }

        public string Position { get; set; }


        public Employee(string firstName, string lastName, int age, char gender, string position)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Age = age;
            this.Position = position;
        }

        public Employee()
        {
        }


        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} - {this.Position}, {this.Age}, {this.Gender}";
        }


        public string GetNames()
        {
            return $"{this.FirstName} {this.LastName}";
        }

    }

}
