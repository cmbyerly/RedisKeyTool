#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["RadishV2/Server/RadishV2.Server.csproj", "RadishV2/Server/"]
COPY ["RadishV2/Shared/RadishV2.Shared.csproj", "RadishV2/Shared/"]
COPY ["RadishV2.Server.Application/RadishV2.Server.Application.csproj", "RadishV2.Server.Application/"]
COPY ["RadishV2/Client/RadishV2.Client.csproj", "RadishV2/Client/"]
RUN dotnet restore "RadishV2/Server/RadishV2.Server.csproj"
COPY . .
WORKDIR "/src/RadishV2/Server"
RUN dotnet build "RadishV2.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RadishV2.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RadishV2.Server.dll"]