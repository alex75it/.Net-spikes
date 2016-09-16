using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Common.Entities
{
    public class User
    {
        public const string KEY = "user.";

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string  Email { get; set; }


        public User(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new Exception("firstName and lastName cannot be nyull or empty");
            FirstName = firstName;
            LastName = lastName;
        }
        public string Id {
            get {
                if (id == null)
                    id = FirstName.ToLowerInvariant() + "." + LastName.ToLowerInvariant();
                return id;
            }
            set { }
        }

        private string id;
    }
}
