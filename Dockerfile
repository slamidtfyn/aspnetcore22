FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY aspnetcore22.csproj ./
RUN dotnet restore aspnetcore22.csproj
COPY . .
WORKDIR /src/
RUN dotnet build aspnetcore22.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish aspnetcore22.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "aspnetcore22.dll"]
