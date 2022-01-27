FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcDemo.Server/GrpcDemo.Server.csproj", "GrpcDemo.Server/"]
RUN dotnet restore "GrpcDemo.Server/GrpcDemo.Server.csproj"
COPY . .
WORKDIR "/src/GrpcDemo.Server"
RUN dotnet build "GrpcDemo.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcDemo.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcDemo.Server.dll"]
