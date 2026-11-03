# Práctica de Programación en C# - Cooperativa Ahorro Seguro

## 1. Datos de los Autores
* **Yohan Javier De Gracia Torres** - Matrícula: 26-EISN-2-009
* **Emil Sebastian Mejia Mendoza** - Matrícula: 26-EISN-2-036
* **José Rafael Jiron Santana** - Matrícula: 26-EISN-2-013
* **Wilkin A. Reyna Sanon** - Matrícula: 26-EISN-2-001
* **Erick Daniel Silvestre** - Matrícula: 25-SISN-2-033

## 2. Descripción del Proyecto
Aplicación de consola desarrollada en C# que integra dos módulos financieros (Cajero Automático y Simulador de Préstamo) bajo un menú principal de selección. El programa permite gestionar operaciones bancarias y proyecciones de préstamos mediante una estructura lógica unificada en el método `Main`, implementando validaciones de entrada de datos y control de flujo iterativo.

## 3. Datos de Entrada
* **Menú Principal:** Opción de navegación elegida por el usuario (1, 2 o 3).
* **Cajero Automático:** PIN de acceso de 4 dígitos, opción de menú del cajero, monto a depositar y monto a retirar.
* **Simulador de Préstamo:** Monto del crédito (RD$ 5,000 a RD$ 500,000), plazo de pago en meses (6 a 60), categoría del socio ('A', 'B' o 'C') y confirmación para continuar o reiniciar la simulación ('S' o 'N').

## 4. Datos que Procesa
* Validación defensiva del PIN bancario con contador de intentos (máximo 3).
* Verificación de depósitos y comprobación de saldo con restricción de retiros en múltiplos de RD$ 100.
* Asignación de tasa anual según la categoría del socio (A: 12%, B: 15%, C: 18%) y su conversión a tasa mensual.
* Cálculo de cuotas fijas mensuales mediante la fórmula de amortización.
* Generación de la tabla de amortización detallando intereses, abono a capital y saldo pendiente mes a mes.

## 5. Datos de Salida
* Saldo disponible en cuenta actualizado en tiempo real.
* Mensajes informativos y de error (PIN incorrecto, fondos insuficientes, montos no permitidos, opciones inválidas).
* Resumen de la simulación: Monto aprobado, plazo, tasa aplicada y cuota mensual.
* Tabla de amortización completa con los totales consolidados de capital e intereses pagados.

## 6. Tecnología Utilizada
* **Lenguaje:** C# (.NET / Consola)
* **Entorno de Desarrollo:** Microsoft Visual Studio
* **Control de Versiones:** Git y GitHub (Repositorio Público)

## 7. Capturas del Programa
Las capturas de pantalla con los casos exitosos y las validaciones de error para cada módulo se encuentran organizadas dentro de la carpeta `Capturas/` en la raíz del proyecto.