using System;

namespace MuffinShack.Entities
{   

    public enum MuffinSize
    {
        Personal,
        Medium,
        Large,
        Family
    }


    public class Muffin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public MuffinSize Size { get; set; }
    }
}
