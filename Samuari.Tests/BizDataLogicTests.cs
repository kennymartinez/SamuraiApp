using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samurai.Data;
using System.Linq;

namespace Samuari.Tests
{
    [TestClass]
    public class BizDataLogicTests
    {
        [TestMethod]
        public void AddMultipleSamuraisReturnsCorrectNumberOfInsertedRows()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("AddMultipleSamurais");
            using (var context = new SamuraiContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                var nameList = new string[] { "Kenny", "Sebastian", "Rocky" };
                var result = bizlogic.AddMultipleSamurais(nameList);
                Assert.AreEqual(nameList.Count(), result);
            }
        }

        [TestMethod]
        public void CanInsertSingleSamurai()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("InsertNewSamurai");

            using (var context = new SamuraiContext(builder.Options))
            {
                var bizlogic = new BusinessDataLogic(context);
                bizlogic.InsertNewSamurai(new Samurai.Domain.Samurai());
            }

            using (var context2 = new SamuraiContext(builder.Options))
            {
                Assert.AreEqual(1, context2.Samurais.Count());
            }
        }
    }
}
