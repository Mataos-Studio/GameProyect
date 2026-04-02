# Flujo de trabajo y documentación del proyecto

Este documento recopila toda la información necesaria para poder entender la estructura de este proyectto, así como los pasos necesarios para poder implementar cualquier nueva funcionalidad.

Es *importantísimo*, por ende, que cada vez que se realice un cambio mayor en el proyecto se actulice este documento para poder facilitar el trabajo en el futuro.

## Estructuración del Proyecto

### Scripts

En lo referente al apartado de programación, dentro de la carpeta **Scripts** encontramos una serie de carpetas que ayudan a separar cada apartado de este proyecto en diferentes secciones. Cada sección se encarga de una tarea concreta para este proyecto:

- **Base**: Almacena la/s clase/s base necesaria/s para la fundación del resto de secciones. Una clase, abstracta o no, o interfaz, se incluirá en **Base** siempre que se cumpla que sirva para diferentes secciones del proyecto (no cuenta que sea referenciado en direfentes secciones), y por tanto no se explica correctamente su funcionamiento en caso de que se añadiera a cualquiera de esas secciones.
- **Interaction**: Constituye todos los elementos dentro del juego con los que el usuario pueda interactuar. La acción de interactuar puede consistir tanto en que el usuario simplemenete pase por encima del elemento, como que tenga que pulsar un botón en específico. Cualquier objeto dentro del ambiente del juego que reaccione ante la presencia del usuario al encontrarse cerca de este se considerará como *Interactable*
    - **Collectable**: Dentro de la categoría de objetos interactuables, en **Collectable** se encuentran aquellos que puedan ser recogidos por parte del usuario, y por tanto, puedan desaparecer o no de la pantalla una vez sean recogidos.
        - **Items**: Elementos pasivos, objetos conocidos como *pasivas* en los *roguelike*, que apliquen cambios al jugador de algún modo al ser recogidos.
        - **Weapons**: Armas que el jugador pueda utilizar para atacar a otros enemigos.
- **Movement**: Todo código que se utilice para el desplazamiento de un elemento en el espacio del juego. Esto no se limita únicamente al jugador, sino cualquier cosa, ya sea NPC o un objeto incluso, que requiera de movimiento para que se cumpla su función.
- **Text**: Sección encargada de la interfaz gráfica del juego, en concreto, para todos los elementos que incluyan un texto que se muestre por la pantalla.
    - **TextRetreaving**: Clases y funciones necesarias para poder obtener las cadenas de texto adecuadas en el idioma correspondiente, usando como referencia un archivo que se ubique dentro de los recursos del juego.


> Las secciones que se encuentran actualmente listadas no son todas las que terminarán siendo. Es normal que este archivo sea actualizado con nuevas zonas conforme se vayan expandiendo las funcionalidades, y es necesario hacerlo de manera que sea totalmente limpio y modular. También corresponde mantener el orden ya establecido respecto a las diferentes secciones.


Cada una de estas secciones debería, a su vez, disponer de una carpeta llamada **Implementations** para almacenar ahí todas las implementaciones finales del código de la susodicha sección. Es decir, el código para armas finales, objetos, pasivas... y todo aquello que sea un único elemento y no sirva como código abstracto para nuevas implementaciones.

Dentro de esta carpeta, la distribuición sería acorde a la sección establecida. Por ejemplo, podrían encontrarse La carpeta **FireWeapons** para una mejor organización, o mantener únicamente la capreta **Implementations**.