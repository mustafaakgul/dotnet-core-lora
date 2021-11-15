#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LoRaWAN.ManagementUI/LoRaWAN.ManagementUI.csproj", "LoRaWAN.ManagementUI/"]
RUN dotnet restore "LoRaWAN.ManagementUI/LoRaWAN.ManagementUI.csproj"
COPY . .
WORKDIR "/src/LoRaWAN.ManagementUI"
RUN dotnet build "LoRaWAN.ManagementUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoRaWAN.ManagementUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoRaWAN.ManagementUI.dll"]