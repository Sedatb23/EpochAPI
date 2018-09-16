FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["EpochApi/EpochApi.csproj", "EpochApi/"]
RUN dotnet restore "EpochApi/EpochApi.csproj"
COPY . .
WORKDIR "/src/EpochApi"
RUN dotnet build "EpochApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EpochApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EpochApi.dll"]