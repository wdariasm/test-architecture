#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TicketManagement.Api/TicketManagement.Api.csproj", "TicketManagement.Api/"]
RUN dotnet restore "TicketManagement.Api/TicketManagement.Api.csproj"
COPY . .
WORKDIR "/src/TicketManagement.Api"
RUN dotnet build "TicketManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketManagement.Api.dll"]