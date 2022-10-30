use MillonesDeRegistrosDB
go;

-- procedure parameter
create type RecordList as table(record varchar(100));

-- test table
create table Records(
	id int identity(1,1) primary key,
	record varchar(100)
);

-- test procedure
create procedure Value_InsertList
	@recordList RecordList readonly
as 
begin

	set nocount on;

	truncate table Records;

	insert into Records
	select record from @recordList;
end;