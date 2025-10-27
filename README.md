Project title: Hospital Management System

Description:
The Hospital Management System is a modern web application designed to streamline hospital operations by providing an intuitive interface for managing:
Patient Records: Register, update, and track patient information including medical history
Doctor Management: Maintain doctor profiles with specializations, schedules, and consultation fees
Appointment Scheduling: Book, manage, and track appointments between patients and doctors
Real-time Data Sync: All data is stored in Firebase Realtime Database for instant updates
This system helps healthcare facilities improve operational efficiency, reduce paperwork, and provide better patient care through digital record management.

Features:
🩺Patient Management

✅ Register new patients with comprehensive details
✅ View complete patient list with search and filter capabilities
✅ Update patient information (contact, address, medical history)
✅ Delete patient records with confirmation
✅ Track patient medical history and blood group
✅ Record emergency contact information

👨‍⚕️ Doctor Management

✅ Add doctors with specialization and qualifications
✅ Manage doctor profiles and availability
✅ Set consultation fees and timings
✅ Track doctor experience and credentials
✅ Update doctor schedules and contact details
✅ Remove doctor records safely

📅 Appointment System

✅ Schedule appointments with date and time selection
✅ Assign patients to specific doctors
✅ Track appointment status (Scheduled/Completed/Cancelled)
✅ Add appointment notes and reasons
✅ Update appointment details
✅ Cancel appointments with confirmation

🎨 User Interface

✅ Modern, responsive design (mobile-friendly)
✅ Intuitive navigation with visual icons
✅ Dashboard with statistics and quick access
✅ Success/Error message notifications
✅ Clean and professional layout
✅ Color-coded status indicators

🔥 Backend & Database

✅ Real-time data synchronization with Firebase
✅ RESTful API integration
✅ Secure data storage
✅ CRUD operations for all entities
✅ Data validation and error handling
✅ Automatic ID generation for records

Installation Steps:

Step 1: Clone the Repository
bash# Clone the project
git clone https://github.com/pKrish03/Hospital-Management-dotnet-MVC.git

# Navigate to project directory
cd HospitalManagement
OR Download ZIP:

Download the project as ZIP file
Extract to your desired location
Open terminal/command prompt in the extracted folder


Step 2: Restore Dependencies
bash# Restore all NuGet packages
dotnet restore

# This will install all required dependencies
Expected Output:
Restore succeeded.

Step 3: Build the Project
bash# Build the project
dotnet build

# Verify no compilation errors
Expected Output:
Build succeeded.
    0 Warning(s)
    0 Error(s)


How to Run the Project:

Method 1: Using .NET CLI (Recommended)

Open Terminal/Command Prompt in project directory
Run the application:

bash   dotnet run

Expected Output:
   Building...
   info: Microsoft.Hosting.Lifetime[14]
         Now listening on: http://localhost:5000
         Now listening on: https://localhost:5001
   info: Microsoft.Hosting.Lifetime[0]
         Application started. Press Ctrl+C to shut down.

Open your web browser and navigate to:
HTTP: http://localhost:5000
HTTPS: https://localhost:5001

Stop the application:
Press Ctrl + C in terminal


Method 2: Using Visual Studio Code

Open project in VS Code:
bash   code .
Install C# Extension (if not already installed):

Click Extensions icon in sidebar
Search for "C# Dev Kit"
Click Install

Run the project:
Press F5 or
Click "Run" → "Start Debugging" or
Open terminal in VS Code and run dotnet run
Browser will automatically open at http://localhost:5000

screenshot:
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155713" src="https://github.com/user-attachments/assets/67a1fb14-c314-414d-a020-11e5410c05ec" />
