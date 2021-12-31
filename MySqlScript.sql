CREATE Database Software
USE Software

CREATE TABLE SoftwareType(
	id MEDIUMINT NOT NULL AUTO_INCREMENT,
	description nvarchar(50) NULL,
	primary key(id)
)

CREATE TABLE Platform(
	id MEDIUMINT NOT NULL AUTO_INCREMENT,
	description nvarchar(350) NULL,
	PRIMARY KEY(ID)
)

CREATE TABLE Location(
	id MEDIUMINT NOT NULL AUTO_INCREMENT,
	location nvarchar(350) NULL,
	primary key(id)
)

CREATE TABLE Software (
	id MEDIUMINT NOT NULL AUTO_INCREMENT,
	typeid int references SoftwareType(id),
	locationid int references location(id),
	platformid int references platform(id),
	unc nvarchar(350) NULL,
	softwareDescription nvarchar(350) NULL,
	softwareName nvarchar(350) NULL,
    primary key(id)
)

INSERT INTO Platform(description) values ('PC');
INSERT INTO Platform(description) values ('PS1');
INSERT INTO Platform(description) values ('PS2');
INSERT INTO Platform(description) values ('PSP');

INSERT INTO SoftwareType(description) VALUES ('Software');
INSERT INTO SoftwareType(description) VALUES ('Game');
INSERT INTO Location(location) values ('D:\\');
