using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Playfair
{
    
    class Playfair
    {
        char[] alfabet = new char[25] { 'a', 'b', 'c','d','e','f','g','h','i','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        char[,] tab = new char[5, 5] { {'k','l','u','c','z' }, {'a','b','d','e','f' }, {'g','h','i','m','n' }, {'o','p','q','r','s' }, {'t','v','w','x','y' } };
       public Playfair() { };
        
     /*   public Playfair(string key)
        {
            
            for(int c = 0; c < key.Length; c++)
                for(int i = 0; i<5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        tab[i,j] = key[c];
                    
                    }
                }
                */
            


        }
        public void show()
        {
            Console.WriteLine("|"+ tab[0,0]+ "|"+ tab[0,1]+ "|"+ tab[0,2]+ "|"+ tab[0,3]+ "|"+ tab[0,4] + "|");
            Console.WriteLine("|"+ tab[1,0]+ "|"+ tab[1,1]+ "|"+ tab[1,2]+ "|"+ tab[1,3]+ "|"+ tab[1,4] + "|");
            Console.WriteLine("|"+ tab[2,0]+ "|"+ tab[2,1]+ "|"+ tab[2,2]+ "|"+ tab[2,3]+ "|"+ tab[2,4] + "|");
            Console.WriteLine("|"+ tab[3,0]+ "|"+ tab[3,1]+ "|"+ tab[3,2]+ "|"+ tab[3,3]+ "|"+ tab[3,4] + "|");
            Console.WriteLine("|"+ tab[4,0]+ "|"+ tab[4,1]+ "|"+ tab[4,2]+ "|"+ tab[4,3]+ "|"+ tab[4,4] + "|");


        }

       

    }


    class Program
    {
        static void Main(string[] args)
        {
            Playfair szyfr = new Playfair;
            szyfr.show();
            Console.ReadKey();
        }
    }
}
