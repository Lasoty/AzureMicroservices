# Azure Service Bus queue

1. W Azure utworzyæ resource grupê `ComarchCwiczenia20250630`.
2. Utworzyæ zasób Service Bus o nazwie `comarch-cwiczenia-sbqueue-namespace` oraz kolejkê  `order-created-queue`
3. W Azure Portal przejdŸ do Settings -> Shared access policies -> RootManageSharedAccessKey.
4. Skopiuj Connection string, bêdzie potrzebny w aplikacjach.
5. Stwórz console project `Lab.Demo.MailNotificationService`
6. Dodaj pakiety NuGet `Azure.Messaging.ServiceBus` do obu projektów.
7. Stwórz serwis wysy³aj¹cy powiadomienia `OrderNotifier`
8. W `MailNotificationService` utwórz konsumenta kolejki `OrderCreatedQueueConsumer` i zarejestruj go w `Program.cs`.
9. SprawdŸ czy aplikacja dzia³a poprawnie, wysy³aj¹c wiadomoœæ do kolejki `order-created-queue` z aplikacji `Lab.Demo.OrderService`.