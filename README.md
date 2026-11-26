# Konzolos Weboldalszerkesztő
*Csoporttagok:* Kárpáti Liliána, Piri Nóra, Tóth Lili Napsugár

#  Weboldal készító alkalmazás

## **_Menü gombok:_**

A menüpontok kiválasztása a kívánt opció számának begépelésével és az enter lenyomásával történik.
> [!NOTE]
> A kilépő gomb a programban mindig jelezve van! 

## **_A program fájljai_**
- *Program.cs*: A program kódja.
- *osszesfajlnev.txt*: nyilvántartja a létrehozott HTML fájlok nevét.
- *beallitasok.txt*: tárolja az aktuálisan szerkesztett vagy használt fájl nevét.
- *cssbeallopciok.txt*: konfigurácios fájl a támogatott css tulajdonságokról.

## **_Lépések_**

>### Az első menü
>
> Szöveg leírása
>> Kér egy fájlnevet
>>
>> Ha a fájl még nem létezik, akkor elkészíti, különben addig kér új fájlnevet, ameddig egyedit nem ad meg a felhasználó.
>>
>>  Ezután a fájlt elkészíti, és a felhasználótól bekéri a szöveget bekezdésenként.
>>
>>Az utolsó bekezdés után a felhasználó egy üres bekezdést ad, és utána a program visszadob a menübe.
>
> Létező fájl módosítása
>
>>A második menüt jeleníti meg
>
> ### A második menü
>
> Add meg a fájl nevét
>
>> Bekér egy fájlnevet, ha nem létezik akkor visszadob a menübe
>
> Tekintsd meg a létező fájlneveket
>
>>Kiírja az összes létező fájl nevét, utána visszadob a menübe
>
> ### A harmadik menü
> HTML
>>A HTML menüponton belül 2 opció van:
>>
>>HTML-deklaráció hozzáadása
>>>
>>>A fájl elejére beilleszti a HTML-deklarációt miután a felhasználótól bekéri a lap címét.
>>>
>>Bekezdések létrehozása
>>>
>>>A beírt összes sort HTML-ben bekezdéssé formázza.
>>
>CSS

> [!NOTE]
> Ha nincs HTML-deklaráció vagy a bekezdés, akkor a program hibát jelez és visszadob a menübe.

>> Létező HTML-elem formázása
>>
>>>Létező HTML-elemet formáz, pl body, p.
>>
>>Új, saját osztály (class) létrehozása
>>>
>>>Saját osztályt hoz létre szövegrészlet formázására. Az osztály neve tetszőleges.
>
>### A negyedik menü
>
>Szöveg szín
>>
>>Bekér egy színt, és az adott szöveget beszínezi.
>>
>Szöveg méret
>>
>>Bekér egy méretet, és az adott szöveget átméretezi.
>>
>Háttérszín
>>
>>Bekér egy színt, és ahátteret beszínezi.
>>
>Egyéb
>>
>>A felhasználó bármilyen általa ismert beállítást beállithat.

> [!NOTE]
> Ha az előző menüben saját osztályt hoztunk létre, akkor a program megkér hogy kiválasszuk a bekezdést, amelyre be szeretnénk állítani a beállításokat.



## Hibakezelés
- Érvénytelen input: ha a user helytelen adatot ad meg, a program jelzi a hibár, majd újra bekéri az adatot (nem fog leállni a program)
- Fájl létezésének ellenőrzése: minden művelet előtt a program ellenőrzi, hogy a fájl létezik-e