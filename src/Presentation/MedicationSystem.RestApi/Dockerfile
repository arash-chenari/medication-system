FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MedicationSystem.RestApi/MedicationSystem.RestApi.csproj", "src/MedicationSystem.RestApi/"]
COPY ["src/Core/MedicationSystem.Domain/MedicationSystem.Domain.csproj", "src/Core/MedicationSystem.Domain/"]
COPY ["src/MedicationSystem.Persistence.EF/MedicationSystem.Persistence.EF.csproj", "src/MedicationSystem.Persistence.EF/"]
COPY ["src/Core/MedicationSystem.Application/MedicationSystem.Application.csproj", "src/Core/MedicationSystem.Application/"]
RUN dotnet restore "src/MedicationSystem.RestApi/MedicationSystem.RestApi.csproj"
COPY . .
WORKDIR "/src/src/MedicationSystem.RestApi"
RUN dotnet build "MedicationSystem.RestApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MedicationSystem.RestApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedicationSystem.RestApi.dll"]
