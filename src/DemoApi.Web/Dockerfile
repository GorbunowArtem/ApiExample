FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY "DemoApi.sln" "DemoApi.sln"
COPY "src/DemoApi.Web/DemoApi.Web.csproj" "src/DemoApi.Web/DemoApi.Web.csproj"
COPY "src/DemoApi.Core/DemoApi.Core.csproj" "src/DemoApi.Core/DemoApi.Core.csproj"
COPY "src/DemoApi.Infrastructure/DemoApi.Infrastructure.csproj" "src/DemoApi.Infrastructure/DemoApi.Infrastructure.csproj"
COPY "tests/DemoApi.Tests/DemoApi.Tests.csproj" "tests/DemoApi.Tests/DemoApi.Tests.csproj"

RUN dotnet restore "DemoApi.sln"

COPY . .
WORKDIR "/src/DemoApi.Web"
RUN dotnet build "DemoApi.sln" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "DemoApi.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final


EXPOSE 8080
EXPOSE 8081

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoAp.Webi.dll"]
