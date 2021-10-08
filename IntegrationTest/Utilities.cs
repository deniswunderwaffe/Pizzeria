// using System.Collections.Generic;
// using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
// using Pizzeria.Core.Models;
// using Pizzeria.Infrastructure.Data;
//
// namespace IntegrationTest
// {
//     public static class Utilities
//         {
//             
//             public static void InitializeDbForTests(ApplicationDbContext db)
//             {
//                 db.Pizzas.AddRange();
//                 db.SaveChanges();
//             }
//     
//             public static void ReinitializeDbForTests(ApplicationDbContext db)
//             {
//                 db.Pizzas.RemoveRange(db.Pizzas);
//                 InitializeDbForTests(db);
//             }
//     
//             public static List<Pizza> GetSeedingMessages()
//             {
//                 return new List<Pizza>()
//                 {
//                     new Pizza(){Id = 1,Name = "hello",Type = "American",Price = 50},
//                     new Pizza(){Id = 2,Name = "hello1",Type = "Italian",Price = 150},
//                     new Pizza(){Id = 3,Name = "hello2",Type = "Japanese",Price = 250}
//                 };
//             }
//             
//         }
// }

