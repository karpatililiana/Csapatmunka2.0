# Konzolos Weboldalszerkesztő
*Csoporttagok:* Kárpáti Liliána, Piri Nóra, Tóth Lili Napsugár

#  Weboldal készító alkalmazás

## **_Menü gombok:_**

- 1.gomb: Szöveg leírása
- 2.gomb: Létező fájl módosítása
- 3.gomb: Kilépés

> [!NOTE]
> A kilépő gomb mindig jelezve van! 

## **_A program fájljai_**
- *Program.cs*: A program kódja
- *osszesfajlnev.txt*: nyilvántartja a létrehozott HTML fájlok nevét
- *beallitasok.txt*: tárolja az aktuálisan szerkesztett vagy használt fájl nevét
- *cssbeallopciok.txt*: konfigurácios fájl a támogatott css tulajdonságokról

## **_Lépések_**

### Az első menü

- szöveg leírása
> Kér egy fájlnevet
> Ha a fájl még nem létezik, akkor elkészíti, különben addig kér új fájlnevet, ameddig egyedit nem ad meg a felhasználó
> Ezután a fájlt elkészíti, és a felhasználótól bekéri a szöveget bekezdésenként
- létező fájl módosítása

> ### A második menü
>
>További menüt nyit meg:
>- Add meg a fájl nevét
>> Bekér egy fájlnevet, ha nem létezik akkor visszadob a menübe
>- Tekintsd meg a létező fájlneveket
>>Kiírja az össze slétező fájl nevét
>

###


## **_Lépések:_**
### 1.gomb: fájl létrehozása, szöveges leírás
1. Bekér egy szöveget
2. Felsorolja a lehetőségeket
3. Meg lehet adni a html és css beállításokat

### 2.gomb: létező fájl módosítása
- Ha az első gombot választja akkor a megadott fájlnévv .html és *beallitasok.txt* fájlokba menti
- 2.gomb kiad három opciót: fájl név megadása, meg lehet tekinteni a létező fájl neveit, kilépés
   - Az 1-es opció elmenti a megadott fájlnév .html néven
   - Az 2-es megnyitja az *osszesfajlnev.txt* nevű szöveges fájl

### Részletek (html, css) 
- Css beállítás opciók a *beallitas.txt* fájlba található
- 3 opció van html és css beállítások meg a kilépés
- Az egyes opció ami html néven van ki ad 3 gombot
   - Az egyes gomb html deklarációt hozzáad
   - Kettes bekezdéseket hoz létre a szövegre (p)
- A kettes, css opció  szintúgy 3 gombot ad ki
   - Elöszőr megnézi, hogy létezik e a .css fájl, ha igen abba fog írni
   - Egyes gomb a létező .html fájl elemét formázza
   - Kettes új, saját osztályt (class) hoz létre
- Ha helytelen adatot ad meg akkor újra bekéri az adott adatot
- Mindig ellenőrzi hogy létezik e az adott fájl

## Hibakezelés
- Érvénytelen input: ha a user helytelen adatot ad meg, a program jelzi a hibár, majd újra bekéri az adatot (nem fog leállni a program)
- Fájl létezésének ellenőrzése: minden művelet előtt a program ellenőrzi, hogy a fájl létezik-e