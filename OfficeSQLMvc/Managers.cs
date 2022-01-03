using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSQLMvc
{
    public class Managers
    {
        string firstName;
        string lastName;
        DateTime Birth;
        string Email;
        string Department;

        public Managers(string firstName, string lastName, DateTime birth, string email, string department)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Birth = birth;
            Email = email;
            Department = department;
        }
    }
}
