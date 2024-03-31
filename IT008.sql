CREATE DATABASE QLDB

USE QLDB

CREATE TABLE ACCOUNT
(
	USERNAME NCHAR(50) NOT NULL UNIQUE,
	PASS NCHAR(50) NOT NULL,
	EMAIL NCHAR(50),
	QUESTION1 NCHAR(100),
	QUESTION2 NCHAR(100),
	QUESTION2 NCHAR(100)
	PRIMARY KEY (USERNAME)
)
CREATE FUNCTION AUTO_IDCLB()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(IDCLB) FROM CLUB) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDCLB, 3)) FROM CLUB
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'CLB00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'CLB0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)

		END
	RETURN @ID
END

CREATE TABLE CLUB
(
	IDCLB CHAR(6) PRIMARY KEY CONSTRAINT IDCLB DEFAULT DBO.AUTO_IDCLB(),
	CLBID NCHAR(30) NOT NULL,
	CLBNAME NVARCHAR(50),
	STADIUM NVARCHAR(50),
	ADDRESS NVARCHAR(50),
	DAYBUILT DATE,
	PIC VARBINARY(MAX),
	NATION nvarchar(50),
	CITY nvarchar(50)
)


CREATE FUNCTION AUTO_IDPL()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(IDPL) FROM FOOTBALL_PLAYER) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDPL, 3)) FROM FOOTBALL_PLAYER
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PL00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 and @ID < 99 THEN 'PL0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 99 THEN 'PL' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE TABLE FOOTBALL_PLAYER
(
	IDPL CHAR(5) PRIMARY KEY CONSTRAINT IDPL DEFAULT DBO.AUTO_IDPL(),
	IDCLB CHAR(6) NOT NULL,
	PLNAME NVARCHAR(30),
	NATIONALITY NVARCHAR(15),
	DAY_BORN DATE,
	VITRI varchar(40),
	SCORE SMALLINT DEFAULT 0,
	YELLOWCARD TINYINT DEFAULT 0,
	REDCARD TINYINT DEFAULT 0,
	PIC VARBINARY(MAX),
	NUMBER int,
	ASSISS smallint default 0
)

CREATE FUNCTION AUTO_IDMAT()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(IDMATCH) FROM MATCH1) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDMATCH, 3)) FROM MATCH1
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'MAT00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 and @ID < 99 THEN 'MAT0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 99 THEN 'MAT' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE TABLE MATCH1
(
	IDMATCH CHAR(6) PRIMARY KEY CONSTRAINT IDMAT DEFAULT DBO.AUTO_IDMAT(),
	CLB1 CHAR(6),
	CLB2 CHAR(6),
	SCORED1 TINYINT DEFAULT 0,
	SCORED2 TINYINT DEFAULT 0,
	STAYDIUM NVARCHAR(30),
	TYPE_MATCH TINYINT DEFAULT 0,
	DATE DATE,
	TIME time(7),
	IDREF char(6)
)
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man Utd', 'Arsenal', 'Old Trafford', '2021/12/3', '2:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Spurs', 'Brentford', 'Tottenham Hotspur Stadium', '2021/12/3', '3:15' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Southampton', 'Leicester', 'St. Mary Stadium', '2021/12/2', '2:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Watford', 'Chelsea', 'Vicarage Road', '2021/12/2', '2:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('West Ham', 'Brighton', 'London Stadium', '2021/12/2', '2:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Wolves', 'Burnley', 'Molineux Stadium', '2021/12/2', '2:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Aston Villa', 'Man City', 'Villa Park', '2021/12/2', '3:15' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Everton', 'Liverpool', 'Goodison Park', '2021/12/2', '3:15' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Newcastle', 'Norwich', 'St. James Park', '2021/12/1', '2:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leeds', 'Crystal Palace', 'Elland Road', '2021/12/1', '3:15' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brighton', 'Leeds', 'Amex Stadium', '2021/11/28', '0:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brentford', 'Everton', 'Brentford Community Statium', '2021/11/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leicester', 'Watford', 'King Power Stadium', '2021/11/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man City', 'West Ham', 'Etihad Stadium', '2021/11/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Chelsea', 'Man Utd', 'Stamford Bridge', '2021/11/28', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Arsenal', 'Newcastle', 'Emirates Stadium', '2021/11/27', '19:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Crystal Palace', 'Aston Villa', 'Selhurst Park', '2021/11/27', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Liverpool', 'Southampton', 'Anfield', '2021/11/27', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Nowich', 'Wolves', 'Carrow Road', '2021/11/27', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Liverpool', 'Arsenal', 'Anfield', '2021/11/21', '0:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man City', 'Everton', 'Etihad Stadium', '2021/11/21', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Spurs', 'Leeds', 'Tottenham Hotspur Stadium', '2021/11/21', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leicester', 'Chelsea', 'King Power Stadium', '2021/11/20', '19:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Aston Villa', 'Brighton', 'Villa Park', '2021/11/20', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Burnley', 'Crystal Palace', 'Turf Moor', '2021/11/20', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Newcastle', 'Brentford', 'St. James Park', '2021/11/20', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Norwich', 'Southampton', 'Carrow Road', '2021/11/20', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Watford', 'Man Utd', 'Vicarage Road', '2021/11/20', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Wolves', 'West Ham', 'Molineux Stadium', '2021/11/20', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brighton', 'Newcastle', 'Amex Stadium', '2021/11/7', '0:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Arsenal', 'Watford', 'Emirates Stadium', '2021/11/7', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Everton', 'Spurs', 'Goodison Park', '2021/11/7', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leeds', 'Leicester', 'Elland Road', '2021/11/7', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('West Ham', 'Liverpool', 'London Stadium', '2021/11/7', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Southampton', 'Aston Villa', 'St. Mary Stadium', '2021/11/6', '3:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man Utd', 'Man City', 'Old Trafford', '2021/11/6', '19:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brentford', 'Norwich', 'Brentford Community Stadium', '2021/11/6', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Chelsea', 'Burnley', 'Stamford Bridge', '2021/11/6', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Crystal Palace', 'Wolves', 'Selhurst Park', '2021/11/6', '22:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Wolves', 'Everton', 'Molineux Stadium', '2021/11/2', '3:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Norwich', 'Leeds', 'Carrow Road', '2021/10/31', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Aston Villa', 'West Ham', 'Villa park', '2021/10/31', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leicester', 'Arsenal', 'King Power Stadium', '2021/10/30', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Burnley', 'Brentford', 'Turf Moor', '2021/10/30', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Liverpool', 'Brighton', 'Anfield', '2021/10/30', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man City', 'Crystal Palace', 'Etihad Stadium', '2021/10/30', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Newcastle', 'Chelsea', 'St. James Park', '2021/10/30', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Watford', 'Southampton', 'Vicarage Road', '2021/10/30', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Spurs', 'Man Utd', 'Tottenham Hotspur Stadium', '2021/10/30', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brentford', 'Leicester', 'Brentford Community Stadium', '2021/10/24', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('West Ham', 'Spurs', 'London Stadium', '2021/10/24', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man Utd', 'Liverpool', 'Old Trafford', '2021/10/24', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Arsenal', 'Aston Villa', 'Emirates Stadium', '2021/10/23', '2:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Chelsea', 'Norwich', 'Stamford Bridge', '2021/10/23', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Crystal Palace', 'Newcastle', 'Selhurst Park', '2021/10/23', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Everton', 'Watford', 'Goodison Park', '2021/10/23', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leeds', 'Wolves', 'Elland Road', '2021/10/23', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Southampton', 'Burnley', 'St. Mary Stadium', '2021/10/23', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brighton', 'Man City', 'Amex Stadium', '2021/10/23', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Arsenal', 'Crystal Palace', 'Emirates Stadium', '2021/10/19', '2:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Everton', 'West Ham', 'Goodison Park', '2021/10/17', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Newcastle', 'Spurs', 'St. James Park', '2021/10/17', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Watford', 'Liverpool', 'Vicarage Road', '2021/10/16', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Aston Villa', 'Wolves', 'Villa Park', '2021/10/16', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leicester', 'Man City', 'King Power Stadium', '2021/10/16', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man City', 'Burnley', 'Etihad Stadium', '2021/10/16', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Norwich', 'Brighton', 'Carrow Road', '2021/10/16', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Southampton', 'Leeds', 'St. Mary Stadium', '2021/10/16', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brentford', 'Chelsea', 'Brentford Community Stadium', '2021/10/16', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Crystal Palace', 'Leicester', 'Selhurst Park', '2021/10/3', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Spurs', 'Aston Villa', 'Tottenham Hotspur Stadium', '2021/10/3', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('West Ham', 'Brentford', 'London Stadium', '2021/10/3', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Liverpool', 'Man City', 'Anfield', '2021/10/3', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man Utd', 'Everton', 'Old Trafford', '2021/10/2', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Burnley', 'Norwich', 'Turf Moor', '2021/10/2', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Chelsea', 'Southampton', 'Stamford Bridge', '2021/10/2', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leeds', 'Watford', 'Elland Road', '2021/10/2', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Wolves', 'Newcastle', 'Molineux Stadium', '2021/10/2', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brighton', 'Arsenal', 'Amex Stadium', '2021/10/2', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Crystal Palace', 'Brighton', 'Selhurst Park', '2021/9/28', '2:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Southampton', 'Wolves', 'St. Mary Stadium', '2021/9/26', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Arsenal', 'Spurs', 'Emirates Stadium', '2021/9/26', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man Utd', 'Aston Villa', 'Old Trafford', '2021/9/25', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Chelsea', 'Man City', 'Stamford Bridge', '2021/9/25', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Everton', 'Norwich', 'Goodison Park', '2021/9/25', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leeds', 'West Ham', 'Elland Road', '2021/9/25', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leicester', 'Burnley', 'King Power Stadium', '2021/9/25', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Watford', 'Newcastle', 'Vicarage Road', '2021/9/25', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brentford', 'Liverpool', 'Brentford Community Stadium', '2021/9/25', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brighton', 'Leicester', 'Amex Stadium', '2021/9/19', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('West Ham', 'Man Utd', 'London Stadium', '2021/9/19', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Spurs', 'Chelsea', 'Tottenham Hotspur Stadium', '2021/9/19', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Newcastle', 'Leeds', 'St. James Park', '2021/9/18', '2:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Wolves', 'Brentford', 'Molineux Stadium', '2021/9/18', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Burnley', 'Arsenal', 'Turf Moor', '2021/9/18', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Liverpool', 'Crystal Palace', 'Anfield', '2021/9/18', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man City', 'Southampton', 'Etihad Stadium', '2021/9/18', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Norwich', 'Watford', 'Carrow Road', '2021/9/18', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Aston Villa', 'Everton', 'Villa Park', '2021/9/18', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Everton', 'Burnley', 'Goodison Park', '2021/9/14', '2:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leeds', 'Liverpool', 'Elland Road', '2021/9/12', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Crystal Palace', 'Spurs', 'Selhurst Park', '2021/9/11', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Arsenal', 'Norwich', 'Emirates Stadium', '2021/9/11', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brentford', 'Brighton', 'Brentford Community Stadium', '2021/9/11', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leicester', 'Man City', 'King Power Stadium', '2021/9/11', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man Utd', 'Newcastle', 'Old Trafford', '2021/9/11', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Southampton', 'West Ham', 'St. Mary Stadium', '2021/9/11', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Watford', 'Wolves', 'Vicarage Road', '2021/9/11', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Chelsea', 'Aston Villa', 'Stamford Bridge', '2021/9/11', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Burnley', 'Leeds', 'Turf Moor', '2021/8/29', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Spurs', 'Watford', 'Tottenham Hotspur Stadium', '2021/8/29', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Wolves', 'Man Utd', 'Molineux Stadium', '2021/8/29', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Aston Villa', 'Brentford', 'Villa Park', '2021/8/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brighton', 'Everton', 'Amex Stadium', '2021/8/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Newcastle', 'Southampton', 'St. James Park', '2021/8/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Liverpool', 'Chelsea', 'Anfield', '2021/8/28', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man City', 'Arsenal', 'Etihad Stadium', '2021/8/28', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Norwich', 'Leicester', 'Carrow Road', '2021/8/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('West Ham', 'Crystal Palace', 'London Stadium', '2021/8/28', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('West Ham', 'Leicester', 'London Stadium', '2021/8/24', '2:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Southampton', 'Man Utd', 'St. Mary Stadium', '2021/8/22', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Wolves', 'Spurs', 'Molineux Stadium', '2021/8/22', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Arsenal', 'Chelsea', 'Emirates Stadium', '2021/8/22', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Liverpool', 'Burnley', 'Anfield', '2021/8/21', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Aston Villa', 'Newcastle', 'Villa Park', '2021/8/21', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Crystal Palace', 'Brentford', 'Selhurst Park', '2021/8/21', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leeds', 'Everton', 'Elland Road', '2021/8/21', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man City', 'Norwich', 'Etihad Stadium', '2021/8/21', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brighton', 'Watford', 'Amex Stadium', '2021/8/21', '23:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Newcastle', 'West Ham', 'St. James Park', '2021/8/15', '20:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Spurs', 'Man City', 'Tottenham Hotspur Stadium', '2021/8/15', '22:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Brentford', 'Arsenal', 'Brentford Community Stadium', '2021/8/14', '2:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Man Utd', 'Leeds', 'Old Trafford', '2021/8/14', '18:30' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Burnley', 'Brighton', 'Turf Moor', '2021/8/14', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Chelsea', 'Crystal Palace', 'Stamford Bridge', '2021/8/14', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Everton', 'Southampton', 'Goodison Park', '2021/8/14', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Leicester', 'Wolves', 'King Power Stadium', '2021/8/14', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Watford', 'Aston Villa', 'Vicarage Road', '2021/8/14', '21:00' )
insert into MATCH1 (CLB1, CLB2, STAYDIUM, DATE, TIME ) VALUES ('Norwich', 'Liverpool', 'Carrow Road', '2021/8/14', '23:30' )



























































































































CREATE FUNCTION AUTO_IDCOACH()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(IDCOACH) FROM COACH) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDCOACH, 3)) FROM COACH
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'COA00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 and @ID < 99 THEN 'COA0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 99 THEN 'COA' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE TABLE COACH 
(
	IDCOACH CHAR(6) PRIMARY KEY CONSTRAINT IDCOA DEFAULT DBO.AUTO_IDCOACH(),
	IDCLB CHAR(6) NOT NULL,
	COACHNAME NVARCHAR(30),
	NATIONALITY NVARCHAR(15),
	DAY_BORN DATE,
	TYPE_COACH varchar(50),
)

CREATE FUNCTION AUTO_IDREFEREE()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(IDREF) FROM REFEREE) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDREF, 3)) FROM REFEREE
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'REF00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 and @ID < 99 THEN 'REF0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 99 THEN 'REF' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE TABLE REFEREE 
(
	IDREF CHAR(6) PRIMARY KEY CONSTRAINT IDREF DEFAULT DBO.AUTO_IDREFEREE(),
	REF_NAME NVARCHAR(30),
	NATIONALITY NVARCHAR(15),
	DAY_BORN DATE,
	TYPE_REF varchar(40),
)

CREATE FUNCTION AUTO_IDGOAL()
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @ID VARCHAR(7)
	IF (SELECT COUNT(IDGOAL) FROM GOAL) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDGOAL, 3)) FROM GOAL
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'GOAL00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 and @ID < 99 THEN 'GOAL0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 99 THEN 'GOAL' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE TABLE GOAL
(
    IDGOAL CHAR(7) PRIMARY KEY CONSTRAINT IDGOAL DEFAULT DBO.AUTO_IDGOAL(),
	IDPL CHAR(5) NOT NULL,
	IDCLB CHAR(6) NOT NULL,
	IDMATCH CHAR(6) NOT NULL,
	TIME_GOAL TINYINT NOT NULL,
	IDPLA CHAR(5) NULL,
	TIME_ASSIST TINYINT NULL,
	FOREIGN KEY(IDPL) REFERENCES FOOTBALL_PLAYER(IDPL),
	FOREIGN KEY(IDPLA) REFERENCES FOOTBALL_PLAYER(IDPL),
	FOREIGN KEY(IDCLB) REFERENCES CLUB(IDCLB),
	FOREIGN KEY(IDMATCH) REFERENCES MATCH1(IDMATCH)
)

CREATE TABLE CARD
(	
	IDCARD CHAR(7) PRIMARY KEY CONSTRAINT IDCARD DEFAULT DBO.AUTO_IDCARD(),
	IDPLY CHAR(5) NULL,
	IDCLB CHAR(6) NOT NULL,
	IDMATCH CHAR(6) NOT NULL,
	TIME_YELLOW TINYINT NULL,
	IDPLR CHAR(5) NULL,
	TIME_RED TINYINT NULL,
	FOREIGN KEY(IDPLY) REFERENCES FOOTBALL_PLAYER(IDPL),
	FOREIGN KEY(IDPLR) REFERENCES FOOTBALL_PLAYER(IDPL),
	FOREIGN KEY(IDCLB) REFERENCES CLUB(IDCLB),
	FOREIGN KEY(IDMATCH) REFERENCES MATCH1(IDMATCH)
)

CREATE FUNCTION AUTO_IDCARD()
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @ID VARCHAR(7)
	IF (SELECT COUNT(IDCARD) FROM CARD) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDCARD, 3)) FROM CARD
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'CARD00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 and @ID < 99 THEN 'CARD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 99 THEN 'CARD' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

CREATE TABLE BXH
(
    IDCLB CHAR(6) NOT NULL,
	PL INT DEFAULT 0,
	W INT DEFAULT 0,
	D INT DEFAULT 0,
	L INT DEFAULT 0,
	GF INT DEFAULT 0,
	GA INT DEFAULT 0,
	GD INT DEFAULT 0,
	PTS SMALLINT DEFAULT 0,
	FOREIGN KEY(IDCLB) REFERENCES CLUB(IDCLB),
)


ALTER TABLE FOOTBALL_PLAYER ADD 
CONSTRAINT FK_PL_CLB FOREIGN KEY (IDCLB) REFERENCES CLUB(IDCLB)

ALTER TABLE COACH ADD 
CONSTRAINT FK_COA_CLB FOREIGN KEY (IDCLB) REFERENCES CLUB(IDCLB)

ALTER TABLE MATCH1 ADD 
CONSTRAINT FK_MATCH_CLB1 FOREIGN KEY (CLB1) REFERENCES CLUB(IDCLB)

ALTER TABLE MATCH1 ADD
CONSTRAINT FK_MATCH_CLB2 FOREIGN KEY (CLB2) REFERENCES CLUB(IDCLB)
