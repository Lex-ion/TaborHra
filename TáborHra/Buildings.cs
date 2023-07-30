using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TáborHra
{
    internal class Buildings
    {
        public int Price { get; set; }
        public int Points { get; set; }
        public int At { get; set; }
        public int Ar { get; set; }
        public int Art { get; set; }
        public int Pos { get; set; }
        public uint Id { get; set; }
        public string Name { get; set; }

        public Buildings(int price, int points, int at, int ar, int art, int pos, uint id, string name)
        { 
            Price = price;
            Points = points;
            At = at;
            Ar = ar;
            Art = art;
            Pos = pos;  
            Id = id;
            Name = name;
        }

    }
}
