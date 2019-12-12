FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /var/www/providersapi # /app
EXPOSE 80
EXPOSE 443
EXPOSE 1433

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Services/Providers/Providers.Api/Providers.Api.csproj", "Services/Providers/Providers.Api/"]
COPY ["Services/Providers/Providers.Infrastructure/Providers.Infrastructure.csproj", "Services/Providers/Providers.Infrastructure/"]
COPY ["Services/Providers/Providers.Domain/Providers.Domain.csproj", "Services/Providers/Providers.Domain/"]
COPY ["Services/Shared/Shared.Domain/Shared.Domain.csproj", "Services/Shared/Shared.Domain/"]
RUN dotnet restore "Services/Providers/Providers.Api/Providers.Api.csproj"
COPY . .
WORKDIR "/src/Services/Providers/Providers.Api"
RUN dotnet build "Providers.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Providers.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Providers.Api.dll"]