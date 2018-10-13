using Jackdaw.Infrastructure;
using Jackdaw.DataLayer;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jackdaw.Test
{
    class Program
    {
        static void Main(string[] args)
        {
           // var context = new Report();
           // context.Create();

            var v = JsonConvert.SerializeObject(new Criterion
            {
                GroupA = 10,
                GroupB = new SubgroupB()
                {
                    SubgroupLanguage = new List<int>() { 9, 10, 8, 9 },
                    SubgroupPhonetic = new List<int>() { 9, 10, 9, 9 },
                    SubgroupIntonation = new List<int>() { 0, 10, 10, 10 }
                },
                GroupC = 150
            });

            //Email.Send("");

            //var alg = new ContestAlgorithm();

            //var AlgorithmParameters = new List<ParameterAlgorithm>
            //{
            //    new ParameterAlgorithm()
            //    {
            //        ParticipantId = 1,
            //        Marks = new Criterion
            //        {
            //            GroupA = 10,
            //            GroupB = new SubgroupB()
            //            {
            //                SubgroupLanguage = new List<int>() { 9, 10, 8, 9 },
            //                SubgroupPhonetic = new List<int>() { 9, 10, 9, 9 },
            //                SubgroupIntonation = new List<int>() { 0, 10, 10, 10 }
            //            },
            //            GroupC = 150
            //        }
            //    },

            //    new ParameterAlgorithm()
            //    {
            //        ParticipantId = 2,
            //        Marks = new Criterion
            //        {
            //        GroupA = 10,
            //        GroupB = new SubgroupB()
            //        {
            //            SubgroupLanguage = new List<int>() { 9,8,9,9 },
            //            SubgroupPhonetic = new List<int>() { 10,10,10,9},
            //            SubgroupIntonation = new List<int>() { 10, 9, 10, 9 }
            //        },
            //            GroupC = 97
            //        }
            //    },

            //    new ParameterAlgorithm()
            //    {
            //        ParticipantId = 3,
            //        Marks = new Criterion
            //        {
            //           GroupA = 0,
            //           GroupB = new SubgroupB()
            //           {
            //              SubgroupLanguage = new List<int>() { 8,8,9,10 },
            //              SubgroupPhonetic = new List<int>() { 10,8,10,10 },
            //              SubgroupIntonation = new List<int>() { 9, 9, 9, 9 }
            //           },
            //           GroupC = 131
            //        }
            //    },

            //    new ParameterAlgorithm()
            //    {
            //        ParticipantId = 4,
            //        Marks =  new Criterion
            //        {
            //           GroupA = 0,
            //           GroupB = new SubgroupB()
            //           {
            //               SubgroupLanguage = new List<int>() { 9,10,10,10 },
            //              SubgroupPhonetic = new List<int>() { 9,8,10,10 },
            //              SubgroupIntonation = new List<int>() { 9, 9, 10, 9 }
            //           },
            //           GroupC = 100
            //    }
            //    }
            //};


            //alg.Execute(1, AlgorithmParameters);
            Console.ReadKey();
        }
    }
}
/*
 *1 Петров Иван
 {
 "GroupA":10,
 "GroupC":150,
 "GroupB":{
   "SubgroupLanguage":[9,10,8,9],
   "SubgroupPhonetic":[9,10,9,9],
   "SubgroupIntonation":[0,10,10,10]
   }
 }

 *2 Лагунова Мария
 {
 "GroupA":10,
 "GroupC":97,
 "GroupB":{
   "SubgroupLanguage":[9,8,9,9],
   "SubgroupPhonetic":[10,10,10,9],
   "SubgroupIntonation":[10,9,10,9]
   }
 }

 *3 Тихомирова Диана
 {
 "GroupA":0,
 "GroupC":131,
 "GroupB":{
   "SubgroupLanguage":[8,8,9,10],
   "SubgroupPhonetic":[10,8,10,10],
   "SubgroupIntonation":[9,9,9,9]
   }
 }

 *4 Жуков Андрей
 {
 "GroupA":0,
 "GroupC":100,
 "GroupB":{
   "SubgroupLanguage":[9,10,10,10],
   "SubgroupPhonetic":[9,8,10,10],
   "SubgroupIntonation":[9,9,10,9]
   }
 }

 *5 Сидоров Василий
 {
 "GroupA":0,
 "GroupC":124,
 "GroupB":{
   "SubgroupLanguage":[10,9,9,9],
   "SubgroupPhonetic":[8,9,10,10],
   "SubgroupIntonation":[10,10,9,9]
   }
 }

 *6 Колесников Кирилл
 {
 "GroupA":10,
 "GroupC":115,
 "GroupB":{
   "SubgroupLanguage":[9,10,10,10],
   "SubgroupPhonetic":[9,10,10,10],
   "SubgroupIntonation":[10,10,10,10]
   }
 }

 *7 Шильцов Матвей
 {
 "GroupA":10,
 "GroupC":145,
 "GroupB":{
   "SubgroupLanguage":[9,8,9,9],
   "SubgroupPhonetic":[10,9,9,8],
   "SubgroupIntonation":[9,9,8,9]
   }
 }
 
 *7 Рябинкина Анастасия 
 {
 "GroupA":10,
 "GroupC":106,
 "GroupB":{
   "SubgroupLanguage":[10,10,9,9],
   "SubgroupPhonetic":[8,9,10,9],
   "SubgroupIntonation":[10,10,8,9]
   }
 }

 *9 Гавриков Глеб
 {
 "GroupA":0,
 "GroupC":123,
 "GroupB":{
   "SubgroupLanguage":[9,9,8,9],
   "SubgroupPhonetic":[9,10,10,9],
   "SubgroupIntonation":[10,10,10,9]
   }
 }
 
 *8 Лопухов Михаил
 {
 "GroupA":10,
 "GroupC":113,
 "GroupB":{
   "SubgroupLanguage":[9,9,9,9],
   "SubgroupPhonetic":[10,9,8,9],
   "SubgroupIntonation":[9,9,9,9]
   }
 }
*/
