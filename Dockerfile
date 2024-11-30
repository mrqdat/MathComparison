# Base image with ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Install platform linker dependencies for Native AOT
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang gcc libc6-dev libz-dev libunwind-dev \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

COPY ["MathComparison/MathComparison.csproj", "MathComparison/"]
RUN dotnet restore "./MathComparison/MathComparison.csproj"
COPY . .
WORKDIR "/src/MathComparison"
RUN dotnet build "./MathComparison.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "./MathComparison.csproj" -c Release -o /app/publish /p:UseAppHost=true

# Final stage with runtime (not runtime-deps)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published files from publish stage
COPY --from=publish /app/publish .

# Set the entry point to the application
ENTRYPOINT ["dotnet", "MathComparison.dll"]
