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

        char[,] tab = new char[5, 5] { { 'k', 'l', 'u', 'c', 'z' }, 
                                       { 'a', 'b', 'd', 'e', 'f' }, 
                                       { 'g', 'h', 'i', 'm', 'n' }, 
                                       { 'o', 'p', 'q', 'r', 's' }, 
                                       { 't', 'v', 'w', 'x', 'y' } };
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

        class Plain
        {
            private int x1, y1, x2, y2;
            private char val1, val2;
            public int getx1() { return x1; }
            public int getx2() { return x2; }
            public int gety1() { return y1; }
            public int gety2() { return y2; }

            public void setx1(int l) { x1 = l; }
            public void setx2(int l) { x2 = l; }
            public void sety1(int l) { y1 = l; }
            public void sety2(int l) { y2 = l; }

       

            public char getval1()
            {
                return val1;
            }
            public char getval2()
            {
                return val2;
            }
            public void setval1(char val)
            {
                val1 = val;
            }
            public void setval2(char val)
            {
                val2 = val;
            }
            public void findCoordinates(Playfair cipher)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cipher.tab[j,i] == val1)
                        {
                            x1 = j;
                            y1 = i;
                        }   
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cipher.tab[j, i] == val2)
                        {
                            x2 = j;
                            y2 = i;
                        }
                    }
                }

                Console.WriteLine("|"+val1 + '(' + y1 + ')' + '(' + x1 + ") "+ val2 + '(' + y2 + ')' + '(' + x2 + ')');
            }

            public void findCipherLetters(Playfair cipher)
            {
                val1 = cipher.getTab()[x1, y1];
                val2 = cipher.getTab()[x2, y2];
                Console.WriteLine("Koordynaty zaszyfrowanego tekstu: ");
                Console.WriteLine("|" + val1 + '(' + y1 + ')' + '(' + x1 + ") " + val2 + '(' + y2 + ')' + '(' + x2 + ')'+'\n');

            }
       

        }


        class Program
        {

            static string encrypt(String text, Playfair cipher)
            {
                text =text.ToLower();
                ArrayList list = new ArrayList();
                if (text[0] == 'j')
                {
                    list.Add('i');
                }
                else
                {
                    list.Add(text[0]);
                }

                    for (int c = 1; c < text.Length; c++)
                {
                    
                    
                    if (text[c] == ' ' || text[c] == ',' || text[c] == '.' || text[c] == '?' || text[c] == '!' || text[c] == ':' || text[c] == ';' || text[c] == '*' || text[c] == '(' || text[c] == ')' || text[c] == '"' || text[c] == '\n') { }
                    
                    else if (text[c] == 'j')
                    {
                        list.Add('i');
                    }
                    else
                    {
                        list.Add(text[c]);
                    }
                }

                for (int c = 1; c < list.Count; c++)
                {
                    if (list[c-1].ToString() == list[c].ToString())
                    {
                        list.Insert(c,'x');
                    }
                }
                    if ((list.Count-1) % 2 == 0 )
                {
                    list.Add('x');
                }


                String plaintext = string.Join("", list.ToArray());
                Console.WriteLine("Plaintext: " + plaintext);

                List<Plain> listPlains = new List<Plain>();
                for (int c = 1; c < plaintext.Length; c++)
                {
                    if (c % 2 == 1 )
                    {
                        Plain plain = new Plain();
                        
                        plain.setval1(plaintext[c-1]);
                        plain.setval2(plaintext[c]);
                        
                        listPlains.Add(plain);
                    }
                }

                List<Plain> listEncrypted = new List<Plain>();
                foreach (Plain p in listPlains)
                {
                    p.findCoordinates(cipher);
                    if (p.getx1() == p.getx2())  //ten sam wiersz
                    {
                        if (p.gety1() == 4)
                        {
                            p.sety2(p.gety2() + 1);
                            p.sety1(0);
                        }
                        else if (p.gety2() == 4)
                        {
                            p.sety2(0);
                            p.sety1(p.gety2() + 1);   
                        }
                        else
                        {
                            p.sety1(p.gety1() + 1);
                            p.sety2(p.gety2() + 1);
                        }
                    }
                    else if (p.gety1() == p.gety2())  //ta sama kolumna
                    {
                        if (p.getx2() == 4)
                        {
                            p.setx2(0);
                            p.setx1(p.getx1() + 1);
                        }
                        else if(p.getx1() == 4)
                        {
                            p.setx2(p.getx2() + 1);
                            p.setx1(0);
                            
                        }
                        else
                        {
                            p.setx1(p.getx1() + 1);
                            p.setx2(p.getx2() + 1);
                        }

                    }
                    else                                    ///reszta
                    {
                        int buf = p.gety1();
                        p.sety1 ( p.gety2());
                        p.sety2 ( buf);

                    }

                    p.findCipherLetters(cipher);

                    listEncrypted.Add(p);
                }

                String encryptedString =null;

                foreach (Plain p in listEncrypted)
                { 
                    encryptedString = encryptedString + string.Join("", p.getval1().ToString()) + string.Join("", p.getval2().ToString());
                }
                return encryptedString;
            }

            static string decrypt(String encryptedString, Playfair cipher)
            {
                encryptedString = encryptedString.ToLower();
                string decryptedString=null;

                List<Plain> listPlains = new List<Plain>();
                for (int c = 1; c < encryptedString.Length; c++)
                {
                    if (c % 2 == 1)
                    {
                        Plain plain = new Plain();

                        plain.setval1(encryptedString[c - 1]);
                        plain.setval2(encryptedString[c]);

                        listPlains.Add(plain);
                    }
                }



                List<Plain> listDecrypted = new List<Plain>();
                foreach (Plain p in listPlains)
                {
                    p.findCoordinates(cipher);
                        if (p.getx1() == p.getx2())  //ten sam wiersz
                        {
                            if (p.gety1() == 0)
                            {
                                p.sety2(p.gety2() -1);
                                p.sety1(4);
                            }
                            else if (p.gety2() == 0)
                            {
                                p.sety2(4);
                                p.sety1(p.gety2() -1);
                            }
                            else
                            {
                                p.sety1(p.gety1() -1);
                                p.sety2(p.gety2() - 1);
                            }
                        }
                        else if (p.gety1() == p.gety2())  //ta sama kolumna
                        {
                            if (p.getx2() == 0)
                            {
                                p.setx2(4);
                                p.setx1(p.getx1() - 1);
                            }
                            else if (p.getx1() == 0)
                            {
                                p.setx2(p.getx2() - 1);
                                p.setx1(4);

                            }
                            else
                            {
                                p.setx1(p.getx1() - 1);
                                p.setx2(p.getx2() - 1);
                            }

                        }
                        else                                    ///reszta
                        {
                            int buf = p.gety1();
                            p.sety1(p.gety2());
                            p.sety2(buf);
                        }

                        p.findCipherLetters(cipher);

                        listDecrypted.Add(p);   
                }
                foreach(Plain p in listDecrypted)
                {
                    decryptedString = decryptedString + string.Join("", p.getval1().ToString()) + string.Join("", p.getval2().ToString());
                }
                for(int c = 1; c<decryptedString.Length;c++)
                {
                    if (c > 0 && c < decryptedString.Length)
                    {
                        if (decryptedString[c] == 'x' && decryptedString[c - 1] == decryptedString[c + 1])
                        {
                            decryptedString = decryptedString.Replace("x","");
                        }

                    }
                }


                return decryptedString;
            }



            static void Main(string[] args)
            {
                Playfair cipher = new Playfair();
                cipher.show();
                Console.WriteLine("\nPodaj napis do zaszyfrowania");
                //string text = Console.ReadLine();
                string encryptedText = encrypt("as. sa", cipher);
                string decryptedText = decrypt(encryptedText, cipher);
                Console.WriteLine(encryptedText + "\n-----------------------------------------");
                Console.WriteLine(decryptedText + "\n-----------------------------------------");
                encryptedText = encrypt("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.", cipher);
                decryptedText = decrypt(encryptedText, cipher);
                Console.WriteLine(encryptedText + "\n-----------------------------------------");
                Console.WriteLine(decryptedText + "\n-----------------------------------------");
                encryptedText = encrypt("asxsesx", cipher);
                decryptedText = decrypt(encryptedText, cipher);
                Console.WriteLine(encryptedText + "\n-----------------------------------------");
                Console.WriteLine(decryptedText + "\n-----------------------------------------");
                encryptedText = encrypt("asxsess", cipher);
                decryptedText = decrypt(encryptedText, cipher);
                // Console.WriteLine(encrypt("assess", cipher)+"\n-----------------------------------------");
                Console.WriteLine(encryptedText + "\n-----------------------------------------");
                Console.WriteLine(decryptedText + "\n-----------------------------------------");
                //Console.WriteLine(encrypt("asses", cipher) + "\n-----------------------------------------");
                //Console.WriteLine(encrypt("nie pytaj mnie o nia znasz ja doskonale budzisz sie codziennie ona robi ci sniadanie", cipher));


                Console.ReadKey();
            }
        }
    }
}
