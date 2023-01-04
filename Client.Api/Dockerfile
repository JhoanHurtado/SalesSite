#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Client.Api/Client.Api.csproj", "Client.Api/"]
COPY ["Client.Dto/Client.Dto.csproj", "Client.Dto/"]
COPY ["Client.Entities/Client.Entities.csproj", "Client.Entities/"]
COPY ["Client.Interface/Client.Interface.csproj", "Client.Interface/"]
COPY ["Client.Services/Client.Services.csproj", "Client.Services/"]
COPY ["Client.Utility/Client.Utility.csproj", "Client.Utility/"]
RUN dotnet restore "Client.Api/Client.Api.csproj"
COPY . .
WORKDIR "/src/Client.Api"
RUN dotnet build "Client.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Client.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client.Api.dll"]