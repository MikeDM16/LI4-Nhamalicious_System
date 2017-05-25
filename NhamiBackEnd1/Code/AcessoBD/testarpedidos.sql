use Nhamalicious

SELECT * FROM Proprietario

SELECT * FROM Restaurante

SELECT * FROM Prato

	
SELECT * FROM Cliente
WHERE ( Cliente.Username = 'jose' AND Cliente.Password = 'cunha1234');

SELECT Prato.Descricao as d FROM Prato
	JOIN Restaurante ON Prato.idRestaurante = Restaurante.idRestaurante
	WHERE Restaurante.idTipoCozinha = 1;

