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
| `DB_CONNECTION_STRING` | SQL Server connection string | `Server=sqlserver,1433;Database=SuperHeros;User Id=SA;Password=Test@123;TrustServerCertificate=True;` |
| `SA_PASSWORD` | SQL Server SA password | `Test@123` |

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
## 🔁 CI/CD Pipeline (GitHub Actions → EC2)
This project uses **GitHub Actions** to automatically deploy changes to an EC2 instance when a pull request is merged into the `development` branch.

## ✅ How it works:
- Trigger: `pull_request` is **closed and merged** into `development`
- GitHub Action runs on `ubuntu-latest` runner
- Uses appleboy/ssh-action to:
  - SSH into EC2
  - Pull latest code
  - Restart Docker containers using `docker-compose`
    
**📁 Workflow File:** `.github/workflows/deploy.yml`

**🔐 Secrets Used:**

| Secret Name   | Description                    |
| ------------- | ------------------------------ |
| `EC2_HOST`    | Public IP or hostname of EC2   |
| `EC2_SSH_KEY` | Private SSH key for EC2 access |

**🧩 Troubleshooting**
- Ensure your EC2 instance allows port `22` (SSH) and `80/443` (HTTP/S) in security group
- Docker must be installed and `docker-compose` available on EC2
- Your GitHub repository secrets must be configured properly
- Make sure your EC2 user (`ubuntu`) has the correct permissions to run docker

# Difficulties
<img width="1919" height="525" alt="image" src="https://github.com/user-attachments/assets/d6afefd3-7f78-4c8a-b161-e6bdc08db138" />
<img width="1800" height="975" alt="Screenshot From 2025-08-05 22-59-20" src="https://github.com/user-attachments/assets/567325b8-7fda-4cee-adea-557ee20f4bbb" />
