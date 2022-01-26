#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#use cmd "docker build" in one level up "solution folder" of the dockerfile path to be able to acces other projects
#docker build -t melharfi/storemanagementapi:latest -f StoreManagement.API/Dockerfile .
#docker run -d --name storemanagementapi -p 9080:80 melharfi/storemanagementapi:latest


FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StoreManagement.API/StoreManagement.API.csproj", "StoreManagement.API/"]
COPY ["StoreManagement.Domain/StoreManagement.Domain.csproj", "StoreManagement.Domain/"]
COPY ["StoreManagement.Application/StoreManagement.Application.csproj", "StoreManagement.Application/"]
COPY ["StoreManagement.Core.Domain/StoreManagement.Core.Domain.csproj", "StoreManagement.Core.Domain/"]
COPY ["StoreManagement.Data.Infrastructure/StoreManagement.Data.Infrastructure.csproj", "StoreManagement.Data.Infrastructure/"]
COPY ["StoreManagement.Data.EF.Infrastructure/StoreManagement.Data.EF.Infrastructure.csproj", "StoreManagement.Data.EF.Infrastructure/"]
RUN dotnet restore "StoreManagement.API/StoreManagement.API.csproj"
COPY . .
WORKDIR "StoreManagement.API"
RUN dotnet build "StoreManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreManagement.API.dll"]