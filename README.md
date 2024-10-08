﻿# Proyecto desafio tecnico Api .Net con Vue.js

**Descripción:**
Este proyecto es una aplicación cuya finalidad es mostrar algunas competencias tecnicas, segun requerimiento con api .net y patron elegido fue repository, con migrations para facilitar la creacion de la base de datos mysql. Y por ultimo un frontend VUE para el consumo de la api

**Tecnologías:**
* .Net Core 6
* Vue.js 3
* Bootstrap 5
* Mysql

**Instalación:**

1. Clonar el repositorio:
   ```bash
   git clone git@github.com:imiranda/test_paynau.git

2. ir a carpeta:
   ```bash
   cd /test_paynau

3. Ejecutar el comando para levantar los 2 proyectos:
   ```bash
   docker-compose up -d

3. ir a navegador y veras las rutas en swagger documentando el backend:
   ```bash
   https://localhost:44393/swagger/index.html

4. ir a navegador para ver el frontend:
   ```bash
   http://localhost:8080

**Instalación sin contenedores:**

1. Clonar el repositorio:
   ```bash
   git clone git@github.com:imiranda/test_paynau.git

2. ir a carpeta:
   ```bash
   cd /test_paynau

3. para ejecutar el backend, ir a carpeta:
   ```bash
   cd /test_api_paynau

4. Verificar credenciales declaradas en cadena de conexiona mysql en archivo appsettings.json en la raiz del proyecto:
   ```bash
   "Server=localhost;Database=test_paynau_im;User=root;Password=;"

5. Ejecutar migracion para creacion de base de datos y objetos necesarios en mysql:
   ```bash
   dotnet ef database update

6. Para ejecutar el proyecto, puedes utilizar visual studio o la misma consola que estas usando con el comando:
   ```bash
   dotnet run

7. ir a navegador y veras las rutas en swagger:
   ```bash
   https://localhost:44393/swagger/index.html

8. En una nueva (tab) consola iremos a ejecutar el frontend, ir a carpeta si estas en la raiz del proyecto:
   ```bash
   cd /test_front_paynau

9. instalar dependencias Vue:
   ```bash
   npm install

10. Ejecutar frontend vue:
   ```bash
   npm run serve

11. ir a navegador:
   ```bash
   http://localhost:8080
