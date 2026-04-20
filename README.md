# AquariumFishTracker

AquariumFishTracker is an ASP.NET Core MVC web application created for **COMP 2084 – Server-Side Scripting** at Georgian College.

The application allows users to manage aquarium tanks and the fish that live in them, with full authentication and social login support.

---

## Live Site
https://aquariumfishtracker.runasp.net
Coming Soon..

## Features

- Full CRUD operations for Tanks and Fish
- ASP.NET Core Identity — local registration and login
- Google OAuth 2.0 social login
- Authenticated-only access to Create, Edit, and Delete operations
- Anonymous users can browse tanks and fish but cannot modify data
- Responsive layout built with Bootstrap

---

## Models

### Tank
Represents an aquarium tank with properties including name, volume (liters), temperature, pH, ammonia level, and last cleaned date.

### Fish
Represents a fish belonging to a specific tank, creating a one-to-many relationship:
**One Tank → Many Fish**

---

## Authentication

### Local Auth
Users can register and log in with an email and password via ASP.NET Core Identity.

### Google Login
Social login is enabled via Google OAuth 2.0. The following redirect URIs are registered in Google Cloud Console:
- `https://localhost:7021/signin-google`
- `https://yourmonsteraspdomain.com/signin-google`

---

## Tech Stack

- ASP.NET Core 8 MVC
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Google OAuth 2.0
- Bootstrap 5

---

## Getting Started

1. Clone the repository
2. Update `appsettings.json` with your SQL Server connection string and Google OAuth keys
3. Run migrations: `Update-Database -Context ApplicationDbContext`
4. Run the app and register an account at `/Identity/Account/Register`

---

## Author

**Ichty Te** — Student #200626964  
COMP 2084 – Server-Side Scripting | Georgian College
