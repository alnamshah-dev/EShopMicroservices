# 🛒 .NET 8 Microservices E-Commerce Architecture  

There is a couple of microservices which implemented e-commerce modules over **Catalog, Basket, Discount and Ordering microservices** with **NoSQL (DocumentDb, Redis)** and **Relational databases (PostgreSQL, Sql Server)** with communicating over **RabbitMQ Event Driven Communication** and using **YARP API Gateway**.  


---

## 📦 What's Included In This Repository  

I have implemented the below features over the **EShopMicroservices** repository:
<img width="1598" height="812" alt="EShop" src="https://github.com/user-attachments/assets/9bf27033-b35f-4eb0-9611-cbf6d8865bf3" />

---

### 📚 Catalog Microservice  
- ⚡ ASP.NET Core **Minimal APIs** with latest features of **.NET 8** and **C# 12**  
- 🗂 Vertical Slice Architecture with **Feature folders** and single `.cs` file including different classes in one file  
- 🔄 **CQRS** implementation using **MediatR** library  
- ✅ CQRS Validation Pipeline Behaviors with **MediatR + FluentValidation**  
- 📝 Use **Marten** library for .NET **Transactional Document DB** on PostgreSQL  
- 🛠 Use **Carter** for Minimal API endpoint definition  
- 📊 Cross-cutting concerns: Logging, Global Exception Handling and Health Checks  

---

### 🛒 Basket Microservice  
- ⚡ ASP.NET 8 Web API application, following **REST API principles, CRUD**  
- 🗃 Using **Redis** as a Distributed Cache over basketdb  
- 🏗 Implements **Proxy, Decorator and Cache-aside patterns**  
- 🔗 Consume **Discount gRPC Service** for inter-service sync communication to calculate product final price  
- 📬 Publish **BasketCheckout Queue** with **MassTransit** and **RabbitMQ**  

---

### 🎟 Discount Microservice  
- 🚀 ASP.NET **gRPC Server** application  
- ⚡ High-performance **gRPC Communication** with Basket Microservice  
- 📦 Exposing gRPC Services with **Protobuf messages**  
- 🛠 **Entity Framework Core ORM** with SQLite Data Provider and Migrations  
- 🗃 SQLite database connection and containerization  

---

### 🔗 Microservices Communication  
- 🔄 Sync inter-service **gRPC Communication**  
- 📡 Async Microservices Communication with **RabbitMQ** Message-Broker Service  
- 📬 Using RabbitMQ **Publish/Subscribe Topic Exchange Model**  
- 🛠 Using **MassTransit** for abstraction over RabbitMQ  
- 📦 Publishing **BasketCheckout event** from Basket microservice → Subscribing in Ordering microservice  
- 🏗 Create **RabbitMQ EventBus.Messages** library and add references to Microservices  

---

### 📦 Ordering Microservice  
- 🏗 Implementing **DDD, CQRS, Clean Architecture** with best practices  
- 🔄 CQRS using **MediatR, FluentValidation, Mapster** packages  
- 📬 Consuming RabbitMQ **BasketCheckout event** queue with **MassTransit-RabbitMQ**  
- 🗃 SQL Server database connection and containerization  
- 🛠 Using **Entity Framework Core ORM** with auto-migrate to SQL Server on app startup  

---

### 🌐 YARP API Gateway Microservice  
- 🚪 Develop API Gateways with **YARP Reverse Proxy** applying **Gateway Routing Pattern**  
- ⚙️ YARP Reverse Proxy Configuration → **Route, Cluster, Path, Transform, Destinations**  
- ⏱ Rate Limiting with **FixedWindowLimiter** on YARP Reverse Proxy  

---

### 💻 WebUI ShoppingApp Microservice  
- 🌐 ASP.NET Core Web Application with **Bootstrap 4** and Razor template  
- 🔗 Call YARP APIs with **Refit HttpClientFactory**  

---

## 🐳 Docker Compose Setup  

We establish microservices with Docker Compose:  
- 📦 Containerization of **microservices**  
- 🗃 Containerization of **databases**  
- ⚙️ Override Environment variables  

---

## 🚀 Run The Project  

### 🛠 Requirements  
- Visual Studio 2022  
- .NET 8 or later  
- Docker Desktop  

### 🔧 Installation Steps  
1. Clone the repository  
2. Ensure Docker Desktop is running  
3. Configure **Docker Settings > Advanced**:  
   - Memory: **4 GB**  
   - CPU: **2**  
4. At root directory, set **docker-compose** as startup project in Visual Studio OR run:  
   ```bash
   docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d


<img width="1918" height="907" alt="image" src="https://github.com/user-attachments/assets/e688db2f-bdf8-496e-952b-d061862ffc97" />
