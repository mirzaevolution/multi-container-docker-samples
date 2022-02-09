#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AESCryptoApi/AESCryptoApi.csproj", "AESCryptoApi/"]
COPY ["AESCryptoApi.Models/AESCryptoApi.Models.csproj", "AESCryptoApi.Models/"]
COPY ["AESCryptoApi.Libs/AESCryptoApi.Libs.csproj", "AESCryptoApi.Libs/"]
RUN dotnet restore "AESCryptoApi/AESCryptoApi.csproj"
COPY . .
WORKDIR "/src/AESCryptoApi"
RUN dotnet build "AESCryptoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AESCryptoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AESCryptoApi.dll"]