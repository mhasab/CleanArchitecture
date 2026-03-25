namespace Domain.Entities
{
    public class User
    {
        private string _firstName;
        private string _email;
        private int _age;
        public int Id { get; set; }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _firstName = value;
                else
                    throw new ArgumentException("First name cannot be empty.");
            }
        }
        public string LastName { get; set; }

        public int Age
        {
            get => _age; set
            {
                if (value >= 0)
                    _age = value;
                else
                    throw new ArgumentException("Age cannot be negative.");
            }
        }

        public string Email
        {
            get => _email; set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Contains("@"))
                    _email = value;
                else
                    throw new ArgumentException("Invalid email address.");
            }
        }

        public User(int id, string firstName, string lastName, int age, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }

    }
}
