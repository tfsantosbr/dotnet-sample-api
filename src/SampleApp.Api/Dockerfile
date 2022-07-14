FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build
COPY ["src/Acropolis.Api/Acropolis.Api.csproj", "src/Acropolis.Api/"]
COPY ["src/Acropolis.Application/Acropolis.Application.csproj", "src/Acropolis.Application/"]
COPY ["src/Acropolis.Infrastructure/Acropolis.Infrastructure.csproj", "src/Acropolis.Infrastructure/"]
RUN dotnet restore "src/Acropolis.Api/Acropolis.Api.csproj"
COPY . .
WORKDIR "/build/src/Acropolis.Api"
RUN dotnet build "Acropolis.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Acropolis.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acropolis.Api.dll"]
