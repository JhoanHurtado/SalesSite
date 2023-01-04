#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Product.Api/Product.Api.csproj", "Product.Api/"]
COPY ["Product.Dto/Product.Dto.csproj", "Product.Dto/"]
COPY ["Product.Entitie/Product.Entitie.csproj", "Product.Entitie/"]
COPY ["Product.Interface/Product.Interface.csproj", "Product.Interface/"]
COPY ["Product.Service/Product.Service.csproj", "Product.Service/"]
COPY ["Product.Utility/Product.Utility.csproj", "Product.Utility/"]
RUN dotnet restore "Product.Api/Product.Api.csproj"
COPY . .
WORKDIR "/src/Product.Api"
RUN dotnet build "Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.Api.dll"]