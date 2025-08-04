# Stage 1: Build .NET app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish "SuperHeros.csproj" -c Release -o /app/out

# Stage 2: Setup runtime image with NGINX
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Install nginx
RUN apt-get update && apt-get install -y nginx && rm -rf /var/lib/apt/lists/*

# Create nginx run dir
RUN mkdir -p /run/nginx

# Copy published app
COPY --from=build /app/out /app

# Copy nginx config
COPY nginx.conf /etc/nginx/nginx.conf

# Set working directory
WORKDIR /app

# Expose port
EXPOSE 80

# Start both app and nginx
CMD dotnet SuperHeros.dll & nginx -g "daemon off;"
