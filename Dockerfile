#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FilemanagerDemo.csproj", ""]
RUN dotnet restore "./FilemanagerDemo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FilemanagerDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FilemanagerDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME /app/storage
# ENTRYPOINT ["dotnet", "FilemanagerDemo.dll"]
COPY scripts/entrypoint.sh /usr/local/bin/
ENTRYPOINT ["entrypoint.sh"]
