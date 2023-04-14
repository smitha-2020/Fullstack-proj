FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /backend
COPY ./Publish ./
EXPOSE 5000
CMD dotnet backend.dll