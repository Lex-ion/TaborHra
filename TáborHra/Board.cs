using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TáborHra
{
    internal class Board
    {
        List<Buildings> UsedBuildings { get; set; }
        int TotalPrice { get; set; }
        int TotalPoints { get; set; }
        int TotalAt { get; set; }
        int TotalAr { get; set; }
        int TotalArt { get; set; }
        int TotalPos { get; set; }
       public float Ratio { get; set; }

        public string Hash { get; set; }

        public Board(List<Buildings> buildings)
        {
            UsedBuildings = buildings;
            Calculate();
            Ratio = (float)TotalPoints / TotalPrice;
            Hash = GenHash();
        }

        string GenHash()
        {
            Dictionary<string, int> countOfBuildings = (Dictionary<string, int>)UsedBuildings.GroupBy(b => b.Name).ToDictionary(x => x.Key, x => x.Count()).OrderBy(y => -y.Value).ToDictionary(x => x.Key, x => x.Value);

            string txt="";

            foreach (KeyValuePair<string, int> kvp in countOfBuildings)
            {
                txt += kvp.Value;
            }
            txt+=Ratio.ToString();

            return txt;
        }

        public void SumUp()
        {
            Dictionary<string, int> countOfBuildings = (Dictionary<string, int>)UsedBuildings.GroupBy(b => b.Name).ToDictionary(x => x.Key, x => x.Count()).OrderBy(y=>-y.Value).ToDictionary(x=>x.Key,x=>x.Value);

            Console.WriteLine("\n#################################\n#################################");
            foreach (KeyValuePair<string, int> kvp in countOfBuildings)
            {
             
                Console.WriteLine($"{kvp.Value}×{kvp.Key}  ");
                
            }
            Console.WriteLine("\n-----");
            Console.WriteLine($"{TotalPrice}|{TotalPoints} -> {TotalAt} {TotalAr} {TotalArt} {TotalPos}");
            Console.WriteLine($"Ratio: {Ratio}");
        }

        void Calculate()
        {
            TotalPrice = UsedBuildings.Sum(p=>p.Price);
            TotalPoints = UsedBuildings.Sum(p=>p.Points);
            TotalAt = UsedBuildings.Sum(p=>p.At);
            TotalAr = UsedBuildings.Sum(p=>p.Ar);
            TotalArt = UsedBuildings.Sum(p=>p.Art);
            TotalPos = UsedBuildings.Sum(p=>p.Pos);

            if (TotalAt < 0)
            {
                TotalPoints += 2 * TotalAt;
            }
            else
                TotalPoints += TotalAt;

            if (TotalAr < 0)
            {
                TotalPoints += 2 * TotalAr;
            }
            else
                TotalPoints += TotalAr;

            if (TotalArt < 0)
            {
                TotalPoints += 2 * TotalArt;
            }
            else
                TotalPoints += TotalArt;

            if (TotalPos < 0)
            {
                TotalPoints+=2*TotalPos;
            }else
                TotalPoints+=TotalPos;
        }
    }
}
