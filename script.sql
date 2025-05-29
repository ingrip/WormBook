--Script
DROP TABLE  Cliente           CASCADE CONSTRAINTS;
DROP TABLE  envio           CASCADE CONSTRAINTS;
DROP TABLE  existencia           CASCADE CONSTRAINTS;
DROP TABLE  juegomesa                CASCADE CONSTRAINTS;
DROP TABLE  libro   CASCADE CONSTRAINTS;
DROP TABLE  producto             CASCADE CONSTRAINTS;
DROP TABLE  productosenviados           CASCADE CONSTRAINTS;
DROP TABLE  sucursal   CASCADE CONSTRAINTS;
DROP TABLE  venta            CASCADE CONSTRAINTS;
DROP TABLE  productovendido            CASCADE CONSTRAINTS;

CREATE TABLE Cliente
(
	Telefono             INTEGER NOT NULL ,
	Nombre               VARCHAR2(20) NULL ,
	Apellido             VARCHAR2(20) NULL 
);

ALTER TABLE Cliente
	ADD CONSTRAINT  XPKCliente PRIMARY KEY (Telefono);


CREATE TABLE Envio
(
	GuiaEnvio            INTEGER NOT NULL ,
	NumCajas             INTEGER NOT NULL ,
	Destino      VARCHAR2(100) NOT NULL ,
	SucursalOrigen       INTEGER NOT NULL,
	Telefono             INTEGER NOT NULL
);

ALTER TABLE Envio
	ADD CONSTRAINT  PK_Envio PRIMARY KEY (GuiaEnvio);

CREATE TABLE Existencia
(
	CodigoInterno        INTEGER NOT NULL ,
	Existencia           INTEGER NOT NULL ,
	CodigoSucursal       INTEGER NOT NULL 
);

ALTER TABLE Existencia
	ADD CONSTRAINT  PK_Existencia PRIMARY KEY (CodigoInterno,CodigoSucursal);

CREATE TABLE JuegoMesa
(
	CodigoInterno        INTEGER NOT NULL ,
	Nombre               VARCHAR2(50) NOT NULL ,
	Marca                VARCHAR2(50) NOT NULL 
);

ALTER TABLE JuegoMesa
	ADD CONSTRAINT  PK_JuegoMesa PRIMARY KEY (CodigoInterno);

CREATE TABLE Libro
(
	CodigoInterno        INTEGER NOT NULL,
	Titulo               VARCHAR2(50) NOT NULL,
	Autor                VARCHAR2(50) NOT NULL,
	ISBN                 VARCHAR2(20) NOT NULL,
	Editorial            VARCHAR2(20) NULL 
);

ALTER TABLE Libro
	ADD CONSTRAINT  PK_Libro PRIMARY KEY (CodigoInterno);


CREATE TABLE Producto
(
	CodigoInterno        INTEGER NOT NULL,
	Precio               INTEGER NULL,
	CodigoBarras         INTEGER NULL 
);

ALTER TABLE Producto
	ADD CONSTRAINT  PK_Producto PRIMARY KEY (CodigoInterno);

CREATE TABLE ProductosEnviados
(
	CodigoInterno        INTEGER NOT NULL,
	GuiaEnvio            INTEGER NOT NULL,
	CantidadEnviada      INTEGER NOT NULL
);

ALTER TABLE ProductosEnviados
	ADD CONSTRAINT  PK_ProductosEnviados PRIMARY KEY (CodigoInterno,GuiaEnvio);

CREATE TABLE ProductoVendido
(
	CodigoInterno        INTEGER NOT NULL,
	NumVenta             INTEGER NOT NULL,
	CantidadVendida      INTEGER NOT NULL 
);

ALTER TABLE ProductoVendido
	ADD CONSTRAINT  PK_ProductoVendido PRIMARY KEY (CodigoInterno,NumVenta);

CREATE TABLE Sucursal
(
	CodigoSucursal       INTEGER NOT NULL,
	NombreSucursal       VARCHAR2(50) NOT NULL,
	Ubicacion            VARCHAR2(20) NOT NULL,
	TelefonoSucursal     VARCHAR2(20) NOT NULL 
);

ALTER TABLE Sucursal
	ADD CONSTRAINT  PK_Sucursal PRIMARY KEY (CodigoSucursal);

CREATE TABLE Venta
(
	NumVenta             INTEGER NOT NULL,
	Total                INTEGER NULL,
	FechaCompra          DATE NULL,
	CodigoSucursal       INTEGER NOT NULL 
);

ALTER TABLE Venta
	ADD CONSTRAINT  PK_Venta PRIMARY KEY (NumVenta);

ALTER TABLE Envio
	ADD (CONSTRAINT R_38 FOREIGN KEY (Telefono) REFERENCES Cliente (Telefono));

ALTER TABLE Envio
	ADD (CONSTRAINT R_49 FOREIGN KEY (SucursalOrigen) REFERENCES Sucursal (CodigoSucursal));

ALTER TABLE Existencia
	ADD (CONSTRAINT R_9 FOREIGN KEY (CodigoInterno) REFERENCES Producto (CodigoInterno));

ALTER TABLE Existencia
	ADD (CONSTRAINT R_22 FOREIGN KEY (CodigoSucursal) REFERENCES Sucursal (CodigoSucursal));

ALTER TABLE JuegoMesa
	ADD (FOREIGN KEY (CodigoInterno) REFERENCES Producto(CodigoInterno) ON DELETE CASCADE);

ALTER TABLE Libro
	ADD (FOREIGN KEY (CodigoInterno) REFERENCES Producto(CodigoInterno) ON DELETE CASCADE);

ALTER TABLE ProductosEnviados
	ADD (CONSTRAINT R_12 FOREIGN KEY (CodigoInterno) REFERENCES Producto (CodigoInterno));

ALTER TABLE ProductosEnviados
	ADD (CONSTRAINT R_13 FOREIGN KEY (GuiaEnvio) REFERENCES Envio (GuiaEnvio));

ALTER TABLE ProductoVendido
	ADD (CONSTRAINT R_10 FOREIGN KEY (CodigoInterno) REFERENCES Producto (CodigoInterno));

ALTER TABLE ProductoVendido
	ADD (CONSTRAINT R_11 FOREIGN KEY (NumVenta) REFERENCES Venta (NumVenta));

ALTER TABLE Venta
	ADD (CONSTRAINT R_26 FOREIGN KEY (CodigoSucursal) REFERENCES Sucursal (CodigoSucursal));

ALTER TABLE Existencia DROP CONSTRAINT R_9;
ALTER TABLE ProductosEnviados DROP CONSTRAINT R_12;
ALTER TABLE ProductoVendido DROP CONSTRAINT R_10;

ALTER TABLE Existencia
    ADD CONSTRAINT R_9 FOREIGN KEY (CodigoInterno) 
    REFERENCES Producto(CodigoInterno) ON DELETE CASCADE;

ALTER TABLE ProductosEnviados
    ADD CONSTRAINT R_12 FOREIGN KEY (CodigoInterno) 
    REFERENCES Producto(CodigoInterno) ON DELETE CASCADE;

ALTER TABLE ProductoVendido
    ADD CONSTRAINT R_10 FOREIGN KEY (CodigoInterno) 
    REFERENCES Producto(CodigoInterno) ON DELETE CASCADE;

-- Cliente
INSERT INTO cliente VALUES (5551234567, 'Sucursal', 'Almacén Central');
INSERT INTO cliente VALUES (6145678901, 'Sucursal', 'Chihuahua');
INSERT INTO cliente VALUES (2292345678, 'Sucursal', 'Veracruz');
INSERT INTO cliente VALUES (8182345678, 'Sucursal', 'Monterrey');

-- Sucursal
INSERT INTO Sucursal VALUES (10, 'Almacén Central', 'Ciudad de México', 5551234567);
INSERT INTO Sucursal VALUES (11, 'Sucursal Norte', 'Monterrey', 8182345678);
INSERT INTO Sucursal VALUES (12, 'Sucursal Sur', 'Guadalajara', 3334567890);
INSERT INTO Sucursal VALUES (13, 'Sucursal Este', 'Puebla', 2223456789);
INSERT INTO Sucursal VALUES (14, 'Sucursal Chihuahua', 'Chihuahua', 6145678901);
INSERT INTO Sucursal VALUES (15, 'Sucursal Centro', 'León', 4771234567);
INSERT INTO Sucursal VALUES (16, 'Sucursal Bajío', 'Querétaro', 4427890123);
INSERT INTO Sucursal VALUES (17, 'Sucursal Pacífico', 'Acapulco', 7445678901);
INSERT INTO Sucursal VALUES (18, 'Sucursal Golfo', 'Veracruz', 2292345678);
INSERT INTO Sucursal VALUES (19, 'Sucursal Península', 'Mérida', 9993456789);
INSERT INTO Sucursal VALUES (20, 'Sucursal Frontera', 'Ciudad Juárez', 6567890123);

--Productos y subtipos
-- Libros
INSERT INTO Producto VALUES (10001, 300, 978849139);
INSERT INTO Producto VALUES (10002, 300, 978842043);
INSERT INTO Producto VALUES (10003, 340, 978849759);
INSERT INTO Producto VALUES (10004, 345, 978840102);
INSERT INTO Producto VALUES (10005, 450, 978849838);
INSERT INTO Producto VALUES (10006, 300, 978840133);
INSERT INTO Producto VALUES (10007, 600, 978841314);
INSERT INTO Producto VALUES (10008, 340, 978846634);
INSERT INTO Producto VALUES (10009, 390, 978842722);
INSERT INTO Producto VALUES (10010, 340, 978849992);
INSERT INTO Producto VALUES (10011, 430, 978841839);
INSERT INTO Producto VALUES (10012, 590, 978843974);
INSERT INTO Libro VALUES (10001, 'La canción de Aquiles', 'Madeline Miller', 978849139, 'Lumen');
INSERT INTO Libro VALUES (10002, 'Cadáver exquisito', 'Agustina Bazterrica', 978842043, 'Alfaguara');
INSERT INTO Libro VALUES (10003, 'El cuento de la criada', 'Margaret Atwood', 978849759, 'Salamandra');
INSERT INTO Libro VALUES (10004, 'La hipótesis del amor', 'Ali Hazelwood', 978840102, 'Planeta');
INSERT INTO Libro VALUES (10005, 'Cien años de soledad', 'Gabriel García Márquez', 978849838, 'Penguin');
INSERT INTO Libro VALUES (10006, 'Entrevista con el vampiro', 'Anne Rice', 978840133, 'Debolsillo');
INSERT INTO Libro VALUES (10007, 'Nacidos de la bruma: El imperio final', 'Brandon Sanderson', 978841314, 'Nova');
INSERT INTO Libro VALUES (10008, 'Los Bridgerton: El duque y yo', 'Julia Quinn', 978846634, 'Plaza  Janes');
INSERT INTO Libro VALUES (10009, 'Hábitos atómicos', 'James Clear', 978842722, 'Diana');
INSERT INTO Libro VALUES (10010, 'Este dolor no es mío', 'Mark Wolynn', 978849992, 'Urano');
INSERT INTO Libro VALUES (10011, 'Cómo hacer que te pasen cosas buenas', 'Marián Rojas', 978841839, 'Espasa');
INSERT INTO Libro VALUES (10012, 'Tan poca vida', 'Hanya Yanagihara', 978843974, 'Lumen');

-- Juegos de mesa
INSERT INTO Producto VALUES (10013, 350, 630509430);
INSERT INTO Producto VALUES (10014, 590, 887894004);
INSERT INTO Producto VALUES (10015, 670, 653569096);
INSERT INTO Producto VALUES (10016, 500, 700304181);
INSERT INTO JuegoMesa VALUES (10013, 'Monopoly Clásico', 'Hasbro');
INSERT INTO JuegoMesa VALUES (10014, 'Ajedrez de Mármol', 'Games Collection');
INSERT INTO JuegoMesa VALUES (10015, 'Catan Edición Especial', 'Devir');
INSERT INTO JuegoMesa VALUES (10016, 'Scrabble Deluxe', 'Mattel');

--Envios
INSERT INTO Envio VALUES (5001, 3, 'Sucursal 10', 11, 5551234567);
INSERT INTO Envio VALUES (5002, 5, 'Sucursal 12' , 10, 5551234567);
INSERT INTO Envio VALUES (5003, 2, 'Sucursal 10', 13, 5551234567);
INSERT INTO Envio VALUES (5004, 1, 'Sucursal 14', 10, 6145678901);
INSERT INTO Envio VALUES (5005, 4, 'Sucursal 10', 15, 2292345678);
INSERT INTO Envio VALUES (5006, 2, 'Sucursal 16', 10, 2292345678);
INSERT INTO Envio VALUES (5007, 3, 'Sucursal 10', 17, 5551234567);
INSERT INTO Envio VALUES (5008, 1, 'Sucursal 18', 10, 2292345678);
INSERT INTO Envio VALUES (5009, 5, 'Sucursal 10', 19, 5551234567);
INSERT INTO Envio VALUES (5010, 2, 'Sucursal 20', 10, 6145678901);
INSERT INTO Envio VALUES (5011, 4, 'Sucursal 10', 12, 5551234567);
INSERT INTO Envio VALUES (5012, 1, 'Sucursal 13', 10, 5551234567);
INSERT INTO Envio VALUES (5013, 3, 'Sucursal 10', 14, 5551234567);
INSERT INTO Envio VALUES (5014, 2, 'Sucursal 15', 10, 8182345678);
INSERT INTO Envio VALUES (5015, 5, 'Sucursal 10', 16, 5551234567);

--Existencia
-- Existencia en Almacén Central (sucursal 10) 
INSERT INTO Existencia VALUES (10001, 150, 10);
INSERT INTO Existencia VALUES (10002, 120, 10);
INSERT INTO Existencia VALUES (10003, 180, 10);
INSERT INTO Existencia VALUES (10004, 200, 10);
INSERT INTO Existencia VALUES (10005, 160, 10);
INSERT INTO Existencia VALUES (10006, 140, 10);
INSERT INTO Existencia VALUES (10007, 130, 10);
INSERT INTO Existencia VALUES (10008, 170, 10);
INSERT INTO Existencia VALUES (10009, 190, 10);
INSERT INTO Existencia VALUES (10010, 110, 10);
INSERT INTO Existencia VALUES (10011, 125, 10);
INSERT INTO Existencia VALUES (10012, 135, 10);
INSERT INTO Existencia VALUES (10013, 105, 10);
INSERT INTO Existencia VALUES (10014, 115, 10);
INSERT INTO Existencia VALUES (10015, 113, 10);
INSERT INTO Existencia VALUES (10016, 103, 10);

-- Sucursal Norte Monterrey (11)
INSERT INTO Existencia VALUES (10001, 3, 11);
INSERT INTO Existencia VALUES (10002, 2, 11);
INSERT INTO Existencia VALUES (10004, 6, 11);
INSERT INTO Existencia VALUES (10007, 1, 11);
INSERT INTO Existencia VALUES (10009, 5, 11);
INSERT INTO Existencia VALUES (10012, 4, 11);
INSERT INTO Existencia VALUES (10013, 5, 11);
INSERT INTO Existencia VALUES (10014, 3, 11);
INSERT INTO Existencia VALUES (10016, 2, 11);

-- Sucursal Sur Guadalajara (12)
INSERT INTO Existencia VALUES (10003, 4, 12);
INSERT INTO Existencia VALUES (10004, 5, 12);
INSERT INTO Existencia VALUES (10006, 2, 12);
INSERT INTO Existencia VALUES (10007, 9, 12);
INSERT INTO Existencia VALUES (10009, 4, 12);
INSERT INTO Existencia VALUES (10011, 7, 12);
INSERT INTO Existencia VALUES (10014, 4, 12);
INSERT INTO Existencia VALUES (10015, 1, 12);

-- Sucursal Este Puebla (13)
INSERT INTO Existencia VALUES (10001, 2, 13);
INSERT INTO Existencia VALUES (10002, 5, 13);
INSERT INTO Existencia VALUES (10004, 1, 13);
INSERT INTO Existencia VALUES (10008, 2, 13);
INSERT INTO Existencia VALUES (10009, 4, 13);
INSERT INTO Existencia VALUES (10012, 1, 13);
INSERT INTO Existencia VALUES (10016, 3, 13);

-- Sucursal Oeste Tijuana (14)
INSERT INTO Existencia VALUES (10001, 4, 14);
INSERT INTO Existencia VALUES (10002, 6, 14);
INSERT INTO Existencia VALUES (10003, 2, 14);
INSERT INTO Existencia VALUES (10004, 7, 14);
INSERT INTO Existencia VALUES (10005, 3, 14);
INSERT INTO Existencia VALUES (10013, 5, 14);
INSERT INTO Existencia VALUES (10015, 4, 14);

-- Sucursal Centro León (15)
INSERT INTO Existencia VALUES (10006, 5, 15);
INSERT INTO Existencia VALUES (10007, 4, 15);
INSERT INTO Existencia VALUES (10008, 1, 15);
INSERT INTO Existencia VALUES (10009, 5, 15);
INSERT INTO Existencia VALUES (10010, 2, 15);
INSERT INTO Existencia VALUES (10014, 7, 15);
INSERT INTO Existencia VALUES (10016, 4, 15);
-- Sucursal Bajío Querétaro (16)
INSERT INTO Existencia VALUES (10001, 4, 16);
INSERT INTO Existencia VALUES (10002, 3, 16);
INSERT INTO Existencia VALUES (10003, 5, 16);
INSERT INTO Existencia VALUES (10004, 2, 16);
INSERT INTO Existencia VALUES (10005, 6, 16);
INSERT INTO Existencia VALUES (10006, 5, 16);
INSERT INTO Existencia VALUES (10011, 2, 16);
INSERT INTO Existencia VALUES (10012, 7, 16);
-- Sucursal Pacífico Acapulco (17)
INSERT INTO Existencia VALUES (10001, 3, 17);
INSERT INTO Existencia VALUES (10002, 3, 17);
INSERT INTO Existencia VALUES (10006, 4, 17);
INSERT INTO Existencia VALUES (10007, 1, 17);
INSERT INTO Existencia VALUES (10008, 5, 17);
INSERT INTO Existencia VALUES (10009, 3, 17);
INSERT INTO Existencia VALUES (10015, 5, 17);

-- Sucursal Golfo Veracruz (18) 
INSERT INTO Existencia VALUES (10001, 6, 18);
INSERT INTO Existencia VALUES (10008, 4, 18);
INSERT INTO Existencia VALUES (10009, 3, 18);
INSERT INTO Existencia VALUES (10010, 5, 18);
INSERT INTO Existencia VALUES (10011, 1, 18);
INSERT INTO Existencia VALUES (10013, 4, 18);
INSERT INTO Existencia VALUES (10014, 2, 18);

-- Sucursal Península Mérida (19)
INSERT INTO Existencia VALUES (10006, 5, 19);
INSERT INTO Existencia VALUES (10007, 3, 19);
INSERT INTO Existencia VALUES (10008, 6, 19);
INSERT INTO Existencia VALUES (10009, 1, 19);
INSERT INTO Existencia VALUES (10010, 8, 19);
INSERT INTO Existencia VALUES (10011, 2, 19);
INSERT INTO Existencia VALUES (10012, 4, 19);
INSERT INTO Existencia VALUES (10013, 6, 19);
INSERT INTO Existencia VALUES (10014, 3, 19);
-- Sucursal Chihuahua (20)
INSERT INTO Existencia VALUES (10001, 4, 20);
INSERT INTO Existencia VALUES (10002, 1, 20);
INSERT INTO Existencia VALUES (10003, 7, 20);
INSERT INTO Existencia VALUES (10004, 3, 20);
INSERT INTO Existencia VALUES (10005, 7, 20);
INSERT INTO Existencia VALUES (10006, 7, 20);
INSERT INTO Existencia VALUES (10007, 2, 20);
INSERT INTO Existencia VALUES (10012, 6, 20);
INSERT INTO Existencia VALUES (10013, 3, 20);
INSERT INTO Existencia VALUES (10014, 5, 20);
INSERT INTO Existencia VALUES (10015, 1, 20);


--Productos enviados
INSERT INTO ProductosEnviados VALUES (10001, 5001, 2);
INSERT INTO ProductosEnviados VALUES (10013, 5001, 3);
INSERT INTO ProductosEnviados VALUES (10005, 5001, 1);
INSERT INTO ProductosEnviados VALUES (10007, 5002, 4);
INSERT INTO ProductosEnviados VALUES (10012, 5002, 10);
INSERT INTO ProductosEnviados VALUES (10002, 5003, 3);
INSERT INTO ProductosEnviados VALUES (10009, 5003, 2);
INSERT INTO ProductosEnviados VALUES (10012, 5004, 10);
INSERT INTO ProductosEnviados VALUES (10016, 5004, 2);
INSERT INTO ProductosEnviados VALUES (10003, 5005, 4);
INSERT INTO ProductosEnviados VALUES (10010, 5005, 3);
INSERT INTO ProductosEnviados VALUES (10014, 5005, 2);
INSERT INTO ProductosEnviados VALUES (10005, 5006, 18);
INSERT INTO ProductosEnviados VALUES (10004, 5007, 3);
INSERT INTO ProductosEnviados VALUES (10011, 5007, 2);
INSERT INTO ProductosEnviados VALUES (10015, 5007, 1); 
INSERT INTO ProductosEnviados VALUES (10006, 5008, 2);
INSERT INTO ProductosEnviados VALUES (10012, 5008, 30);
INSERT INTO ProductosEnviados VALUES (10007, 5009, 5);
INSERT INTO ProductosEnviados VALUES (10012, 5009, 3);
INSERT INTO ProductosEnviados VALUES (10016, 5009, 2);
INSERT INTO ProductosEnviados VALUES (10012, 5010, 1);
INSERT INTO ProductosEnviados VALUES (10009, 5010, 15);
INSERT INTO ProductosEnviados VALUES (10014, 5010, 2);
INSERT INTO ProductosEnviados VALUES (10002, 5011, 4);
INSERT INTO ProductosEnviados VALUES (10010, 5011, 3);
INSERT INTO ProductosEnviados VALUES (10005, 5012, 2);
INSERT INTO ProductosEnviados VALUES (10006, 5012, 15);
INSERT INTO ProductosEnviados VALUES (10012, 5012, 10);
INSERT INTO ProductosEnviados VALUES (10003, 5013, 3);
INSERT INTO ProductosEnviados VALUES (10009, 5013, 2);
INSERT INTO ProductosEnviados VALUES (10015, 5013, 1);
INSERT INTO ProductosEnviados VALUES (10004, 5014, 2);
INSERT INTO ProductosEnviados VALUES (10012, 5014, 10);
INSERT INTO ProductosEnviados VALUES (10008, 5015, 5);
INSERT INTO ProductosEnviados VALUES (10013, 5015, 3);
INSERT INTO ProductosEnviados VALUES (10016, 5015, 2);

-- Ventas
INSERT INTO Venta VALUES (1, 350.75, TO_DATE('2025-04-05', 'YYYY-MM-DD'), 11);
INSERT INTO Venta VALUES (2, 420.00, TO_DATE('2025-04-12', 'YYYY-MM-DD'), 11);
INSERT INTO Venta VALUES (3, 390.25, TO_DATE('2025-04-20', 'YYYY-MM-DD'), 11);
INSERT INTO Venta VALUES (4, 480.00, TO_DATE('2025-04-03', 'YYYY-MM-DD'), 12);
INSERT INTO Venta VALUES (5, 315.50, TO_DATE('2025-04-18', 'YYYY-MM-DD'), 12);
INSERT INTO Venta VALUES (6, 335.99, TO_DATE('2025-04-30', 'YYYY-MM-DD'), 12);
INSERT INTO Venta VALUES (7, 410.00, TO_DATE('2025-04-01', 'YYYY-MM-DD'), 13);
INSERT INTO Venta VALUES (8, 375.99, TO_DATE('2025-04-10', 'YYYY-MM-DD'), 13);
INSERT INTO Venta VALUES (9, 450.00, TO_DATE('2025-04-25', 'YYYY-MM-DD'), 13);
INSERT INTO Venta VALUES (10, 395.00, TO_DATE('2025-04-07', 'YYYY-MM-DD'), 14);
INSERT INTO Venta VALUES (11, 499.50, TO_DATE('2025-04-17', 'YYYY-MM-DD'), 14);
INSERT INTO Venta VALUES (12, 360.00, TO_DATE('2025-04-27', 'YYYY-MM-DD'), 14);
INSERT INTO Venta VALUES (13, 385.25, TO_DATE('2025-04-06', 'YYYY-MM-DD'), 15);
INSERT INTO Venta VALUES (14, 430.00, TO_DATE('2025-04-15', 'YYYY-MM-DD'), 15);
INSERT INTO Venta VALUES (15, 470.75, TO_DATE('2025-04-22', 'YYYY-MM-DD'), 15);
INSERT INTO Venta VALUES (16, 495.99, TO_DATE('2025-05-02', 'YYYY-MM-DD'), 16);
INSERT INTO Venta VALUES (17, 405.00, TO_DATE('2025-05-10', 'YYYY-MM-DD'), 16);
INSERT INTO Venta VALUES (18, 325.50, TO_DATE('2025-05-18', 'YYYY-MM-DD'), 16);
INSERT INTO Venta VALUES (19, 399.99, TO_DATE('2025-05-01', 'YYYY-MM-DD'), 17);
INSERT INTO Venta VALUES (20, 449.99, TO_DATE('2025-05-08', 'YYYY-MM-DD'), 17);
INSERT INTO Venta VALUES (21, 388.80, TO_DATE('2025-05-15', 'YYYY-MM-DD'), 17);
INSERT INTO Venta VALUES (22, 335.20, TO_DATE('2025-05-03', 'YYYY-MM-DD'), 18);
INSERT INTO Venta VALUES (23, 345.00, TO_DATE('2025-05-11', 'YYYY-MM-DD'), 18);
INSERT INTO Venta VALUES (24, 380.75, TO_DATE('2025-05-19', 'YYYY-MM-DD'), 18);
INSERT INTO Venta VALUES (25, 377.77, TO_DATE('2025-05-05', 'YYYY-MM-DD'), 19);
INSERT INTO Venta VALUES (26, 455.00, TO_DATE('2025-05-13', 'YYYY-MM-DD'), 19);
INSERT INTO Venta VALUES (27, 398.25, TO_DATE('2025-05-20', 'YYYY-MM-DD'), 19);
INSERT INTO Venta VALUES (28, 360.60, TO_DATE('2025-05-04', 'YYYY-MM-DD'), 20);
INSERT INTO Venta VALUES (29, 443.00, TO_DATE('2025-05-12', 'YYYY-MM-DD'), 20);
INSERT INTO Venta VALUES (30, 389.90, TO_DATE('2025-05-21', 'YYYY-MM-DD'), 20);

-- Producto vendido
INSERT INTO ProductoVendido VALUES (10001, 1, 1);
INSERT INTO ProductoVendido VALUES (10003, 1, 1);
INSERT INTO ProductoVendido VALUES (10002, 2, 3);
INSERT INTO ProductoVendido VALUES (10004, 3, 1);
INSERT INTO ProductoVendido VALUES (10005, 3, 1);
INSERT INTO ProductoVendido VALUES (10006, 4, 1);
INSERT INTO ProductoVendido VALUES (10001, 4, 1);
INSERT INTO ProductoVendido VALUES (10007, 5, 2);
INSERT INTO ProductoVendido VALUES (10008, 6, 1);
INSERT INTO ProductoVendido VALUES (10009, 6, 1);
INSERT INTO ProductoVendido VALUES (10010, 7, 1);
INSERT INTO ProductoVendido VALUES (10011, 8, 1);
INSERT INTO ProductoVendido VALUES (10012, 8, 1);
INSERT INTO ProductoVendido VALUES (10013, 9, 1);
INSERT INTO ProductoVendido VALUES (10014, 9, 1);
INSERT INTO ProductoVendido VALUES (10015, 10, 1);
INSERT INTO ProductoVendido VALUES (10016, 11, 1);
INSERT INTO ProductoVendido VALUES (10001, 13, 2);
INSERT INTO ProductoVendido VALUES (10003, 13, 1);
INSERT INTO ProductoVendido VALUES (10002, 14, 1);
INSERT INTO ProductoVendido VALUES (10005, 15, 2);
INSERT INTO ProductoVendido VALUES (10007, 15, 1);
INSERT INTO ProductoVendido VALUES (10006, 16, 2);
INSERT INTO ProductoVendido VALUES (10008, 17, 1);
INSERT INTO ProductoVendido VALUES (10009, 17, 1);
INSERT INTO ProductoVendido VALUES (10010, 18, 2);
INSERT INTO ProductoVendido VALUES (10012, 19, 1);
INSERT INTO ProductoVendido VALUES (10013, 19, 1);
INSERT INTO ProductoVendido VALUES (10014, 20, 1);
INSERT INTO ProductoVendido VALUES (10015, 21, 1);
INSERT INTO ProductoVendido VALUES (10004, 23, 1);
INSERT INTO ProductoVendido VALUES (10006, 23, 1);
INSERT INTO ProductoVendido VALUES (10007, 24, 2);
INSERT INTO ProductoVendido VALUES (10009, 25, 1);
INSERT INTO ProductoVendido VALUES (10010, 25, 2);
INSERT INTO ProductoVendido VALUES (10011, 26, 1);
INSERT INTO ProductoVendido VALUES (10014, 27, 1);
INSERT INTO ProductoVendido VALUES (10015, 27, 1);
INSERT INTO ProductoVendido VALUES (10016, 28, 2);
INSERT INTO ProductoVendido VALUES (10003, 30, 1);
-- Agregar URL a los libros, juegos de mesa y 
ALTER TABLE Libro
ADD URL VARCHAR2(255);

ALTER TABLE JuegoMesa
ADD URL VARCHAR2(255);

UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/6197NHIuvAL._AC_UF894,1000_QL80_.jpg' WHERE CodigoInterno = 10001;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/81GdvpmsH1L.jpg' WHERE CodigoInterno = 10002;
UPDATE Libro SET URL = 'https://images.cdn1.buscalibre.com/fit-in/520x520/6c/dc/6cdca797aa4ff4ecdc9a8d6816627c1f.jpg' WHERE CodigoInterno = 10003;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/81plBFoPgtL._AC_UF350,350_QL50_.jpg' WHERE CodigoInterno = 10004;
UPDATE Libro SET URL = 'https://www.rae.es/sites/default/files/portada_cien_anos_de_soledad_0.jpg' WHERE CodigoInterno = 10005;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/M/MV5BZmJkMGIxOWYtZmExZS00MzkxLWE2ZjItYWYyMDgwYTczZGRkXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg' WHERE CodigoInterno = 10006;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/91AD20mBK4L._AC_UF894,1000_QL80_.jpg' WHERE CodigoInterno = 10007;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/71xUCZbuogL._AC_UF894,1000_QL80_.jpg' WHERE CodigoInterno = 10008;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/71mssSA7QgL._AC_UF894,1000_QL80_.jpg' WHERE CodigoInterno = 10009;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/51R9GoucIIL._AC_UF894,1000_QL80_.jpg' WHERE CodigoInterno = 10010;
UPDATE Libro SET URL = 'https://m.media-amazon.com/images/I/715coA35k-L._UF894,1000_QL80_.jpg' WHERE CodigoInterno = 10011;
UPDATE Libro SET URL = 'https://www.penguinlibros.com/mx/3078707-large_default/tan-poca-vida.webp' WHERE CodigoInterno = 10012;
UPDATE JuegoMesa SET URL = 'https://assets.infinitygamingtable.com/assets/GameIcons/4/icon-0000000669/Monopolygreen__FitMaxWzI1NiwyNTZd.png' WHERE CodigoInterno = 10013;
UPDATE JuegoMesa SET URL = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTd4T-ADLQnEGO9xBnXpiujhnu1EqYjqSCUCw&s' WHERE CodigoInterno = 10014;
UPDATE JuegoMesa SET URL = 'https://m.media-amazon.com/images/I/71xfEOIdUWL.jpg' WHERE CodigoInterno = 10015;
UPDATE JuegoMesa SET URL = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRKDN7AVq6inthCJLTNJQMJFjJm4JUGroYMJA&s' WHERE CodigoInterno = 10016;



--Agregar Login
CREATE TABLE Login (
    userId NUMBER GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY,
    email VARCHAR2(255) NOT NULL,
    pass VARCHAR2(255) NOT NULL,
    cliente NUMBER(1) DEFAULT 0 NOT NULL
);
ALTER TABLE Login RENAME COLUMN pass TO password;
