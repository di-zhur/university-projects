using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvents
{
    public class ValueEvent : EventArgs
    {
        public int ValueCurrent;

        public ValueEvent(int valueCurrent)
        {
            ValueCurrent = valueCurrent;
        }
    }

    public class CalcValue
    {
        public event EventHandler<ValueEvent> ValueChanged; 
        private int _value;

        protected virtual void OnValueChanged(ValueEvent е)
        {
            ValueChanged?.Invoke(this, е);
        }

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnValueChanged(new ValueEvent(value));
            }
        }
    }


    class Program
    {
        
        static int Pow(int i) => i * i;
        static bool B(string n) => n.Contains("а");

        static Action<int> method1 = delegate(int i) { var result = i*i; };
        private static Func<int, double> method2 = i => Double.Parse(i.ToString());
        static Predicate<int> predicate = delegate(int i) { return true; }; 

        static void Main(string[] args)
        {
            IEnumerable<Example> f = new Example[] {new Example(), };

            var ff = f.AsQueryable();
            var g = ff.ElementType;
            

            var calcValue = new CalcValue();
            //подписываемся на событие 
            calcValue.ValueChanged += chaged;
            calcValue.Value = 10;
            calcValue.Value = 20;
            calcValue.Value = 30;
            //отписываемся от события
            calcValue.ValueChanged -= chaged;
            calcValue.Value = 40;
            Console.ReadKey();

            Example example = new Example();
            example = 1;
        }

        static void chaged(object sender, ValueEvent e)
        {
             Console.WriteLine($"Значение = {e.ValueCurrent}"); 
        }
    }

    public class Example
    {
        public int Id { get; set; }

        public static implicit operator Example(int id)
        {
            var example = new Example();
            example.Id = id;
            return example;
        }
    }
}
