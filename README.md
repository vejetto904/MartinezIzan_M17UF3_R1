# MartinezIzan_M17UF3_R1
# Historia: El Último Supersoldado

En un mundo que alguna vez fue testigo del resplandor de la civilización, ahora yace en ruinas, envuelto en la sombra de un apocalipsis desencadenado por una plaga zombie. Entre los horrores que acechan en la oscuridad, hay un hombre que se yergue como un bastión de esperanza en medio del caos: el último supersoldado.

Su nombre es Capitán James "Rayo" Johnson, una vez un orgulloso y valiente líder en las filas de las fuerzas especiales. Ahora, se encuentra solo, en un bosque que alguna vez fue un remanso de tranquilidad, pero que ahora resuena con los gemidos y los susurros de los muertos vivientes.

Rayo no es un hombre común. A través de experimentos militares secretos, fue sometido a mejoras genéticas y cibernéticas que lo convirtieron en algo más que humano: un supersoldado. Sin embargo, incluso con sus habilidades aumentadas, enfrenta desafíos abrumadores en este nuevo mundo devastado por los no muertos.

El bosque que ahora es su hogar es un refugio temporal, un lugar donde puede encontrar un breve respiro entre las incursiones en las tierras infestadas de los zombis. Cada día, se aventura más allá de los límites del bosque en busca de suministros y sobrevivientes, mientras lucha contra hordas de criaturas putrefactas y descompuestas.

A medida que pasa el tiempo, Rayo se encuentra enfrentando no solo a los zombis, sino también a su propia humanidad fracturada. Recuerdos de amigos perdidos y camaradas caídos acechan en las sombras de su mente, recordándole el alto precio que ha pagado por su habilidad para sobrevivir.

Sin embargo, a pesar de las dificultades, Rayo sigue adelante, aferrándose a la esperanza de que en algún lugar, en algún momento, pueda encontrar una cura para la plaga que ha consumido al mundo. Con su valor inquebrantable y su fuerza inigualable, el último supersoldado avanza hacia el futuro incierto, una luz en la oscuridad de un mundo sumido en el caos.

# Controles del Personaje

Este documento describe los controles utilizados para manejar al personaje en el juego.

## Controles Básicos

- **Caminar:** Mueve al personaje en la dirección deseada. La velocidad del movimiento está determinada por la posición del joystick o las teclas de dirección. ASDW
- **Correr:** Aumenta la velocidad de movimiento del personaje. Mantén presionado el botón asignado para correr. Shift
- **Saltar:** Hace que el personaje salte. Pulsa el botón asignado para saltar. Space
- **Agacharse:** Hace que el personaje se agache. Pulsa el botón asignado para agacharse. Cntrl
- **Apuntar:** Permite al jugador apuntar con una mira o cambiar el modo de visualización. Pulsa el botón asignado para apuntar. Click Derecho
- **Cambiar Cámara:** Alterna entre diferentes cámaras o modos de visualización. Pulsa el botón asignado para cambiar la cámara. Tab
- **Inventario/Inventario de Objetos:** Abre o cierra el inventario del personaje o accede a un inventario de objetos. Pulsa el botón asignado para abrir/cerrar el inventario. I

-No me a dado tiempo a conel click izquierdo hacer que recoja objeros con el NewInputSystem pero esta pendiente.

## Interactuando con los Controles

Los controles se gestionan mediante un sistema de eventos. Cada acción tiene un evento asociado que puede ser escuchado por otros scripts para realizar acciones específicas en respuesta a las entradas del jugador.

### Eventos Disponibles

- **Caminar:** Se activa cuando el jugador mueve el joystick o presiona las teclas de dirección.
- **Correr:** Se activa cuando el jugador mantiene presionado el botón de correr.
- **Saltar:** Se activa cuando el jugador pulsa el botón de saltar.
- **Agacharse:** Se activa cuando el jugador pulsa el botón de agacharse.
- **Apuntar:** Se activa cuando el jugador pulsa el botón de apuntar.
- **Cambiar Cámara:** Se activa cuando el jugador pulsa el botón de cambiar cámara.
- **Inventario/Inventario de Objetos:** Se activa cuando el jugador pulsa el botón de abrir o cerrar el inventario.

## Implementación

Los controles se gestionan mediante un script llamado InputController. Este script utiliza el sistema de entrada de Unity para detectar las entradas del jugador y activar los eventos correspondientes. Los eventos están definidos como acciones estáticas que otros scripts pueden suscribirse para manejar las entradas del jugador.
