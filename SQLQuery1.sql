USE [PapeleriaObligatorio];
GO
-- Insertando datos de prueba en la tabla Articulos
INSERT INTO [dbo].[Articulos] (Nombre, Codigo, Descripcion, Precio)
VALUES 
('Cuaderno A4', 'CUA4', 'Cuaderno tamaño A4 con 100 hojas', 3.50),
('Bolígrafo Azul', 'BOLAZ', 'Bolígrafo de tinta azul', 0.50),
('Lápiz HB', 'LAPHB', 'Lápiz grafito HB', 0.25),
('Goma de Borrar', 'GOMA1', 'Goma de borrar blanca', 0.30),
('Marcador Permanente', 'MARKP', 'Marcador permanente negro', 1.20),
('Resaltador Amarillo', 'RESA', 'Resaltador amarillo', 0.80),
('Tijeras', 'TIJ', 'Tijeras de acero inoxidable', 2.00),
('Pegamento en Barra', 'PEGB', 'Pegamento en barra 20g', 0.75),
('Cartulina Blanca', 'CARB', 'Cartulina blanca tamaño A3', 0.50),
('Grapadora', 'GRAP', 'Grapadora metálica', 5.00),
('Cinta Adhesiva', 'CINT', 'Cinta adhesiva transparente', 1.00),
('Corrector Líquido', 'CORL', 'Corrector líquido blanco', 1.25),
('Carpeta Archivadora', 'CARP', 'Carpeta archivadora con anillas', 4.50),
('Rotulador Rojo', 'ROTR', 'Rotulador de tinta roja', 0.70),
('Bloc de Notas', 'BLON', 'Bloc de notas adhesivas', 1.50),
('Papel Fotocopia A4', 'PAPA4', 'Papel de fotocopia tamaño A4', 3.00),
('Calculadora Científica', 'CALC', 'Calculadora científica con funciones avanzadas', 15.00),
('Regla 30cm', 'REG30', 'Regla de plástico 30 cm', 0.50),
('Compás', 'COMP', 'Compás metálico', 2.00),
('Estuche', 'EST', 'Estuche escolar', 3.00),
('Mochila Escolar', 'MOCH', 'Mochila escolar con compartimentos', 25.00),
('Cuaderno de Bocetos', 'CUAB', 'Cuaderno de bocetos tamaño A4', 4.00),
('Pegamento Líquido', 'PEGL', 'Pegamento líquido 100ml', 1.00),
('Sacapuntas', 'SAC', 'Sacapuntas metálico', 0.50),
('Lápices de Colores', 'LAPC', 'Set de 12 lápices de colores', 3.00),
('Agenda 2024', 'AGEN24', 'Agenda año 2024', 7.00),
('Plastilina', 'PLAS', 'Set de plastilina de colores', 2.50),
('Pinceles', 'PINC', 'Set de pinceles para pintar', 3.50),
('Tempera', 'TEMP', 'Set de temperas de colores', 4.00),
('Paleta para Pintar', 'PALP', 'Paleta de plástico para mezclar pintura', 1.50),
('Portaminas', 'PORT', 'Portaminas con 3 minas de repuesto', 2.50),
('Minas 0.5mm', 'MIN05', 'Set de minas 0.5mm para portaminas', 1.00),
('Borrador para Pizarra', 'BORP', 'Borrador de fieltro para pizarra blanca', 1.25),
('Marcadores para Pizarra', 'MARP', 'Set de 4 marcadores para pizarra blanca', 5.00),
('Tiza Blanca', 'TIZB', 'Caja de tiza blanca', 1.00),
('Tiza de Colores', 'TIZC', 'Caja de tiza de colores', 1.50),
('Carpetas de Plástico', 'CARPP', 'Set de 10 carpetas de plástico transparentes', 3.00),
('Archivador Metálico', 'ARCHM', 'Archivador metálico de 4 cajones', 50.00),
('Cajas de Archivo', 'CAJAR', 'Set de 5 cajas de archivo', 10.00),
('Rotulador Permanente', 'ROTP', 'Rotulador permanente negro', 1.00),
('Pluma Estilográfica', 'PLUM', 'Pluma estilográfica con cartuchos', 12.00),
('Cartuchos de Tinta', 'CART', 'Set de 5 cartuchos de tinta para pluma', 2.00),
('Cuaderno de Matemáticas', 'CUAM', 'Cuaderno cuadriculado para matemáticas', 3.00),
('Libreta de Notas', 'LIBN', 'Libreta de notas tamaño A6', 2.00),
('Set de Geometría', 'SETG', 'Set de geometría con regla, compás y transportador', 3.50),
('Plastilina de Colores', 'PLACO', 'Set de plastilina de colores', 2.50),
('Tijeras de Punta Redonda', 'TIJR', 'Tijeras de punta redonda para niños', 1.50),
('Cinta Correctora', 'CINC', 'Cinta correctora', 2.00),
('Papel de Embalar', 'PAPEM', 'Rollo de papel de embalar', 3.00),
('Papel de Regalo', 'PAPRG', 'Rollo de papel de regalo', 2.00),
('Envoltorio para Libros', 'ENVL', 'Set de 10 envoltorios para libros', 5.00),
('Caja de Lápices', 'CAJAL', 'Caja de 24 lápices de colores', 6.00),
('Archivador de Palanca', 'ARCHP', 'Archivador de palanca tamaño A4', 4.00),
('Bolsa de Plástico', 'BOLP', 'Bolsa de plástico con cierre hermético', 1.50),
('Bolígrafo Negro', 'BOLN', 'Bolígrafo de tinta negra', 0.50),
('Bolígrafo Rojo', 'BOLR', 'Bolígrafo de tinta roja', 0.50),
('Marcador Fluorescente', 'MARF', 'Marcador fluorescente', 1.00),
('Papel Mantequilla', 'PAPM', 'Rollo de papel mantequilla', 2.50),
('Libreta de Dibujo', 'LIBD', 'Libreta de dibujo tamaño A4', 4.00),
('Separadores de Cartulina', 'SEPC', 'Set de 10 separadores de cartulina', 1.50),
('Cinta Adhesiva de Doble Cara', 'CINDC', 'Cinta adhesiva de doble cara', 3.00),
('Estuche de Lápices', 'ESTL', 'Estuche con 24 lápices de colores', 10.00),
('Carpeta con Separadores', 'CARSE', 'Carpeta con separadores tamaño A4', 5.00),
('Archivador A-Z', 'ARCHAZ', 'Archivador A-Z tamaño A4', 6.00),
('Set de Sobres', 'SETS', 'Set de 50 sobres blancos', 3.00),
('Borrador de Plástico', 'BORPL', 'Borrador de plástico blanco', 0.30),
('Grapas', 'GRAPA', 'Caja de grapas', 1.00),
('Cuaderno de Espiral', 'CUAE', 'Cuaderno de espiral tamaño A5', 2.50),
('Bloc de Dibujo', 'BLOD', 'Bloc de dibujo tamaño A3', 5.00),
('Papel Crepé', 'PAPC', 'Set de 10 hojas de papel crepé', 2.00),
('Bolígrafo Verde', 'BOLV', 'Bolígrafo de tinta verde', 0.50),
('Cuaderno de Música', 'CUAMU', 'Cuaderno de música con pentagramas', 3.50);

-- Insertando datos de prueba en la tabla Clientes
INSERT INTO [dbo].[Clientes] (RazonSocial, Rut, NombreCliente_Nombre, NombreCliente_Apellido, Direccion_NombreCalle, Direccion_NumeroPuerta, Direccion_Ciudad, Direccion_DistanciaKm)
VALUES
('Papelería El Escriba', '12345678-9', 'Juan', 'Pérez', 'Calle Falsa', '123', 'Montevideo', 15.5),
('Oficinas Express', '87654321-0', 'Ana', 'González', 'Av. Libertador', '456', 'Salto', 200.0),
('Librería Central', '11223344-5', 'Carlos', 'Rodríguez', 'Calle Real', '789', 'Paysandú', 250.0),
('La Oficina Moderna', '55667788-9', 'Laura', 'Fernández', 'Calle Principal', '321', 'Maldonado', 120.0),
('Papeles y Más', '99887766-5', 'María', 'López', 'Avenida Siempreviva', '987', 'Rivera', 300.0),
('Librería Escolar', '44556677-8', 'José', 'García', 'Calle Comercio', '654', 'Canelones', 50.0),
('Tienda de Papelería', '33445566-7', 'Lucía', 'Martínez', 'Av. Central', '543', 'San José', 80.0),
('El Mundo del Papel', '22334455-6', 'Luis', 'Hernández', 'Calle 8 de Octubre', '210', 'Durazno', 160.0),
('Librería Estrella', '66778899-0', 'Marta', 'Gómez', 'Calle Nueva', '147', 'Colonia', 130.0),
('Papelería y Regalos', '88990011-2', 'Pedro', 'Díaz', 'Avenida Principal', '369', 'Florida', 90.0);

-- Insertando datos de prueba en la tabla Configuraciones
INSERT INTO [dbo].[Configuraciones] (Nombre, Valor)
VALUES
('DescuentoMayoreo', 10),
('Impuesto', 21),
('EnvioGratis', 50),
('StockMinimo', 5),
('TiempoEntrega', 7),
('HoraCierre', 18),
('HoraApertura', 9),
('DiasDeTrabajo', 5),
('NumeroMaximoPedidos', 100),
('PromocionMes', 20),
('Tope', 60),
('PageSize', 10);

-- Insertando datos de prueba en la tabla Usuarios
INSERT INTO [dbo].[Usuarios] (Email, Password, PasswordSinEncript, NombreCompleto_Nombre, NombreCompleto_Apellido, Discriminator)
VALUES
('juan.perez@escriba.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Juan', 'Pérez', 'Encargado'),
('ana.gonzalez@oficinas.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Ana', 'González', 'Encargado'),
('carlos.rodriguez@libreria.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Carlos', 'Rodríguez', 'Encargado'),
('laura.fernandez@moderna.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Laura', 'Fernández', 'Encargado'),
('maria.lopez@papeles.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'María', 'López', 'Encargado'),
('jose.garcia@escolar.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'José', 'García', 'Encargado'),
('lucia.martinez@papeleria.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6!', 'Admin1234!', 'Lucía', 'Martínez', 'Encargado'),
('luis.hernandez@mundo.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Luis', 'Hernández', 'Encargado'),
('marta.gomez@estrella.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Marta', 'Gómez', 'Encargado'),
('pedro.diaz@regalos.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Pedro', 'Díaz', 'Encargado'),
('andres.sosa@correo.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Andrés', 'Sosa', 'Administrador'),
('paula.mendez@empresa.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Paula', 'Méndez', 'Administrador'),
('roberto.alvarez@negocios.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Roberto', 'Álvarez', 'Administrador'),
('veronica.torres@personal.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Verónica', 'Torres', 'Administrador'),
('martin.lopez@proyectos.com', '5ce41ada64f1e8ffb0acfaafa622b141438f3a5777785e7f0b830fb73e40d3d6', 'Admin1234!', 'Martín', 'López', 'Administrador');


-- Insertando datos de prueba en la tabla TipoMovimientos
INSERT INTO [dbo].[TipoMovimientos] (Nombre, TipoMovStock)
VALUES
('Entrada', 2),
('Salida', 1),
('Devolución', 2),
('Venta', 1),
('Transferencia', 1),
('Donación', 1),
('Destrucción', 1),
('Producción', 2),
('Reparación', 2);

-- Insertando datos de prueba en la tabla Pedidos
INSERT INTO [dbo].[Pedidos] (ClienteId, Fecha, FechaPrometida, Anulado, Discriminator)
VALUES
(1, '2024-06-01 10:00:00', '2024-06-10 10:00:00', 0, 'PedidoComun'),
(2, '2024-06-02 11:00:00', '2024-06-11 11:00:00', 0, 'PedidoComun'),
(3, '2024-06-03 12:00:00', '2024-06-12 12:00:00', 0, 'PedidoComun'),
(4, '2024-06-04 13:00:00', '2024-06-13 13:00:00', 0, 'PedidoExpress'),
(5, '2024-06-05 14:00:00', '2024-06-14 14:00:00', 0, 'PedidoExpress'),
(6, '2024-06-06 15:00:00', '2024-06-15 15:00:00', 0, 'PedidoComun'),
(7, '2024-06-07 16:00:00', '2024-06-16 16:00:00', 0, 'PedidoComun'),
(8, '2024-06-08 17:00:00', '2024-06-17 17:00:00', 0, 'PedidoExpress'),
(9, '2024-06-09 18:00:00', '2024-06-18 18:00:00', 0, 'PedidoComun'),
(10, '2024-06-10 19:00:00', '2024-06-19 19:00:00', 0, 'PedidoExpress');

-- Insertando datos de prueba en la tabla Movimientos
INSERT INTO [dbo].[Movimientos] (FechaMovimiento, ArticuloId, TipoMovimientoId, CantUnidades, EmailUsuario)
VALUES
('2023-06-01 10:00:00', 1, 1, 50, 'juan.perez@escriba.com'),
('2023-06-02 11:00:00', 2, 2, 20, 'ana.gonzalez@oficinas.com'),
('2023-06-03 12:00:00', 3, 1, 30, 'carlos.rodriguez@libreria.com'),
('2023-06-04 13:00:00', 4, 2, 10, 'laura.fernandez@moderna.com'),
('2024-06-05 14:00:00', 5, 1, 40, 'maria.lopez@papeles.com'),
('2024-06-06 15:00:00', 6, 2, 15, 'jose.garcia@escolar.com'),
('2024-06-07 16:00:00', 7, 1, 25, 'lucia.martinez@papeleria.com'),
('2024-06-08 17:00:00', 8, 2, 12, 'luis.hernandez@mundo.com'),
('2024-06-09 18:00:00', 9, 1, 35, 'marta.gomez@estrella.com'),
('2024-06-10 19:00:00', 10, 2, 22, 'pedro.diaz@regalos.com'),
('2024-06-11 10:00:00', 11, 1, 45, 'juan.perez@escriba.com'),
('2024-06-12 11:00:00', 12, 2, 18, 'ana.gonzalez@oficinas.com'),
('2024-06-13 12:00:00', 13, 1, 32, 'carlos.rodriguez@libreria.com'),
('2024-06-14 13:00:00', 14, 2, 14, 'laura.fernandez@moderna.com'),
('2024-06-15 14:00:00', 15, 1, 38, 'maria.lopez@papeles.com'),
('2024-06-16 15:00:00', 16, 2, 16, 'jose.garcia@escolar.com'),
('2024-06-17 16:00:00', 17, 1, 27, 'lucia.martinez@papeleria.com'),
('2024-06-18 17:00:00', 18, 2, 13, 'luis.hernandez@mundo.com'),
('2024-06-19 18:00:00', 19, 1, 34, 'marta.gomez@estrella.com'),
('2024-06-20 19:00:00', 20, 2, 21, 'pedro.diaz@regalos.com'),
('2024-06-21 10:00:00', 21, 1, 49, 'juan.perez@escriba.com'),
('2024-06-22 11:00:00', 22, 2, 20, 'ana.gonzalez@oficinas.com'),
('2025-06-23 12:00:00', 23, 1, 31, 'carlos.rodriguez@libreria.com'),
('2025-06-24 13:00:00', 24, 2, 11, 'laura.fernandez@moderna.com'),
('2025-06-25 14:00:00', 25, 1, 41, 'maria.lopez@papeles.com'),
('2025-06-26 15:00:00', 26, 2, 17, 'jose.garcia@escolar.com'),
('2025-06-27 16:00:00', 27, 1, 29, 'lucia.martinez@papeleria.com'),
('2025-06-28 17:00:00', 28, 2, 13, 'luis.hernandez@mundo.com'),
('2025-06-29 18:00:00', 29, 1, 36, 'marta.gomez@estrella.com'),
('2025-06-30 19:00:00', 30, 2, 19, 'pedro.diaz@regalos.com');
