#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["airline.notification.service/airline.notification.service.csproj", "airline.notification.service/"]
COPY ["airline.management.sharedkernal/airline.management.sharedkernal.csproj", "airline.management.sharedkernal/"]
COPY ["airline.management.abstractions/airline.management.abstractions.csproj", "airline.management.abstractions/"]
RUN dotnet restore "airline.notification.service/airline.notification.service.csproj"
COPY . .
WORKDIR "/src/airline.notification.service"
RUN dotnet build "airline.notification.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "airline.notification.service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "airline.notification.service.dll"]