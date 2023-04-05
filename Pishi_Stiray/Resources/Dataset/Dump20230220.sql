-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: trade
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `order_compound`
--

DROP TABLE IF EXISTS `order_compound`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_compound` (
  `order_id` int NOT NULL AUTO_INCREMENT,
  `compound` varchar(80) NOT NULL,
  `amount` int NOT NULL,
  PRIMARY KEY (`order_id`,`compound`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_compound`
--

LOCK TABLES `order_compound` WRITE;
/*!40000 ALTER TABLE `order_compound` DISABLE KEYS */;
INSERT INTO `order_compound` VALUES (1,'А112Т4',10),(2,'A346R4',10),(3,'B730E2',10),(4,'H452A3',10),(5,'F719R5',1),(6,'N459R6',2),(7,'J539R3',20),(8,'A567R4',5),(9,'K753R3',1),(10,'S425T6',5);
/*!40000 ALTER TABLE `order_compound` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_status`
--

DROP TABLE IF EXISTS `order_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_status` (
  `id` int NOT NULL AUTO_INCREMENT,
  `status` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_status`
--

LOCK TABLES `order_status` WRITE;
/*!40000 ALTER TABLE `order_status` DISABLE KEYS */;
INSERT INTO `order_status` VALUES (1,'Новый '),(2,'Завершен');
/*!40000 ALTER TABLE `order_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderproduct`
--

DROP TABLE IF EXISTS `orderproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderproduct` (
  `OrderID` int NOT NULL,
  `ProductArticleNumber` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`OrderID`,`ProductArticleNumber`),
  KEY `ProductArticleNumber` (`ProductArticleNumber`),
  CONSTRAINT `orderproduct_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `orderuser` (`OrderID`),
  CONSTRAINT `orderproduct_ibfk_2` FOREIGN KEY (`ProductArticleNumber`) REFERENCES `product` (`ProductArticleNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderproduct`
--

LOCK TABLES `orderproduct` WRITE;
/*!40000 ALTER TABLE `orderproduct` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderuser`
--

DROP TABLE IF EXISTS `orderuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderuser` (
  `OrderID` int NOT NULL AUTO_INCREMENT,
  `OrderStatus` int NOT NULL,
  `OrderDeliveryDate` datetime NOT NULL,
  `OrderPickupPoint` text NOT NULL,
  `Point of issue` int NOT NULL,
  `FullNameClient` varchar(45) DEFAULT NULL,
  `ReceiptCode` varchar(45) NOT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `order_status_fk_idx` (`OrderStatus`),
  CONSTRAINT `order_compound_fk` FOREIGN KEY (`OrderID`) REFERENCES `order_compound` (`order_id`),
  CONSTRAINT `order_status_fk` FOREIGN KEY (`OrderStatus`) REFERENCES `order_status` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderuser`
--

LOCK TABLES `orderuser` WRITE;
/*!40000 ALTER TABLE `orderuser` DISABLE KEYS */;
INSERT INTO `orderuser` VALUES (1,1,'2024-05-20 22:00:00','18.05.2022',3,'Высоцкая Майя Давидовна','311'),(2,2,'2025-05-20 22:00:00','19.05.2022',4,'Агеев Дамир Давидович','312'),(3,1,'2026-05-20 22:00:00','20.05.2022',5,'','313'),(4,1,'2027-05-20 22:00:00','21.05.2022',6,'','314'),(5,2,'2028-05-20 22:00:00','22.05.2022',7,'','315'),(6,1,'2029-05-20 22:00:00','23.05.2022',10,'','316'),(7,1,'2030-05-20 22:00:00','24.05.2022',11,'','317'),(8,1,'2031-05-20 22:00:00','25.05.2022',20,'Терентьев Филипп Богданович','318'),(9,1,'2001-06-20 22:00:00','26.05.2022',30,'Голубева Лея Петровна','319'),(10,1,'2002-06-20 22:00:00','27.05.2022',33,'','320');
/*!40000 ALTER TABLE `orderuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pmanufacturer`
--

DROP TABLE IF EXISTS `pmanufacturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pmanufacturer` (
  `PManufacturerID` int NOT NULL AUTO_INCREMENT,
  `ProductManufacturer` varchar(80) NOT NULL,
  PRIMARY KEY (`PManufacturerID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pmanufacturer`
--

LOCK TABLES `pmanufacturer` WRITE;
/*!40000 ALTER TABLE `pmanufacturer` DISABLE KEYS */;
INSERT INTO `pmanufacturer` VALUES (1,'Attache'),(2,'Erich Krause'),(3,'FLEXOFFICE CANDEE'),(4,'GoodMark'),(5,'Hatber'),(6,'Pilot'),(7,'Svetocopy'),(8,'Unimax'),(9,'Комус');
/*!40000 ALTER TABLE `pmanufacturer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pname`
--

DROP TABLE IF EXISTS `pname`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pname` (
  `PNameID` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(100) NOT NULL,
  PRIMARY KEY (`PNameID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pname`
--

LOCK TABLES `pname` WRITE;
/*!40000 ALTER TABLE `pname` DISABLE KEYS */;
INSERT INTO `pname` VALUES (1,'Бумага офисная'),(2,'Карандаш-корректор'),(3,'Клей ПВА'),(4,'Клей-карандаш'),(5,'Кнопки'),(6,'Корректирующая жидкость'),(7,'Корректирующая лента'),(8,'Лента клейкая'),(9,'Маркер'),(10,'Набор шариковых ручек одноразовых'),(11,'Ножницы'),(12,'Папка-скоросшиватель'),(13,'Ручка гелевая'),(14,'Ручка шариковая'),(15,'Ручка шариковая автоматическая'),(16,'Скобы'),(17,'Скрепки'),(18,'Степлер'),(19,'Стикеры'),(20,'Тетрадь');
/*!40000 ALTER TABLE `pname` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `ProductArticleNumber` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ProductName` int NOT NULL,
  `ProductDescription` text NOT NULL,
  `ProductCategory` int NOT NULL,
  `ProductPhoto` varchar(150) NOT NULL,
  `ProductManufacturer` int NOT NULL,
  `ProductCost` float NOT NULL,
  `ProductMaxDiscount` int DEFAULT NULL,
  `ProductProvider` int NOT NULL,
  `ProductDiscountAmount` tinyint DEFAULT NULL,
  `ProductQuantityInStock` int NOT NULL,
  `Unit` int DEFAULT NULL,
  `ProductStatus` text,
  PRIMARY KEY (`ProductArticleNumber`),
  KEY `unit_fk_idx` (`Unit`),
  KEY `product_fk_idx` (`ProductName`),
  KEY `provider_fk_idx` (`ProductProvider`),
  KEY `product_category_fk_idx` (`ProductCategory`),
  KEY `product_manufacture_fk_idx` (`ProductManufacturer`),
  CONSTRAINT `product_category_fk` FOREIGN KEY (`ProductCategory`) REFERENCES `product_category` (`id`),
  CONSTRAINT `product_fk` FOREIGN KEY (`ProductName`) REFERENCES `pname` (`PNameID`),
  CONSTRAINT `product_manufacture_fk` FOREIGN KEY (`ProductManufacturer`) REFERENCES `pmanufacturer` (`PManufacturerID`),
  CONSTRAINT `provider_fk` FOREIGN KEY (`ProductProvider`) REFERENCES `provider` (`id`),
  CONSTRAINT `unit_fk` FOREIGN KEY (`Unit`) REFERENCES `unit` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('A297U6',13,'Ручка гелевая ErichKrause® G-Cube®, цвет чернил черный',4,'',2,52,20,1,4,18,2,NULL),('A340R5',9,'Маркер перманентный GoodMark 2-х сторонний.для СD/DVD черный',3,'',4,66,15,1,4,27,2,NULL),('A346R4',15,'Ручка шариковая автоматическая с синими чернилами, диаметр шарика 0,9 мм',4,'A346R4.jpg',1,35,20,2,3,23,2,NULL),('A384T5',20,'Тетрадь, 18 листов, А5 линейка Hatber/Хатбер Серия Зеленая 10шт в блистере',4,'',5,87,20,1,3,23,1,NULL),('A543T6',14,'Ручка шариковая Erich Krause, R-301 ORANGE 0.7 Stick, синий',3,'A543T6.jpg',2,13,30,1,6,12,2,NULL),('A567R4',14,'Шариковая ручка PILOT SuperGrip 0,7 мм синяя BPGP-10R-F-L',4,'',6,64,30,1,2,32,2,NULL),('B730E2',14,'Ручка шариковая одноразовая автоматическая Unimax Fab GP синяя (толщина линии 0.5 мм)',4,'B730E2.jpg',8,41,10,2,3,45,2,NULL),('D367R4',3,'Клей ПВА 85г Hatber/Хатбер',4,'',5,26,20,1,4,16,2,NULL),('D419T7',4,'Клей-карандаш Erich Krause 15 гр.',3,'D419T7.png',2,61,18,1,4,26,2,NULL),('F719R5',12,'Папка-скоросшиватель, А4 Hatber/Хатбер 140/180мкм АССОРТИ, пластиковая с перфорацией прозрачный верх',3,'F719R5.jpg',5,18,20,1,3,8,2,NULL),('G278R6',14,'Ручка шариковая FLEXOFFICE CANDEE 0,6 мм, синяя',3,'G278R6.png',3,15,30,1,7,23,2,NULL),('H452A3',20,'Тетрадь, 24 листа, Зелёная обложка Hatber/Хатбер, офсет, клетка с полями',4,'H452A3.png',5,10,8,1,3,25,2,NULL),('J539R3',5,'Кнопки канцелярские Комус металлические цветные (50 штук в упаковке)',3,'',9,96,20,2,3,24,1,NULL),('K345R5',7,'Корректирующая лента Attache Economy 5 мм x 5 м',3,'',1,87,20,2,3,12,2,NULL),('K502T9',2,'Карандаш-корректор GoodMark, морозостойкий, 8мл, металлический наконечник',3,'',4,70,25,1,2,7,2,NULL),('K753R3',6,'Корректирующая жидкость (штрих) Attache быстросохнущая 20 мл',4,'',1,50,30,2,2,5,2,NULL),('K932R4',7,'Корректор лента 5мм*4м, блистер, GoodMark',3,'',4,70,25,1,3,16,2,NULL),('M892R4',11,'Ножницы 195 мм Attache с пластиковыми прорезиненными анатомическими ручками бирюзового/черного цвета',4,'',1,209,15,2,5,13,2,NULL),('N459R6',19,'Стикеры Attache Selection 51х51 мм неоновые 5 цветов (1 блок, 250 листов)',3,'',1,194,25,2,3,9,1,NULL),('N592T4',19,'Стикеры Attache 76x76 мм пастельные желтые (1 блок, 100 листов)',3,'',1,34,15,2,2,17,1,NULL),('R259E6',1,'Бумага офисная Svetocopy NEW A4 80г 500л',3,'R259E6.jpg',7,299,25,1,4,32,1,NULL),('S276E6',17,'Скрепки Комус металлические никелированные 33 мм (100 штук в упаковке)',3,'',9,46,30,2,2,14,1,NULL),('S425T6',16,'Скобы для степлера №24/6 Attache оцинкованные (1000 штук в упаковке)',3,'',1,25,20,2,2,16,1,NULL),('S453G7',17,'Скрепки 28 мм Attache металлические (100 штук в упаковке)',3,'',1,21,15,2,4,20,1,NULL),('S512T7',16,'Скобы №10 1000шт, к/к, GoodMark',3,'',4,25,15,1,3,32,1,NULL),('S563T6',18,'Степлер Attache 8215 до 25 листов черный',3,'',1,231,25,2,4,17,2,NULL),('T564P5',10,'Набор шариковых ручек одноразовых Attache Economy Spinner 10 цветов (толщина линии 0.5 мм)',4,'T564P5.jpg',1,50,15,2,9,5,1,NULL),('Z390R4',8,'Клейкая лента упаковочная Комус 50 мм x 100 м 50 мкм прозрачная',3,'',9,195,20,2,2,9,2,NULL),('Z539E3',8,'Лента клейкая 12мм*33м прозрачная, Hatber/Хатбер',3,'',5,16,15,1,2,14,2,NULL),('А112Т4',14,'Ручка шариковая с синими чернилами,толщина стержня 7 мм',3,'А112Т4.jpg',6,12,30,2,2,6,2,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_category`
--

DROP TABLE IF EXISTS `product_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_category` (
  `id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_category`
--

LOCK TABLES `product_category` WRITE;
/*!40000 ALTER TABLE `product_category` DISABLE KEYS */;
INSERT INTO `product_category` VALUES (1,'Бумага офисная'),(2,'Для офиса'),(3,'Тетради школьные'),(4,'Школьные принадлежности');
/*!40000 ALTER TABLE `product_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `provider`
--

DROP TABLE IF EXISTS `provider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `provider` (
  `id` int NOT NULL AUTO_INCREMENT,
  `provider_name` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `provider`
--

LOCK TABLES `provider` WRITE;
/*!40000 ALTER TABLE `provider` DISABLE KEYS */;
INSERT INTO `provider` VALUES (1,'Буквоед'),(2,'Комус');
/*!40000 ALTER TABLE `provider` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(100) NOT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Администратор'),(2,'Клиент'),(3,'Менеджер');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit`
--

DROP TABLE IF EXISTS `unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unit` (
  `id` int NOT NULL AUTO_INCREMENT,
  `unit_name` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit`
--

LOCK TABLES `unit` WRITE;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` VALUES (1,'уп.'),(2,'шт.');
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `UserSurname` varchar(100) NOT NULL,
  `UserName` varchar(100) NOT NULL,
  `UserPatronymic` varchar(100) NOT NULL,
  `UserLogin` text NOT NULL,
  `UserPassword` text NOT NULL,
  `UserRole` int NOT NULL,
  PRIMARY KEY (`UserID`),
  KEY `user_ibfk_1` (`UserRole`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`UserRole`) REFERENCES `role` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=151 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (101,'Никифоров ','Всеволод','Иванович','loginDEjrm2018','Cpb+Im',2),(102,'Воронов ','Донат','Никитевич','loginDEpxl2018','P6h4Jq',1),(103,'Игнатьева ','Евгения','Валентиновна','loginDEwgk2018','&mfI9l',2),(104,'Буров ','Федот','Егорович','loginDEpou2018','gX3f5Z',1),(105,'Иванов','Иван ','Семёновна','loginDEjwl2018','D4ZYHt',3),(106,'Денисов ','Дамир','Филатович','loginDEabf2018','*Tasm+',2),(107,'Ершов ','Максим','Геласьевич','loginDEwjm2018','k}DJKo',2),(108,'Копылов ','Куприян','Пётрович','loginDEjvz2018','&|bGTy',3),(109,'Носов ','Валерьян','Дмитрьевич','loginDEuyv2018','8hhrZ}',3),(110,'Силин ','Игорь','Авдеевич','loginDExdm2018','DH68L9',1),(111,'Дроздова ','Александра','Мартыновна','loginDEeiv2018','H*BxlS',3),(112,'Дроздов ','Аркадий','Геласьевич','loginDEfuc2018','VuM+QT',2),(113,'Боброва ','Варвара','Евсеевна','loginDEoot2018','usi{aT',3),(114,'Чернова ','Агата','Данииловна','loginDElhk2018','Okk0jY',3),(115,'Лыткина ','Ульяна','Станиславовна','loginDEazg2018','s3bb|V',2),(116,'Лаврентьев ','Леонид','Игнатьевич','loginDEaba2018','#ИМЯ?',1),(117,'Кулаков ','Юрий','Владленович','loginDEtco2018','tTKDJB',2),(118,'Соловьёв ','Андрей','Александрович','loginDEsyq2018','2QbpBN',3),(119,'Корнилова ','Марфа','Макаровна','loginDEpxi2018','+5X&hy',2),(120,'Белоусова ','Любовь','Георгьевна','loginDEicr2018','3+|Sn{',2),(121,'Анисимов ','Никита','Гордеевич','loginDEcui2018','Zi1Tth',3),(122,'Стрелкова ','Фаина','Федосеевна','loginDEpxc2018','G+nFsv',2),(123,'Осипов ','Евгений','Иванович','loginDEqrd2018','sApUbt',1),(124,'Владимирова ','Иванна','Павловна','loginDEsso2018','#ИМЯ?',3),(125,'Кудрявцева ','Жанна','Демьяновна','loginDErsy2018','{Aa6nS',3),(126,'Матвиенко ','Яков','Брониславович','loginDEvpz2018','mS0UxK',3),(127,'Селезнёв ','Егор','Артёмович','loginDEfog2018','glICay',2),(128,'Брагин ','Куприян','Митрофанович','loginDEpii2018','Ob}RZB',2),(129,'Гордеев ','Виктор','Эдуардович','loginDEhyk2018','*gN}Tc',1),(130,'Мартынов ','Онисим','Брониславович','loginDEdxi2018','ywLUbA',3),(131,'Никонова ','Евгения','Павловна','loginDEzro2018','B24s6o',3),(132,'Полякова ','Анна','Денисовна','loginDEuxg2018','K8jui7',2),(133,'Макарова ','Пелагея','Антониновна','loginDEllw2018','jNtNUr',2),(134,'Андреева ','Анна','Вячеславовна','loginDEddg2018','gGGhvD',1),(135,'Кудрявцева ','Кира','Ефимовна','loginDEpdz2018','#ИМЯ?',2),(136,'Шилова ','Кира','Егоровна','loginDEyiw2018','cnj3QR',3),(137,'Ситников ','Игорь','Борисович','loginDEqup2018','95AU|R',1),(138,'Русаков ','Борис','Христофорович','loginDExil2018','w+++Ht',1),(139,'Капустина ','Ульяна','Игоревна','loginDEkuv2018','Ade++|',3),(140,'Беляков ','Семён','Германнович','loginDEmox2018','Je}9e7',3),(141,'Гурьев ','Ириней','Игнатьевич','loginDEvug2018','lEa{Cn',2),(142,'Мишин ','Христофор','Леонидович','loginDEzre2018','N*VX+G',2),(143,'Лазарева ','Антонина','Христофоровна','loginDEbes2018','NaVtyH',3),(144,'Маркова ','Ираида','Сергеевна','loginDEkfg2018','r1060q',2),(145,'Носкова ','Пелагея','Валерьевна','loginDEyek2018','KY2BL4',2),(146,'Баранов ','Станислав','Дмитрьевич','loginDEloq2018','NZV5WR',1),(147,'Ефремов ','Демьян','Артёмович','loginDEjfb2018','TNT+}h',3),(148,'Константинов ','Всеволод','Мэлсович','loginDEueq2018','GqAUZ6',3),(149,'Ситникова ','Ираида','Андреевна','loginDEpqz2018','F0Bp7F',3),(150,'Матвеев ','Кондрат','Иванович','loginDEovk2018','JyJM{A',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-20 16:12:17
