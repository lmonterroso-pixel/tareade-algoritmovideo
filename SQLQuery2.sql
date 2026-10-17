
USE GastosDB;
GO

DELETE FROM Gastos;
GO

INSERT INTO Gastos (Descripcion, Monto, Categoria)
VALUES
('Almuerzo', 45.50, 'Comida'),
('Gasolina', 250.00, 'Transporte'),
('Cine', 75.00, 'Entretenimiento');
GO