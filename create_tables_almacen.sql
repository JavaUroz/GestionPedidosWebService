CREATE TABLE Clientes(
   clCuit INT NOT NULL,
   clRazonSocial VARCHAR(50),
   clDireccion VARCHAR(50),
   clTelefono VARCHAR(50),
   clEmail VARCHAR(50),
   PRIMARY KEY(clCuit)
)
CREATE TABLE Productos(
   prId INT NOT NULL,
   prCodigo INT NOT NULL,
   prDescripcion VARCHAR(50),
   prUnidadMedida VARCHAR(50),
   clEmail VARCHAR(50),
   prPrecioVenta DECIMAL(18, 2),
   prPrecioCompra DECIMAL(18, 2),
   prFechaActPrecioVenta DATE,
   prFechaActPrecioCompra DATE,
   PRIMARY KEY(prId)
)
CREATE TABLE ProductosPedidos(
   ppId INT NOT NULL,
   ppIdProducto INT NOT NULL,
   ppIdCliente INT NOT NULL,
   ppCantidad FLOAT,
   prUnidadMedida VARCHAR(50),   
   ppPrecioVenta DECIMAL(18, 2),  
   PRIMARY KEY(ppId)
)
;