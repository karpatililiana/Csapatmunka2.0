using System;

class main()
{
    void rendszer()
    {
        fo();
    }
    void fo()
    {
        string fajl = "adatok.txt";
        string[] adatok = new string[100];

        Dictionary<string, string> bent = new();

        while(true)
        {
            Console.Write("1. gomb: szöveg leírása");
            Console.Write("2. gomb: html");
            Console.Write("3. gomb: css");
            Console.Write("4. gomb: kilépés");
            Console.WriteLine("Kérem adja meg hanyas gomb: ");
            string gomb = Console.ReadLine();

            if (gomb == "1")
            {

            }
        }
    }
}