use Nhamalicious

SELECT * FROM Proprietario

SELECT * FROM Restaurante

SELECT * FROM Prato

	
SELECT * FROM Cliente
WHERE ( Cliente.Username = 'jose' AND Cliente.Password = 'cunha1234');

SELECT * FROM Proprietario, cliente
	WHERE ((Proprietario.Username = 'jose' AND Proprietario.Password = 'cunha1234')
	OR ( Cliente.Username = 'jose' AND Cliente.Password = 'cunha1234'));