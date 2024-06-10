# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Debug stage for additional debug-specific steps
FROM base AS debug
RUN apt-get update && apt-get install -y procps

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MY-WEB-APP/MY-WEB-APP.csproj", "MY-WEB-APP/"]
RUN dotnet restore "./MY-WEB-APP/MY-WEB-APP.csproj"
COPY . .
WORKDIR "/src/MY-WEB-APP"
RUN dotnet build "./MY-WEB-APP.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MY-WEB-APP.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MY-WEB-APP.dll"]