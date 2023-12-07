FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
LABEL maintainer="André Da Silva Aquilau"
WORKDIR /workspace/api
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /workspace/src
COPY . .
RUN dotnet restore ./MyFinanceWeb.Web/MyFinanceWeb.Web.csproj
RUN dotnet build ./MyFinanceWeb.Web/MyFinanceWeb.Web.csproj -c Release -o ./MyFinanceWeb.Web/build

FROM build AS publish
RUN dotnet publish ./MyFinanceWeb.Web/MyFinanceWeb.Web.csproj -c Release -o ./MyFinanceWeb.Web/publish

# Build runtime image
FROM base AS final
WORKDIR /workspace/api
COPY --from=publish /workspace/src/MyFinanceWeb.Web/publish .
CMD ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT ASPNETCORE_URLS="http://*:$PORT" dotnet MyFinanceWeb.Web.dll 