# Dockerfile

### Treœæ zadania dla uczestników szkolenia

Twoim zadaniem jest przygotowanie zoptymalizowanego i bezpiecznego Dockerfile dla mikroserwisu .NET **Lab.Debo.Products** w solucji **Lab.Debo**. Zadanie obejmuje:

1. Utworzenie endpointu `/healthz` w kontrolerze, który zwraca 200 OK.
2. Stworzenie Dockerfile wykorzystuj¹cego multi-stage build (etap build z SDK i etap runtime z ASP.NET).
3. Optymalizacjê publikacji przy pomocy flag `PublishTrimmed` i `PublishReadyToRun`, zmniejszaj¹c rozmiar finalnego obrazu.
4. Dodanie u¿ytkownika nie-rootowego i konfiguracjê polecenia HEALTHCHECK do sprawdzania `/healthz`.

Na koniec uczestnicy uruchamiaj¹ kontener lokalnie i weryfikuj¹ dzia³anie aplikacji.
