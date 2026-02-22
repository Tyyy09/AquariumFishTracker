# AquariumFishTracker

AquariumFishTracker is a simple ASP.NET Core MVC web application created for **COMP 2084 – Server-Side Scripting**.  
The purpose of this project is to demonstrate core MVC concepts including:

- Model creation  
- One-to-many relationships  
- Controllers and Views  
- CRUD operations  
- SQL Server database integration  
---

## Project Description

This application allows users to manage **aquarium tanks** and the **fish** that live in them.  
It includes two main models:

### **Tank**
Represents an aquarium tank with properties such as:
- Name  
- Volume (liters)  
- Temperature  
- pH and water quality levels  
- Last cleaned date  

### **Fish**
Represents a fish that belongs to a specific tank.  
This creates a **one-to-many relationship**:  
**One Tank -> Many Fish**

Users can create, view, edit, and delete both tanks and fish.
