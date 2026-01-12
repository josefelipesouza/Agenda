FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Agenda.sln ./
COPY Api.API/*.csproj Api.API/
COPY Api.Application/*.csproj Api.Application/
COPY Api.Infrastructure/*.csproj Api.Infrastructure/
COPY Api.Domain/*.csproj Api.Domain/
COPY Api.Authentication/*.csproj Api.Authentication/

RUN dotnet restore

COPY . .
WORKDIR /src/Api.API
RUN dotnet publish -c Release -o /app/publish

FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Api.API.dll"]
