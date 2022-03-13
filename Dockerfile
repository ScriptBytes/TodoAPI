FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env

# Copy csproj and restore as distinct layers
COPY ./TodoAPI/TodoAPI.csproj ./TodoAPI/TodoAPI.csproj
COPY *.sln .
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o build --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env ./build .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT [ "dotnet", "TodoAPI.dll" ]