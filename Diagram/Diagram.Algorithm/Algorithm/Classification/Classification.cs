using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using Diagram.Algorithm.Algorithm.Classification;
using Newtonsoft.Json.Linq;
using Diagram.Algorithm.Algorithm;
using Diagram.Algorithm.Types;
using Diagram.DataAccess;

namespace Diagram.Algorithm.Algorithm.Classification
{
    public class Classification : BaseAlgorithm
    {
       
        public override void Execute(IDictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey("UniversityId") && !parameters.ContainsKey("FacultyId") && !parameters.ContainsKey("SpecialtyId"))
                throw new Exception("Нет параметров");

            Guid universityId;
            Guid facultyId;

            if (Guid.TryParse(parameters["UniversityId"], out universityId) && Guid.TryParse(parameters["FacultyId"], out facultyId))
            {
                var university = UnitOfWork.UniversityRepository.GetById(universityId);
                var faculty = UnitOfWork.FacultyRepository.GetById(facultyId);
                var specialty = UnitOfWork.SpecialtyRepository.GetWhere(o => o.FacultyId == faculty.Id);
                var setTotals = UnitOfWork.SetTotalRepository.GetWhere(o => o.Year == new DateTime(2017, 08, 01)); 
                var dataAnalysis = specialty
                    .Join(setTotals, s => s.Id, st => st.SpecialtyId, 
                    (s, st) => new AnalysisClassification
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Request = st.Request,
                        Mark = st.Mark,
                        Places = st.Places
                    })
                    .ToList();

                var nodes = new List<BaseAttribute>()
                {
                    new MarkAttribute(dataAnalysis),
                    new RequestAttribute(dataAnalysis),
                    new PlacesAttribute(dataAnalysis)
                }
                .OrderByDescending(o => o.Probability.Gain);

                var leafTree = BuildTree(nodes, dataAnalysis);

                var categoriesDiagram = leafTree.Select(o => o.Group["ShortName"]);
                var valuesDiagram = leafTree.Select(o => o.Specialties.Count());
                var values = leafTree.Select(o => new
                {
                    GroupName = o.Group["Name"],
                    LeafParameters = o.Group["LeafParameters"],
                    Specialties = o.Specialties
                });

                Result = JsonConvert.SerializeObject(new
                {
                    CategoriesDiagram = categoriesDiagram,
                    ValuesDiagram = valuesDiagram,
                    Values = values
                });
            }
            else
            {
                throw new Exception("Неверный тип входных параметров");
            }
        }
        
        private List<ResultClassification> BuildTree(IEnumerable<BaseAttribute> nodes, List<AnalysisClassification> dataAnalysis)
        {
            var treeRoot = nodes.ElementAt(0);
            treeRoot.SetValues(dataAnalysis);
            var treeNode1 = nodes.ElementAt(1);
            var treeNode2 = nodes.ElementAt(2);

            var leaf = new List<ResultClassification>();
            var numberGroup = 1;
            foreach (var value1 in treeRoot.Values)
            {
                var node1 = treeNode1.Clone();
                node1.SetValues(value1.AnalysisSpecialties);

                foreach (var value2 in node1.Values)
                {
                    var node2 = treeNode2.Clone();
                    node2.SetValues(value2.AnalysisSpecialties);

                    foreach (var value3 in node2.Values)
                    {
                        var groupName = GetGroup(numberGroup);
                        var leafParameters = $"{GetLeafParameters(treeRoot.Name, value1.Range)}, {GetLeafParameters(node1.Name, value2.Range)}, {GetLeafParameters(node2.Name, value3.Range)}";
                        leaf.Add(new ResultClassification
                        {
                            Group = new Dictionary<string, string>()
                                {
                                    { "ShortName", groupName },
                                    { "Name", $"Группа { groupName }" },
                                    { "LeafParameters", leafParameters }
                                },
                            Specialties = value3.AnalysisSpecialties
                        });
                        numberGroup++;
                    }
                }
            }

            return leaf;
        }

        private string GetLeafParameters(string nameAttr, Range range)
        {
            return $"{nameAttr} {RangeToString(range)}";
        }

        private string RangeToString(Range range)
        {
            return $"[{Math.Round(range.Min, 2)}-{Math.Round(range.Max, 2)}]";
        }

        private string GetGroup(int number)
        {
            switch (number)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                default:
                    return null;
            }
        }
    }
}

