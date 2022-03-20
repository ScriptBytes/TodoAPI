FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env

# Copy csproj and restore as distinct layers
COPY ./TodoAPI/TodoAPI.csproj ./TodoAPI/TodoAPI.csproj
COPY *.sln .
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o build --no-restore

ARG MIGRATION_CONNECTION
RUN dotnet ef database update --connection $MIGRATION_CONNECTION

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env ./build .
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
ENTRYPOINT [ "dotnet", "TodoAPI.dll" ]