// Este archivo contiene una pequeña demostración de JavaScript para la página principal.
// Sirve para explicar que el navegador puede reaccionar a eventos del usuario sin recargar la página completa.

// Esperamos a que el documento esté listo para ejecutar el código.
document.addEventListener('DOMContentLoaded', function () {
    // Buscamos un botón de ejemplo dentro de la página principal.
    const demoButton = document.getElementById('demoButton');

    if (demoButton) {
        demoButton.addEventListener('click', function () {
            // Este pequeño ejemplo muestra cómo JavaScript puede manipular el DOM.
            const output = document.getElementById('demoOutput');
            const customerName = document.getElementById('NombreCliente');

            if (output) {
                const nombre = customerName && customerName.value.trim()
                    ? customerName.value.trim()
                    : 'cliente';

                output.textContent = `Demo JavaScript: Hola ${nombre}, la página responde en el navegador.`;
                output.classList.remove('text-muted');
                output.classList.add('text-success');
            }
        });
    }
});
