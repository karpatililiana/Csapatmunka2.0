//ékezetes betűk megoldása:
using System.Text.Unicode;

System.Text.Encoding.RegisterProvider(
    System.Text.CodePagesEncodingProvider.Instance
);

Console.InputEncoding = System.Text.Encoding.GetEncoding(1250);
Console.OutputEncoding = System.Text.Encoding.UTF8;

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

// menü
while (true)
{
    // beallitasok.txt beolvasása
    List<string> beallitasok = new();
    string[] beallitasokSzoveg = File.ReadAllLines("beallitasok.txt");
    foreach (string i in beallitasokSzoveg)
    {
        beallitasok.Add(i);
        Console.WriteLine(i);
    }
    while (beallitasok.Count < 3)
    {
        beallitasok.Add("");
    }

    // menü gombok
    Console.WriteLine("========================================");
    Console.WriteLine("       WEBOLDAL KÉSZÍTŐ");
    Console.WriteLine("========================================");
    Console.WriteLine(" [1] Új weboldal készítése");
    Console.WriteLine(" [2] Meglévő fájl módosítása");
    Console.WriteLine(" [3] Kilépés");
    Console.WriteLine("----------------------------------------");
    Console.Write("Kérem adja meg hanyas gomb: ");
    string gomb1 = Console.ReadLine();

    if (gomb1 == "1")
    {
        string fajlNev = "";
        while (true)
        {
            Console.WriteLine("Adj meg egy fájlnevet (kiterjesztés nélkül)\nKilépéshez hagyd üresen: ");
            fajlNev = Console.ReadLine();
            if (fajlNev == "")
            {
                break;
            }
            if (!File.Exists($"{fajlNev}.html"))
            {
                File.WriteAllText($"{fajlNev}.html", "");
                File.AppendAllText("osszesfajlnev.txt", $"{fajlNev}.html\n");
                beallitasok[2] = fajlNev;
                File.WriteAllLines("beallitasok.txt", beallitasok);
                break;
            }
            else
            {
                Console.WriteLine("Ez a fájl már létezik!");
            }
        }
        // üres fájlnév
        if (fajlNev == "")
        {
            continue;
        }

        Console.WriteLine("Illeszd be a szöveget (jobb klikk=>paste) (az utolsó bekezdés után nyomj egy extra entert): ");
        List<string> beirtSorok = new();
        while (true)
        {
            string szoveg1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(szoveg1))
            {
                break;
            }
            beirtSorok.Add(szoveg1);
        }
        File.WriteAllLines($"{fajlNev}.html", beirtSorok);
        Console.WriteLine("A szöveg elmentve!");
    }
    // létező fájl módosítása
    else if (gomb1 == "2")
    {
        // fájlválasztó menü
        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" [1] Add meg a fájl nevét");
            Console.WriteLine(" [2] Tekintsd meg a létező fájlneveket");
            Console.WriteLine(" [3] Kilépés");
            Console.WriteLine("----------------------------------------");
            Console.Write("Kérem adja meg hanyas gomb: ");
            string gomb3 = Console.ReadLine();
            if (gomb3 == "1")
            {
                Console.Write("Fájl neve: ");
                string fajlNev2 = Console.ReadLine();
                if (fajlNev2.EndsWith(".html"))
                {
                    fajlNev2 = fajlNev2.Substring(0, fajlNev2.Length - 5);
                }

                if (!File.Exists($"{fajlNev2}.html"))
                {
                    Console.WriteLine("Ilyen fájl nincs. Az összes létező fájl kiírásához válaszd a 2. gombot.");
                }
                else
                {
                    // ez lesz a jelenleg használt fájl
                    beallitasok[2] = fajlNev2;
                    File.WriteAllLines("beallitasok.txt", beallitasok);
                    string htmlFajl = $"{fajlNev2}.html";

                    // SZERKESZTŐ MENÜ (html / css)
                    while (true)
                    {
                        Console.WriteLine("========================================");
                        Console.WriteLine(" [1] html");
                        Console.WriteLine(" [2] css");
                        Console.WriteLine(" [3] Kilépés");
                        Console.WriteLine("----------------------------------------");
                        Console.Write("Kérem adja meg hanyas gomb: ");
                        string gomb2 = Console.ReadLine();

                        // HTML MENÜ
                        if (gomb2 == "1")
                        {
                            while (true)
                            {
                                Console.WriteLine("========================================");
                                Console.WriteLine(" [1] HTML-deklaráció hozzáadása");
                                Console.WriteLine(" [2] Bekezdések létrehozása (<p>, </p>)");
                                Console.WriteLine(" [3] Kilépés");
                                Console.WriteLine("----------------------------------------");
                                Console.Write("Kérem adja meg hanyas gomb: ");
                                string gomb4 = Console.ReadLine();

                                if (gomb4 == "1")
                                {
                                    string tartalom = File.ReadAllText(htmlFajl);
                                    if (tartalom.Contains("<!DOCTYPE html>"))
                                    {
                                        Console.WriteLine("A HTML-deklaráció már létezik!");
                                    }
                                    else
                                    {
                                        Console.Write("Add meg az oldal címét: ");
                                        string oldalCim = Console.ReadLine();
                                        tartalom = tartalom.TrimEnd();
                                        if (tartalom != "")
                                        {
                                            tartalom += "\n";
                                        }
                                        File.WriteAllText(htmlFajl, $"<!DOCTYPE html>\n<html lang=\"hu\">\n<head>\n    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <link rel=\"stylesheet\" href=\"{fajlNev2}.css\">\n    <title>{oldalCim}</title>\n</head>\n<body>\n{tartalom}</body>\n</html>\n");
                                        Console.WriteLine("A HTML-deklaráció elkészült!");
                                    }
                                }
                                else if (gomb4 == "2")
                                {
                                    string htmlSzoveg = File.ReadAllText(htmlFajl);
                                    if (htmlSzoveg.Contains("<p>"))
                                    {
                                        Console.WriteLine("A bekezdések már léteznek!");
                                    }
                                    else
                                    {
                                        // ha van <body>, csak az azon belüli részt alakítjuk át, különben az egész fájlt
                                        string torzs = htmlSzoveg;
                                        int kezdet = 0;
                                        int veg = htmlSzoveg.Length;
                                        if (htmlSzoveg.Contains("<body>") && htmlSzoveg.Contains("</body>"))
                                        {
                                            kezdet = htmlSzoveg.IndexOf("<body>") + 6;
                                            veg = htmlSzoveg.IndexOf("</body>");
                                            torzs = htmlSzoveg.Substring(kezdet, veg - kezdet);
                                        }

                                        string ujTorzs = "";
                                        foreach (string s in torzs.Split('\n'))
                                        {
                                            if (!string.IsNullOrWhiteSpace(s))
                                            {
                                                ujTorzs += $"<p>{s.Trim()}</p>\n";
                                            }
                                        }

                                        if (ujTorzs == "")
                                        {
                                            Console.WriteLine("Nincs szöveg a fájlban, amiből bekezdés készülhetne!");
                                        }
                                        else
                                        {
                                            string elejeSzoveg = htmlSzoveg.Substring(0, kezdet);
                                            if (kezdet > 0)
                                            {
                                                elejeSzoveg += "\n";
                                            }
                                            File.WriteAllText(htmlFajl, elejeSzoveg + ujTorzs + htmlSzoveg.Substring(veg));
                                            Console.WriteLine("A bekezdések elkészültek!");
                                        }
                                    }
                                }
                                else if (gomb4 == "3")
                                {
                                    break; // vissza a html/css menübe
                                }
                                else
                                {
                                    Console.WriteLine("Invalid gomb");
                                }
                            }
                        }
                        // css menü
                        else if (gomb2 == "2")
                        {
                            string aktualis = File.ReadAllText(htmlFajl);
                            if (!aktualis.Contains("<!DOCTYPE html>"))
                            {
                                Console.WriteLine("Előbb hozz létre HTML-deklarációt! (html => 1. gomb)");
                            }
                            else if (!aktualis.Contains("<p>"))
                            {
                                Console.WriteLine("Előbb hozz létre bekezdéseket! (html => 2. gomb)");
                            }
                            else
                            {
                                if (!File.Exists($"{fajlNev2}.css"))
                                {
                                    File.WriteAllText($"{fajlNev2}.css", "");
                                }

                                while (true)
                                {
                                    Console.WriteLine("========================================");
                                    Console.WriteLine(" [1] Létező HTML elem formázása");
                                    Console.WriteLine(" [2] Új, saját osztály (class) létrehozása)");
                                    Console.WriteLine(" [3] Kilépés");
                                    Console.WriteLine("----------------------------------------");
                                    Console.Write("Kérem adja meg hanyas gomb: ");
                                    string gomb5 = Console.ReadLine();

                                    if (gomb5 == "1" || gomb5 == "2")
                                    {
                                        string selector = "";
                                        string osztalyNev = "";
                                        if (gomb5 == "1")
                                        {
                                            Console.WriteLine("HTML elemek: body (A teljes oldal), p (Bekezdések)");
                                            Console.Write("Melyik elemet szeretnéd formázni? ");
                                            selector = Console.ReadLine().Trim();
                                        }
                                        else
                                        {
                                            Console.Write("Az osztály neve (pl. kiemelt): ");
                                            osztalyNev = Console.ReadLine().Trim();
                                            if (osztalyNev != "")
                                            {
                                                selector = "." + osztalyNev;
                                            }
                                        }
                                        if (selector == "")
                                        {
                                            Console.WriteLine("Nem adtál meg nevet!");
                                            continue;
                                        }

                                        // cssbeallopciok.txt
                                        List<string> cssbeallitasopciok = new();
                                        string[] cssSorok = File.ReadAllLines("cssbeallopciok.txt");
                                        for (int k = 1; k < cssSorok.Length; k++)
                                        {
                                            if (cssSorok[k].Trim() != "")
                                            {
                                                cssbeallitasopciok.Add(cssSorok[k]);
                                            }
                                        }

                                        // beállítások megadása
                                        while (true)
                                        {
                                            Console.WriteLine("Milyen beállítást szeretnél megadni?");
                                            for (int k = 0; k < cssbeallitasopciok.Count; k++)
                                            {
                                                string[] sor = cssbeallitasopciok[k].Split(';');
                                                Console.WriteLine($"{k + 1}. gomb: {sor[0]}");
                                            }
                                            Console.WriteLine($"{cssbeallitasopciok.Count + 1}. gomb: Egyéb (saját CSS tulajdonság megadása)");
                                            Console.WriteLine("0. gomb: kész");
                                            Console.Write("Kérem adja meg hanyas gomb: ");
                                            string valasztas = Console.ReadLine();

                                            if (valasztas == "0")
                                            {
                                                break;
                                            }

                                            string tulajdonsag = "";
                                            string tipp = "érték";

                                            if (valasztas == (cssbeallitasopciok.Count + 1).ToString())
                                            {
                                                // egyéb
                                                Console.Write("Add meg a CSS tulajdonság nevét (pl. text-align): ");
                                                tulajdonsag = Console.ReadLine().Trim();
                                                if (tulajdonsag == "")
                                                {
                                                    Console.WriteLine("Nem adtál meg tulajdonságot!");
                                                    continue;
                                                }
                                            }
                                            else if (int.TryParse(valasztas, out int szam) && szam >= 1 && szam <= cssbeallitasopciok.Count)
                                            {
                                                // a fájlban szereplő beállítások
                                                string[] sor = cssbeallitasopciok[szam - 1].Split(';');
                                                tulajdonsag = sor[1];
                                                if (sor.Length > 2)
                                                {
                                                    tipp = sor[2];
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid gomb");
                                                continue;
                                            }

                                            Console.Write($"Add meg az értéket ({tipp}): ");
                                            string ertek = Console.ReadLine().Trim();
                                            if (ertek == "")
                                            {
                                                Console.WriteLine("Nem adtál meg értéket!");
                                                continue;
                                            }
                                            if (ertek.ToLower() == "piros") ertek = "red";
                                            if (ertek.ToLower() == "kék") ertek = "blue";
                                            if (ertek.ToLower() == "zöld") ertek = "green";
                                            if (ertek.ToLower() == "sárga") ertek = "yellow";
                                            if (ertek.ToLower() == "fekete") ertek = "black";
                                            if (ertek.ToLower() == "fehér") ertek = "white";

                                            if (tulajdonsag == "font-size" && int.TryParse(ertek, out _))
                                            {
                                                ertek += "px";
                                            }

                                            File.AppendAllText($"{fajlNev2}.css", $"{selector} {{ {tulajdonsag}: {ertek}; }}\n");
                                            Console.WriteLine("A beállítás elmentve!");
                                        }

                                        // saját osztály
                                        if (gomb5 == "2")
                                        {
                                            string[] htmlSorok = File.ReadAllLines(htmlFajl);
                                            int db = 0;
                                            for (int k = 0; k < htmlSorok.Length; k++)
                                            {
                                                if (htmlSorok[k].StartsWith("<p>"))
                                                {
                                                    db++;
                                                    Console.WriteLine($"{db}. {htmlSorok[k]}");
                                                }
                                            }

                                            if (db == 0)
                                            {
                                                Console.WriteLine("Nincs olyan bekezdés, amihez hozzá lehetne rendelni az osztályt.");
                                            }
                                            else
                                            {
                                                Console.Write("Melyik bekezdéshez rendeljük hozzá? (sorszám, 'mind' az összeshez, üresen hagyod: egyikhez sem): ");
                                                string kivalasztott = Console.ReadLine().Trim().ToLower();
                                                if (kivalasztott != "")
                                                {
                                                    int sz = 0;
                                                    bool talalt = false;
                                                    for (int k = 0; k < htmlSorok.Length; k++)
                                                    {
                                                        if (htmlSorok[k].StartsWith("<p>"))
                                                        {
                                                            sz++;
                                                            if (kivalasztott == "mind" || kivalasztott == sz.ToString())
                                                            {
                                                                htmlSorok[k] = $"<p class=\"{osztalyNev}\">" + htmlSorok[k].Substring(3);
                                                                talalt = true;
                                                            }
                                                        }
                                                    }
                                                    if (talalt)
                                                    {
                                                        File.WriteAllLines(htmlFajl, htmlSorok);
                                                        Console.WriteLine("Az osztály hozzárendelve!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ilyen sorszámú bekezdés nincs.");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (gomb5 == "3")
                                    {
                                        break; // vissza a html/css menübe
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid gomb");
                                    }
                                }
                            }
                        }
                        else if (gomb2 == "3")
                        {
                            break; // vissza a fájlválasztó menübe
                        }
                        else
                        {
                            Console.WriteLine("Invalid gomb");
                        }
                    }
                }
            }
            else if (gomb3 == "2")
            {
                string[] osszesFajlnevFile = File.ReadAllLines("osszesfajlnev.txt");
                foreach (string s in osszesFajlnevFile)
                {
                    if (s.Trim() != "")
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            else if (gomb3 == "3")
            {
                break; // vissza a főmenübe
            }
            else
            {
                Console.WriteLine("Invalid gomb");
            }
        }
    }
    else if (gomb1 == "3")
    {
        break; // kilépés a programból
    }
    else
    {
        Console.WriteLine("Invalid gomb");
    }
}
