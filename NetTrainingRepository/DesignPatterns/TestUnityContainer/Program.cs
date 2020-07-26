using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace TestUnityContainer
{

    public interface IFunction
    {
        string Name { get; set; }
        List<string> GetListFunc { get; set; }
        void Write();
    }

    public class Function : IFunction
    {
        public string Name { get; set; }

        public List<string> GetListFunc { get; set; } = new List<string>()
        {
            "func1",
            "func2"
        };

        public void Write()
        {
            foreach (var func in GetListFunc)
            {
                Console.WriteLine(func);
            }
        }
    }

    public class FunctionCustom : IFunction
    {
        public FunctionCustom(int id, string name)
        {
            GetListFunc = new List<string>() { $"{id}-{name}" };
        }


        public string Name { get; set; }

        public List<string> GetListFunc { get; set; } 
        
        public void Write()
        {
            foreach (var func in GetListFunc)
            {
                Console.WriteLine(func);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();
            //RegisterInstance
            unityContainer.RegisterInstance<IFunction>(new Function());
            //RegisterType
            unityContainer.RegisterType<IFunction, Function>("Func");
            //RegisterType with constructor
            unityContainer.RegisterType<IFunction, FunctionCustom>("FuncCustom", new InjectionConstructor(1, "name"));
            unityContainer.RegisterType<IFunction, FunctionCustom>("FuncCustomPropertyOverride", new InjectionConstructor(1, "name"));

            //Resolve
            var resolveInstance = unityContainer.Resolve<IFunction>("Func");
            var resolveType = (IFunction)unityContainer.Resolve(typeof(Function));
            var resolveTypeCustom = unityContainer.Resolve<IFunction>("FuncCustom");


            //Resolve ParameterOverrides
            var resolveTypeCustomParameterOverride = unityContainer.Resolve<IFunction>("FuncCustom", new ParameterOverrides()
                {
                    {"id", 55},
                    {"name", "NAME"}
                });
            resolveTypeCustomParameterOverride.Write();


            //Resolve PropertyOverride ???
            var resolveTypeCustomPropertyOverride = unityContainer.Resolve<IFunction>("FuncCustomPropertyOverride",
                new PropertyOverride("Name", "Тестируем юнити"));
            Console.WriteLine(resolveTypeCustomPropertyOverride.Name);


            //Resolve all
            foreach (var uc in unityContainer.ResolveAll<IFunction>())
            {
                uc.Write();
            }
            
            Console.ReadKey();
        }

    }
}
