using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    

    public class People
    {
        public string Name { get; set; } = "Люди";
    }

    public class Men : People
    {
        public string NameMen { get; set; } = "Dima";
    }

    public class Object_IS_AS
    {
        public void Info()
        {
            var men = new Men();
            var people = new People();
            var p = men as People;

            Console.WriteLine("{0}, {1}, {2}", men.GetHashCode(), men.GetType(), men.ToString());
            Console.WriteLine("{0}, {1}, {2}", people as Men, men is People, p.Name);
        }
    }
}
