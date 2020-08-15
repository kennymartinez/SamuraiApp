using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samurai.Data;

namespace Samuari.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabase()
        {
            using (var context = new SamuraiContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var samurai = new Samurai.Domain.Samurai();
                context.Samurais.Add(samurai);
                Debug.WriteLine($"Before save: {samurai.Id}");

                context.SaveChanges();
                Debug.WriteLine($"After save: {samurai.Id}");

                Assert.AreNotEqual(0, samurai.Id);
            }
        }
    }
}
