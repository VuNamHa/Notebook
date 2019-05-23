use Notebook
go
create table Users
(
	UserID int identity (1,1) primary key,
	UserName varchar(30) NOT NULL UNIQUE,
	UserPassword nvarchar(50),
	Email varchar(50) NOT NULL UNIQUE,
	CreatedAt datetime
)
go
create table Notes
(
	NoteID int identity (1,1) primary key,
	NoteTitle nvarchar(50),
	NoteContent nvarchar(MAX),
	UserID int references Users(UserID),
	CreatedAt datetime,
	EditedAt datetime
)
go
create table Todos
(
	TodoID int identity (1,1) primary key,
	NoteID int references Notes(NoteID),
	TodoMessage nvarchar(255),
	DoneStatus bit default 0,
	CreatedAt datetime,
	EditedAt datetime
)