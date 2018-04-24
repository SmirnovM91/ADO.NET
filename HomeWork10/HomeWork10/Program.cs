using DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext db = new DataContext())
            {



                List<Worker> workers = new List<Worker>();
                List<Department> departments = new List<Department>();
                List<Worker> animals = new List<Worker>();

                workers.Add(new Worker
                {
                    FirstName = "Alex",
                    LastName = "Smirnov"
                });
                workers.Add(new Worker
                {
                    FirstName = "Mikhail",
                    LastName = "Smirnov"
                });


                animals.Add(new Worker
                {
                    FirstName = "Cat",
                    LastName = "Tom"
                });
                animals.Add(new Worker
                {
                    FirstName = "Mouse",
                    LastName = "Jerry"
                });



                departments.Add(new Department
                {
                    Name = "Programmers",
                    Workers = workers
                });


                departments.Add(new Department
                {
                    Name = "Animals",
                    Workers = animals
                });

                Company company = new Company { Name = "ITSTEP", Departments = departments };

                db.Workers.AddRange(workers);
                db.Workers.AddRange(animals);
                db.Departments.AddRange(departments);
                db.Companies.Add(company);
               

                db.SaveChanges();


                var companies = db.Companies;
         
                Console.WriteLine("Список компаний:");
                foreach (var c in companies)
                {
                    Console.WriteLine("{0}", c.Name);
                    foreach (var d in c.Departments)
                    {
                        Console.WriteLine("\t{0}", d.Name);
                        foreach (var w in d.Workers)
                        {
                            Console.WriteLine("\t\t{0} {1}", w.FirstName, w.LastName);
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
