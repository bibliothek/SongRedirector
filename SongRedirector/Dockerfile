#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM node:10 AS node
WORKDIR /ng
COPY SongRedirector/ng .
RUN npm install
RUN npm run build-prod

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SongRedirector/SongRedirector.csproj", "SongRedirector/"]
RUN dotnet restore "SongRedirector/SongRedirector.csproj"
COPY . .
WORKDIR "/src/SongRedirector"
RUN dotnet build "SongRedirector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SongRedirector.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=node /ng/dist/song-redirector ng/dist
ENTRYPOINT ["dotnet", "SongRedirector.dll"]