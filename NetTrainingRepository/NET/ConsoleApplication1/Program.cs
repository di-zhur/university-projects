using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public class NameClass
    {
        public string Name { get; set; }
    }

    
    class Program
    {
        static void Main(string[] args)
        {

            var model = new ModelMS();
            model.TestTables.Add(new TestTable
            {
                Id = Guid.Empty,
                Json = "Дима"
            });
            model.SaveChanges();

            var data = model.TestTables.ToList();
            var obj = JsonConvert.DeserializeObject<NameClass>(data[0].Json);


            Console.ReadKey();
        }
    }
}
