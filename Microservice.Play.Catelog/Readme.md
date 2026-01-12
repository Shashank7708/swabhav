# Microservice.Play.Catalog

A catalog microservice for managing product/item information in a distributed microservices architecture. This service is designed to handle catalog operations independently while communicating with the Play.Inventory service through RabbitMQ messaging.

## 🎯 Overview

The Play.Catalog microservice is responsible for managing the catalog of items, products, or entities within the Play distributed system. It provides RESTful APIs for creating, reading, updating, and deleting catalog entries, and communicates with the **Play.Inventory** service through **RabbitMQ** for event-driven updates and synchronization.

## ✨ Key Features

- **CRUD Operations**: Complete Create, Read, Update, Delete functionality for catalog items
- **RESTful API**: Well-defined REST endpoints following industry standards
- **Independent Deployment**: Can be deployed and scaled independently from other services
- **Persistent Storage**: Database integration for reliable data persistence
- **Service Communication**: Supports inter-service communication patterns
- **RabbitMQ Integration**: Event-driven messaging with Play.Inventory service
- **Async Messaging**: Publishes and consumes events for catalog changes
- **Health Monitoring**: Built-in health check endpoints for monitoring and orchestration
- **API Documentation**: Interactive API documentation (Swagger/OpenAPI)

## 🏗️ Architecture

This microservice follows common microservices patterns including:
- **Database Per Service**: Owns its data and schema
- **API Gateway Integration**: Can work with an API gateway for routing
- **Service Discovery**: Supports service registry and discovery mechanisms
- **Event-Driven Communication**: Uses **RabbitMQ** for asynchronous communication with **Play.Inventory** service
- **Message Publishing**: Publishes catalog events (item created, updated, deleted) to RabbitMQ
- **Message Consumption**: Listens to inventory-related events for synchronization

### Service Communication Flow

```
┌─────────────────────┐         RabbitMQ          ┌─────────────────────┐
│  Play.Catalog       │◄───────────────────────────►│  Play.Inventory     │
│  Service            │    (Event Messages)         │  Service            │
└─────────────────────┘                             └─────────────────────┘
         │                                                    │
         ▼                                                    ▼
  ┌──────────────┐                                   ┌──────────────┐
  │  MongoDB     │                                   │  MongoDB     │
  │  (Catalog)   │                                   │  (Inventory) │
  └──────────────┘                                   └──────────────┘
```

**Events Published by Catalog Service:**
- `CatalogItemCreated`: When a new item is added to the catalog
- `CatalogItemUpdated`: When an item's information is modified
- `CatalogItemDeleted`: When an item is removed from the catalog

**Events Consumed from Inventory Service:**
- Inventory stock updates
- Item availability changes

## 🛠️ Technology Stack

**Backend Framework**: ASP.NET Core / .NET 9
**Database**: **MongoDB**
**Message Broker**: **RabbitMQ** (for communication with Play.Inventory)
**API Documentation**: Swagger/OpenAPI
**Containerization**: Docker
**Orchestration**: Docker Compose (configured in play.infra)

## 📋 Prerequisites

Before you begin, ensure you have:

- **.NET 6 SDK** or higher
- **Docker** and **Docker Compose**
- **MongoDB** (included in docker-compose setup)
- **RabbitMQ** (included in docker-compose setup)
- **Git** for version control
- **IDE**: Visual Studio, VS Code, or Rider
- **MongoDB Compass** (optional, for database visualization)

## 🚀 Getting Started

### Clone the Repository

```bash
git clone https://github.com/Shashank7708/swabhav.git
cd swabhav/Microservice.Play.Catelog
```

### Docker Compose Setup

The complete infrastructure setup including RabbitMQ, databases, and all services is defined in the **play.infra** repository:

```bash
# Navigate to the infrastructure folder
cd ../play.infra

# Start all services (Catalog, Inventory, RabbitMQ, Databases)
docker-compose up -d

# View running services
docker-compose ps

# View logs for catalog service
docker-compose logs -f catalog-service

# Stop all services
docker-compose down
```

### Environment Configuration


**For Docker:**
```env
DATABASE_CONNECTION_STRING=mongodb://mongodb:27017/catalog
SERVICE_PORT=5000
RABBITMQ_HOST=rabbitmq
RABBITMQ_PORT=5672
RABBITMQ_USERNAME=guest
RABBITMQ_PASSWORD=guest
RABBITMQ_EXCHANGE=play.catalog.exchange
```

### Installation & Running

#### Using .NET (if applicable)

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the service
dotnet run
```

#### Using Docker

```bash
# Build Docker image
docker build -t play-catalog-service .

# Run container
docker run -p 5000:5000 --name catalog-service play-catalog-service
```

#### Using Docker Compose (Recommended)

The complete infrastructure is managed in the **play.infra** repository which contains the `docker-compose.yml` file:

```bash
# From the play.infra directory
docker-compose up -d

# This will start:
# - Play.Catalog Service
# - Play.Inventory Service
# - RabbitMQ
# - MongoDB
# - Any other dependent services

# View all running services
docker-compose ps

# View logs
docker-compose logs -f catalog-service

# Stop all services
docker-compose down
```

The service will be available at: `http://localhost:5000`

## 📚 API Documentation

### Base URL
```
http://localhost:5000/api
```

### Swagger UI
Access interactive API documentation at:
```
http://localhost:5000/swagger
```

### Main Endpoints

#### Catalog Items

| Method | Endpoint | Description | Request Body |
|--------|----------|-------------|--------------|
| GET | `/api/catalog` | Get all catalog items | - |
| GET | `/api/catalog/{id}` | Get specific item | - |
| POST | `/api/catalog` | Create new item | CatalogItem JSON |
| PUT | `/api/catalog/{id}` | Update existing item | CatalogItem JSON |
| DELETE | `/api/catalog/{id}` | Delete an item | - |
| GET | `/api/catalog/search?name={name}` | Search items by name | - |

#### Health Checks

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/health` | Overall health status |
| GET | `/health/ready` | Readiness probe |
| GET | `/health/live` | Liveness probe |

### Example Requests

**Create a Catalog Item:**
```bash
curl -X POST http://localhost:5000/api/catalog \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Wireless Mouse",
    "description": "Ergonomic wireless mouse with 2.4GHz connectivity",
    "price": 29.99,
    "quantity": 150,
    "category": "Electronics"
  }'
```

**Response:**
```json
{
  "id": "507f1f77bcf86cd799439011",
  "name": "Wireless Mouse",
  "description": "Ergonomic wireless mouse with 2.4GHz connectivity",
  "price": 29.99,
  "quantity": 150,
  "category": "Electronics",
  "createdAt": "2025-01-03T10:30:00Z",
  "updatedAt": "2025-01-03T10:30:00Z"
}
```

**Get All Items:**
```bash
curl -X GET http://localhost:5000/api/catalog
```

**Update an Item:**
```bash
curl -X PUT http://localhost:5000/api/catalog/507f1f77bcf86cd799439011 \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Wireless Mouse Pro",
    "price": 34.99,
    "quantity": 200
  }'
```

## 📁 Project Structure

```
swabhav/
├── Microservice.Play.Catelog/      # Catalog microservice
│   ├── src/
│   │   ├── Controllers/            # API endpoint controllers
│   │   │   └── CatalogController.cs
│   │   ├── Models/                 # Domain models and entities
│   │   │   └── CatalogItem.cs
│   │   ├── DTOs/                   # Data Transfer Objects
│   │   │   ├── CreateCatalogItemDto.cs
│   │   │   └── UpdateCatalogItemDto.cs
│   │   ├── Services/               # Business logic layer
│   │   │   ├── ICatalogService.cs
│   │   │   └── CatalogService.cs
│   │   ├── Repositories/           # Data access layer
│   │   │   ├── ICatalogRepository.cs
│   │   │   └── CatalogRepository.cs
│   │   ├── Messaging/              # RabbitMQ integration
│   │   │   ├── MessagePublisher.cs
│   │   │   ├── MessageConsumer.cs
│   │   │   └── Messages/
│   │   │       ├── CatalogItemCreated.cs
│   │   │       ├── CatalogItemUpdated.cs
│   │   │       └── CatalogItemDeleted.cs
│   │   ├── Data/                   # Database context
│   │   │   └── MongoDbContext.cs
│   │   │   └── IMongoDbContext.cs
│   │   ├── Middleware/             # Custom middleware
│   │   ├── Extensions/             # Extension methods
│   │   └── Program.cs              # Application entry point
│   ├── tests/
│   │   ├── UnitTests/              # Unit tests
│   │   └── IntegrationTests/       # Integration tests
│   └── README.md                   # This file
│
├── Play.Inventory/                 # Inventory microservice
│   └── ...                         # (Connected via RabbitMQ)
│
└── play.infra/                     # Infrastructure configuration
    ├── docker-compose.yml          # Docker compose file for all services
    ├── rabbitmq/                   # RabbitMQ configuration
    ├── databases/                  # Database initialization scripts
    └── README.md                   # Infrastructure documentation
```

## ⚙️ Configuration

### MongoDB Database Configuration

**Connection Settings:**
```json
{
  "DatabaseSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "CatalogDb",
    "CollectionName": "CatalogItems"
  }
}
```

**For Docker Environment:**
```json
{
  "DatabaseSettings": {
    "ConnectionString": "mongodb://mongodb:27017",
    "DatabaseName": "CatalogDb",
    "CollectionName": "CatalogItems"
  }
}
```

### MongoDB Schema

**CatalogItem Document:**
```json
{
  "_id": "ObjectId",
  "name": "string",
  "description": "string",
  "price": "decimal",
  "quantity": "int",
  "category": "string",
  "createdAt": "ISODate",
  "updatedAt": "ISODate"
}
```

### Connecting to MongoDB

**Using MongoDB Compass:**
```
Connection String: mongodb://localhost:27017
Database: CatalogDb
Collection: CatalogItems
```

**Using MongoDB Shell:**
```bash
# Connect to MongoDB
mongosh mongodb://localhost:27017

# Switch to CatalogDb
use CatalogDb

# View all catalog items
db.CatalogItems.find().pretty()

# Count documents
db.CatalogItems.countDocuments()
```

**Using Docker:**
```bash
# Access MongoDB container
docker exec -it mongodb mongosh

# Or if using play.infra
cd play.infra
docker-compose exec mongodb mongosh
```

### Service Settings

```json
{
  "ServiceSettings": {
    "ServiceName": "Catalog",
    "Port": 5000,
    "Authority": "https://localhost:5001"
  }
}
```

### Message Broker (RabbitMQ)

**Configuration for service communication with Play.Inventory:**

```json
{
  "RabbitMQ": {
    "Host": "rabbitmq",
    "Port": 5672,
    "Username": "guest",
    "Password": "guest",
    "VirtualHost": "/",
    "ExchangeName": "play.catalog.exchange",
    "QueueName": "play.catalog.queue",
    "RoutingKeys": {
      "CatalogItemCreated": "catalog.item.created",
      "CatalogItemUpdated": "catalog.item.updated",
      "CatalogItemDeleted": "catalog.item.deleted"
    }
  }
}
```

**Message Contracts:**

```csharp
// CatalogItemCreated event
public class CatalogItemCreated
{
    public Guid ItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}

// CatalogItemUpdated event
public class CatalogItemUpdated
{
    public Guid ItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime UpdatedAt { get; set; }
}

// CatalogItemDeleted event
public class CatalogItemDeleted
{
    public Guid ItemId { get; set; }
    public DateTime DeletedAt { get; set; }
}
```

## 🧪 Testing

### Run All Tests
```bash
dotnet test
```

### Run Unit Tests Only
```bash
dotnet test --filter Category=Unit
```

### Run Integration Tests
```bash
dotnet test --filter Category=Integration
```

### Test Coverage
```bash
dotnet test /p:CollectCoverage=true /p:CoverageReportFormat=opencover
```

## 🚢 Deployment

### Docker Compose Deployment (Recommended)

All services are orchestrated through the **play.infra** repository:

```bash
# Navigate to infrastructure directory
cd play.infra

# Start all services
docker-compose up -d

# Check service health
docker-compose ps

# Scale catalog service (if needed)
docker-compose up -d --scale catalog-service=3

# View logs
docker-compose logs -f

# Stop all services
docker-compose down

# Stop and remove volumes
docker-compose down -v
```

### Individual Docker Deployment

```bash
# Build image
docker build -t shashank7708/play-catalog:latest .

# Push to registry
docker push shashank7708/play-catalog:latest

# Run container
docker run -d -p 5000:5000 --name catalog-service \
  -e DATABASE_CONNECTION_STRING="your_connection_string" \
  shashank7708/play-catalog:latest
```

### Kubernetes Deployment

```yaml
# deployment.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: catalog-service
spec:
  replicas: 3
  selector:
    matchLabels:
      app: catalog-service
  template:
    metadata:
      labels:
        app: catalog-service
    spec:
      containers:
      - name: catalog-service
        image: shashank7708/play-catalog:latest
        ports:
        - containerPort: 5000
        env:
        - name: DATABASE_CONNECTION_STRING
          valueFrom:
            secretKeyRef:
              name: catalog-secrets
              key: db-connection
```

```bash
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml
```

### CI/CD Pipeline

This project can be integrated with:
- **GitHub Actions** - See `.github/workflows/`
- **Azure DevOps**
- **Jenkins**
- **GitLab CI**

## 📊 Monitoring & Observability

### Health Checks
- **Liveness Probe**: `/health/live` - Is the service running?
- **Readiness Probe**: `/health/ready` - Is the service ready to accept requests?

### Logging
- Structured logging with Serilog/NLog
- Log levels: Trace, Debug, Information, Warning, Error, Critical
- Integration with logging platforms (ELK, Application Insights, etc.)

### Metrics
- Performance metrics exposed at `/metrics` (Prometheus format)
- Custom business metrics tracking
- Request/response time monitoring

### Tracing
- Distributed tracing with OpenTelemetry
- Correlation ID propagation across services
- Request flow visualization

## 🔒 Security

- **Authentication**: JWT Bearer token authentication (if applicable)
- **Authorization**: Role-based access control
- **HTTPS**: TLS/SSL encryption for all communications
- **Input Validation**: Request validation and sanitization
- **CORS**: Configurable Cross-Origin Resource Sharing
- **Rate Limiting**: API rate limiting to prevent abuse
- **Secrets Management**: Environment variables and secret stores

## 🤝 Contributing

We welcome contributions! Please follow these guidelines:

### How to Contribute

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Make your changes**
4. **Write/update tests**
5. **Commit your changes**
   ```bash
   git commit -m "Add: Brief description of your changes"
   ```
6. **Push to your branch**
   ```bash
   git push origin feature/your-feature-name
   ```
7. **Create a Pull Request**

### Coding Standards

- Follow C# coding conventions or Java style guide
- Write meaningful commit messages
- Add XML documentation for public APIs
- Maintain test coverage above 80%
- Ensure all tests pass before submitting PR
- Update documentation for new features

### Code Review Process

- All submissions require review
- Address reviewer feedback
- Squash commits before merging
- Ensure CI/CD pipeline passes

## 🔗 Integration with Play.Inventory

### Communication Flow

The Catalog service communicates with the Inventory service through RabbitMQ:

1. **When a catalog item is created:**
   ```
   Catalog Service → Publishes "CatalogItemCreated" → RabbitMQ → Inventory Service
   ```

2. **When a catalog item is updated:**
   ```
   Catalog Service → Publishes "CatalogItemUpdated" → RabbitMQ → Inventory Service
   ```

3. **When a catalog item is deleted:**
   ```
   Catalog Service → Publishes "CatalogItemDeleted" → RabbitMQ → Inventory Service
   ```

4. **Inventory updates:**
   ```
   Inventory Service → Publishes "InventoryUpdated" → RabbitMQ → Catalog Service (subscribes)
   ```

### Testing RabbitMQ Connection

```bash
# Access RabbitMQ Management UI (if enabled)
http://localhost:15672
# Default credentials: guest/guest

# Check exchanges
curl -u guest:guest http://localhost:15672/api/exchanges

# Check queues
curl -u guest:guest http://localhost:15672/api/queues
```

### Message Flow Example

```bash
# 1. Create a catalog item via API
curl -X POST http://localhost:5000/api/catalog \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Gaming Keyboard",
    "price": 89.99,
    "quantity": 50
  }'

# 2. This triggers RabbitMQ message publication
# 3. Inventory service receives the message
# 4. Inventory service creates corresponding inventory record
```

## 🐛 Troubleshooting

### Common Issues

**Issue: Database Connection Failed**
```bash
# Solution:
1. Check MongoDB connection string in appsettings.json
2. Verify MongoDB service is running:
   docker ps | grep mongodb
3. Test connection:
   mongosh mongodb://localhost:27017
4. Check MongoDB logs:
   docker logs mongodb
5. Verify network connectivity between containers
6. Ensure correct database name and collection name
```

**Issue: Port Already in Use**
```bash
# Solution:
# Find and kill the process using the port (Windows)
netstat -ano | findstr :5000
taskkill /PID <process_id> /F

# On Linux/Mac
lsof -ti:5000 | xargs kill -9

# Or change the port in configuration
```

**Issue: Docker Container Fails to Start**
```bash
# Solution:
# View container logs
docker logs catalog-service

# Check container status
docker ps -a

# Inspect container
docker inspect catalog-service

# Restart from play.infra
cd play.infra
docker-compose restart catalog-service
```

**Issue: RabbitMQ Connection Failed**
```bash
# Solution:
# Check if RabbitMQ is running
docker ps | grep rabbitmq

# Check RabbitMQ logs
docker logs rabbitmq

# Verify connection settings in appsettings.json
# Ensure host is set to "rabbitmq" (service name) in Docker
# Use "localhost" for local development outside Docker

# Test RabbitMQ connectivity
curl http://localhost:15672/api/health/checks/alarms
```

**Issue: Messages Not Being Published/Consumed**
```bash
# Solution:
# 1. Check RabbitMQ Management UI
http://localhost:15672

# 2. Verify exchange exists
# Navigate to Exchanges tab and look for "play.catalog.exchange"

# 3. Check queue bindings
# Navigate to Queues tab and verify bindings

# 4. Check application logs for messaging errors
docker-compose logs -f catalog-service

# 5. Verify message serialization settings
# Ensure consistent JSON serialization between services
```

**Issue: 401 Unauthorized**
```bash
# Solution:
# Ensure you're passing the JWT token
curl -H "Authorization: Bearer YOUR_TOKEN" http://localhost:5000/api/catalog
```

## 📖 Documentation

- [Architecture Overview](docs/architecture.md)
- [API Reference](docs/api-reference.md)
- [RabbitMQ Integration Guide](docs/rabbitmq-integration.md)
- [Service Communication](docs/service-communication.md)
- [Deployment Guide](docs/deployment.md)
- [Development Setup](docs/development-setup.md)
- [Infrastructure Setup](../play.infra/README.md)

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Shashank** - *Initial work* - [Shashank7708](https://github.com/Shashank7708)

## 🙏 Acknowledgments

- Built following microservices architecture patterns
- Part of the Swabhav project ecosystem
- Event-driven communication using RabbitMQ
- Integrates with Play.Inventory service
- Infrastructure managed through play.infra repository
- Inspired by industry best practices
- Thanks to all contributors

## 📞 Support

For questions, issues, or contributions:
- **Issues**: [GitHub Issues](https://github.com/Shashank7708/swabhav/issues)
- **Discussions**: [GitHub Discussions](https://github.com/Shashank7708/swabhav/discussions)
- **Email**: Create an issue for support requests

## 🗺️ Roadmap

- [x] Basic CRUD operations for catalog items
- [x] RabbitMQ integration with Play.Inventory
- [x] Docker containerization
- [x] Docker Compose orchestration (via play.infra)
- [ ] Add authentication and authorization
- [ ] Implement caching layer (Redis)
- [ ] Add retry policies for RabbitMQ
- [ ] Implement circuit breaker pattern
- [ ] Add saga pattern for distributed transactions
- [ ] Implement CQRS pattern
- [ ] Add GraphQL support
- [ ] Performance optimization
- [ ] Enhanced monitoring and alerting
- [ ] Multi-language support

---

**⭐ If you find this project helpful, please consider giving it a star!**

**Related Repositories:**
- [Play.Inventory](https://github.com/Shashank7708/swabhav/tree/master/Play.Inventory) - Inventory management service
- [play.infra](https://github.com/Shashank7708/swabhav/tree/master/play.infra) - Infrastructure and Docker Compose configuration

**Last Updated**: January 2026

**Status**: Active Development

---

**Important**: This README is a comprehensive template. Please review and update the following sections based on your actual implementation:
- Technology stack and versions
- Actual API endpoints and schemas
- Configuration specifics
- Database schema and migrations
- Authentication/authorization implementation
- Deployment specifics
- Environment-specific configurations