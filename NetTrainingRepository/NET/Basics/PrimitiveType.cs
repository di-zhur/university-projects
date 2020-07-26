using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public struct Struct
    {

    }

    public class PrimitiveType
    {
        Struct structVarс;

        public void Action()
        {
            //для проверки переполнения 
            checked
            {
                Byte b = 200;
                b = (Byte) (b + 200);
            }

            //где переполнение не вызывает проблем
            unchecked
            {
                
            }
        }

        public void ValueType()
        {
            Console.WriteLine("class,");
        }

        public void RefType()
        {
            //Object->System.ValueType
            Console.WriteLine("structure(int, decimal), enum");
        }
    }
}
