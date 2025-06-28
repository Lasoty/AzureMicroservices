#  Strangler Fig pattern

**Strangler Fig to sposób na bezpieczne odcinanie kawałków monolitu.**
  Nazwa pochodzi od drzewa‐dusiciela, które oplata stare drzewo i stopniowo przejmuje jego miejsce. W architekturze robimy podobnie: najpierw otulamy monolit warstwą proxy, a potem systematycznie przenosimy kolejne funkcje do nowych mikroserwisów.

* **Krok pierwszy – wstawiamy bramę (proxy lub API Gateway).**
  Cały ruch klienta trafia najpierw do bramy, która decyduje, czy żądanie obsłuży stary monolit, czy już nowy serwis. Dzięki temu użytkownicy niczego nie zauważają, a my mamy jedno miejsce sterowania ruchem.

* **Krok drugi – wybieramy mały, samodzielny fragment domeny.**
  Zamiast przepisywać wszystko naraz, bierzemy coś prostego, np. moduł katalogu produktów. Tworzymy mikroserwis *Products*, kopiujemy logikę i dane, podpinamy własną bazę.

* **Krok trzeci – przekierowujemy tylko ten jeden endpoint.**
  W bramie mówimy: „/api/products → nowy serwis”. Reszta żądań dalej leci do monolitu. System działa, a my mamy pierwszy kawałek „na wolności”.

* **Krok czwarty – obserwujemy metryki.**
  Sprawdzamy: czas odpowiedzi, błędy, koszty. Jeśli wszystko wygląda dobrze, wybieramy kolejny moduł i powtarzamy proces. Stopniowo dusimy monolit, aż zostaje sam pusty pień, który w końcu usuwamy.