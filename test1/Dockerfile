FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY test1.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish_self -r linux-x64 --self-contained -p:PublishSingleFile=false -p:PublishTrimmed=true

FROM ubuntu AS final
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
WORKDIR /app
COPY --from=build /app/publish_self .
EXPOSE 8001
CMD ["./test1"]