using MuffinShack.Data;
using MuffinShack.Entities;
using System;

namespace MuffinShack.Business
{
    public class MuffinService
    {
        private readonly MuffinContext _context;

        public MuffinService(MuffinContext context)
        {
            _context = context;
        }

        public void CreateMuffin(Muffin muffin)
        {
            //do some work business stuff
            _context.Muffins.Add(muffin);
            _context.SaveChanges();
        }
    }
}
