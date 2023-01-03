go
create table dmathang
(
	id varchar(36) primary key,
	code varchar(50) character set utf8,
	name varchar(255) character set utf8,
	dongia int
)
go
create table dkhachhang
(
	id varchar(36) primary key,
	code varchar(50) character set utf8,
	name varchar(255) character set utf8,
	dienthoai varchar(10) character set utf8,
	diachi varchar(255) character set utf8
)
go
create table dbanggia
(
	id varchar(36) primary key,
	name varchar(255) character set utf8,
	tungay date,
	denngay date
)
go
create table dbanggiachitiet
(
	id varchar(36) primary key,
	dbanggiaid varchar(36),
	dmathangid varchar(36),
	duoi1kg int,
	tu1kgtrolen int
)
go
create table tdonhang
(
	id varchar(36) primary key,
	ngay date,
	name varchar(255) character set utf8,
	dkhachhangid varchar(36),
	note varchar(1000) character set utf8,
	tongcong int
)
go
create table tdonhangchitiet
(
	id varchar(36) primary key,
	tdonhangid varchar(36),
	dmathangid varchar(36),
	soluong decimal(18,2),
	dongia int,
	thanhtien int
)
go
create table tthanhtoan
(
	id varchar(36) primary key,
	ngay date,
	name varchar(255) character set utf8,
	dkhachhangid varchar(36),
	tongcong int,
	note varchar(1000) character set utf8
)