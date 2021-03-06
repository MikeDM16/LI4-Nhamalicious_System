use Nhamalicious

SELECT * FROM Proprietario

SELECT * FROM Restaurante

SELECT * FROM Cozinha

	
SELECT * FROM Cliente
WHERE ( Cliente.Username = 'jose' AND Cliente.Password = 'cunha1234');

SELECT Prato.Descricao as d FROM Prato
	JOIN Restaurante ON Prato.idRestaurante = Restaurante.idRestaurante
	WHERE Restaurante.idTipoCozinha = 1;

SELECT * FROM Prato AS P 
JOIN Restaurante AS R  ON R.idRestaurante = P.idRestaurante 
JOIN Cozinha AS C ON C.idCozinha = R.idTipoCozinha 
WHERE  C.Designacao = 'vegetariana'

SELECT Cozinha.Designacao, Cozinha.idCozinha FROM Cliente AS C
JOIN Cliente_Preferencia_Cozinha AS PrefsC ON PrefsC.idClientePref = C.idCliente
JOIN Cozinha ON Cozinha.idCozinha = PrefsC.idCozinhaPref
WHERE C.Username = 'jose';

SELECT R.idRestaurante, R.Designacao, R.Pontuacao, R.Localizacao, 
R.idproprietario, R.idTipoCozinha, R.Contacto, VisR.Data FROM Restaurante AS R
JOIN Cliente_Visita_Restaurante AS VisR ON VisR.Restaurante_idRestaurante = R.idRestaurante
JOIN Cliente AS C ON C.idCliente = VisR.Cliente_idCliente
WHERE C.Username = 'jose';

SELECT Cozinha.Designacao, Cozinha.idCozinha FROM Cliente AS C
JOIN Cliente_Preferencia_Cozinha AS PrefsC ON PrefsC.idClientePref = C.idCliente
JOIN Cozinha ON Cozinha.idCozinha = PrefsC.idCozinhaPref
WHERE C.Username = 'jose'

SELECT R.idRestaurante, R.Designacao, R.Pontuacao, R.Localizacao,
R.Contacto, R.idProprietario, R.idTipoCozinha FROM Restaurante AS R
JOIN Proprietario ON Proprietario.idProprietario = R.idproprietario
WHERE P.Username = 'jose';

SELECT R.idRestaurante, R.Designacao, R.Pontuacao, R.Localizacao,
R.idproprietario, R.idTipoCozinha, R.Contacto FROM Proprietario
JOIN Restaurante AS R ON (R.idproprietario = 1)
WHERE Proprietario.Username = 'jose';

SELECT R.idRestaurante, R.Designacao, R.Pontuacao, R.Localizacao,
R.idproprietario, R.idTipoCozinha, R.Contacto, VisR.Data FROM Restaurante AS R
JOIN Cliente_Visita_Restaurante AS VisR ON VisR.Restaurante_idRestaurante = R.idRestaurante
JOIN Cliente AS C ON C.idCliente = VisR.Cliente_idCliente
WHERE C.Username = 'jose';


DECLARE @document varchar(64);  
SELECT @document = 'Reflectors are vital safety' +  
                   ' components of your bicycle.';  
if CHARINDEX('bicle', @document) > 0  
GO  

SELECT * FROM Prato
WHERE CHARINDEX('sopa', Prato.Designacao) > 0 

SELECT * FROM Prato
WHERE Prato.Designacao LIKE '%frango%' 