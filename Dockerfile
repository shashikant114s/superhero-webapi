# Stage 1: Build .NET app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish "SuperHeros.csproj" -c Release -o /app/out

# Stage 2: Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port inside Docker Network (Not to host)
EXPOSE 80

# Start API
ENTRYPOINT ["dotnet", "SuperHeros.dll"]

