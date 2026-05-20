# KindLink

## 📌 Overview

**KindLink** is a web application built using ASP.NET that connects volunteers with organizations offering volunteer opportunities. The platform allows organizations to post volunteer positions and helps users discover meaningful ways to contribute to their community.

## 🎯 Purpose

The purpose of this application is to:

* Simplify the process of finding volunteer opportunities
* Help organizations reach potential volunteers
* Promote community engagement and social impact

## 🛠️ Technologies Used

* ASP.NET Core (MVC)
* C#
* HTML5 & CSS3
* Bootstrap
* JavaScript / jQuery

## 🧩 Features

* 🏠 Home page with navigation
* 🔐 User authentication (login/register)
* 🏢 Organization management
* 📋 Volunteer position listings
* 📅 Event-based opportunities with date and location
* 📱 Responsive design using Bootstrap

## 📂 Project Structure

* **Models/**

  * `Organization.cs` → Stores organization details (name, email, phone, address)
  * `VolunteerPosition.cs` → Stores volunteer opportunities linked to organizations
* **Views/**

  * Razor views for UI rendering
* **Controllers/**

  * Handles application logic and routing
* **wwwroot/**

  * Static files (CSS, JS, libraries)

## 🧱 Data Models

### Organization

Represents an organization offering volunteer opportunities:

* `OrganizationId` (Primary Key)
* `Name`
* `Email`
* `PhoneNumber`
* `Address`

### VolunteerPosition

Represents a volunteer opportunity:

* `VolunteerPositionId` (Primary Key)
* `Title`
* `Description`
* `EventDate`
* `Location`
* `OrganizationId` (Foreign Key)

## 🚀 How to Run the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/kindlink.git
   ```
2. Open the project in Visual Studio
3. Restore dependencies
4. Run the application

## 📸 Future Improvements

* Add search and filtering for volunteer opportunities
* Allow users to apply directly to positions
* Add user profiles and tracking of volunteer hours
* Improve UI/UX design

## 👩‍💻 Author

**Naomi Soubhia Doi**
Student ID: 200645137
Course: Server-Side Scripting - ASP.NET (COMP2084)

