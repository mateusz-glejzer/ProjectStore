using System;
using System.Collections.Generic;

namespace ProjectStore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        
        public DateTime Birthday { get; set; }
        public int PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
