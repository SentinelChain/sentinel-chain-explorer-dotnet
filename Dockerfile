# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source
COPY *.sln .
COPY NethereumBlazor/. ./NethereumBlazor/
RUN dotnet build

#FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /source/NethereumBlazor/
CMD dotnet run --framework netstandard2.1

