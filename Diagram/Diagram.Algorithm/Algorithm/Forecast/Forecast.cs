using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Diagram.DataAccess;
using System.Linq;
using Newtonsoft.Json;
using Diagram.Algorithm.Types;

namespace Diagram.Algorithm.Algorithm.Forecast
{
    public class Forecast : BaseAlgorithm
    {
        
        public override void Execute(IDictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey("UniversityId") && !parameters.ContainsKey("FacultyId") && !parameters.ContainsKey("SpecialtyId"))
                throw new Exception("Нет параметров");

            Guid universityId;
            Guid facultyId;
            Guid specialtyId;

            if (Guid.TryParse(parameters["UniversityId"], out universityId) && Guid.TryParse(parameters["FacultyId"], out facultyId) && Guid.TryParse(parameters["SpecialtyId"], out specialtyId))
            {
                var university = UnitOfWork.UniversityRepository.GetById(universityId);
                var faculty = UnitOfWork.FacultyRepository.GetById(facultyId);
                var specialty = UnitOfWork.SpecialtyRepository.GetById(specialtyId);
                var data = UnitOfWork.SetTotalRepository.GetWhere(o => o.SpecialtyId == specialty.Id).Select(o => new
                {
                    Year = o.Year.Year,
                    Mark = o.Mark
                }).OrderBy(by => by.Year).ToList();

                var years = data.Select(o => o.Year).ToList();
                years.Add(years.Max() + 1);
                var marks = data.Select(o => o.Mark).ToList();
                float error;
                CalculationForecast(ref marks, out error);

                Result = JsonConvert.SerializeObject(new
                {
                    Years = years,
                    Marks = marks,
                    LastMark = Math.Round(marks.Last(), 2),
                    ErrorAverage = Math.Round(error, 2)
                });
            }
            else
            {
                throw new Exception("Неверный тип входных параметров");
            }
        }

        private void CalculationForecast(ref List<float> marks, out float errorAverage)
        {
            var countMarks = marks.Count();
            var alpha = (float)2 / (countMarks + 1);

            var listError = new List<float>();
            var Ut = marks.Average();
            float calcValue;
            for (int i = 0; i <= countMarks; i++)
            {
                if (i != countMarks)
                {
                    calcValue = alpha * marks.ElementAt(i) + (1 - alpha) * Ut;
                    var error = (Math.Abs(marks.ElementAt(i) - calcValue)) / marks.ElementAt(i) * 100;
                    listError.Add(error);
                    Ut = calcValue;
                    continue;
                }

                calcValue = alpha * marks.ElementAt(i - 1) + (1 - alpha) * Ut;
                marks.Add(calcValue);
            }

            errorAverage = listError.Sum() / marks.Count();
        }
    }
}
