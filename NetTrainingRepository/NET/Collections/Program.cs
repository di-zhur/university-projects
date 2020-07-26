using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univer.Repository;

namespace Collections
{
    public class People
    {
        public string Name { get; set; }
        public int Old { get; set; }
    }

    public class PeopleCollection : Collection<People>
    {
       
    }


    class Program
    {
        static UnitOfWork unitOfWork = new UnitOfWork();

        static void Main(string[] args)
        {
            //var data = unitOfWork.RepositorySetTotal.GetAll().ToList();

            //var peopleCollection = new PeopleCollection();
            //peopleCollection.Add(new People { Name = "Dima", Old = 23 });

            //var list = new List<string>();
            
            
            //data.ForEach(x => Console.WriteLine(x.Mark));

            Company.Execute();

            Console.ReadKey();
        }
    }
}
