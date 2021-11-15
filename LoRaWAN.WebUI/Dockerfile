#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LoRaWAN.WebUI/LoRaWAN.WebUI.csproj", "LoRaWAN.WebUI/"]
RUN dotnet restore "LoRaWAN.WebUI/LoRaWAN.WebUI.csproj"
COPY . .
WORKDIR "/src/LoRaWAN.WebUI"
RUN dotnet build "LoRaWAN.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoRaWAN.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoRaWAN.WebUI.dll"]