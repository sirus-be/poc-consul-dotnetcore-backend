FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Sirus.Poc.Consul.Backend.RestApi/Sirus.Poc.Consul.Backend.RestApi.csproj", "Sirus.Poc.Consul.Backend.RestApi/"]
RUN dotnet restore "Sirus.Poc.Consul.Backend.RestApi/Sirus.Poc.Consul.Backend.RestApi.csproj"
COPY . .
WORKDIR "/src/Sirus.Poc.Consul.Backend.RestApi"
RUN dotnet build "Sirus.Poc.Consul.Backend.RestApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sirus.Poc.Consul.Backend.RestApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sirus.Poc.Consul.Backend.RestApi.dll"]