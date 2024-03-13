# Prueba técnica para Desarrollador .NET ARKEERO

### Autor: Brayan Badillo Diaz
#### Esp. Ingenieria de Software | Ing. Electronico

## Instrucciones:

* La prueba consta de tres secciones: Desarrollo de código, Diseño y Arquitectura, y Preguntas de concepto.
* Se espera que completes todas las secciones dentro del tiempo asignado.
* Utiliza C# para el desarrollo de código.
* Documenta tus decisiones de diseño y arquitectura.
* Considera las mejores prácticas de codificación y patrones de diseño.

## Sección 1: Desarrollo de Código

**Crear una aplicación MVC:**

* Crea una aplicación MVC básica utilizando .NET 8.
* La aplicación debe tener una página de inicio que muestre un mensaje de bienvenida y un enlace a una lista de productos.
 
**Integración con PostgreSQL:**

* Implementa un modelo de datos para gestionar productos en una base de datos PostgreSQL.
* Crea una migración para inicializar la base de datos.
* Implementa un repositorio utilizando el patrón repositorio para interactuar con la base de datos y realizar operaciones CRUD en los productos.

**Interfaz de Usuario con Bootstrap y JavaScript:**  

* Diseña una interfaz de usuario para mostrar la lista de productos utilizando Bootstrap para estilos.
* Implementa funcionalidades adicionales utilizando JavaScript para mejorar la experiencia del usuario, como la capacidad de agregar nuevos productos sin recargar la página.

## Sección 2: Diseño y Arquitectura

**Uso de AutoMapper:**

* Implementa AutoMapper para mapear los modelos de datos de la base de datos a modelos de vista en la capa de presentación.

**Patrón Mediator con Entity Framework y LINQ:**

* Utiliza el patrón Mediator junto con Entity Framework y LINQ para separar las responsabilidades en la capa de servicio y realizar consultas a la base de datos.

## Sección 3: Preguntas de Concepto

**Responde las siguientes preguntas brevemente:**

* ¿Qué es el patrón repositorio y cuál es su utilidad en el desarrollo de software?
* Explica el propósito de CI/CD y menciona algunas herramientas populares para implementarlo en proyectos .NET.
* ¿Qué es AutoMapper y en qué situaciones es útil?
* ¿Qué es el patrón Mediator? ¿Cuáles son las ventajas de utilizarlo?

## Solucion
## Sección 1: Desarrollo de Código
[Documentacion del Proyecto ](./Document.md)

### Sección 3: Preguntas de Concepto
#### ¿Qué es el patrón repositorio y cuál es su utilidad en el desarrollo de software?

Es una abstraccion de la capa de datos, en pocas palabras un repositorio es como una caja la cual nos puede servir para recibir como para enviar datos a nuestra base de datos o donde persistamos la data, una de las ventajas de este patron es que le es indifirente el motor de base de datos que se este utilizando porque estamos abstrayendo la implementacion. Es importante este patron debido a que podremos realizar migraciones sin tanto esfuerzo, podriamos tener varias fuentes de datos y facilitan la realizacion del testing.

___La princial utilidad es tener un codigo mucho mas limpio, legible y mas facil de mantener y como lo menciono anteriormente facilita la migracion a otros motores de base de datos, facilita las pruebas unitarias.___

 #### Explica el propósito de CI/CD y menciona algunas herramientas populares para implementarlo en proyectos .NET.

 Integracion Continua y despliegue Continuo, el proposito princial es reducir los errores durante la integracion y la implementacion mientras se aumenta la velocidad del proyecto, en pocas palabras se simplifica el proceso de llevar el nuevo codigo desde la creacion hasta su despliegue en produccion o ambiente requerido, en lugar de hacerlo manualmente, porque hace que las partes complicadas del proceso se automaticen, haciendo que el equipo sea mas eficiente debido a que las pruebas y despliegue del software quedo automatizado.

 ___Herramientas populares CI/CD en .NET:___
 
 * Azure Devops (Pipelines) 
 * Jenkis
 * AWS (Aws CodePipeline)
 * GitLab CI/CD

 #### ¿Qué es AutoMapper y en qué situaciones es útil?

AutoMapper es una de las librerias mas famosa para mapear objetos dentro de .NET, esta libreria nos ayuda como desarrolladores a no tener que mapear los objetos de forma manual, por lo que esta libreria nos ayuda a mapear objetos entre si, en pocas palabras nos ayuda a copiar los datos de un objeto a otro de forma automatica agilizando el proceso de desarrollo del software.

___Es util utilizar AutoMapper cuando necesitemos asignar o copiar datos entre objetos de diferentes tipos, como lo podria ser:___
1. Mapeo entre entidades y DTOs.
2. Mapeos entre modelos de vista y modelos de dominio hablando de aplicaciones MVC. 
3. Para transformar datos de un formato a otro en solicitudes del tipo HTTP.
4. Para evitar codigo repetitivo y poder implementar Clean Code y principios Solid.

#### ¿Qué es el patrón Mediator? ¿Cuáles son las ventajas de utilizarlo?

Es un patron de comportamiento el cual nos permite la comunicacion de varios objetos entre si, sin que ninguno de estos objetos conozca la estructura de los otros, este patron tambien llamado coodirnador es el que se encarga de manejar la comunicacion o trafico entre las partes que forman la estructura principal y que se defina en la logica de nuestro codigo. En resumidas palabras es quien ayuda a objetos a comunicarse con otros objetos enrutandolos y comunicandose con los el resto de objetos, esto hace que el mantenimiento sea relativamente sencillo y que es debilmente acoplado.

___Como lo menciono anteriormente sus principales ventajas son:___

1. Desacoplar componentes pero aun asi permitir su comunicacion entre si atraves del mediador.
2. Sencilles al desarrollar el software.
3. Mantenimiento sencillo.
4. Implemntear pruebas de forma mas sencilla.
