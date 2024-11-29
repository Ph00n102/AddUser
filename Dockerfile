FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env
WORKDIR /HosxpUi
COPY HosxpUi.csproj .
RUN dotnet restore "HosxpUi.csproj"
COPY / .
RUN dotnet build "HosxpUi.csproj" -c Release -o /build
FROM build-env AS publish
RUN dotnet publish "HosxpUi.csproj" -c Release -o /publish
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /publish/wwwroot /usr/local/webapp/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf