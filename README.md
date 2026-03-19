# 📘 DATABASE MANAGEMENT ROADMAP

---

## 🚀 Day 1 - Connecting C# to SQL Server

### 📌 Theory
1. What is database connection  
2. What is connection string  
3. How to generate/get the connection string  
4. Basic classes: SqlConnection, SqlCommand, SqlDataReader  
5. What is using block and why we use it  

---

### 💻 Github Practice - Day01-DbCOnnectionTest
1. Create a new console app  
2. Add SqlClient to connect to db  
3. Write code to open connection to SQL server and execute select query on Students table  
4. Print result from the table in console  
5. Handle connection errors with try-catch  

```
root@localhost:3306
-trusted connections
```

---

## 🚀 Day 2 - Insert and Delete Operations

### 📌 Theory
1. ExecuteNonQuery() method for insert and delete.  
2. Parameterized queries (very important)  
3. What is SQL injection  
4. Why SQL injection is dangerous  

---

### 💻 GitHub Practice - Day02-InsertDeleteStudents
1. Menu: 1. Add student, 2. Delete Student 3. Exit  
2. Take input from FB  
3. Insert student by id  
4. Delete student by id  
5. Show number of rows affected  

---

## 🚀 Day 3 - Full CRUD Console App

### 📌 Theory
1. Learn full CRUD cycle : Insert, Select, Update, Delete  
2. Organizing code into method  
3. How to keep menu driven applications clean and structured  
4. Why always use parameterized queries over direct queries  

---

### 💻 GitHub Practice - Day03-StudentCRUDApp
1. Menu: Add Student, View Student, Update Student, Delete Student, Exit  
2. Each operation in separate method  
3. Use parameterized queries  
4. Use Exception handling  
5. Reuse same connection string  

---

## 🚀 Day 4 - LINQ on Data Loaded from Database

### 📌 Theory
1. What is LINQ?  
2. Why LINQ is used?  
3. When to use LINQ? When not to use LINQ?  
4. Basic methods: Where(), OrderBy(), FirstOrDefault(), Any(), etc  
5. Using LINQ on Lists  

---

### 💻 Github Practice - Day04-StudentSearchWithLinq
1. Load all student data into a List<Student>  
2. Use LINQ to Filter students older than 20  
3. Sort Students by email  
4. Search students by email  
5. Count total students  

---

## 🚀 Day 5 - Final Mini Project : StudentManagementSytem

### 📌 Features
1. Add Student  
2. View Students  
3. Update student  
4. Delete student  
5. Uses Parameterized queries  

---

### 🔍 Searching and Filtering
1. Search by name  
2. Filter by age  
3. Sort by name  
4. Show total student count  
5. All using LINQ  
