string fajl = "adatok.txt";
string[] adatok = new string[100];

if (!File.Exists("osszesfajlnev.txt"))
{
    File.WriteAllText("osszesfajlnev.txt", "");
}
if (!File.Exists("beallitasok.txt"))
{
    File.WriteAllText("beallitasok.txt", "");
}

Dictionary<string, string> bent = new();

Console.WriteLine("1. gomb: szöveg leírása");
Console.WriteLine("2. gomb: létező fájl módostása");
Console.WriteLine("3. gomb: kilépés");
Console.WriteLine("Kérem adja meg hanyas gomb: ");
string gomb1 = Console.ReadLine();
if (gomb1 == "1")
{
    Console.WriteLine("Illeszd be a szöveget (jobb klikk=>paste): ");
    string szoveg=Console.ReadLine();
    Console.WriteLine("Adj meg egy fájlnevet (kiterjesztés nélkül): ");
    string fajlNev=Console.ReadLine();

    if (!File.Exists($"{fajlNev}.html")){
        File.WriteAllText($"{fajlNev}.html", "");
        File.AppendAllText($"osszesfajlnev.txt", $"{fajlNev}.html");
    }
    else
    {
        Console.WriteLine("Ez a fájl már létezik!");
    }
}
while (gomb1 == "2")
{
    
    Console.WriteLine("1. gomb: Add meg a fájl nevét");
    Console.WriteLine("2. gomb: Tekintsd meg a létező fájlneveket");
    Console.WriteLine("3. gomb: kilépés");
    Console.WriteLine("Kérem adja meg hanyas gomb: ");
    string gomb3=Console.ReadLine();
    if (gomb3 == "1")
    {
        string fajlNev=Console.ReadLine();
        if (!File.Exists(fajlNev) || !File.Exists($"{fajlNev}.html")){
            Console.WriteLine("Ilyen fájl nincs.");
        }
        else if (File.Exists(fajlNev))
        {
            string textBenneVan = File.ReadAllText(fajlNev);
        }
        else if (File.Exists(fajlNev))
        {
            string textBenneVan = File.ReadAllText($"{fajlNev}.html");
        }
    }
    if (gomb3 == "2") {
        Console.Write(File.ReadAllText("osszesfajlnev.txt"));
    }
}
while (true)
{
    Console.WriteLine("1. gomb: html");
    Console.WriteLine("2. gomb: css");
    Console.WriteLine("3. gomb: kilépés");
    Console.WriteLine("Kérem adja meg hanyas gomb: ");
    string gomb2 = Console.ReadLine();

}