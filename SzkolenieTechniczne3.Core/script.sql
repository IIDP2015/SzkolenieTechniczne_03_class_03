create table ComplaintStatus
(
  Id          int identity
    constraint PK_ComplaintStatus
    primary key,
  Name        varchar(max) not null,
  Description varchar(max) not null
)
go

create table Category
(
  Id   int identity
    constraint PK_Category
    primary key,
  Name varchar(max) not null
)
go

create table Product
(
  Id          int identity
    constraint PK_Product
    primary key,
  Name        varchar(max) not null,
  CategoryId  int          not null
    constraint FK_Product_Category
    references Category,
  Price       int          not null,
  Description varchar(max) not null,
  Model       varchar(max) not null,
  Quantity    int          not null
)
go

create table User
(
  Id          int identity
    constraint PK_User
    primary key,
  Name        varchar(max) not null,
  Surname     varchar(max) not null,
  Pesel       int          not null,
  PhoneNumber int          not null,
  Email       varchar(max) not null,
  Password    varchar(max)
)
go

create table Orders
(
  Id        int identity
    constraint PK_Orders
    primary key,
  UserId    int  not null
    constraint FK_Orders_User
    references User,
  ProductId int  not null
    constraint FK_Orders_Product
    references Product,
  Quantity  int  not null,
  OrderDate date not null,
  Paid      bit  not null
)
go

create table News
(
  DateFromView date         not null
    constraint PK_News
    primary key,
  DateToView   date         not null,
  Contents     varchar(max) not null,
  UserId       int          not null
    constraint FK_News_User
    references User
)
go

create table Complaint
(
  Id              int identity
    constraint PK_Complaint
    primary key,
  OrderId         int          not null
    constraint FK_Complaint_Orders
    references Orders,
  Description     varchar(max) not null,
  InfoFromService varchar(max) not null,
  StatusId        int          not null
    constraint FK_Complaint_ComplaintStatus
    references ComplaintStatus
)
go


