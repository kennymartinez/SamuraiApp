using Samurai.Data;
using Samurai.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class BusinessDataLogic
    {
        private readonly SamuraiContext _context;

        public BusinessDataLogic(SamuraiContext context)
        {
            this._context = context;
        }

        public BusinessDataLogic()
        {
            this._context = new SamuraiContext();
        }

        public int AddMultipleSamurais(string[] nameList)
        {
            var samuraiList = new List<Samurai.Domain.Samurai>();
            foreach (var name in nameList)
            {
                samuraiList.Add(new Samurai.Domain.Samurai { Name = name });
            }
            _context.Samurais.AddRange(samuraiList);
            var dbResult = _context.SaveChanges();
            return dbResult;
        }

        public int InsertNewSamurai(Samurai.Domain.Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            return _context.SaveChanges();
        }
    }
}
