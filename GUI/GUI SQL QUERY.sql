CREATE DATABASE ExaminationManagement
USE ExaminationManagement

CREATE TABLE tblStudent
(stdId varchar(5) not null Primary Key,
StdName varchar(10),
StdAge int,
Gender varchar(7),
Username varchar(20) unique,
Password varchar(10));

CREATE TABLE tblLecturer
(lecId varchar(5) not null Primary Key,
lecName varchar(10),
lecAge int,
Gender varchar(7),
Username varchar(20) unique,
Password varchar(10));

CREATE TABLE tblExamination
(ExmId varchar(5) not null Primary Key,
ExmName varchar(10),
WEDate Date,
CWDate Date);

CREATE TABLE tblStudentMarks
(StdId varchar(5) references tblStudent(stdId),
ExmID varchar(5) references tblExamination(ExmID),
WEMarks decimal(5,2),
CWMarks decimal(5,2),
TotalMarks decimal(5,2),
Primary key(StdID,ExmID));

CREATE TABLE tblStudentGrade
(StdId varchar(5) references tblStudent(stdId),
ExmID varchar(5) references tblExamination(ExmID),
WEGrade varchar(3),
CWGrade varchar(3),
FinalGrade varchar(3),
PassFail varchar(5),
Primary key(StdID,ExmID));

CREATE TABLE tblAdmin
(username varchar(20) not null Primary Key,
password varchar(20) not null);

INSERT INTO tblAdmin VALUES
('Admin123','1234');


