--------------- CREATE TABLES ---------------

--Creating "Country" table
CREATE TABLE Country
(
CountryId int identity(1,1) primary key,
CountryName nvarchar(50) null
)
--Creating "State" table
CREATE TABLE State
(
StateId int identity(1,1) primary key,
StateName nvarchar(50) null,
CountryId int references Country(CountryId)
)
--Creating "City" table
CREATE TABLE City
(
CityId int identity(1,1) primary key,
CityName nvarchar(50) null,
StateId int references State(StateId)
)

--------------- INSERT DATA ---------------

--Inserting countries into "Country" table
INSERT INTO Country(CountryName) VALUES ('India');
INSERT INTO Country(CountryName) VALUES ('USA');
INSERT INTO Country(CountryName) VALUES ('United Kingdom');

--Inserting states for "India" into "State" table
INSERT INTO State(StateName, CountryId) VALUES ('Andhra Pradesh', 1);
INSERT INTO State(StateName, CountryId) VALUES ('Gujarat', 1);
--Inserting states for "USA" into "State" table
INSERT INTO State(StateName, CountryId) VALUES ('Florida', 2);
INSERT INTO State(StateName, CountryId) VALUES ('New York', 2);
--Inserting states for "United Kingdom" into "State" table
INSERT INTO State(StateName, CountryId) VALUES ('Hillingdon', 3);
INSERT INTO State(StateName, CountryId) VALUES ('Wokingham', 3);

--Inserting cities for "Andhra Pradesh" into "City" table
INSERT INTO City(CityName, StateId) VALUES ('Anakapalle', 1);
INSERT INTO City(CityName, StateId) VALUES ('Chirala', 1);
INSERT INTO City(CityName, StateId) VALUES ('Hyderabad', 1);
--Inserting cities for "Gujarat" into "City" table
INSERT INTO City(CityName, StateId) VALUES ('Ahmedabad', 2);
INSERT INTO City(CityName, StateId) VALUES ('Baroda', 2);
INSERT INTO City(CityName, StateId) VALUES ('Surat', 2);
--Inserting cities for "Florida" into "City" table
INSERT INTO City(CityName, StateId) VALUES ('Apollo Beach', 3);
INSERT INTO City(CityName, StateId) VALUES ('Belleair Beach', 3);
INSERT INTO City(CityName, StateId) VALUES ('Chipley', 3);
--Inserting cities for "New York" into "City" table
INSERT INTO City(CityName, StateId) VALUES ('Adams Center', 4);
INSERT INTO City(CityName, StateId) VALUES ('Bayport', 4);
INSERT INTO City(CityName, StateId) VALUES ('Cincinnatus', 4);
--Inserting cities for "Hillingdon" into "City" table
INSERT INTO City(CityName, StateId) VALUES ('Eastcote', 5);
INSERT INTO City(CityName, StateId) VALUES ('New Bedfont', 5);
INSERT INTO City(CityName, StateId) VALUES ('Yiewsley', 5);
--Inserting cities for "Wokingham" into "City" table
INSERT INTO City(CityName, StateId) VALUES ('Arborfield', 6);
INSERT INTO City(CityName, StateId) VALUES ('Shiplake', 6);
INSERT INTO City(CityName, StateId) VALUES ('Twyford', 6);