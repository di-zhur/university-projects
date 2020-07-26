using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread.Tasks
{
    //задача с продолжением
    public class Task1
    {
        public void Run()
        {
            var task = Task.Run(() => { new PgContext().Insert(2, "данные2"); });

            var taskContinueWith1 = task.ContinueWith(t => new PgContext().Insert(3, "данные3"), TaskContinuationOptions.NotOnRanToCompletion);
            var taskContinueWith2 = task.ContinueWith(t => new PgContext().Get());

            var res = taskContinueWith2.Result.ToList();

            Console.WriteLine("{0},{1}", task.Id, task.Status);
            Console.WriteLine("{0},{1}", taskContinueWith1.Id, taskContinueWith1.Status);
            Console.WriteLine("{0},{1}", task.Id, task.Status);
            task.Wait();
            Console.WriteLine("{0},{1}", task.Id, task.Status);
            Console.WriteLine("{0},{1}", taskContinueWith1.Id, taskContinueWith1.Status);
            Console.WriteLine("{0},{1}", task.Id, task.Status);
        }
    }

    
}
