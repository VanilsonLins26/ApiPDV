# Use o SDK do .NET 9 para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia o arquivo do projeto e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos e publica a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Usa a imagem mais leve só com runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copia a aplicação compilada da etapa build
COPY --from=build /app/out .

# Expõe a porta 80
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "ApiPDV.dll"]
