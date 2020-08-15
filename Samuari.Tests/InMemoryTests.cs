using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samurai.Data;

namespace Samuari.Tests
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertSamurai");

            using (var context = new SamuraiContext(builder.Options))
            {
                var samurai = new Samurai.Domain.Samurai();
                context.Samurais.Add(samurai);
                Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
            }
        }
    }
}
