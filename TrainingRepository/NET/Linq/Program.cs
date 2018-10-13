using System;
using System.Collections.Generic;
using System.Linq;
using Univer.Repository;

namespace Linq
{
    public class Entity
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }

    class Program
    {
        private static UnitOfWork unitOfWork;

        static void Main(string[] args)
        {
            unitOfWork = new UnitOfWork();

            var list0 = new List<Entity>()
            {
                new Entity() {Id = 1, Value = 11 },
                new Entity() {Id = 2, Value = 22 },
                null
            };

          
            


            var list1 = new List<Entity>()
            {
                new Entity() {Id = 1, Value = 11 },
                new Entity() {Id = 2, Value = 22 },
                new Entity() {Id = 3, Value = 33 }
            };

            var list2 = new List<Entity>()
            {
                new Entity() {Id = 1, Value = 11 },
                new Entity() {Id = 2, Value = 22 }
            };

            var list = list1.Select(x => x.Id).Except(list2.Select(x => x.Id)).ToList();

            RestrictionOperators();
            SelectOperators();
            PartitioningOperators();
            OrderingOperators();
            GroupingOperators();
            SetOperators();
            ElementOperators();
            GenerationOperators();
            Quantifiers();
            AggregateOperators();
            MiscellaneousOperators();
            JoinOperators();

            Console.ReadKey();
        }

      
        /// <summary>
        /// Where
        /// </summary>
        static void RestrictionOperators()
        {
            Console.WriteLine("Where");

            var data = unitOfWork.RepositorySetTotal.GetAll().ToList();

            var queryFirst = data.Where(item => item.Mark > 200 && item.BudgetPlaces > 10);
            Console.WriteLine(queryFirst.Count());

            var querySecond = data.Where(item => item.Mark > 200 || item.BudgetPlaces > 10);
            Console.WriteLine(querySecond.Count());
            
            var sqlForm = from item in data
                where item.Mark > 200 && item.BudgetPlaces > 10
                select item;
            Console.WriteLine(sqlForm.Count());
            
            var sqlEqually = from item in data
                where item.Mark == 248.75
                select item;
            Console.WriteLine(sqlEqually.Count());
            

            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// Select, SelectMany
        /// </summary>
        static void SelectOperators()
        {
            Console.WriteLine("Select, SelectMany");

            var data = unitOfWork.RepositorySpecialty.GetAll().ToList();

            var sqlForm = from item in data
                select new
                {
                    Id = item.Id,
                    Name = item.Name
                };

            foreach (var val in sqlForm)
            {
                Console.WriteLine($"{val.Name},{val.Id}");
            }

            var query = data.Select(item => new
            {
                Name = $"{item.Id},{item.Name}"
            });

            foreach (var val in query)
            {
                Console.WriteLine(val.Name);
            }

            var queryMany = data.Take(1).SelectMany(item => item.Name);
            foreach (var val in queryMany)
            {
                Console.WriteLine($"{val},");
            }

            var queryIndex = data.Select((item, index) => new
            {
                Name = item.Name,
                Index = index
            });

            foreach (var val in queryIndex)
            {
                Console.WriteLine($"{val.Index}-{val.Name},");
            }

            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// Take, Skip, TakeWhile, SkipWhile
        /// </summary>
        static void PartitioningOperators()
        {
            Console.WriteLine("Take, Skip, TakeWhile, SkipWhile");

            var data = unitOfWork.RepositorySetTotal.GetAll().ToList();

            foreach (var val in data.Take(2))
            {
                Console.WriteLine($"Take - {val.Id}");
            }

            foreach (var val in data.Skip(4))
            {
                Console.WriteLine($"Skip - {val.Id}");
            }

            var takeWhile = data.TakeWhile(x => x.BudgetPlaces > 6).ToList();
            foreach (var val in takeWhile)
            {
                Console.WriteLine($"TakeWhile - {val.Id}");
            }

            var skipWhile = data.SkipWhile(x => x.BudgetPlaces > 6).ToList();
            foreach (var val in skipWhile)
            {
                Console.WriteLine($"SkipWhile - {val.Id}");
            }

            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// OrderBy, ThenBy
        /// </summary>
        static void OrderingOperators()
        {
            Console.WriteLine("OrderBy, ThenBy");

            var data = unitOfWork.RepositorySpecialty.GetAll().ToList();

            var sqlForm = from item in data
                orderby item.Name
                select item.Name;

            foreach (var val in sqlForm)
            {
                Console.WriteLine($"OrderBy - {val}");
            }

            var queryDescending = data.OrderByDescending(item => item.Name);
            foreach (var val in queryDescending)
            {
                Console.WriteLine($"OrderByDescending - {val.Name}");
            }

            //дополнительная сортровка т.е. по длине + сразу в этих по объектам, типа селекта мани
            var queryThenBy = data.OrderBy(item => item.Name.Length).ThenBy(item => item.Name);
            foreach (var val in queryThenBy)
            {
                Console.WriteLine($"OrderByAndThenBy - {val.Name}");
            }
            /*
             Основной показатель:
             Биотехнические системы и технологии
             Информационные системы и технологии
            */
            Console.WriteLine("---------------------");
        }

        static void GroupingOperators()
        {
            Console.WriteLine("GroupingOperators");

            var data = unitOfWork.RepositorySetTotal.GetAll().ToList();

            var sqlForm = from item in data
                group item by item.BudgetPlaces
                into g
                select new
                {
                    Key = g.Key,
                    Value = g
                };

            foreach (var val in sqlForm)
            {
                Console.WriteLine($"Grouping - {val.Key}:");

                foreach (var v in val.Value)
                {
                    Console.WriteLine($"{v.Id}");
                }
            }
            
            var queryGroupBy = data.GroupBy(item => item.BudgetPlaces).Select(g => new
            {
                Key = g.Key,
                Value = g
            });

            Console.WriteLine($"Count GroupingLinq = {queryGroupBy.Count()}");

            foreach (var val in queryGroupBy)
            {
                Console.WriteLine($"GroupingLinq - {val.Key}:");

                foreach (var v in val.Value)
                {
                    Console.WriteLine($"{v.Id}");
                }
            }

            Console.WriteLine("---------------------");
        }

        static void SetOperators()
        {
            Console.WriteLine("SetOperators");

            var specialty = unitOfWork
                .RepositorySpecialty
                .GetAll()
                .Take(3)
                .Select(item => item.Id)
                .ToList();

            var setTotal = unitOfWork
                .RepositorySetTotal
                .GetAll()
                .ToList();

            var setTotalSpecialtyIds = setTotal
                .Skip(3)
                .Select(item => item.SpecialtyId);

            var union = specialty.Union(setTotalSpecialtyIds);

            foreach (var val in union)
            {
                Console.WriteLine($"Union - {val}");
            }
            
            foreach (var val in setTotal.Select(item => item.BudgetPlaces).Distinct())
            {
                Console.WriteLine($"Distinct - {val}");
            }

            //Intersect выводит одинаковые в наборах
            var a = new[] { 0, 2, 4, 5, 6, 8, 9 };
            var b = new[] { 1, 3, 5, 7, 8 };

            foreach (var n in a.Intersect(b))
            {
                Console.WriteLine($"Intersect - {n}");
            }

            //Except выводит разные в наборах
            foreach (var n in a.Except(b))
            {
                Console.WriteLine($"Except - {n}");
            }


            Console.WriteLine("---------------------");
        }

       

        static void ElementOperators()
        {
            Console.WriteLine("ElementOperators");

            var setTotal = unitOfWork
                .RepositorySetTotal
                .GetAll()
                .ToList();

            var first = (from item in setTotal select item.Mark).First();
            var firstOrDefault = (from item in setTotal select item.Mark).FirstOrDefault();
            var elementAtByIndex = (from item in setTotal select item.Mark).ElementAt(2);
            Console.WriteLine($"First - {first}");
            Console.WriteLine($"FirstOrDefault - {firstOrDefault}");
            Console.WriteLine($"ElementAt - {elementAtByIndex}");
            Console.WriteLine("---------------------");
        }

        static void GenerationOperators()
        {
            Console.WriteLine("Range, Repeat");

            var range = Enumerable.Range(1, 10).Select(x => new
            {
                Result = "Dima Zuravlev"
            });

            foreach (var val in range)
            {
                Console.WriteLine($"Range - {val.Result}");
            }
            
            var repeat = Enumerable.Repeat("Dima", 2);

            foreach (var val in repeat)
            {
                Console.WriteLine($"Repeat  - {val}");
            }

            Console.WriteLine("---------------------");
        }

        static void Quantifiers()
        {
            Console.WriteLine("Quantifiers");

            var setTotal = unitOfWork
                .RepositorySetTotal
                .GetAll()
                .ToList();

            var any = setTotal.Any(item => item.Mark > 200);
            Console.WriteLine($"Any  - {any}");
            var all = setTotal.All(item => item.Mark > 200);
            Console.WriteLine($"All - {all}");

            var anyInWhere = setTotal.GroupBy(item => item.BudgetPlaces).Where(g => g.Any(a => a.BudgetPlaces > 10)).ToList();
            
            Console.WriteLine("---------------------");
        }

        static void AggregateOperators()
        {
            Console.WriteLine("AggregateOperators");

            int ten = 10;
            int[] a = { 1, 2, 3, 4, 5, 6};

            var max =
                a.Aggregate(ten,
                    (current, next) =>
                        current > next ? current : next, 
                        val => val * 10);

            Console.WriteLine("Max: {0}", max);

            Console.WriteLine("---------------------");
        }

        static void MiscellaneousOperators()
        {
            Console.WriteLine("Concat, EqualAll");

            var setTotal = unitOfWork
                .RepositorySetTotal
                .GetAll()
                .ToList();

            var specialty = unitOfWork
                .RepositorySpecialty
                .GetAll()
                .ToList();

            var concat = setTotal
                .Select(o => o.Id)
                .Concat(specialty.Select(o => o.Id))
                .Select(o =>  $"{o},");

            Console.WriteLine("Concat: {0}", String.Concat(concat));

            var equal = setTotal.Select(item => item.SpecialtyId).SequenceEqual(specialty.Select(item => item.Id));
            Console.WriteLine("Equal: {0}", equal);

            Console.WriteLine("---------------------");
        }


        static void JoinOperators()
        {
            Console.WriteLine("Join");

            var setTotal = unitOfWork
                .RepositorySetTotal
                .GetAll()
                .ToList();

            var specialty = unitOfWork
                .RepositorySpecialty
                .GetAll()
                .ToList();

            var sqlForm = from s in specialty
                join t in setTotal on s.Id equals t.SpecialtyId
                select new
                {
                    Name = s.Name,
                    Mark = t.Mark
                };

            foreach (var val in sqlForm)
            {
                Console.WriteLine($"Join - {val.Name}, {val.Mark}");
            }

            var query = specialty.Join(setTotal, 
                s => s.Id, 
                st => st.SpecialtyId, 
                (s, st) =>
                new
                {
                    Name = s.Name,
                    Mark = st.Mark
                });

            foreach (var val in query)
            {
                Console.WriteLine($"Join Linq - {val.Name}, {val.Mark}");
            }

            Console.WriteLine("---------------------");


            Console.WriteLine("Left Join");
            var sqlLeftForm = from s in specialty
                join t in setTotal on s.Id equals t.SpecialtyId
                into values
                from v in values.DefaultIfEmpty()
                select new
                {
                    Name = s.Name,
                    Mark = v.Mark
                };

            foreach (var val in sqlLeftForm)
            {
                Console.WriteLine($"Left Join - {val.Name}, {val.Mark}");
            }

            var queryLeft = specialty.GroupJoin(setTotal,
                s => s.Id,
                st => st.SpecialtyId,
                (s, totals) => new
                {
                    s = s,
                    totals = totals
                });
                //.SelectMany(s => s.totals.DefaultIfEmpty(), (x, y) => new
                //{
                //    s = x,
                //    t = y.Mark
                //})
                //.Select(x => new
                //{
                //    Name = x.Name,
                //    Mark = x.Mark
                //});
           

            foreach (var val in query)
            {
                Console.WriteLine($"Join Linq - {val.Name}, {val.Mark}");
            }
        }
        
    }
}

