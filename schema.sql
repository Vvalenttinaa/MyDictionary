-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema my_dictionary
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema my_dictionary
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `my_dictionary` DEFAULT CHARACTER SET utf8 ;
USE `my_dictionary` ;

-- -----------------------------------------------------
-- Table `my_dictionary`.`word`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `my_dictionary`.`word` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `content` VARCHAR(120) NOT NULL,
  `translation` VARCHAR(120) NOT NULL,
  `idiom` TINYINT NOT NULL,
  `like` TINYINT NULL,
  `delete` TINYINT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
