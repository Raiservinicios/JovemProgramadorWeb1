SELECT * FROM Aluno

DELETE Aluno
WHERE codigo = 6;

INSERT INTO Aluno (Nome, Email, Cep, CPF, Idade, Matricula)
VALUES ('Kely Souza', 'kely@example.com', '12345-678', '12345678900', 20, 'MAT123456');

-- Exemplo 1
INSERT INTO Aluno (Nome, Email, Cep, CPF, Idade, Matricula)
VALUES ('João Silva', 'joao@example.com', '54321-987', '98765432100', 22, 'MAT987654');

-- Exemplo 2
INSERT INTO Aluno (Nome, Email, Cep, CPF, Idade, Matricula)
VALUES ('Maria Santos', 'maria@example.com', '98765-432', '12345678901', 25, 'MAT567890');

-- Exemplo 3
INSERT INTO Aluno (Nome, Email, Cep, CPF, Idade, Matricula)
VALUES ('Carlos Mendes', 'carlos@example.com', '23456-789', '23456789012', 21, 'MAT345678');

-- Exemplo 4
INSERT INTO Aluno (Nome, Email, Cep, CPF, Idade, Matricula)
VALUES ('Ana Oliveira', 'ana@example.com', '34567-890', '34567890123', 24, 'MAT456789');

-- Exemplo 5
INSERT INTO Aluno (Nome, Email, Cep, CPF, Idade, Matricula)
VALUES ('Valerio Marcelo', 'valerio@example.com', '88356-036', '08995766999', 24, 'MAT456789');

ALTER TABLE Aluno
ALTER COLUMN CPF VARCHAR(14);

UPDATE Aluno
SET CPF = SUBSTRING(CPF, 1, 3) + '.' + SUBSTRING(CPF, 4, 3) + '.' + SUBSTRING(CPF, 7, 3) + '-' + SUBSTRING(CPF, 10, 2)
WHERE CPF IS NOT NULL;

ALTER TABLE Aluno
ADD CONSTRAINT UQ_CPF UNIQUE (CPF);

CREATE TABLE Aluno (
    codigo INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50),
    Email VARCHAR(100),
    Cep VARCHAR(10),
    CPF VARCHAR(11),
    Idade INT,
    Matricula VARCHAR (1000)
);
UPDATE Aluno
SET CPF = '753.571.827-17'
WHERE Codigo = 5;
SELECT *FROM Aluno