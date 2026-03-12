# DVLD - Driving License Management System

![C#](https://img.shields.io/badge/C%23-.NET%20Framework-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2012%2B-red)
![Architecture](https://img.shields.io/badge/3--Layer-Architecture-brightgreen)

## 📋 Overview
**DVLD** (Driving Vehicle Licensing Department) is a C# Windows Forms application for managing driving licenses, vehicles, violations, and users. Built with **3-Layer Architecture** and **SQL Server**, it ensures clean separation of concerns and scalability.

## ✨ Features
- **User Management** (login, roles, permissions)
- **People Registry** (citizen data)
- **License Services** (issue, renew, replace, international)
- **Vehicle Registration** & ownership tracking
- **Traffic Violations** (record, fines, payments)
- **Tests Management** (vision, theory, driving)
- **Reports & Statistics**
- **Secure Data Persistence** via SQL Server

## 🛠 Technologies
- C# (.NET Framework 4.7.2)
- Windows Forms
- SQL Server
- ADO.NET
- 3-Layer Architecture (Presentation, Business, Data Access)

## 📁 Project Structure
DVLD/ # Root folder
├── DVLD.Presentation/ # UI (Forms, Controls)
├── DVLD.Business/ # Business Logic Layer
├── DVLD.DataAccess/ # Data Access Layer (SQL)
├── DVLD.Utilities/ # Helpers (optional)
├── DVLD.sln
└── README.md

 Default login: `Msaqer77` / `1234`.

## 🚀 Usage
After login, navigate through modules: People, Users, Licenses, Applications, Tests, Violations, Vehicles, Reports.

## 💡 Architecture Note
The project follows **3-Layer Architecture**:
- **Presentation**: WinForms (no direct DB access)
- **Business**: Encapsulates business rules
- **Data Access**: Handles all SQL communication via stored procedures
This design improves maintainability, testability, and reusability.

