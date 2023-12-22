FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DocManager.Core.Domain/DocManager.Core.Domain.csproj", "DocManager.Core.Domain/"]
RUN dotnet restore "DocManager.Core.Domain/DocManager.Core.Domain.csproj"
COPY . .
WORKDIR "/src/DocManager.Core.Domain"
RUN dotnet build "DocManager.Core.Domain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocManager.Core.Domain.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocManager.Core.Domain.dll"]
