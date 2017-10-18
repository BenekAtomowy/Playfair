using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Playfair
{


    class Playfair
    {
        char[] alfabet = new char[25] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public void show()
        {
            Console.WriteLine("|" + tab[0, 0] + "|" + tab[0, 1] + "|" + tab[0, 2] + "|" + tab[0, 3] + "|" + tab[0, 4] + "|");
            Console.WriteLine("|" + tab[1, 0] + "|" + tab[1, 1] + "|" + tab[1, 2] + "|" + tab[1, 3] + "|" + tab[1, 4] + "|");
            Console.WriteLine("|" + tab[2, 0] + "|" + tab[2, 1] + "|" + tab[2, 2] + "|" + tab[2, 3] + "|" + tab[2, 4] + "|");
            Console.WriteLine("|" + tab[3, 0] + "|" + tab[3, 1] + "|" + tab[3, 2] + "|" + tab[3, 3] + "|" + tab[3, 4] + "|");
            Console.WriteLine("|" + tab[4, 0] + "|" + tab[4, 1] + "|" + tab[4, 2] + "|" + tab[4, 3] + "|" + tab[4, 4] + "|");
        }

        char[,] tab = new char[5, 5] { { 'k', 'l', 'u', 'c', 'z' }, { 'a', 'b', 'd', 'e', 'f' }, { 'g', 'h', 'i', 'm', 'n' }, { 'o', 'p', 'q', 'r', 's' }, { 't', 'v', 'w', 'x', 'y' } };
        public char[,] getTab()
        {
            return tab;
        } 
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





    class Plain
    {
        int x1, x2, y1, y2;
        public char val1, val2;
        public void find(Playfair cipher)
        {
            char[,] tab = cipher.getTab();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (tab[i, j] == val1)
                    {
                        x1 = i;
                        y1 = j;
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (tab[i, j] == val2)
                    {
                        x2 = i;
                        y2 = j;
                    }
                }
            }

        } 
        public char getval1()
        {
            return val1;
        }
        public char getval2()
        {
            return val2;
        }
    }

    
    class Program
    {

        static string encrypt(String text, Playfair cipher)
        {
            ArrayList list = new ArrayList() ;
            list.Add(text[0]);
            for (int c = 1; c < text.Length; c++)
            {
                if(text[c] == text[c -1])
                {
                    list.Add('x');
                    list.Add(text[c - 1]);
                }
                else list.Add(text[c]);
            }

            String plaintext = string.Join("",list.ToArray());
            Plain plain = new Plain();
            ArrayList listPlains = new ArrayList();

            for (int c = 0;c<plaintext.Length; c++)
            {
                if (c % 2 == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (plaintext[c] == cipher.getTab()[i, j])
                            {
                                plain.val1 = plaintext[c];
                                if (plaintext[c + 1] == '\n')
                                    plain.val2 = 'x';
                                else
                                    plain.val2 = plaintext[c+1];
                                plain.find(cipher);
                                listPlains.Add(plain);

                            }
                        }
                    }
                }
            }
            String encryptedString = null;
           
            foreach (Plain p in listPlains)
            { 
                encryptedString = string.Join("", p.val1);
                encryptedString = string.Join("", p.val2);
            }



            return encryptedString;
        }





        static void Main(string[] args)
        {
            Playfair cipher = new Playfair();
            cipher.show();
            Console.WriteLine("\nPodaj napis do zaszyfrowania");
            string text = Console.ReadLine();

            Console.WriteLine(encrypt(text,cipher));

            Console.ReadKey();
        }
    }
}
