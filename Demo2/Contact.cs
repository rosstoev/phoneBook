using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class Contact
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }

        public Contact(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
    }
}
