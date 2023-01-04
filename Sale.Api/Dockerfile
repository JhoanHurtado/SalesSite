#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sale.Api/Sale.Api.csproj", "Sale.Api/"]
COPY ["Sale.Dto/Sale.Dto.csproj", "Sale.Dto/"]
COPY ["Sale.Entitie/Sale.Entitie.csproj", "Sale.Entitie/"]
COPY ["Sale.Interface/Sale.Interface.csproj", "Sale.Interface/"]
COPY ["Sale.Service/Sale.Service.csproj", "Sale.Service/"]
COPY ["Sale.Utility/Sale.Utility.csproj", "Sale.Utility/"]
RUN dotnet restore "Sale.Api/Sale.Api.csproj"
COPY . .
WORKDIR "/src/Sale.Api"
RUN dotnet build "Sale.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sale.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sale.Api.dll"]