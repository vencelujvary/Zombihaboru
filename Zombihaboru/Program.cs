namespace Zombihaboru
{
    internal class Program
    {
        static Random r = new Random();

        static string[] NevekLetrehozasa(int db)
        {
            string[] nevekOsszes = {"Vencel", "Ádám", "Bence", "Csaba", "Dávid", "Erik", "Ferenc", "Gábor", "Hunor", "István", "János", "Károly", "Levente", "Márk", "Norbert", "Péter", "Richárd", "Sándor", "Tamás", "Viktor", "Zoltán", "Anna", "Barbara", "Csilla", "Dóra", "Eszter", "Fanni", "Hanna", "Kata", "Lilla", "Zsófia" };
            string[] nevek = new string[db];
            for (int i = 0; i < db; i++)
            {
               int index = r.Next(nevekOsszes.Length);
                nevek[i] = nevekOsszes[index];
            }
            return nevek;
        }
        static void kiir(string[] nevek) 
        {
            foreach (var item in nevek)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();

            
        }
        static void ZombikInvazioja(string[] lakossag, string[] zombik)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                int index = r.Next(lakossag.Length);
                Console.WriteLine(zombik[i] + " megtámadta " + lakossag[index]);
            }
        }
        private static int[] eleteroBeallitasa(int lakossagSzama)
        {
            int[] eleterok = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                eleterok[i] = 100;
            }
            return eleterok;
        }
        private int[] tamadoEroBeallita()
        {
            int[] tamadoEro = new int[5];
            for (int i = 0; i < tamadoEro.Length; i++)
            {
                tamadoEro[i] = r.Next(10, 25);
            }
            return tamadoEro;
        }
        static void KiirSzamok(int[]tomb)
        {
            foreach (var item in tomb)
            {
                Console.Write(item + " ");
            }
            
        }
        static bool VanEELakos(int[] eleterok)
        {
            foreach (var item in eleterok)
            {
                if (item > 0)
                    return true;
            }
            return false;
        }
        static void Jatek(int[] lakossagEletereje, int[] zombikTamadoEreje, string[] lakossag, string[] zombik)
        {
            int kor = 1;

            while (VanEELakos(lakossagEletereje) && VanEZombi(zombikTamadoEreje))
            {
                Console.WriteLine("\n" + kor + ". kör");

                for (int i = 0; i < zombik.Length; i++)
                {
                    if (zombikTamadoEreje[i] > 0 && VanEELakos(lakossagEletereje))
                    {
                        int index = r.Next(lakossag.Length);

                        while (lakossagEletereje[index] <= 0)
                        {
                            index = r.Next(lakossag.Length);
                        }

                        Console.WriteLine(zombik[i] + " megtámadta " + lakossag[index]);

                        lakossagEletereje[index] -= zombikTamadoEreje[i];

                        zombikTamadoEreje[i] -= r.Next(1, 6);

                        if (lakossagEletereje[index] <= 0)
                        {
                            Console.WriteLine(lakossag[index] + " meghalt!");
                        }

                        if (zombikTamadoEreje[i] <= 0)
                        {
                            zombikTamadoEreje[i] = 0;
                            Console.WriteLine(zombik[i] + " elvesztette a támadóerejét!");
                        }
                    }
                }

                Console.WriteLine("\nEmberek életereje:");
                KiirSzamok(lakossagEletereje);

                Console.WriteLine("Zombik támadóereje:");
                KiirSzamok(zombikTamadoEreje);

                kor++;
            }

            Console.WriteLine("\nJÁTÉK VÉGE!");

            if (VanEELakos(lakossagEletereje))
            {
                Console.WriteLine("Az emberek túlélték a zombiháborút!");
            }
            else
            {
                Console.WriteLine("A zombik legyőzték az embereket!");
            }
        }
        static void Main(string[] args)
        {
            int lakossagSzama = 10;
            int zombikSzama = 5;

            Console.WriteLine("Lakosság:");
            string[] lakossag = NevekLetrehozasa(lakossagSzama);

            Console.WriteLine("Zombik:");
            string[] zombik = NevekLetrehozasa(zombikSzama);

            kiir(lakossag);
            kiir(zombik);

            int[] lakossagEletereje = eleteroBeallitasa(lakossagSzama);
            int[] zombikTamadoEreje = tamadoEroBeallita();

            Console.Write("Lakosság életereje: ");
            KiirSzamok(lakossagEletereje);

            Console.Write("Zombik támadóereje: ");
            KiirSzamok(zombikTamadoEreje);

            Jatek(lakossagEletereje, zombikTamadoEreje, lakossag, zombik);


        }

    }
}
