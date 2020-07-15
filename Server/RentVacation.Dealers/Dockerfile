#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RentVacation.Dealers/RentVacation.Dealers.csproj", "RentVacation.Dealers/"]
COPY ["RentVacation.Common/RentVacation.Common.csproj", "RentVacation.Common/"]
RUN dotnet restore "RentVacation.Dealers/RentVacation.Dealers.csproj"
COPY . .
WORKDIR "/src/RentVacation.Dealers"
RUN dotnet build "RentVacation.Dealers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentVacation.Dealers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentVacation.Dealers.dll"]