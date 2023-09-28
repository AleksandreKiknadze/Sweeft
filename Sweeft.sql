--create database Sweeft;

use Sweeft;

--CREATE TABLE Pupil (
--	Id int primary key identity(1, 1),
--    FirstName nvarchar(255),
--	LastName nvarchar(255),
--	Gender TinyInt,
--	Class TinyInt
--);

--CREATE TABLE Teacher (
--	Id int primary key identity(1, 1),
--    FirstName nvarchar(255),
--	LastName nvarchar(255),
--	Gender TinyInt,
--	[Subject] nvarchar(255)
--);

--CREATE TABLE PupilTeacher(
--	PupilId int foreign key references Pupil(Id),
--	TeacherId int foreign key references Teacher(Id),
--	CONSTRAINT PK_PupilTeacher PRIMARY KEY (TeacherId, PupilId)
--);

--insert into Pupil (FirstName, LastName,Gender,Class)
--values 
--(N'გიორგი', N'ბერიძე', 1, 10),
--(N'სანდრო', N'კიკნაძე', 1, 11),
--(N'მიხო', N'კიკნაძე', 1, 12),
--(N'სანდრო', N'ფოცხიშვილი', 1, 12);

--insert into Teacher (FirstName, LastName,Gender,[Subject])
--values 
--(N'მარინა', N'ბერიძე', 0, N'ისტორია'),
--(N'სანდრო', N'მოსიძე', 1, N'მათემატიკა'),
--(N'პაატა', N'კიკნაძე', 1, N'ქართული'),
--(N'ალეკო', N'ფოცხიშვილი', 1, N'ფიზიკა');

--insert into PupilTeacher(PupilId, TeacherId)
--values
--(1, 2),
--(1, 4),
--(3, 4),
--(3, 3),
--(2, 1);

SELECT t.Id, t.FirstName, p.FirstName 
FROM Teacher as t
INNER JOIN PupilTeacher as pt ON t.Id = pt.TeacherId
INNER JOIN Pupil as p ON pt.PupilId = p.Id
WHERE p.FirstName = N'გიორგი'; -- p.FirstName like N'%გიორგი%'