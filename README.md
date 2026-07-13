# Azure Message Processing System

A cloud-based message processing solution built using **ASP.NET Core**, **Azure Service Bus**, **Azure Functions**, and **Azure Blob Storage**. The application demonstrates an event-driven architecture where orders submitted through a REST API are processed asynchronously and stored in Azure Blob Storage.

## 📌 Features

- ASP.NET Core 8 Web API
- Azure Service Bus Queue for asynchronous messaging
- Azure Functions (Isolated Worker)
- Azure Blob Storage integration
- Dependency Injection
- Asynchronous message processing
- Structured logging
- Shared project for reusable models and contracts
- NUnit test project (in progress)

## 🛠️ Technology Stack

| Technology | Purpose |
|------------|---------|
| ASP.NET Core 8 | REST API |
| Azure Service Bus | Message Queue |
| Azure Functions | Background Processing |
| Azure Blob Storage | Store processed messages |
| Azure Storage Account | Blob Storage |
| Azure SDK | Azure Service Integration |
| Dependency Injection | Service Registration |
| NUnit | Unit Testing |
| Moq | Mocking Dependencies |
| FluentValidation | Request Validation (Upcoming) |
| Application Insights | Monitoring (Upcoming) |

---

## 🏗️ Architecture

```text
                Client
                  │
                  ▼
      ASP.NET Core Web API
                  │
        Publish Order Message
                  │
                  ▼
      Azure Service Bus Queue
                  │
                  ▼
     Azure Function (Trigger)
                  │
      Process Order Message
                  │
                  ▼
      Azure Blob Storage
```

---

## 📁 Project Structure

```text
AzureMessageProcessingSystem
│
├── src
│   ├── AzureMessageProcessing.Api
│   ├── AzureMessageProcessing.Function
│   └── AzureMessageProcessing.Shared
│
├── tests
│   └── AzureMessageProcessing.Tests
│
├── README.md
└── AzureMessageProcessingSystem.sln
```

---

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 8 SDK
- Azure Subscription
- Azure Service Bus
- Azure Storage Account

---

### Azure Resources

Create the following Azure resources:

- Resource Group
- Service Bus Namespace
- Service Bus Queue (`order-queue`)
- Storage Account
- Blob Container (`processed-orders`)

---

### Configuration

Update your local configuration with:

```json
{
  "ServiceBusSettings": {
    "ConnectionString": "",
    "QueueName": "order-queue"
  },
  "BlobStorageConnection": "",
  "BlobContainerName": "processed-orders"
}
```

> **Note:** Do not commit secrets to GitHub. Use **User Secrets** or **Azure Key Vault**.

---

## 🔄 Workflow

1. User submits an order using the REST API.
2. The API publishes the order to Azure Service Bus.
3. Azure Function is triggered automatically.
4. The Function processes the message.
5. Processed order is stored as a JSON file in Azure Blob Storage.

---

## 📋 Sample Request

```http
POST /api/orders
```

```json
{
  "customerName": "Allwin",
  "productName": "Laptop",
  "quantity": 1,
  "price": 65000
}
```

---

## 📂 Sample Blob Output

```json
{
  "orderId": "f3a9d4d4-92c8-49bb-92c1-1fd8d4d0e5ab",
  "customerName": "Allwin",
  "productName": "Laptop",
  "quantity": 1,
  "price": 65000,
  "createdOn": "2026-07-13T10:30:00Z",
  "status": "Pending"
}
```

---

## 🧪 Testing

The project includes an NUnit test project for unit testing.

Upcoming test coverage:

- OrderService
- BlobStorageService
- Azure Function
- Validators
- Message Publisher

---

## 📅 Roadmap

- [x] ASP.NET Core Web API
- [x] Azure Service Bus Integration
- [x] Azure Function Trigger
- [x] Azure Blob Storage Integration
- [ ] FluentValidation
- [ ] Global Exception Handling
- [ ] NUnit Test Coverage
- [ ] Application Insights
- [ ] Dead Letter Queue
- [ ] Azure Key Vault
- [ ] Docker Support
- [ ] GitHub Actions CI/CD

---

## 👨‍💻 Author

**Allwin Joseph Rajan**

GitHub: https://github.com/Allwin997
