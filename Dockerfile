FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
# Copy everything
COPY *.csproj ./
# Restore as distinct layers
RUN dotnet restore
# Copy everything
COPY . ./
# Build
RUN dotnet build "ApiKey.csproj" -c Release -o /app/build
RUN dotnet tool install -g Microsoft.dotnet-httprepl
RUN dotnet dev-certs https --trust

# publish a release
FROM build AS publish
RUN dotnet publish "ApiKey.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiKey.dll"]