using Mongo_Console.Model;
using Mongo_Console.Repository;
using System;

namespace Mongo_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MongoCRUD("Test");
           // db.AddAsync<Person>("person", new Person { Age = 12, Name = "Ho3n" }).GetAwaiter();
            var result =  db.GetAllAsync<Person>("person").GetAwaiter().GetResult();

           // db.UpdateByNameAsync<Person>("person", "Hamed", new Person { Name = "Ali" });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} / {item.Age}");
            }


            Console.ReadKey();
        }
    }
}
