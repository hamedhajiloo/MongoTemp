using System;
using System.Collections.Generic;
using System.Text;

namespace Mongo_Console.Model
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

    }
}
