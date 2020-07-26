using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread.Tasks
{
    public class Task3
    {
        static void Run()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Start - Task={Task.CurrentId} " +
                                  $"Thread={Thread.CurrentThread.ManagedThreadId}");

                //3 дочерних таска
                Task.Factory.StartNew(() => { Calc(3); }, TaskCreationOptions.AttachedToParent);
                Task.Factory.StartNew(() => { Calc(2); }, TaskCreationOptions.AttachedToParent);
                Task.Factory.StartNew(() => { Calc(5); }, TaskCreationOptions.AttachedToParent);
            });

            parent.Wait();

            Console.ReadKey();
        }


        static void Run2()
        {
            var parent = new Task(() =>
            {
                Console.WriteLine($"Start - Task={Task.CurrentId} " +
                                 $"Thread={Thread.CurrentThread.ManagedThreadId}");
                var task = new TaskFactory<string>(
                    new CancellationToken(),
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);

                var childTask = new[]
                {
                    task.StartNew(() => Calc(3)),
                    task.StartNew(() => Calc(2)),
                    task.StartNew(() => Calc(5))
                };


                task.ContinueWhenAny(
                    childTask.ToArray(),
                    tasks =>
                    {
                        Console.WriteLine("Какая-то выполнена!");
                        Console.WriteLine($"Task={Task.CurrentId} " +
                                 $"Thread={Thread.CurrentThread.ManagedThreadId}");
                        return null;
                    });

                task.ContinueWhenAll(
                    childTask.ToArray(),
                    tasks =>
                    {
                        Console.WriteLine("Все выполнены!");
                        Console.WriteLine($"Task={Task.CurrentId} " +
                                 $"Thread={Thread.CurrentThread.ManagedThreadId}");
                        return null;
                    });


                foreach (Task<string> t in childTask)
                {
                    Console.WriteLine(t.Result);
                }


            });

            parent.Start();

            Console.ReadKey();
        }

        static string Calc(int i)
        {
            Console.WriteLine($"Start {i} - Task={Task.CurrentId} Thread={Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(i * 1000);
            Console.WriteLine($"Finish {i} - Task={Task.CurrentId} Thread={Thread.CurrentThread.ManagedThreadId}");
            return i.ToString();
        }
    }
}
