using Microsoft.EntityFrameworkCore;
using Samurai.Data;
using Samurai.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        public static SamuraiContext context = new SamuraiContext();

        private static void Main(string[] args)
        {
            //context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
            //AddSamurai();
            //GetSamurais("After Add:");
            QueryFilters();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai.Domain.Samurai { Name = "Rocky" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void QueryFilters()
        {
            var name = "Rocky";
            //var samurais = context.Samurais.Where(s => s.Name == name).ToList();
            var samurais = context.Samurais.Where(s => EF.Functions.Like(s.Name, "R%")).ToList();
        }
    }
}
