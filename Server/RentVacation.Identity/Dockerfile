#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RentVacation.Identity/RentVacation.Identity.csproj", "RentVacation.Identity/"]
COPY ["RentVacation.Common/RentVacation.Common.csproj", "RentVacation.Common/"]
RUN dotnet restore "RentVacation.Identity/RentVacation.Identity.csproj"
COPY . .
WORKDIR "/src/RentVacation.Identity"
RUN dotnet build "RentVacation.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentVacation.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentVacation.Identity.dll"]