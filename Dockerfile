FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY shared/SampleApp.Shared.Notifications/*.csproj shared/SampleApp.Shared.Notifications/
COPY shared/SampleApp.Shared.Notifications.AspNet/*.csproj shared/SampleApp.Shared.Notifications.AspNet/
COPY src/SampleApp.Api/*.csproj src/SampleApp.Api/
COPY src/SampleApp.Domain/*.csproj src/SampleApp.Domain/
COPY src/SampleApp.Infra/*.csproj src/SampleApp.Infra/
RUN dotnet restore src/SampleApp.Api/SampleApp.Api.csproj

# copy and build app and libraries
COPY shared/SampleApp.Shared.Notifications/ shared/SampleApp.Shared.Notifications/
COPY shared/SampleApp.Shared.Notifications.AspNet/ shared/SampleApp.Shared.Notifications.AspNet/
COPY src/SampleApp.Api/ src/SampleApp.Api/
COPY src/SampleApp.Domain/ src/SampleApp.Domain/
COPY src/SampleApp.Infra/ src/SampleApp.Infra/
WORKDIR /source/src/SampleApp.Api
RUN dotnet build -c release --no-restore

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SampleApp.Api.dll"]
