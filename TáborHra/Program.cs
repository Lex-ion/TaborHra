namespace TáborHra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            
            List<Buildings> buildings = SetBuildings();
            List<Buildings> current = new List<Buildings>();
            List<Board> mem = new List<Board>();

            foreach (Buildings building in buildings)
            {
                Console.WriteLine($"{building.Name} - {building.Price}/{building.Points}    {building.At} {building.Ar} {building.Art} {building.Pos}");
            
            }


            int[] all = new int[30];
            for (int i = 0; i < all.Length; i++)
            {
                all[i] = 0;
            }

            bool working = true;
            DateTime TimeStamp = DateTime.Now;
            int TotalCount = 0;
            while (working)
            {
               Console.Title=TotalCount +" -- "+ ( DateTime.Now-TimeStamp).ToString();
                current.Clear();

                int iterations = 0;
                foreach (int i in all)
                {
                    if (i > buildings.Count-1)
                    {
                        all[iterations] = 0;
                        if (iterations < all.Length)
                            all[iterations + 1]++;
                        else
                            working = false;
                        
                    }
                    
                    iterations++;
                }
                foreach (int i in all)
                {
                    current.Add(buildings[i]);
                }

                Board CurrentBoard = new Board(current);
                if (mem.Any(p => p.Hash!=CurrentBoard.Hash)||mem.Count<1)
                {
                    mem.Add(CurrentBoard);
                    mem[mem.Count - 1].SumUp();
                    TotalCount++;
                }
                all[0]++;
            }

            mem.OrderBy(m => m.Ratio);
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            for (int i = 0; i < 10; i++)
            {
                mem[i].SumUp();
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Beep(1350, 1000);
                Thread.Sleep(1000);
            }
            


        }
        static List<Buildings> SetBuildings()
        {
            List<Buildings> buildings = new List<Buildings>();

            buildings.Add(new Buildings(12, 12,     3, -3,  1, -2,   0x00, "Univerzita"));
            buildings.Add(new Buildings(10,  9,     4, -1, -1, -2,   0x01, "Divadlo"));
            buildings.Add(new Buildings( 8,  7,     3, -2,  1,  0,   0x02, "Soud"));
            buildings.Add(new Buildings( 4,  4,     2, -1, -1,  0,   0x03, "Knihovna"));
            buildings.Add(new Buildings( 6,  6,     1,  0,  0, -2,   0x04, "Chrám"));

            buildings.Add(new Buildings(14, 13,    -2,  3, -3,  1,   0x05, "Pevnost"));
            buildings.Add(new Buildings(10,  7,    -1,  4, -2,  0,   0x06, "Aréna"));
            buildings.Add(new Buildings( 6,  4,    -1,  3,  0, -1,   0x07, "Kasárna"));
            buildings.Add(new Buildings( 6 , 6,     0,  1, -1, -1,   0x08, "Věž"));
            buildings.Add(new Buildings( 4,  4,     0,  2, -1, -1,   0x09, "Palisáda"));

            buildings.Add(new Buildings(14, 12,    -2, -3,  4, -2,   0x0A, "Nemocnice"));
            buildings.Add(new Buildings(10,  7,    -1, -2,  3,  1,   0x0B, "Observatoř"));
            buildings.Add(new Buildings(10,  9,     1, -2,  1, -1,   0x0C, "Zahrada"));
            buildings.Add(new Buildings( 8,  6,    -1,  1,  3, -2,   0x0D, "Cvičiště"));
            buildings.Add(new Buildings( 4,  3,    -1,  0,  3, -1,   0x0E, "Arboretrum"));

            buildings.Add(new Buildings(16, 15,    -2,  1, -3,  3,   0x0F, "Přístav"));
            buildings.Add(new Buildings(13, 10,    -2,  1, -2,  4,   0x11, "Maják"));
            buildings.Add(new Buildings( 8,  6,    -1, -2,  1,  3,   0x12, "Loděnice"));
            buildings.Add(new Buildings( 6,  6,     1,  0, -3,  2,   0x13, "Akvadukt"));
            buildings.Add(new Buildings( 4,  3,    -1, -1,  1,  2,   0x14, "Rybářská chýše"));

            buildings.Add(new Buildings( 4, 12,    -2, -2, -2, -2,   0x15, "Trůn panovníka"));
            buildings.Add(new Buildings(12,  0,     2,  2,  2,  2,   0x16, "Socha boha Dia"));

            buildings.Add(new Buildings( 0,  0,     0,  0,  0,  0,   0x17, "PRÁZDNO"));

            
            
            return buildings;
        }
    }
}