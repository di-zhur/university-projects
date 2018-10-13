using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFpg
{
    class Program
    {
        static void Main(string[] args)
        {

            var pg = new Model();
            var data = pg.Cathedra.ToList();

            Console.ReadKey();
        }
    }
}

   
