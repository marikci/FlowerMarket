#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FlowerMarket.Web.Api/FlowerMarket.Web.Api.csproj", "FlowerMarket.Web.Api/"]
COPY ["FlowerMarket.DataAccess/FlowerMarket.DataAccess.csproj", "FlowerMarket.DataAccess/"]
COPY ["FlowerMarket.Model/FlowerMarket.Model.csproj", "FlowerMarket.Model/"]
COPY ["FlowerMarket.Business/FlowerMarket.Business.csproj", "FlowerMarket.Business/"]
RUN dotnet restore "FlowerMarket.Web.Api/FlowerMarket.Web.Api.csproj"
COPY . .
WORKDIR "/src/FlowerMarket.Web.Api"
RUN dotnet build "FlowerMarket.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlowerMarket.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlowerMarket.Web.Api.dll"]