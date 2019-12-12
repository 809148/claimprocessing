FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 1433

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services/Claims/Claims.Api/Claims.Api.csproj", "Services/Claims/Claims.Api/"]
COPY ["Services/Claims/Claims.Infrastructure/Claims.Infrastructure.csproj", "Services/Claims/Claims.Infrastructure/"]
COPY ["Services/Shared/Shared.Domain/Shared.Domain.csproj", "Services/Shared/Shared.Domain/"]
COPY ["Services/Claims/Claims.Domain/Claims.Domain.csproj", "Services/Claims/Claims.Domain/"]
#COPY ["Services/Shared/Shared.Utils/Shared.Utils.csproj", "Services/Shared/Shared.Utils/"]
RUN dotnet restore "Services/Claims/Claims.Api/Claims.Api.csproj"
COPY . .
WORKDIR "/src/Services/Claims/Claims.Api"
RUN dotnet build "Claims.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Claims.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Claims.Api.dll"]