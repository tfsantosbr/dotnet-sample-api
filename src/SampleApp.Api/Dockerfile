FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build
COPY ["shared/SampleApp.Shared.Notifications/SampleApp.Shared.Notifications.csproj", "shared/SampleApp.Shared.Notifications/"]
COPY ["shared/SampleApp.Shared.Notifications.AspNet/SampleApp.Shared.Notifications.AspNet.csproj", "shared/SampleApp.Shared.Notifications.AspNet/"]
COPY ["src/SampleApp.Api/SampleApp.Api.csproj", "src/SampleApp.Api/"]
COPY ["src/SampleApp.Domain/SampleApp.Domain.csproj", "src/SampleApp.Domain/"]
COPY ["src/SampleApp.Infra/SampleApp.Infra.csproj", "src/SampleApp.Infra/"]
RUN dotnet restore "src/SampleApp.Api/SampleApp.Api.csproj"
COPY . .
WORKDIR "/build/src/SampleApp.Api"
RUN dotnet build "SampleApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleApp.Api.dll"]
