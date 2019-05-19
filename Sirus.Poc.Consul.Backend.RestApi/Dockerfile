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

# Add Envconsule to path!
RUN curl -so envconsul.tgz https://releases.hashicorp.com/envconsul/0.7.3/envconsul_0.7.3_linux_amd64.tgz
RUN tar -xvzf envconsul.tgz
RUN mv envconsul /usr/local/bin/envconsul
RUN chmod +x /usr/local/bin/envconsul

ENTRYPOINT ["envconsul", "-prefix", "dev/Sirus.Poc.Consul.Backend.RestApi", "-consul-addr", "host.docker.internal:8500", "dotnet", "Sirus.Poc.Consul.Backend.RestApi.dll"]