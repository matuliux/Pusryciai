using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Matas_Lukšys_darbo_užduotis
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch laikmatis = new Stopwatch();
            int kiausiniu_kiekis, sonines_gabaliuku_kiekis;

            kiausiniu_kiekis = Kiausiniu_kiekio_nustymas();
            sonines_gabaliuku_kiekis = Sonines_kiekio_nustymas();

            laikmatis.Start();                                                      // Laiko matavimo pradzia

            Pasiruosimas pasiruosimas = Pasiruosimas_darbui();
            Kiausinis kiausinis = Kepimas(kiausiniu_kiekis);
            Sonine sonine = Kepimas(kiausiniu_kiekis, sonines_gabaliuku_kiekis);    // Pateikiame 2 kintamuosiu, siekiant suzinoti ar reikia sildyti keptuve
            Skrebutis skrebutis = Skrebucio_skrudinimas();
            
            
            //Klasems kiausinis, sonine, skrebutis sukuriau motinine klase Maistas ir joje aprasiau metoda Dejimas, nes visom trim klasem reikia atlikti ta pati veiksma
            //Dejimas parodo, kas dedama i lekste 
            
            kiausinis.Dejimas();
            sonine.Dejimas();
            skrebutis.Dejimas();

            Kava kava = Kavos_virimas();


            laikmatis.Stop();                                                       // Laiko matavimo pabaiga

            Console.WriteLine("Pusryciai paruosti!\nJu gaminimas uztruko {0} sekundes\n", ((double)laikmatis.ElapsedMilliseconds) / 1000.0);

            
        }

        public static int Kiausiniu_kiekio_nustymas()                   // Funkcija, suzinanti kiausiniu kieki
        {
            int kiausiniu_kiekis, temp; int patikrinimas = 0;
            string kiausiniu_kiekis_string = "";
            Console.WriteLine("Kiek kiausiniu kepsime?");

            while (patikrinimas == 0)                                   // Tikriname ar ivedimas yra skaicius, jei ne, parasome klaida ir prasome ivesti dar karta
            {
                kiausiniu_kiekis_string = Console.ReadLine();
                
                if (!int.TryParse(kiausiniu_kiekis_string, out temp))
                {
                    Console.WriteLine("Neiteisingas ivedimas, iveskite skaiciu");
                }
                else
                {
                    patikrinimas = 1;
                }
            }

            kiausiniu_kiekis = Int32.Parse(kiausiniu_kiekis_string);
            return kiausiniu_kiekis;

        }

        public static int Sonines_kiekio_nustymas()                         // Sonines kiekio nustatymas
        {
            int sonines_gabaliuku_kiekis, temp; int patikrinimas = 0;
            string sonines_gabaliuku_kiekis_string = "";
            Console.WriteLine("Kiek sonines gabaliuku kepsime?");

            while (patikrinimas == 0) {                                     // Tikriname ar ivedimas yra skaicius, jei ne, parasome klaida ir prasome ivesti dar karta

                sonines_gabaliuku_kiekis_string = Console.ReadLine();

                if (!int.TryParse(sonines_gabaliuku_kiekis_string, out temp))
                {
                    Console.WriteLine("Neiteisingas ivedimas, iveskite skaiciu");
                }
                else
                {
                    patikrinimas = 1;
                }
            }

            sonines_gabaliuku_kiekis = Int32.Parse(sonines_gabaliuku_kiekis_string);
            return sonines_gabaliuku_kiekis;

        }

        public static Pasiruosimas Pasiruosimas_darbui()            // Atspausdiname pasiruosimo zingsnius
        {
            Console.WriteLine("\nParuosiami indai");
            Thread.Sleep(500);
            Console.WriteLine("Nuplaunamos rankos\n");
            Thread.Sleep(500);

            return new Pasiruosimas();

        }

        public static Kiausinis Kepimas(int kiek)                   // Atspausdiname kiausiniu kepimo zingsnius
        {
            if (kiek > 0)                                           // Jeigu turime kiausiniu, sildome keptuve ir juos kepame
            {
                Console.WriteLine("I keptuve ipilamas ir sildomas aliejus\n");
                Thread.Sleep(500);

                for (int i = 0; i < kiek; i++)                      // Kepame visus kiausinius
                {
                    Console.WriteLine("Kepamas {0}-(as) kiausinis", i + 1);
                    Thread.Sleep(500);
                }
                Console.WriteLine("Kiausianiai paruosti!\n");
            }

            else                                                    // Jei kiausiniu neturime ju nekepame
            {
                Console.WriteLine("Kiausiniu nekepame, nes ju neturime\n");
            }

            return new Kiausinis();
        }

        public static Sonine Kepimas(int kiek_k, int kiek_s)        // Funkcijoje kiausiniu kieki vadinsime kiek_k, sonines kieki vadinsime kiek_s
                                                                    // Atspausdiname sonines kepimo zingsnius
        {
            if(kiek_k == 0 && kiek_s > 0)                           // Tikriname ar reikia sildyti alieju
            {
                Console.WriteLine("I keptuve ipilamas ir sildomas aliejus\n");
                Thread.Sleep(500);
            }

            if(kiek_s > 0)                                          // Jei turime sonines, ja kepsime
            {
                for (int i = 0; i < kiek_s; i++)                    // Kepame visa sonine
                {
                    Console.WriteLine("Kepamas {0}-(as) sonines gabaliukas", i + 1);
                    Thread.Sleep(500);
                }
                Console.WriteLine("Sonine paruosta!\n");

            }

            else if(kiek_s == 0)                                    // Jei sonines neturime, jos nekepame
            {
                Console.WriteLine("Sonines nekepame, nes jos neturime\n");
            }

            return new Sonine();
        }

        public static Skrebutis Skrebucio_skrudinimas()                     // Atspausdiname skrebucio skurdinima
        {
            Console.WriteLine("Idedame skrebuti i skrudintuve");
            Thread.Sleep(500);
            Console.WriteLine("Isimame skrebuti ir uztepame sviesta");
            Thread.Sleep(500); 
            Console.WriteLine("Skrebutis paruostas!\n");

            return new Skrebutis();
        }

        public static Kava Kavos_virimas()                                  // Atspausdiname kavos virima
        {
            Console.WriteLine("\nUzkaiciame vandeni");
            Thread.Sleep(500);
            Console.WriteLine("Uzpilame kava ir idedame cukraus");
            Thread.Sleep(500);
            Console.WriteLine("Kava paruosta!\n");



            return new Kava();
        }
    }
}
