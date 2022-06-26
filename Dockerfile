FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR .
COPY ["AlugaCarros.BalcaoAtendimento.BFF/AlugaCarros.BalcaoAtendimento.BFF.csproj", "./AlugaCarros.BalcaoAtendimento.BFF/"]

RUN dotnet restore "AlugaCarros.BalcaoAtendimento.BFF/AlugaCarros.BalcaoAtendimento.BFF.csproj"
COPY . .
WORKDIR "AlugaCarros.BalcaoAtendimento.BFF"
RUN dotnet build "AlugaCarros.BalcaoAtendimento.BFF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlugaCarros.BalcaoAtendimento.BFF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlugaCarros.BalcaoAtendimento.BFF.dll"]