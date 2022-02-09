#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["airline.management.api/airline.management.api.csproj", "airline.management.api/"]
COPY ["airline.management.sharedkernal/airline.management.sharedkernal.csproj", "airline.management.sharedkernal/"]
COPY ["airline.management.infrastructure/airline.management.infrastructure.csproj", "airline.management.infrastructure/"]
COPY ["airline.management.domain/airline.management.domain.csproj", "airline.management.domain/"]
COPY ["airline.management.abstractions/airline.management.abstractions.csproj", "airline.management.abstractions/"]
COPY ["airline.management.application/airline.management.application.csproj", "airline.management.application/"]
RUN dotnet restore "airline.management.api/airline.management.api.csproj"
COPY . .
WORKDIR "/src/airline.management.api"
RUN dotnet build "airline.management.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "airline.management.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "airline.management.api.dll"]