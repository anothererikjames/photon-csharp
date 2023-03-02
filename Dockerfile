FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /photon/
COPY . ./
ENV CONTAINER=true
