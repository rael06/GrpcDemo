FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcDemo.Client/GrpcDemo.Client.csproj", "GrpcDemo.Client/"]
RUN dotnet restore "GrpcDemo.Client/GrpcDemo.Client.csproj"
COPY . .
WORKDIR "/src/GrpcDemo.Client"
RUN dotnet build "GrpcDemo.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcDemo.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcDemo.Client.dll"]
