# Prueba Tecnica para Backend - Bancosol

El repositorio actual contiene los recursos necesarios para desplegar apis rest usando clean architecture y una base de datos postgres; ademas contiene un api de ejemplo que se integra con un servicio externo (pokeapi) para guiar y facilitar el desarrollo de la prueba.

## Manual de Instalacion

### Despliegue de base de datos
Para desplegar la base de datos debes ejecutar el comando `docker compose up -d`, esto te desplegara las siguientes herramientas:
- Postgres
- Sql Server
- Redis

Puedes revisar las credenciales de cada base de datos en el [docker compose](/docker-compose.yml).
> Las bases de datos **NO** usan volumes, por lo que si borras o reinicias los contenedores, tambien se **borraran los datos.**

### Comandos

#### Migraciones


Usando el proyecto predeterminado `Infraestructura` en la consola de administrador de paquetes nuget:

crear una migracion:
- `add-migration <nombre de la migracion>`

ejecutar una migracion: 
- `Update-Database`

