#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FridgeManager.AuthMicroService/FridgeManager.AuthMicroService.csproj", "FridgeManager.AuthMicroService/"]
COPY ["FridgeManager.Shared/FridgeManager.Shared.csproj", "FridgeManager.Shared/"]
RUN dotnet restore "FridgeManager.AuthMicroService/FridgeManager.AuthMicroService.csproj"
COPY . .
WORKDIR "/src/FridgeManager.AuthMicroService"
RUN dotnet build "FridgeManager.AuthMicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FridgeManager.AuthMicroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FridgeManager.AuthMicroService.dll"]