# Wzorce odporności (Polly) 

1️. Wprowadzenie do problemu: dlaczego mikroserwisy potrzebują mechanizmów odporności (awarie, fluktuacje sieci, cold-starty).

2️. Omówienie wzorców Polly: Retry z jitterem, Circuit Breaker, Bulkhead, Timeout + Fallback.

3️. Konfiguracja `OrderService`: dodanie pakietu Polly, rejestracja `HttpClient` z politykami Retry i Circuit Breaker dla `FaultyService`.

4️. Implementacja wywołania do `FaultyService` w kontrolerze lub serwisie domenowym `OrderService`.

5️. Uruchomienie `FaultyService`, symulowanie błędów i obserwacja działania polityk.

6️. Rozszerzenie: dodanie BulkheadPolicy i TimeoutPolicy oraz omówienie ich wpływu na zachowanie serwisu.
