# **Sistema de Gestión para Clínica Veterinaria (Vet Clinic App)**

Esta aplicación está diseñada para gestionar las operaciones de una clínica veterinaria de manera eficiente, atendiendo las necesidades de administradores, empleados y demas. Permite la gestión de mascotas, citas, productos entre otras implementaciones. A continuación, se describen las funcionalidades principales del sistema:

---

## **Funciones Principales**

### **Gestión de Mascotas**

- Agregar mascotas a la base de datos con sus respectivos datos e imágenes.
- Visualizar una galería de mascotas con sus imágenes e información detallada.
- Manejo de usuarios, ventas, stock y roles para administrador entre otras implementaciones.

### **Gestión de Usuarios**

- Registro e inicio de sesión como cliente, empleado o administrador.
- Gestionar perfiles de usuario, incluyendo la actualización de foto de perfil.
- Los administradores pueden ver los empleados, junto con sus datos personales, historial en ventas y foto de perfil.

### **Gestión de Citas**

- Reservar citas para mascotas especificando los siguientes detalles:
  - **Fecha:** Ejemplo: `22-11-2024`.
  - **Servicio:** Ejemplo: `Baño y corte de pelo`.
  - **Peso y edad de la mascota.**
  - **Nombre de la mascota.**
  - **Notas:** Ejemplo: `La mascota es alérgica...`.
  - **Imágenes de la mascota.**
- Los empleados pueden gestionar citas únicamente para las mascotas que les fueron asignadas.
- Los administradores pueden gestionar todas las citas sin restricciones.

### **Gestión de Productos**

- Mostrar los productos disponibles en la veterinaria.
- Tanto empleados como administradores pueden concretar ventas.
- Los administradores pueden crear productos con los siguientes detalles:
  - **Nombre.**
  - **Descripción.**
  - **Categoría.**
  - **Precio.**
  - **Imagen del producto.**
- Los administradores pueden eliminar productos y actualizar su cantidad en inventario.

---

## **Roles y Funcionalidades**

### **Administrador**

- **Inicio:** Visualiza todas las mascotas con sus respectivas citas.
- **Gestión de citas:** Crear citas y mascotas relacionadas.
- **Gestión de productos:**
  - Crear productos con nombre, descripción, categoría, precio e imagen.
  - Eliminar productos y actualizar el stock o cantidad.
- **Ventas:** Acceso al apartado de ventas para ver transacciones realizadas.
- **Gestión de usuarios:**
  - Visualizar empleados con sus imágenes, datos personales y rendimiento en ventas.

---

### **Empleado (Usuario Normal)**

- **Inicio:** Puede visualizar únicamente las mascotas que él mismo asignó para citas.
- **Gestión de citas:** Crear citas y mascotas relacionadas con los datos mencionados anteriormente.
- **Productos:**
  - Ver todos los productos disponibles en la veterinaria.
  - Concretar ventas, pero sin permisos para eliminar productos ni actualizar el stock.

---

- **Fotos de Perfil:**
  Tanto los empleados como los administradores pueden actualizar su foto de perfil dentro de la aplicación.

---

Este sistema ofrece una solución para la gestión eficiente de clínicas veterinarias, optimizando los procesos y mejorando la experiencia tanto de los empleados como de los clientes.
