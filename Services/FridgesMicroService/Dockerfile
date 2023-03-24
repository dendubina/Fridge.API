#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FridgeManager.FridgesMicroService/FridgeManager.FridgesMicroService.csproj", "FridgeManager.FridgesMicroService/"]
COPY ["FridgeManager.Shared/FridgeManager.Shared.csproj", "FridgeManager.Shared/"]
RUN dotnet restore "FridgeManager.FridgesMicroService/FridgeManager.FridgesMicroService.csproj"
COPY . .
WORKDIR "/src/FridgeManager.FridgesMicroService"
RUN dotnet build "FridgeManager.FridgesMicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FridgeManager.FridgesMicroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FridgeManager.FridgesMicroService.dll"]