CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `UserProfiles` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `FullName` longtext CHARACTER SET utf8mb4 NULL,
    `Email` longtext CHARACTER SET utf8mb4 NULL,
    `IsoCountry2` longtext CHARACTER SET utf8mb4 NULL,
    `Gender` int NOT NULL,
    CONSTRAINT `PK_UserProfiles` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220212202210_Init', '5.0.14');

COMMIT;

