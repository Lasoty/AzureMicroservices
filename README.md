# Event-driven integration z Azure Service Bus Topics

Zbudujemy integracjê event-driven z u¿yciem Azure Service Bus Topic. OrderService opublikuje zdarzenie OrderCreated do topika, a MailNotificationService zasubskrybuje to zdarzenie przez w³asn¹ subskrypcjê.

Kroki:

1. W Azure Portal utwórz Service Bus namespace i Topic `order-events`. Dodaj dwie subskrypcje: `mail-notifications` i (opcjonalnie) `analytics`.
 
1. W `OrderService` skonfiguruj Service Bus Client i Publisher, który wyœle komunikat do Topic `order-events`.

1. W `MailNotificationService` utwórz Service Bus Processor, który nas³uchuje subskrypcji `mail-notifications` z Topic `order-events`. Przy odbiorze zdarzenia wyœlij potwierdzenie mailowe (imitacja).

1. Dodaj `CorrelationId` i loguj go w obu serwisach.

1. Przetestuj scenariusz z kilkoma subskrybentami (np. dodaj now¹ subskrypcjê do tego samego Topic bez zmian w kodzie OrderService).

Kluczowe punkty:
* Topic pozwala wielu konsumentom niezale¿nie subskrybowaæ zdarzenia.
* To klasyczny model choreografii w architekturze event-driven.
* Obs³u¿ Eventual consistency, idempotencjê i monitorowanie kolejek / subskrypcji w Azure Portal.