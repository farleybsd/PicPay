#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y curl
USER app
WORKDIR /app
EXPOSE 443
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PicPay.Simplificado.Api/PicPay.Simplificado.Api.csproj", "PicPay.Simplificado.Api/"]
COPY ["PicPay.Simplificado.Application/PicPay.Simplificado.Application.csproj", "PicPay.Simplificado.Application/"]
COPY ["PicPay.Simplificado.Domain/PicPay.Simplificado.Domain.csproj", "PicPay.Simplificado.Domain/"]
COPY ["PicPay.Simplificado.Domain.Core/PicPay.Simplificado.Domain.Core.csproj", "PicPay.Simplificado.Domain.Core/"]
COPY ["PicPay.Simplificado.Infrastructure/PicPay.Simplificado.Infrastructure.csproj", "PicPay.Simplificado.Infrastructure/"]
COPY ["PicPay.Simplificado.Service/PicPay.Simplificado.Service.csproj", "PicPay.Simplificado.Service/"]
RUN dotnet restore "PicPay.Simplificado.Api/PicPay.Simplificado.Api.csproj"
COPY . .
RUN dotnet build "PicPay.Simplificado.Api/PicPay.Simplificado.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PicPay.Simplificado.Api/PicPay.Simplificado.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PicPay.Simplificado.Api.dll"]

#cd /mnt/c/Git/PicPay/PicPay.Simplificado/src
#docker build -f PicPay.Simplificado.Api/Dockerfile -t picpay.simplificado .
