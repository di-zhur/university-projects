using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Assembly
{


    //class Loader: MarshalByRefObject
    //{
    //    static void Main()
    //    {
    //        AppDomain.CurrentDomain.AssemblyResolve += FindAssembly;

    //        Program.Go();
    //        Thread.Sleep(1000);
    //    }

    //    static System.Reflection.Assembly FindAssembly(object sender, ResolveEventArgs args)
    //    {
    //        string simpleName = new AssemblyName(args.Name).Name;
    //        string path = @"C:\Users\dmitr\Desktop\project\TrainingRepository\NET\LibraryForTest\bin\Debug\" + simpleName + ".dll";
    //        if (!File.Exists(path)) return null;
    //        return System.Reflection.Assembly.LoadFrom(path);
    //    }

    //}

    class Program
    {
        
        static void Main()
        {
            var assemblyArray = GetTestAssembly();
            var assembly = System.Reflection.Assembly.Load(assemblyArray);
            
            Type myType = assembly.ExportedTypes.FirstOrDefault(o => o.Name == "Class");
            // Get the method to call.
            MethodInfo myMethod = myType.GetMethod("Run");
            // Create an instance.
            var obj = Activator.CreateInstance(myType);
            // Execute the method.
            var result =  myMethod.Invoke(obj, null);
                       

            Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.CodeBase);
            Console.ReadKey();
        }

        private static byte[] GetTestAssembly()
        {
            var path = @"C:\Users\dmitr\Desktop\project\TrainingRepository\NET\LibraryForTest\bin\Debug\LibraryForTest.dll";
            using (var ms = new MemoryStream())
            using (var assembly = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var length = assembly.Length;
                var bytes = new byte[length];
                assembly.Read(bytes, 0, (int)length);
                ms.Write(bytes, 0, (int)length);
                return ms.ToArray();
            }
        }
    }
}

