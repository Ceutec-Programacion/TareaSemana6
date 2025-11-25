# Tarea Semana 6

Este proyecto implementa una arquitectura de **microservicios en .NET 8**, junto
con un **API Gateway utilizando YARP**, que actúa como punto de entrada
unificado para tres servicios independientes:

- **ProductService**
- **CustomerService**
- **OrderService**
- **Gateway (YARP Reverse Proxy)**

Cada microservicio corre en su propio contenedor Docker y expone rutas
independientes. El Gateway las unifica bajo un solo dominio mediante rutas:

- `/api/products`
- `/api/customers`
- `/api/orders`

## Arquitectura del Proyecto

Cada servicio corre en el puerto interno **8080**, y Docker Compose los expone
así:

| Servicio        | URL Externa           |
| --------------- | --------------------- |
| ProductService  | http://localhost:5001 |
| CustomerService | http://localhost:5002 |
| OrderService    | http://localhost:5003 |
| Gateway         | http://localhost:5000 |

---

# Endpoints funcionando

A continuación se muestran las pruebas realizadas tanto **directamente en cada
microservicio**, como **a través del API Gateway**.

---

# 1. ProductService

### Obtener todos los productos

**GET /products**

![products](./assets/:products.png)

### Obtener producto por ID

**GET /products/1**

![products1](./assets/:products:1.png)

---

# 2. CustomerService

### Obtener todos los clientes

**GET /customers**

![customers](./assets/:customers.png)

### Obtener cliente por ID

**GET /customers/1**

![customers1](./assets/:customers:1.png)

---

# 3. OrderService

### Obtener todas las órdenes

**GET /orders**

![orders](./assets/:orders.png)

### Obtener orden por ID

**GET /orders/1**

![orders1](./assets/:orders:1.png)

---

# 4. API Gateway (YARP)

El Gateway expone los endpoints unificados:

- **GET /api/products**
- **GET /api/customers**
- **GET /api/orders**

### Productos desde el gateway

![api-products](./assets/:api:products.png)

### Clientes desde el gateway

![api-customers](./assets/:api:customers.png)

### Órdenes desde el gateway

![api-orders](./assets/:api:orders.png)

---

# Docker

Para ejecutar todo el sistema:

```sh
docker compose up --build
```

Esto levanta los 4 servicios y los deja listos para recibir tráfico.
