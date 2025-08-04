# SuperHero Web API 🦸‍♂️

A simple .NET 8 Web API with SQL Server and NGINX reverse proxy, dockerized for easy deployment.

---

## 🚀 Features
- .NET 8 WebAPI (SuperHeroes)
- SQL Server 2019 (Dockerized)
- NGINX Reverse Proxy
- Swagger UI for API testing
- Easy Deployment using Docker Compose

---

## 📋 Prerequisites
- Docker & Docker Compose installed
- .NET 8 SDK (For Local Development)
- Git
- EC2 Instance (Ubuntu 20.04 / 22.04 LTS Recommended)

---

## ⚙️ Environment Variables
| Variable | Description | Example |
|----------|-------------|---------|
| `DB_CONNECTION_STRING` | SQL Server connection string | `Server=sqlserver,1433;Database=SuperHeros;User Id=SA;Password=Shashi@12;TrustServerCertificate=True;` |
| `SA_PASSWORD` | SQL Server SA password | `Shashi@12` |

---

## 🛠️ Setup Instructions

### 1. Clone the Repository
```bash
git clone <your-repo-url>
cd superhero-webapi
```
## Build & Run using Docker Compose
```bash
docker-compose up --build -d
```
## Access the API (Swagger UI)
```bash
http://<YOUR-EC2-IP>/swagger/index.html
```

# Difficulties
<img width="1919" height="525" alt="image" src="https://github.com/user-attachments/assets/d6afefd3-7f78-4c8a-b161-e6bdc08db138" />
