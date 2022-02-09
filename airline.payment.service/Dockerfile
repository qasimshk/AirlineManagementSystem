#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["airline.payment.service/airline.payment.service.csproj", "airline.payment.service/"]
COPY ["airline.management.sharedkernal/airline.management.sharedkernal.csproj", "airline.management.sharedkernal/"]
COPY ["airline.management.abstractions/airline.management.abstractions.csproj", "airline.management.abstractions/"]
RUN dotnet restore "airline.payment.service/airline.payment.service.csproj"
COPY . .
WORKDIR "/src/airline.payment.service"
RUN dotnet build "airline.payment.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "airline.payment.service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "airline.payment.service.dll"]