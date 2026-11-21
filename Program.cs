//ékezetes betűk megoldása:
System.Text.Encoding.RegisterProvider(
    System.Text.CodePagesEncodingProvider.Instance
);

Console.InputEncoding = System.Text.Encoding.GetEncoding(1250);
Console.OutputEncoding = System.Text.Encoding.UTF8;

// adatok változó és az adatok.txt elkészítése
string fajl = "adatok.txt";
string[] adatok = new string[100];
// fájl létezés check
if (!File.Exists("osszesfajlnev.txt"))
{
    File.WriteAllText("osszesfajlnev.txt", "");
}
if (!File.Exists("beallitasok.txt"))
{
    File.WriteAllText("beallitasok.txt", "--------\nJelenleg használt fájl neve\n \n--------");
}
if (!File.Exists("cssbeallopciok.txt"))
{
    File.WriteAllText("cssbeallopciok.txt", "beállítás neve;beállítás parancs;paraméter1;paraméter2;paraméter3\nSzöveg mérete;font-size;méret\nSzöveg színe;color;szín\nHáttérszín;background-color;szín");
}
// dict létrehozás
Dictionary<string, string> bent = new();

// menü gombok
Console.WriteLine("1. gomb: szöveg leírása");
Console.WriteLine("2. gomb: létező fájl módosítása");
Console.WriteLine("3. gomb: kilépés");
Console.Write("Kérem adja meg hanyas gomb: ");
string gomb1 = Console.ReadLine();
//beallitasok.txt beolvasása
List<string> beallitasok = new();
var beallitasokSzoveg = File.ReadAllLines("beallitasok.txt");
foreach (string i in beallitasokSzoveg)
{
    beallitasok.Add(i);
    Console.WriteLine(i);
}
if (gomb1 == "1")
{
    while (true)
    {
        Console.WriteLine("Adj meg egy fájlnevet (kiterjesztés nélkül)\nKilépéshez hagyd üresen: ");
        string fajlNev = Console.ReadLine();
        // szöveg eltárolása
        if (fajlNev == "")
        {
            break;
        }
        if (!File.Exists($"{fajlNev}.html"))
        {
            File.WriteAllText($"{fajlNev}.html", "");
            File.AppendAllText($"osszesfajlnev.txt", $"{fajlNev}.html");
            Console.WriteLine(beallitasok.Count());
            beallitasok[2] = fajlNev;
            File.WriteAllText("beallitasok.txt", "");
            foreach (string i in beallitasok)
            {
                File.AppendAllText("beallitasok.txt", $"{i}\n");
            }
            break;
        }
        else
        {
            Console.WriteLine("Ez a fájl már létezik!");
        }
    }
    //kinyeri a jelenleg szerkesztett fájl nevét a beallitasok.txt-ből kinyert szövegből
    string fajlNevBeal1 = beallitasok[2];
    Console.WriteLine("Illeszd be a szöveget (jobb klikk=>paste) (az utolsó bekezdés után hagyj nyomj egy extra entert): ");
    while (true)
    {
        string szoveg = Console.ReadLine();
        if (szoveg == "")
        {
            break;
        }
        Console.WriteLine(szoveg);
        File.AppendAllText($"{fajlNevBeal1}.html", $"{szoveg}\n");
    }
}

while (gomb1 == "2" && true)
{
    Console.WriteLine("1. gomb: Add meg a fájl nevét");
    Console.WriteLine("2. gomb: Tekintsd meg a létező fájlneveket");
    Console.WriteLine("3. gomb: Kilépés");
    Console.Write("Kérem adja meg hanyas gomb: ");
    string gomb3 = Console.ReadLine();
    if (gomb3 == "1")
    {
        // fájlnév alapján keresés
        Console.Write("Fájl neve: ");
        string fajlNev = Console.ReadLine();
        // nincs meg a fájl
        if (!File.Exists(fajlNev) || !File.Exists($"{fajlNev}.html"))
        {
            Console.WriteLine("Ilyen fájl nincs. Az összes létező fájl kiírásához válaszd a 2. gombot.");
        }
        // megvan a fájl
        else if (File.Exists(fajlNev))
        {
            string textBenneVan = File.ReadAllText(fajlNev);
            break;
        }
        else if (File.Exists($"{fajlNev}.html"))
        {
            string textBenneVan = File.ReadAllText($"{fajlNev}.html");
            break;
        }
    }
    if (gomb3 == "2")
    {
        Console.Write(File.ReadAllText("osszesfajlnev.txt"));
        break;
    }
    if (gomb3 == "3")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid gomb");
    }
}
//cssbeallitasopciok beolvasasa
List<string> cssbeallitasopciok = new();
var cssbeallitasopciokSzoveg = File.ReadAllLines("beallitasok.txt");
foreach (string i in cssbeallitasopciokSzoveg)
{
    cssbeallitasopciok.Append(i);
}
//kinyeri a jelenleg szerkesztett fájl nevét a beallitasok.txt-ből kinyert szövegből
string fajlNevBeal = beallitasok[2];
// kiterjesztés kiválasztás
while (true)
{
    Console.WriteLine("1. gomb: html");
    Console.WriteLine("2. gomb: css");
    Console.WriteLine("3. gomb: kilépés");
    Console.Write("Kérem adja meg hanyas gomb: ");
    string gomb2 = Console.ReadLine();
    if (gomb2 == "1")
    {
        Console.WriteLine("1. gomb: HTML-deklaráció hozzáadása");
        Console.WriteLine("2. gomb: Bekezdések létrehozása (<p>, </p>)");
        Console.WriteLine("3. gomb: kilépés");
        Console.Write("Kérem adja meg hanyas gomb: ");
        string gomb4 = Console.ReadLine();
    }
    if (gomb2 == "2")
    {
        if (!File.Exists($"{fajlNevBeal}.css"))
        {
            File.WriteAllText($"{fajlNevBeal}.css", "");
        }
        Console.WriteLine("1. gomb: Létező HTML elem formázása");
        Console.WriteLine("2. gomb: Új, saját osztály (class) létrehozása");
        Console.WriteLine("3. gomb: kilépés");
        Console.Write("Kérem adja meg hanyas gomb: ");
        string gomb5 = Console.ReadLine();
        if (gomb5 == "1")
        {
            Console.WriteLine("HTML elemek: body (A teljes oldal), p (Bekezdések)");
            string cssBealNev = Console.ReadLine();
            Console.WriteLine("Milyen beállítást szeretnél megadni?");
            foreach (string i in cssbeallitasopciok)
            {
                string[] sor = i.Split(';');
                Console.Write(sor[0]);
            }
        }
    }
}

//dw bro