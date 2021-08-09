#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/MarsRover.UI/MarsRover.UI.csproj", "src/MarsRover.UI/"]
COPY ["src/MarsRover.Service/MarsRover.Service.csproj", "src/MarsRover.Service/"]
RUN dotnet restore "src/MarsRover.UI/MarsRover.UI.csproj"
COPY . .
WORKDIR "/src/src/MarsRover.UI"
RUN dotnet build "MarsRover.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarsRover.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarsRover.UI.dll"]