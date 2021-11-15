#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LoRaWAN.APIMobile/LoRaWAN.APIMobile.csproj", "LoRaWAN.APIMobile/"]
RUN dotnet restore "LoRaWAN.APIMobile/LoRaWAN.APIMobile.csproj"
COPY . .
WORKDIR "/src/LoRaWAN.APIMobile"
RUN dotnet build "LoRaWAN.APIMobile.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoRaWAN.APIMobile.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoRaWAN.APIMobile.dll"]