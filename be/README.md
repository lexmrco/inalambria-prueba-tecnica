# Proyecto Base JWT(JSON Web Token)
## Endpoints
###
##### Identificar si la api se está ejecutando
* Url: http://localhost:5000/api/ping
* Método: GET
* Response: pong

### Obtener un token de autenticación:
* Url: http://localhost:5000/api/Auth
* Método: POST
* Body:
  * JSON Data:
   * UserName: admin
   * Password: Rino?015
* Response: token

#### Mostrar el usuario autenticado
* Url: http://localhost:5000/api/Auth/EchoUser
* Método: GET
* Header: 
  * Authorization
   * Type: Bearer Token
   * Token: Token generado por la api
* Response: Nombre del usuario

## Endpoints de prueba
### Clientes
* Url: http://localhost:5000/api/customers
* Método: GET
* Header: 
  * Authorization
   * Type: Bearer Token
   * Token: Token generado por la api
* Response: Lista de clientes

### Obtener un cliente

#### Mostrar el usuario autenticado
* Url: http://localhost:5000/api/customers/[customerId]
* Método: GET
* Header: 
  * Authorization
   * Type: Bearer Token
   * Token: Token generado por la api
* Response: Datos del cliente

