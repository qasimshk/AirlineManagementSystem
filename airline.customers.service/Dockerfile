#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["airline.customers.service/airline.customers.service.csproj", "airline.customers.service/"]
COPY ["airline.management.sharedkernal/airline.management.sharedkernal.csproj", "airline.management.sharedkernal/"]
COPY ["airline.management.abstractions/airline.management.abstractions.csproj", "airline.management.abstractions/"]
RUN dotnet restore "airline.customers.service/airline.customers.service.csproj"
COPY . .
WORKDIR "/src/airline.customers.service"
RUN dotnet build "airline.customers.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "airline.customers.service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "airline.customers.service.dll"]