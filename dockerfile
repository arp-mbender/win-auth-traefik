FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019
EXPOSE 80

COPY . c:\\build\\server

WORKDIR c:\\build\\server
RUN dotnet publish WindowsLoginSample.csproj --output c:\\server

RUN net user test /ADD
USER test

WORKDIR c:\\server
CMD dotnet WindowsLoginSample.dll --urls=http://*:80