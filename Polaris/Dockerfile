#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Polaris.Web/Polaris.Web.csproj", "Polaris.Web/"]
RUN dotnet restore "Polaris.Web/Polaris.Web.csproj"
COPY . .
WORKDIR "/src/Polaris.Web"
RUN dotnet build "Polaris.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Polaris.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polaris.Web.dll"]