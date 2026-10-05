FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MiniEcommerce.Api.csproj", "./"]
RUN dotnet restore "MiniEcommerce.Api.csproj"
COPY . .
RUN dotnet publish "MiniEcommerce.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MiniEcommerce.Api.dll"]