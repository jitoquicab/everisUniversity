FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

COPY NuGet.Config ./
COPY NugetPackage/travelExpensesRestClient.1.0.0.nupkg NugetPackage/
RUN dir /src/NugetPackage

COPY Everis.Back.FAQ.sln ./
COPY Everis.Back.FAQ/Everis.Back.FAQ.csproj Everis.Back.FAQ/
COPY Everis.back.FAQ.core.kiwi/Everis.back.FAQ.core.kiwi.csproj Everis.back.FAQ.core.kiwi/
COPY Everis.back.FAQ.core.models/Everis.back.FAQ.core.models.csproj Everis.back.FAQ.core.models/
COPY Everis.back.FAQ.core.rabbit/Everis.back.FAQ.core.rabbit.csproj Everis.back.FAQ.core.rabbit/
RUN dotnet restore Everis.Back.FAQ/Everis.Back.FAQ.csproj
COPY . .
WORKDIR /src/Everis.Back.FAQ
RUN dotnet build Everis.Back.FAQ.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Everis.Back.FAQ.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Everis.Back.FAQ.dll"]