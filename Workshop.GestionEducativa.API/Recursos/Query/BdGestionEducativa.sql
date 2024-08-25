CREATE TABLE Apoderado
(
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
    NumeroDocumento VARCHAR(15),
    CorreoElectronico VARCHAR(100),
    Celular VARCHAR(100),
    Direccion VARCHAR(100),
    Estado BOOLEAN,
    FechaRegistro DATE,
    UsuarioRegistro VARCHAR(50)
);

CREATE TABLE Alumno
(
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
    FechaNacimiento DATE,
    NumeroDocumento VARCHAR(15),
    IdApoderado INT REFERENCES Apoderado(Id) ON DELETE CASCADE,
    Estado BOOLEAN,
    FechaRegistro DATE,
    UsuarioRegistro VARCHAR(50)
);

CREATE TABLE PeriodoEscolar
(
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Periodo VARCHAR(50),
    FechaInicio DATE,
    FechaFin DATE,
    Estado BOOLEAN,
    FechaRegistro DATE,
    UsuarioRegistro VARCHAR(50)
);

CREATE TABLE Grado
(
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Estado BOOLEAN,
    FechaRegistro DATE,
    UsuarioRegistro VARCHAR(50)
);

CREATE TABLE Matricula
(
    Id SERIAL PRIMARY KEY,
    IdAlumno INT REFERENCES Alumno(Id) ON DELETE CASCADE,
    IdGrado INT REFERENCES Grado(Id) ON DELETE CASCADE,
    IdPeriodoEscolar INT REFERENCES PeriodoEscolar(Id) ON DELETE CASCADE,
    Estado BOOLEAN,
    FechaRegistro DATE,
    UsuarioRegistro VARCHAR(50)
);
