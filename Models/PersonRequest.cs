using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Models
{
    public class PersonRequest
    {
        public PersonRequest(string name)
        {
            this.Name = name;

        }
        public string Name { get; set; }
    }
}