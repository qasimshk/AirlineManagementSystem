#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["airline.flightdetail.api/airline.flightdetail.api.csproj", "airline.flightdetail.api/"]
COPY ["airline.management.sharedkernal/airline.management.sharedkernal.csproj", "airline.management.sharedkernal/"]
RUN dotnet restore "airline.flightdetail.api/airline.flightdetail.api.csproj"
COPY . .
WORKDIR "/src/airline.flightdetail.api"
RUN dotnet build "airline.flightdetail.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "airline.flightdetail.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "airline.flightdetail.api.dll"]