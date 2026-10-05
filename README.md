# Mini E-Commerce API (.NET 8 + Docker + Redis)



Un progetto dimostrativo che simula il backend di un sistema E-Commerce. Costruito per approfondire le architetture moderne, l'inversione delle dipendenze e la containerizzazione tramite Docker.



## Tecnologie Utilizzate

* **Framework:** C# / ASP.NET Core 8 Web API

* **Database Relazionale:** PostgreSQL (tramite Entity Framework Core)

* **Cache Distribuita:** Redis (per una gestione fulminea dei carrelli temporanei)

* **Infrastruttura:** Docker & Docker Compose

* **Documentazione:** Swagger / OpenAPI



## Scelte Architetturali

* **Inversione delle Dipendenze (Dependency Injection):** Il servizio del carrello utilizza nativamente l'interfaccia `IDistributedCache`. Questo ha permesso di sviluppare la logica in locale utilizzando la RAM e di passare a **Redis** in produzione modificando una sola riga di configurazione in `Program.cs`.

* **Containerizzazione:** L'intero stack (API, DB, Cache) è orchestrato tramite `docker-compose`, garantendo un ambiente di sviluppo isolato e riproducibile al 100%.



## Come avviare il progetto



Non c'è bisogno di installare .NET SDK, PostgreSQL o Redis sul tuo computer. Basta avere **Docker Desktop** avviato.



Clona la repository:

  ```bash

  git clone \[https://github.com/DarioCr00/MiniEcommerce.git](https://github.com/DarioCr00/MiniEcommerce.git)

  cd MiniEcommerce

