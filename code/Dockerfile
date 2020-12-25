#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["RedisKeyTool/Server/RedisKeyTool.Server.csproj", "RedisKeyTool/Server/"]
COPY ["RedisKeyTool/Shared/RedisKeyTool.Shared.csproj", "RedisKeyTool/Shared/"]
COPY ["RedisKeyTool.Server.Application/RedisKeyTool.Server.Application.csproj", "RedisKeyTool.Server.Application/"]
COPY ["RedisKeyTool/Client/RedisKeyTool.Client.csproj", "RedisKeyTool/Client/"]
RUN dotnet restore "RedisKeyTool/Server/RedisKeyTool.Server.csproj"
COPY . .
WORKDIR "/src/RedisKeyTool/Server"
RUN dotnet build "RedisKeyTool.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisKeyTool.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisKeyTool.Server.dll"]