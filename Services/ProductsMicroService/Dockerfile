#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FridgeManager.ProductsMicroService/FridgeManager.ProductsMicroService.csproj", "FridgeManager.ProductsMicroService/"]
COPY ["FridgeManager.Shared/FridgeManager.Shared.csproj", "FridgeManager.Shared/"]
RUN dotnet restore "FridgeManager.ProductsMicroService/FridgeManager.ProductsMicroService.csproj"
COPY . .
WORKDIR "/src/FridgeManager.ProductsMicroService"
RUN dotnet build "FridgeManager.ProductsMicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FridgeManager.ProductsMicroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FridgeManager.ProductsMicroService.dll"]