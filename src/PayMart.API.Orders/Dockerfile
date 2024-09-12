FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY ./PayMart.Domain.Orders/PayMart.Domain.Orders.csproj ./PayMart.Domain.Orders/
COPY ./PayMart.Infrastructure.Orders/PayMart.Infrastructure.Orders.csproj ./PayMart.Infrastructure.Orders/
COPY ./PayMart.API.Orders/PayMart.API.Orders.csproj ./PayMart.API.Orders/
RUN dotnet restore ./PayMart.API.Orders/PayMart.API.Orders.csproj

COPY ./PayMart.Domain.Orders ./PayMart.Domain.Orders/
COPY ./PayMart.Infrastructure.Orders ./PayMart.Infrastructure.Orders/
COPY ./PayMart.API.Orders ./PayMart.API.Orders/

WORKDIR /app/PayMart.API.Orders
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/PayMart.API.Orders/out .

EXPOSE 5003

ENTRYPOINT ["dotnet", "PayMart.API.Orders.dll"]
