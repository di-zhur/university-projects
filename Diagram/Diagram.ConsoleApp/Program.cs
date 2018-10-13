using Diagram.Algorithm;
using Diagram.Algorithm.Algorithm.Assessment;
using Diagram.Algorithm.Algorithm.Classification;
using Diagram.Algorithm.Algorithm.Forecast;
using Diagram.DataAccess;
using System;
using System.Collections.Generic;

namespace Diagram.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var forecast = new Classification();
            var algorithm = new AlgorithmCreator(forecast);
            var parameters = new Dictionary<string, string>()
            {
                { "UniversityId", "c4ac9dd7-5304-4a24-b2be-ecfd85367828" },
                { "FacultyId", "050652ce-1fed-4a8b-bb29-065bf4b0e4b7" },
                { "SpecialtyId", "f4e91ff8-885c-4dc1-9659-8ce6ab0c2833" }
            };
            algorithm.Make(parameters);
            var result = forecast.GetResult();
            Console.ReadKey();
        }
    }
}
