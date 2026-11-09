DROP DATABASE IF EXISTS `BD PARCIAL 3`;
CREATE DATABASE `BD PARCIAL 3` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `BD PARCIAL 3`;

CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    nombre_completo VARCHAR(100) NOT NULL,
    password_hash VARCHAR(100) NOT NULL,
    fecha_creacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE intentos_login (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(50) NOT NULL,
    exitoso TINYINT(1) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_intentos_usuario (nombre_usuario),
    INDEX idx_intentos_fecha (fecha)
);
