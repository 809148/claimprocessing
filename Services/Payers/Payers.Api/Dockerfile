FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

COPY ["Services/Payers/Payers.Api/Payers.Api.csproj", "Services/Payers/Payers.Api/"]
COPY ["Services/Payers/Payers.Infrastructure/Payers.Infrastructure.csproj", "Services/Payers/Payers.Infrastructure/"]
COPY ["Services/Payers/Payers.Domain/Payers.Domain.csproj", "Services/Payers/Payers.Domain/"]
COPY ["Services/Shared/Shared.Domain/Shared.Domain.csproj", "Services/Shared/Shared.Domain/"]
RUN dotnet restore "Services/Payers/Payers.Api/Payers.Api.csproj"
COPY . .
WORKDIR "/src/Services/Payers/Payers.Api"
RUN dotnet build "Payers.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Payers.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Payers.Api.dll"]