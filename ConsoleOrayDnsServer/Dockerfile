FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ConsoleOrayDnsServer/ConsoleOrayDnsServer.csproj", "ConsoleOrayDnsServer/"]
RUN dotnet restore "ConsoleOrayDnsServer/ConsoleOrayDnsServer.csproj"
COPY . .
WORKDIR "/src/ConsoleOrayDnsServer"
RUN dotnet build "ConsoleOrayDnsServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ConsoleOrayDnsServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ConsoleOrayDnsServer.dll"]