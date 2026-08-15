# Servicio de Facturación

Este proyecto es una base educativa creada para seguir un tutorial de YouTube sobre ASP.NET Core Razor Pages, con un enfoque práctico en la construcción de un sistema de facturación.

Es un proyecto pensado para aprender paso a paso, no como una implementación terminada de negocio. La idea es ir ampliando la aplicación con nuevas funcionalidades a medida que se explican conceptos fundamentales de ASP.NET Core.

## Propósito del proyecto

Este repositorio sirve como punto de partida para:

- aprender los fundamentos de ASP.NET Core
- entender el patrón de Razor Pages
- explorar la estructura básica de una aplicación web
- ir construyendo una aplicación de facturación desde cero
- usarlo como soporte visual y práctico para una explicación en video

## Tipo de proyecto

Se trata de una aplicación web ASP.NET Core con Razor Pages.

Razor Pages es un modelo de programación de ASP.NET Core orientado a páginas web. En lugar de separar completamente la lógica de negocio y la interfaz en una gran cantidad de archivos, esta arquitectura organiza el proyecto en:

- páginas (.cshtml)
- modelos de página (.cshtml.cs)
- archivos compartidos de diseño, como layouts
- servicios y configuración del sistema

## Estructura básica de este tipo de proyectos

Una aplicación Razor Pages normalmente tiene una estructura similar a esta:

- `Program.cs`: punto de entrada de la aplicación. Aquí se configura la aplicación, se registran servicios y se inicializa el pipeline HTTP.
- `Pages/`: carpeta donde viven las páginas de la aplicación. Cada página suele incluir:
  - un archivo `.cshtml` con la interfaz HTML
  - un archivo `.cshtml.cs` con la lógica de la página (PageModel)
- `Pages/Shared/`: archivos reutilizables para toda la app, como layouts y componentes compartidos
- `wwwroot/`: archivos estáticos como CSS, JavaScript e imágenes
- `appsettings.json`: configuración general de la aplicación

## Enfoque educativo

Este proyecto está diseñado para una finalidad didáctica:

- explicar conceptos básicos de manera clara
- mostrar el flujo de una petición web
- demostrar cómo se conecta la vista con el código
- introducir dependency injection, configuración y rutas
- servir como base para agregar funcionalidad más adelante

## Nota

El contenido de este repositorio es principalmente educativo y puede ser modificado, extendido o reestructurado durante el desarrollo del tutorial.

La intención no es entregar una solución comercial lista para producción, sino seguir una progresión de aprendizaje útil para principiantes en ASP.NET Core.
