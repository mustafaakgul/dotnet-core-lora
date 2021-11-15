#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LoRaWAN.Middleware/LoRaWAN.Middleware.csproj", "LoRaWAN.Middleware/"]
RUN dotnet restore "LoRaWAN.Middleware/LoRaWAN.Middleware.csproj"
COPY . .
WORKDIR "/src/LoRaWAN.Middleware"
RUN dotnet build "LoRaWAN.Middleware.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoRaWAN.Middleware.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoRaWAN.Middleware.dll"]