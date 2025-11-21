<h1 align="center"><em>Sport Event Manager</em></h1>

<p align="center">
  <img src="https://img.shields.io/badge/Plataforma-.NET_9-purple" />
  <img src="https://img.shields.io/badge/Frontend-Blazor_Server-blueviolet" />
  <img src="https://img.shields.io/badge/Frontend-WebAssembly_MVC-blue" />
  <img src="https://img.shields.io/badge/Base_de_datos-SQLite-green" />
  <img src="https://img.shields.io/badge/ORM-Entity_Framework_Core-orange" />
</p>

---

## 👟 Descripción del proyecto
**Sport Event Manager** es un sistema desarrollado en **.NET 9**, pensado para gestionar eventos deportivos (carreras), usuarios e inscripciones.

El proyecto integra:
- Una aplicación **Blazor Server (Razor Components)** para la administración.
- Una aplicación **ASP.NET MVC WebAssembly** para la parte pública.

Incluye manejo de usuarios, eventos, inscripciones, gestión de datos y un backend sólido con Entity Framework Core + SQLite.

---

## 👟 Tecnologías utilizadas

- `.NET 9`
- `ASP.NET Core 9`
- `Blazor Server`
- `ASP.NET WebAssembly MVC`
- `Entity Framework Core`
- `SQLite Express`
- `Bootstrap`
- `Razor Components`

## 👟 Funcionalidades del proyecto

- `Gestión de eventos`: creación, edición, eliminación y visualización de carreras/eventos.
- `Gestión de usuarios`: registro, login, seguimiento de su estado en la carrera.
- `Inscripciones`: los usuarios pueden ser inscriptos a eventos disponibles.
- `Administración`: panel con herramientas para manejar datos, usuarios y eventos.
- `WebAssembly público`: parte de cara al usuario final con MVC.
- `Reportes básicos`: listado de inscriptos, detalles por evento, etc.

## 👟 Estructura del proyecto
```
Taller_Eventos_PuntoNet/
│
├── wwwroot/               → Archivos estáticos (css, js, img, bootstrap)
│
├── Components/
│   ├── Data/              → DbContext, acceso a datos
│   ├── Layout/            → Layouts visuales
│   ├── Models/            → Entidades del dominio
│   ├── Pages/             → Componentes y páginas .razor
│   └── Services/          → Servicios y lógica del negocio
│
├── Migrations/            → Migraciones EF Core
├── Pages/                 → _Host.cshtml
├── appsettings.json       → Configuración y SQLite
├── libman.json            → Librerías front-end
└── Program.cs             → Configuración general
```


---

## 👟 Características de la aplicación y demostración
### ▫️ Diagrama de Clases
<img style="vertical-align:middle" width="603" height="915" alt="image" src="https://github.com/user-attachments/assets/3d392e30-8525-4f88-85c3-8f2b53946b21" />
