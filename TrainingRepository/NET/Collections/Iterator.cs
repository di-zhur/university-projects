using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{

    public class Job
    {
        public string Name { get; }

        public Job(string name)
        {
            Name = name;
        }
    }
    
    public class Company: IEnumerable
    {
        public static void Execute()
        {
            var iterator = new Company();
            var getEnumerator = iterator.GetEnumerator();
            while (getEnumerator.MoveNext())
            {
                var job = getEnumerator.Current as Job;

                if (job != null)
                    Console.WriteLine(job.Name);
            }
        }

        List<Job> _jobs = new List<Job>()
        {
            new Job("1"),
            new Job("2"),
            new Job("3"),
            new Job("4"),
            new Job("5"),
        };

        public IEnumerator GetEnumerator()
        {
            return new Worker(this);
        }

        public int Count => _jobs.Count;

        public Job this[int index]
        {
            get { return _jobs[index]; }
            set { _jobs.Insert(index, value); }
        }
    }

    public class Worker: IEnumerator
    {
        private int _current = -1;
        private Company _company;

        public Worker(Company company)
        {
            _company = company;
        }

        public object Current => _company[_current];

        public bool MoveNext()
        {
            if (_current < _company.Count - 1)
            {
                _current++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _current = -1;
        }
    }
}
