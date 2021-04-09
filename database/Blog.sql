-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Tempo de geração: 09/04/2021 às 03:29
-- Versão do servidor: 10.4.14-MariaDB
-- Versão do PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `Blog`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `Comentarios`
--

CREATE TABLE `Comentarios` (
  `Id` int(11) NOT NULL,
  `Autor` varchar(100) DEFAULT NULL,
  `Conteudo` text DEFAULT NULL,
  `Data` datetime(6) NOT NULL,
  `PostId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `Comentarios`
--

INSERT INTO `Comentarios` (`Id`, `Autor`, `Conteudo`, `Data`, `PostId`) VALUES
(1, 'Rafael', 'Que bacana!', '0001-01-01 00:00:00.000000', 1),
(2, 'João', 'Um pilar do desenvolvimento web!', '0001-01-01 00:00:00.000000', 3),
(3, 'Pedro', 'Ótimo post!', '0001-01-01 00:00:00.000000', 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `Posts`
--

CREATE TABLE `Posts` (
  `Id` int(11) NOT NULL,
  `Titulo` varchar(100) DEFAULT NULL,
  `Texto` text DEFAULT NULL,
  `Data` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `Posts`
--

INSERT INTO `Posts` (`Id`, `Titulo`, `Texto`, `Data`) VALUES
(1, 'HTML5', 'É uma linguagem de marcação de hipertexto.', '2021-03-01 10:24:00.000000'),
(3, 'JavaScript', 'Linguagem de programação utilizada para realizar animações e interações dentro das páginas web.', '2021-03-01 11:03:00.000000'),
(4, 'CSS', 'Linguagem utilizada em páginas web para criação e aplicação de estilos.', '2021-03-01 11:04:00.000000');

-- --------------------------------------------------------

--
-- Estrutura para tabela `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20210330130843_CreateDatabase', '2.2.6-servicing-10079'),
('20210401124620_ChangeVarchar', '2.2.6-servicing-10079');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `Comentarios`
--
ALTER TABLE `Comentarios`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Comentarios_PostId` (`PostId`);

--
-- Índices de tabela `Posts`
--
ALTER TABLE `Posts`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `Comentarios`
--
ALTER TABLE `Comentarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `Posts`
--
ALTER TABLE `Posts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `Comentarios`
--
ALTER TABLE `Comentarios`
  ADD CONSTRAINT `FK_Comentarios_Posts_PostId` FOREIGN KEY (`PostId`) REFERENCES `Posts` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
