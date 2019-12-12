FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 1433
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

COPY ["Services/Members/Members.Api/Members.Api.csproj", "Services/Members/Members.Api/"]
COPY ["Services/Members/Members.Infrastructure/Members.Infrastructure.csproj", "Services/Members/Members.Infrastructure/"]
COPY ["Services/Shared/Shared.Domain/Shared.Domain.csproj", "Services/Shared/Shared.Domain/"]
COPY ["Services/Members/Members.Domain/Members.Domain.csproj", "Services/Members/Members.Domain/"]
RUN dotnet restore "Services/Members/Members.Api/Members.Api.csproj"
COPY . .
WORKDIR "/src/Services/Members/Members.Api"
RUN dotnet build "Members.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Members.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Members.Api.dll"]