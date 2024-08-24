FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["eHospitalServer/eHospitalServer.WebAPI/eHospitalServer.WebAPI.csproj", "eHospitalServer.WebAPI/"]
COPY ["eHospitalServer/eHospitalServer.Business/eHospitalServer.Business.csproj", "eHospitalServer.Business/"]
COPY ["eHospitalServer/eHospitalServer.Entities/eHospitalServer.Entities.csproj", "eHospitalServer.Entities/"]
COPY ["eHospitalServer/eHospitalServer.DataAccess/eHospitalServer.DataAccess.csproj", "eHospitalServer.DataAccess/"]

WORKDIR /src/eHospitalServer.WebAPI
RUN dotnet restore "eHospitalServer.WebAPI.csproj"

COPY . .

RUN dotnet build "eHospitalServer.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eHospitalServer.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eHospitalServer.WebAPI.dll"]
