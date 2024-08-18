--drop database Restaurants;
create database Restaurants;


insert into chefs(Name,Salary,PhoneNumber) values('Chef1',25000.25,'98-456123');
insert into chefs(Name,Salary,PhoneNumber) values('Chef2',25000.25,'11-125489');
insert into chefs(Name,Salary,PhoneNumber) values('Chef3',1000.98,'12-7854623');
insert into chefs(Name,Salary,PhoneNumber) values('Chef4',50000,'25-124562');
insert into chefs(Name,Salary,PhoneNumber) values('Chef5',45000,'98-451265');
insert into chefs(Name,Salary,PhoneNumber) values('Chef6',4500.25,'98-454265');
insert into chefs(Name,Salary,PhoneNumber) values('Chef7',95000.50,'48-671265');
insert into chefs(Name,Salary,PhoneNumber) values('Chef8',115000,'97-451356');
insert into chefs(Name,Salary,PhoneNumber) values('Chef9',45000,'19-451273');



insert into foods(Name,FoodCategory,Price,ChefId) values('Pepperoni',1,30.05,2);
insert into foods(Name,FoodCategory,Price,ChefId) values('Steak and garlic',1,50.05,3);
insert into foods(Name,FoodCategory,Price,ChefId) values('Mushroom Burger',3,30,1);
insert into foods(Name,FoodCategory,Price,ChefId) values('Kebab',1,60,4);
insert into foods(Name,FoodCategory,Price,ChefId) values('Pesto',1,20,1);
insert into foods(Name,FoodCategory,Price,ChefId) values('Alfredo',2,100,2);
insert into foods(Name,FoodCategory,Price,ChefId) values('TexMex',1,200,2);
insert into foods(Name,FoodCategory,Price,ChefId) values('Mushroom Burger',3,120,1);


insert into customers(Name,PhoneNumber,LastVisit,Expense) values('John','99-125469',GETDATE(),100);
insert into customers(Name,PhoneNumber,LastVisit,Expense) values('Tom','99-125459','2023/05/11',25);
insert into customers(Name,PhoneNumber,LastVisit,Expense) values('Paul','99-125469','2022/11/24',60);
insert into customers(Name,PhoneNumber,LastVisit,Expense) values('Janice','99-125469',GETDATE(),40);
insert into customers(Name,PhoneNumber,LastVisit,Expense) values('Jerry','99-12546959945959',GETDATE(),70);
insert into customers(Name,PhoneNumber,LastVisit,Expense) values('ksdjaskdnasdnasdkjaso;djaso;da','99-12546959945959',GETDATE(),80);



insert into CustomerFood values(2,3);
insert into CustomerFood values(3,4);
insert into CustomerFood values(4,4);
insert into CustomerFood values(5,2);
insert into CustomerFood values(5,3);


select * from customers;
select * from foods;
select * from chefs;