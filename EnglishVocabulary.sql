use master

go 
create database EnglishVocabulary

go
use EnglishVocabulary

go 
create table Unit (
	id int primary key identity(1,1),
	name nvarchar(100)
)

go 
create table En_to_Vi (
	id int primary key identity(1,1),
	en nvarchar(100),
	vi nvarchar(100),
	unit int,
	constraint FK_EnToVi_Unit foreign key (unit) references Unit(id)
)


