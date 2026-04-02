# Flujo de trabajo para el proyecto

Este documento sirve para describir los pasos necesarios con los que se implementarán y desarrollaran las funciones dentro del proyecto.

## Modo de trabajo

### Paso 1: Identificar la zona de trabajo

Lo primero de todo será concretar sobre qué nos estaremos basando. ¿Es un arma? ¿Un nuevo objeto? ¿Un nuevo sistema de diálogo para el juego? Dependiendo de lo que estaremos buscando hacer tendremos que focalizarnos en una zona concreta del proyecto.

### Paso 2: Identificar los requisitos del desarrollo

Este paso es más sencillo. Consiste en entender si lo que estamos buscando realizar consiste en una implementación final, una clase base (o interfaz), o si se trata de una sección totalmente nueva.

Dependiendo de la respuesta que encontremos, tendremos que asegurarnos de que tenemos todo lo necesario para poder hacerlo. Si queremos hacer un arma pero resulta que la clase base necesaria no está preparada todavía, hará falta esperar a que se haga, pedírsela a otro compañero, o implementarla uno mismo. O, si resulta que la sección sobre la que se piensa trabajar todavía no está contemplada en la estructura de carpetas, hará falta también actualizar el **README.md** para asegurarnos de que nuestros cambios se vean reflejados para las siguientes implementaciones.

---

## Creación de rama

Una vez identificada la tarea que se va a realizar, se deberá crear una nueva rama a partir de la rama principal de desarrollo `main`.


Antes de crear una nueva rama, se debe asegurar que la rama base está actualizada.

### Actualizar rama base

```bash
git checkout main
git pull origin main
```

Esto recogerá todos los cambios del repositorio de la rama `main`.

Para crear una nueva rama, ahora sí, se realizará con el siguiente comando:

```bash
git checkout -b nombre-rama
```

Además de crearla, automáticamente te moverá a ella para empezar a trabajar.

### Nomenglatura de los nombres

El nombre de la rama deberá seguir una convención clara y descriptiva que permita identificar rápidamente el objetivo del cambio.

Formato recomendado:

```
tipo/nombre-descriptivo
```

Ejemplos:

```
feature/nueva-arma-laser
bugfix/error-colision-enemigos
refactor/sistema-inventario
docs/actualizacion-readme
```

Es recomendable que miréis las ramas ya creadas para ver si ya existe una categoría específica para lo que vayáis a hacer. En general:
- feature: una implementación completamente nueva.
- bugfix: un error encontrado que ha sido arreglado.
- refactor: cambio en el código, no necesariamiente porque falle, sino para mejorarlo de algún modo u otro.
- docs: cualquier tipo de cambio en la documentación, comentarios, ect.

## Permisos de rama

Las ramas, por lo general, no tendrán permisos específicos, ya que confío en vosotros (no me seáis cabrones).

Lo que *sí* que hay que tener en cuenta es que la rama `main` se va a usar única y exclusivamente para subir las versiones del juego estables y que funcionen correctamente. Por tanto, evitar subir cambios directamente a `main` siempre que sea posible.

Antes de fusionar una rama en la principal:

- El código deberá compilar correctamente.
- No deberá contener errores conocidos.
- Se deberán haber resuelto los posibles conflictos.
- El código deberá ser revisado por otro miembro del equipo (si aplica).

Si existen conflictos durante la fusión, deberán resolverse manualmente antes de completar el proceso.

### Como mergear ramas

Para poder *mergear*, primero hay que moverse a la rama a la que queremos llevar nuestros cambios, que casi siempre será `main`:

```
git checkout rama-destino
```

Nos aseguramos de que esté actualizada:

```
git pull
```

Una vez estando allí, ejecutamos el siguiente comando:

```
git merge rama-a-fusionar
```

Esto debería subir a la rama todos los cambios de la rama que queramos unir, eliminando esa rama que hayamos creado adicional.

Por último, subimos los cambios:

```
git push origin rama-destino
```

Todo este proceso debe realizarse **al pie de la letra**, a no ser que queráis que el coordinador os haga un fisting con las dos manos. Sin embargo, dicho coordinador (el menda) se ofrece a realizar todos los merge que sean necesarios y controlar los conflictos que pudieran surgir.

> ¡Ojo! que el coordinador se ofrezca a hacer los merges no implica que no se produjeran los fistings en caso de que la rama genere más conflictos que pelo me queda en la cabeza

## Traer cambios

Ya se han mencionado todos los comandos necesarios, así que en este apartado no los voy a repetir porque me da pereza.

Para traer cambios se usa `git pull` como ya se ha visto, pero hay un caso especial. Es posible que alguien esté trabajando en una rama, y durante ese tiempo se haya subido una versión nueva a `main`. Si, para aseguraros de que todo va bien, queréis conseguir todos los otros cambios que se hayan subido, basta con hacer el proceso inverso que se ha mencionado antes para poder mergear los cambios nuevos a la rama en la que uno esta trabajando.

Es decir:
1. Nos movemos a la rama main.
2. Hacemos un pull para asegurarnos de que la tenemos actualizada.
3. Nos movemos a la rama en la que estemos trabajando.
4. Hacemos un git merge

Este proceso debería añadir a la rama en la que estés trabajando todos los cambios nuevos que se hayan subido a `main`. También pueden producirse conflictos de mergeo en este caso, así que tened cuidado.

## Consideraciones

Como se puede apreciar en este documento, usar git es al mismo tiempo una bendición y una maldición. Aquí os dejo una pequeña lista de consejos a seguir (o no) para cuando vayáis a programar:

- **Crearos siempre una rama antes**, por muy estúpido que os parezca el cambio. Da igual que hayan 300.000 ramas, al irse mergeando con el main irán desapareciendo y luego podremos tener todos los cambios bien organizados y saber qué ha explotado, cómo, cuándo y dónde.
- **Subid en la rama solo los cambios que sean necesarios**: aseguraros de trabajar siempre con un código que luego se pueda usar para cualquier caso. Podéis crearos ejemplos de prueba, dummies, y lo que queráis para testear, pero todo ese código no debe de aparecer en la rama porque luego al subirse podría dar conflicto con otro código que ya estuviera subido y generar problemas.
- **Mirad qué archivos se van a subir a la rama**: relacionado con lo anterior. Mantener código que vosotros tengáis en local y que el resto del equipo no es extremadamente fácil. Lo único de lo que tenéis que preocuparos es de que esos archivos no se suban a la rama cuando vayáis a hacer el commit, y San Seacabó. Así podréis tener quinientos archivos de Player si os da la gana, y no daréis problemas a nadie que quiera hacer cambios en otras zonas.
- **Avisad cuando sea posible**: no es obligatorio y tampoco pasa nada, pero no está de más que pongáis algo por el discord mismamente para que el resto sepa que se han subido nuevos cambios. No tiene que ser para cada cosa, como armas u objetos... pero si se tratan de cosas más importantes como generación de mapas u otros apartados pues sin problema.
- **Haced commits pequeños**: Tomad como ejemplo cada cuánto hacíamos commmits en SD. Por lo general, suele venir bien tener commits pequeños y que tengan sentido, como una función nueva, o un cambio en específico, porque así volver hacia atrás si hace falta es mucho más sencillo. Si no, volver atrás con un commit gigantesco implica tener que guardar todo el código que no quisiéramos deshacer y volverlo a pegar. No es el fin del mundo pero sí un coñazo.

## Eso es todo

![atencion](m.jpg)