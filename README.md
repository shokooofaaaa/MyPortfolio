# 🌐 My Portfolio Website

![GitHub language count](https://img.shields.io/github/languages/count/shokooofaaaa/MyPortfolio?color=blue)
![GitHub repo size](https://img.shields.io/github/repo-size/shokooofaaaa/MyPortfolio?color=green)

This is the source code for my professional portfolio website. It is built using **ASP.NET Core** and follows **Clean Architecture** principles.

🔗 **Live Demo:** [tagharobianshokoofa.ir](https://tagharobianshokoofa.ir/?culture=en-US)

---

## 🏗️ Architecture & Project Structure

The project is designed based on **Clean Architecture**:

- **MyPortfolio.Domain:** Core entities and interfaces.
- **MyPortfolio.Application:** Business logic and Service interfaces.
- **MyPortfolio.Infrastructure:** Data access and SQL Server configuration.
- **MyPortfolio.EndPoint_UI:** Presentation layer (ASP.NET Core MVC).

---

## 🛠️ Tech Stack

- **Backend:** .NET 8 / ASP.NET Core
- **Database:** SQL Server / EF Core
- **Design Pattern:** Clean Architecture, Repository Pattern
- **Frontend:** HTML5, CSS3, JavaScript

---

## 🚀 Getting Started

1. Clone the repository:
   git clone https://github.com/shokooofaaaa/MyPortfolio.git

2. Update Database Connection:
   Update connection string in MyPortfolio.EndPoint_UI/appsettings.json

3. Apply Migrations:
   dotnet ef database update --project MyPortfolio.Infrastructure --startup-project MyPortfolio.EndPoint_UI

4. Run the app:
   dotnet run --project MyPortfolio.EndPoint_UI

---

## 👩‍💻 About Me

I am a **.NET Backend Developer** focused on clean code and professional engineering standards.

- 💼 **LinkedIn:** [https://www.linkedin.com/in/shokoofa-tagharobian-6548762b5]
- 🌐 **Portfolio:** [tagharobianshokoofa.ir](https://tagharobianshokoofa.ir)

---
*Developed with ❤️ by Shokoufa Taghbagian*


---


   
