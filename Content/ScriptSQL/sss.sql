-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: bd_estudo
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_clientes`
--

DROP TABLE IF EXISTS `tbl_clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `tbl_clientes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `tipo` varchar(10) DEFAULT NULL,
  `apelido` varchar(45) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `cep` varchar(15) DEFAULT NULL,
  `telefone_1` varchar(18) NOT NULL,
  `telefone_2` varchar(18) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `rg` varchar(15) DEFAULT NULL,
  `cpf_cnpj` varchar(20) DEFAULT NULL,
  `ssplocal` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `a_idx` (`uf`),
  KEY `ssplocal_cliente_idx` (`ssplocal`),
  CONSTRAINT `estado_clientes` FOREIGN KEY (`uf`) REFERENCES `tbl_estado` (`uf`),
  CONSTRAINT `ssplocal_cliente` FOREIGN KEY (`ssplocal`) REFERENCES `tbl_estado` (`uf`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8 COLLATE=utf8_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_clientes`
--

LOCK TABLES `tbl_clientes` WRITE;
/*!40000 ALTER TABLE `tbl_clientes` DISABLE KEYS */;
INSERT INTO `tbl_clientes` VALUES (44,'MANOEL','F','','','','BELO HORIZONTE','MG','','(31) 99752-4220','','','','','MG'),(45,'ADILSON OLIVEIRA','F','','','','LIMEIRA','SP','','(00) 00000-0000','','','','','SP'),(46,'MARCUS PIRES','F',NULL,NULL,NULL,NULL,NULL,NULL,'(31) 99999-9999',NULL,NULL,NULL,NULL,NULL),(47,'CARLOS PACHECO GONÇALVES','F',NULL,NULL,NULL,NULL,NULL,NULL,'(21) 99417-2521',NULL,NULL,NULL,NULL,NULL),(48,'WARLEY FERREIRA ARAUJO','F',NULL,NULL,NULL,NULL,NULL,NULL,'(31) 99412-5880',NULL,NULL,NULL,NULL,NULL),(49,'ALEXANDRE LEONARDO DA SILVA','F',NULL,NULL,NULL,NULL,NULL,NULL,'(11) 99617-9085',NULL,NULL,NULL,NULL,NULL),(50,'CARLOS FARINHA','F',NULL,NULL,NULL,NULL,NULL,NULL,'(00) 00000-0000',NULL,NULL,NULL,NULL,NULL),(51,'DUPLA MOVEIS PROJETADOS EIRELI','J',NULL,NULL,NULL,NULL,NULL,NULL,'(37) 99100-2536',NULL,NULL,NULL,NULL,NULL),(52,'LYU ALVES','F',NULL,NULL,NULL,NULL,NULL,NULL,'(41) 99658-4385',NULL,NULL,NULL,NULL,NULL),(53,'CLEDSON','F',NULL,NULL,NULL,NULL,NULL,NULL,'(81) 99646-3637',NULL,NULL,NULL,NULL,NULL),(54,'HORLEY','F',NULL,NULL,NULL,NULL,NULL,NULL,'(88) 99495-4978',NULL,NULL,NULL,NULL,NULL),(55,'SILMAR','F',NULL,NULL,NULL,NULL,NULL,NULL,'(62) 99111-1111',NULL,NULL,NULL,NULL,NULL),(56,'ROBERTA FARIAS FERREIRA','F',NULL,NULL,NULL,NULL,NULL,NULL,'(21) 98872-4807',NULL,NULL,NULL,NULL,NULL),(57,'BENETON LUIZ FERREIRA','F',NULL,NULL,NULL,NULL,NULL,NULL,'(31) 97500-0595',NULL,NULL,NULL,NULL,NULL),(58,'HANILTON BELARMINHO DOS SANTOS','F',NULL,NULL,NULL,NULL,NULL,NULL,'(21) 96416-0030',NULL,NULL,NULL,NULL,NULL),(60,'SIMON - AMAZONBRISA','F',NULL,NULL,NULL,NULL,NULL,NULL,'(69) 99355-3383',NULL,NULL,NULL,NULL,NULL),(61,'JAIME COSTA FERNANDES','F',NULL,NULL,NULL,NULL,NULL,NULL,'(00) 00000-0000',NULL,NULL,NULL,NULL,NULL),(62,'JEFFERSON PIMENTA LIMA','J',NULL,NULL,NULL,NULL,NULL,NULL,'(00) 00000-0000',NULL,NULL,NULL,NULL,NULL),(63,'DISTRIBUIDORA D EJORNAIS E PERIÓDICOS VITÓRIA LBX LTDA','J',NULL,NULL,NULL,NULL,NULL,NULL,'(00) 00000-0000',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_diaria`
--

DROP TABLE IF EXISTS `tbl_diaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `tbl_diaria` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Data` datetime NOT NULL,
  `Rota` int NOT NULL,
  `Km_Adicional` decimal(5,2) DEFAULT NULL,
  `Obs` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`,`Rota`,`Data`),
  UNIQUE KEY `Data_UNIQUE` (`Data`),
  KEY `Rota_idx` (`Rota`),
  CONSTRAINT `Rota` FOREIGN KEY (`Rota`) REFERENCES `tbl_rotas` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8 COLLATE=utf8_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_diaria`
--

LOCK TABLES `tbl_diaria` WRITE;
/*!40000 ALTER TABLE `tbl_diaria` DISABLE KEYS */;
INSERT INTO `tbl_diaria` VALUES (10,'2021-09-16 00:00:00',15,0.00,NULL),(11,'2021-09-15 00:00:00',15,0.00,NULL),(12,'2021-09-13 00:00:00',15,0.00,NULL),(13,'2021-09-14 00:00:00',15,0.00,NULL),(14,'2021-08-23 00:00:00',17,0.00,NULL),(15,'2021-08-24 00:00:00',15,0.00,NULL),(16,'2021-08-25 00:00:00',18,0.00,NULL),(17,'2021-08-26 00:00:00',15,0.00,NULL),(18,'2021-08-27 00:00:00',16,0.00,NULL),(19,'2021-08-30 00:00:00',16,0.00,NULL),(20,'2021-08-31 00:00:00',15,0.00,NULL),(21,'2021-09-01 00:00:00',15,0.00,NULL),(22,'2021-09-02 00:00:00',15,0.00,NULL),(23,'2021-09-03 00:00:00',15,0.00,NULL),(24,'2021-09-06 00:00:00',15,0.00,NULL),(26,'2021-09-08 00:00:00',19,0.00,NULL),(27,'2021-09-09 00:00:00',15,0.00,NULL),(29,'2021-09-10 00:00:00',19,0.00,'passando mal'),(30,'2021-09-11 00:00:00',17,0.00,'Internet e serviço Rolt'),(32,'2021-09-17 00:00:00',15,0.00,NULL);
/*!40000 ALTER TABLE `tbl_diaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_estado`
--

DROP TABLE IF EXISTS `tbl_estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `tbl_estado` (
  `uf` varchar(2) NOT NULL,
  `nome` varchar(75) DEFAULT NULL,
  `ibge` int DEFAULT NULL,
  `pais` int DEFAULT NULL,
  `ddd` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`uf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_estado`
--

LOCK TABLES `tbl_estado` WRITE;
/*!40000 ALTER TABLE `tbl_estado` DISABLE KEYS */;
INSERT INTO `tbl_estado` VALUES ('AC','Acre',12,1,'68'),('AL','Alagoas',27,1,'82'),('AM','Amazonas',13,1,'97,92'),('AP','Amapá',16,1,'96'),('BA','Bahia',29,1,'77,75,73,74,71'),('CE','Ceará',23,1,'88,85'),('DF','Distrito Federal',53,1,'61'),('ES','Espírito Santo',32,1,'28,27'),('EX','Exterior',99,2,NULL),('GO','Goiás',52,1,'62,64,61'),('MA','Maranhão',21,1,'99,98'),('MG','Minas Gerais',31,1,'34,37,31,33,35,38,32'),('MS','Mato Grosso do Sul',50,1,'67'),('MT','Mato Grosso',51,1,'65,66'),('PA','Pará',15,1,'91,94,93'),('PB','Paraíba',25,1,'83'),('PE','Pernambuco',26,1,'81,87'),('PI','Piauí',22,1,'89,86'),('PR','Paraná',41,1,'43,41,42,44,45,46'),('RJ','Rio de Janeiro',33,1,'24,22,21'),('RN','Rio Grande do Norte',24,1,'84'),('RO','Rondônia',11,1,'69'),('RR','Roraima',14,1,'95'),('RS','Rio Grande do Sul',43,1,'53,54,55,51'),('SC','Santa Catarina',42,1,'47,48,49'),('SE','Sergipe',28,1,'79'),('SP','São Paulo',35,1,'11,12,13,14,15,16,17,18,19'),('TO','Tocantins',17,1,'63');
/*!40000 ALTER TABLE `tbl_estado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_grupo`
--

DROP TABLE IF EXISTS `tbl_grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `tbl_grupo` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NOME` varchar(45) NOT NULL,
  `STATUS` tinyint DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `NOME_UNIQUE` (`NOME`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8 COLLATE=utf8_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_grupo`
--

LOCK TABLES `tbl_grupo` WRITE;
/*!40000 ALTER TABLE `tbl_grupo` DISABLE KEYS */;
INSERT INTO `tbl_grupo` VALUES (1,'ADMIN',1),(2,'GRUPO 1',1),(3,'GRUPO 2',1),(39,'DDDDD',1);
/*!40000 ALTER TABLE `tbl_grupo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_rotas`
--

DROP TABLE IF EXISTS `tbl_rotas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `tbl_rotas` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `DESCRICAO` varchar(255) NOT NULL,
  `TOTAL_KM` decimal(5,2) NOT NULL,
  `OBS` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rotas`
--

LOCK TABLES `tbl_rotas` WRITE;
/*!40000 ALTER TABLE `tbl_rotas` DISABLE KEYS */;
INSERT INTO `tbl_rotas` VALUES (15,'CASA/ESCRITO/CASA',20.30,'CASA ESCRITÓRIO, ESRITÓRIO PARA CASA'),(16,'CASA/ESCRITORIO/SEMPRE EDITORA/CASA',58.80,NULL),(17,'CASA/SEMPRE EDITORA/CASA',54.30,NULL),(18,'CASA/SEMPRE EDITORA/DIARIO/CASA',81.70,NULL),(19,'CASA',0.00,NULL);
/*!40000 ALTER TABLE `tbl_rotas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_usuarios`
--

DROP TABLE IF EXISTS `tbl_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `tbl_usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(45) NOT NULL,
  `senha` varchar(45) NOT NULL,
  `ID_GRUPO` int NOT NULL,
  `status` bit(1) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `nome` varchar(45) NOT NULL,
  `telefone_1` varchar(20) NOT NULL,
  `telefone_2` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `USUARIO_UNIQUE` (`usuario`),
  KEY `Grupo_idx` (`ID_GRUPO`),
  CONSTRAINT `Grupo` FOREIGN KEY (`ID_GRUPO`) REFERENCES `tbl_grupo` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_0900_ai_ci COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_usuarios`
--

LOCK TABLES `tbl_usuarios` WRITE;
/*!40000 ALTER TABLE `tbl_usuarios` DISABLE KEYS */;
INSERT INTO `tbl_usuarios` VALUES (1,'welbert','Rua22n29@',2,_binary '','WELBERT@GMAIL.COM','WELBERT','',NULL),(2,'3465465','123456',1,_binary '','welbet@gmail.com','WELBERT ALVES DE ALMEIDA SABINO','',NULL),(3,'GATITO.FERNANDES','123456',3,_binary '','gatito@gmail.com','GATITO','(33) 33333-3333',''),(6,'ANTONIO.ROBERTO','123456',3,_binary '','AntonioRoberto@gmail.com','ANTONIO ROBERTO','',NULL),(9,'DADFASFD','123456',1,_binary '','a@a.com.br','65465FDA','(11) 11111-1111',''),(10,'1111111FRRR','123456',1,_binary '','a@a.com.br','RRRR','(11) 11111-1111',''),(11,'ASDFADF','123456',3,_binary '','a@a.com.br','TTTT','(11) 11111-1111',''),(13,'IIIIIIIIIIIII','123456',3,_binary '','a@a.com.br','IIIII','(11) 11111-1111',''),(16,'BBBBB','123456',3,_binary '','a@a.com.br','BBBBB','(11) 11111-1111',''),(19,'DADFASFDGGG','123456',3,_binary '','a@a.com.br','NNNNNNNN','(11) 11111-1111','');
/*!40000 ALTER TABLE `tbl_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_vendas`
--

DROP TABLE IF EXISTS `tbl_vendas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `tbl_vendas` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `idCliente` int DEFAULT '0',
  `data_venda` date DEFAULT NULL,
  `valor_venda` decimal(8,2) DEFAULT '0.00',
  `detalhe_venda` text,
  `valor_pago` decimal(8,2) DEFAULT '0.00',
  `detalhes_pagamento` text,
  `tipo` int DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `venda_clientes_idx` (`idCliente`),
  CONSTRAINT `venda_clientes` FOREIGN KEY (`idCliente`) REFERENCES `tbl_clientes` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8 COLLATE=utf8_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_vendas`
--

LOCK TABLES `tbl_vendas` WRITE;
/*!40000 ALTER TABLE `tbl_vendas` DISABLE KEYS */;
INSERT INTO `tbl_vendas` VALUES (17,45,'2021-07-16',80.00,'AJUSTE ME SISTEMA',0.00,NULL,1),(18,45,'2021-06-20',80.00,'AJUSTE EM SISTEMA',0.00,NULL,1),(19,49,'2021-07-25',150.00,'CONSULTORIA PARA MELHORIA DO SEU SISTEMA',0.00,NULL,1),(20,49,'2021-07-01',80.00,'CONSULTORIA',0.00,NULL,1),(21,49,'2021-06-08',300.00,'CONSULTORIA',0.00,NULL,1),(22,57,'2021-05-27',80.00,'CONSULTORIA',0.00,NULL,1),(23,50,'2021-05-12',180.00,'AJUDA NO DESENVOLVIMENTO DE SISTEMA PRODUÇÃO',0.00,NULL,1),(24,47,'2021-06-18',180.00,'AULA PARA AJUDA DESENVOLVER SISTEMA PARA FACULTADADE',0.00,NULL,1),(25,47,'2021-06-01',40.00,'AULA PARA MONTAR SISTEMA',0.00,NULL,1),(26,47,'2021-05-04',40.00,'AULA PARA FACULDADE',0.00,NULL,1),(27,63,'2021-09-01',2400.00,'SISTEMA PARA GERAÇÃO DE REPARTE E ESTADÃO',0.00,NULL,1),(28,51,'2021-09-09',300.00,'CONSULTORIA DE DESENVOLVIMENTO DE SISTEMA DE MARCENARIA',0.00,NULL,1),(29,51,'2021-08-25',210.00,'CONSULTORIA E DESENOLVIMENTO SISTEMA MARCENARIA',0.00,NULL,1),(30,51,'2021-02-08',180.00,'CONSULTORIA E DESENOLVIMENTO SISTEMA MARCENARIA',0.00,NULL,1),(31,51,'2021-07-16',250.00,'CONSULTORIA E DESENOLVIMENTO SISTEMA MARCENARIA',0.00,NULL,1),(32,51,'2021-06-25',300.00,'CONSULTORIA E DESENOLVIMENTO SISTEMA MARCENARIA',0.00,NULL,1),(33,51,'2021-05-19',300.00,'CONSULTORIA E DESENOLVIMENTO SISTEMA MARCENARIA',0.00,NULL,1),(34,58,'2021-06-12',50.00,'------------------',0.00,NULL,1),(35,61,'2021-09-16',1800.00,'SISTEMA PARA CONTROLE DE MÁQUINA E OBRAS',0.00,NULL,1),(36,52,'2021-05-11',55.00,'AJUSTE EM SEU SISTEMA',0.00,NULL,1),(37,46,'2021-05-07',100.00,'AJUDA EM SISTEMA QUE ELE VENDEU',0.00,NULL,1),(38,56,'2021-05-27',120.00,'AJUDA EM SISTEMA',0.00,NULL,1),(39,55,'2021-05-29',80.00,'AJUDA EM PLANILHA DE EXCEL',0.00,NULL,1),(40,55,'2021-05-14',40.00,'AJUDA EM SISTEMA EM EXCEL',0.00,NULL,1),(41,60,'2021-08-04',100.00,'AJUSTE EM SISTEMA VENDIDO',0.00,NULL,1),(42,48,'2021-09-23',200.00,'envio de agendamento personalizado, envio de email por banco',0.00,NULL,1),(43,48,'2021-08-16',120.00,'ajuste em sistema ',0.00,NULL,1),(44,48,'2021-05-19',200.00,'AJUSTE EM SISTEMA',0.00,NULL,1),(45,45,'2021-07-16',0.00,NULL,80.00,NULL,0),(46,45,'2021-06-20',0.00,NULL,80.00,NULL,0),(47,49,'2021-07-25',0.00,NULL,150.00,NULL,0),(48,49,'2021-07-01',0.00,NULL,80.00,NULL,0),(49,49,'2021-06-08',0.00,NULL,300.00,NULL,0),(50,57,'2021-05-27',0.00,NULL,80.00,NULL,0),(51,50,'2021-05-12',0.00,NULL,180.00,NULL,0),(52,47,'2021-06-18',0.00,NULL,180.00,NULL,0),(53,47,'2021-06-01',0.00,NULL,40.00,NULL,0),(54,47,'2021-05-04',0.00,NULL,40.00,NULL,0),(55,63,'2021-09-01',0.00,NULL,2400.00,NULL,0),(56,51,'2021-09-09',0.00,NULL,300.00,NULL,0),(57,51,'2021-08-25',0.00,NULL,210.00,NULL,0),(58,51,'2021-02-08',0.00,NULL,180.00,NULL,0),(59,51,'2021-07-16',0.00,NULL,250.00,NULL,0),(60,51,'2021-06-25',0.00,NULL,300.00,NULL,0),(61,51,'2021-05-19',0.00,NULL,300.00,NULL,0),(62,58,'2021-06-12',0.00,NULL,50.00,NULL,0),(64,52,'2021-05-11',0.00,NULL,55.00,NULL,0),(65,46,'2021-05-07',0.00,NULL,100.00,NULL,0),(66,56,'2021-05-27',0.00,NULL,120.00,NULL,0),(67,55,'2021-05-29',0.00,NULL,80.00,NULL,0),(68,55,'2021-05-14',0.00,NULL,40.00,NULL,0),(69,60,'2021-08-04',0.00,NULL,100.00,NULL,0),(71,48,'2021-08-16',0.00,NULL,120.00,NULL,0),(72,48,'2021-05-19',0.00,NULL,200.00,NULL,0),(76,51,'2021-09-29',350.00,'AJUSTE EM SISTEMA E CONSULTORIA PARA DESENVOLVIMENTO DE SISTEMA DE MARCENARIA',0.00,NULL,1),(77,56,'2021-09-29',60.00,'AJUDA PARA DESENVOLVIMENTO SISTEMA\r\n',0.00,NULL,1),(79,51,'2021-09-29',0.00,NULL,350.00,'CONSULTORIA E DESENOLVIMENTO SISTEMA MARCENARIA',0),(80,61,'2021-09-29',0.00,NULL,1400.00,'PAGAMENTO ATÉ SEGUNDA PARCELA',0);
/*!40000 ALTER TABLE `tbl_vendas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vendas_pagamentos`
--

DROP TABLE IF EXISTS `vendas_pagamentos`;
/*!50001 DROP VIEW IF EXISTS `vendas_pagamentos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8 */;
/*!50001 CREATE VIEW `vendas_pagamentos` AS SELECT 
 1 AS `idCliente`,
 1 AS `SomaVenda`,
 1 AS `somaPag`,
 1 AS `diferenca`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `vendas_pagamentos`
--

/*!50001 DROP VIEW IF EXISTS `vendas_pagamentos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vendas_pagamentos` AS select `tbl_vendas`.`idCliente` AS `idCliente`,sum(`tbl_vendas`.`valor_venda`) AS `SomaVenda`,sum(`tbl_vendas`.`valor_pago`) AS `somaPag`,(sum(`tbl_vendas`.`valor_venda`) - sum(`tbl_vendas`.`valor_pago`)) AS `diferenca` from `tbl_vendas` group by `tbl_vendas`.`idCliente` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-29 16:00:19
