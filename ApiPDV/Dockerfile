# Use o SDK do .NET 9 para construir a aplica��o
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia o arquivo do projeto e restaura depend�ncias
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos e publica a aplica��o
COPY . ./
RUN dotnet publish -c Release -o out

# Usa a imagem mais leve s� com runtime para rodar a aplica��o
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copia a aplica��o compilada da etapa build
COPY --from=build /app/out .

# Exp�e a porta 80
EXPOSE 80

# Comando para rodar a aplica��o
ENTRYPOINT ["dotnet", "ApiPDV.dll"]
