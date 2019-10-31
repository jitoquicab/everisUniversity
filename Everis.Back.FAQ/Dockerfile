FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Everis.Back.FAQ/Everis.Back.FAQ.csproj", "Everis.Back.FAQ/"]
RUN dotnet restore "Everis.Back.FAQ/Everis.Back.FAQ.csproj"
COPY . .
WORKDIR "/src/Everis.Back.FAQ"
RUN dotnet build "Everis.Back.FAQ.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Everis.Back.FAQ.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Everis.Back.FAQ.dll"]