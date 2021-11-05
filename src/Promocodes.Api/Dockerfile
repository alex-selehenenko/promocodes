#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Promocodes.Api/Promocodes.Api.csproj", "src/Promocodes.Api/"]
COPY ["src/Promocodes.Business/Promocodes.Business.csproj", "src/Promocodes.Business/"]
COPY ["src/Promocodes.Data.Core/Promocodes.Data.Core.csproj", "src/Promocodes.Data.Core/"]
COPY ["src/Promocodes.Identity/Promocodes.Identity.csproj", "src/Promocodes.Identity/"]
COPY ["src/Promocodes.Data.Persistence/Promocodes.Data.Persistence.csproj", "src/Promocodes.Data.Persistence/"]
RUN dotnet restore "src/Promocodes.Api/Promocodes.Api.csproj"
COPY . .
WORKDIR "/src/src/Promocodes.Api"
RUN dotnet build "Promocodes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Promocodes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Promocodes.Api.dll"]
