
create database StarWars
go

use StarWars
go

create table Images(
Id int identity primary key,
Name varchar(50),
Image varbinary(max)
)

create table Prices(
Id int identity primary key,
Name varchar(50),
MetalCost int,
GasCost int,
MineralsCost int,
TimeCost int
)

create table ResurceBuildingsLevels(
Name varchar(50) check (Name in ('MetalFactory','GasFactory','MineralsFactory','WarFactory')),
Level int,
PriceId int foreign key references Prices(Id),
ResourceTime int,
ResourseAmount int,

constraint PK_ResurceBuildingsLevels
primary key (Name, Level)
)

create table Factories(
Id int identity primary key,
Name varchar(50) check (Name in ('MetalFactory','GasFactory','MineralsFactory','WarFactory')),
Level int,
Health int,
ImageId int foreign key references Images(Id)
)

create table UnitLevels(
Name varchar(50),
Level int,
--battle
Atack int,
Shield int,
Armor int,
Health int,
Speed int,

constraint PK_unitLevels
primary key (Level, Name)
) 

create table EngineeringLevelsPrices(
EngineeringLevel int primary key,
AtackPrice int foreign key references Prices(Id),
ShieldPrice int foreign key references Prices(Id),
ArmorPrice int foreign key references Prices(Id),
SpeedPrice int foreign key references Prices(Id),
ScoutPrice int foreign key references Prices(Id),
)

create table Units(
Id int identity primary key,
Name varchar(50),
--Price
PriceId int foreign key references Prices(Id),

--battle stats
Atack int,
Shield int,
Armor int,

Speed int,
FuelConsumption int, --per square
WarFactotyRequiredLevel int,
ImageId int foreign key references Images(Id)
)

create table EngineeringFactories(
Id int identity primary key,
Name varchar(50),
AtackLevel int,
ShieldLevel int,
ArmorLevel int,
ScoutLevel int,
HealthLevel int,
ImageId int foreign key references Images(Id)
)

create table Planets(
Id int identity primary key,
Name varchar(50),
FactoryId int foreign key references Factories(Id),
EngineeringFactoryId int foreign key references EngineeringFactories(Id)
)

create table Players(
Id int identity primary key,
Name varchar(50),

PlanetId int foreign key references Planets(Id),
Metal int default 200,
Gas int default 200,
Minerals int default 200,

IncomeMetalTime int,
IncomeMetalAmount int,
IncomeGasTime int,
IncomeGasAmount int,
IncomeMineralsTime int,
IncomeMineralsAmount int
)

create table CreateUnits(
Id int identity primary key,
Name varchar(50),

Atack int,
Shield int,
Armor int,
Health int,
Speed int,
)