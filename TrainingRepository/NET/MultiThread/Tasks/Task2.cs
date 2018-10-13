using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread.Tasks
{
    //whenAll, whenAny
    public class Task2
    {
        public void Run()
        {
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine($"1 - Task={Task.CurrentId} Thread={Thread.CurrentThread.ManagedThreadId}");
            });

            var task2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"2 - Task={Task.CurrentId} Thread={Thread.CurrentThread.ManagedThreadId}");
            });

            Task.WhenAll(task2, task1)
                .ContinueWith(t =>
                {
                    Console.WriteLine($"Все задачи выполнены! - Task={Task.CurrentId} Thread={Thread.CurrentThread.ManagedThreadId}");
                });

            Task.WhenAny(task2, task1)
                .ContinueWith(t =>
                {
                    Console.WriteLine($"Какая-то задача выполнена! - Task={Task.CurrentId} Thread={Thread.CurrentThread.ManagedThreadId}");
                });

        }
    }
}
