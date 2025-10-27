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
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155105" src="https://github.com/user-attachments/assets/889a6a66-b0a4-4e05-a976-112f1c3dd69f" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155134" src="https://github.com/user-attachments/assets/93129f97-4506-4bb7-97e7-5407282df19d" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155512" src="https://github.com/user-attachments/assets/f94de056-db97-4cfd-967a-bb211dfb2d94" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155528" src="https://github.com/user-attachments/assets/82bd5b65-89b7-45c8-a35b-c68c4d39f264" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155611" src="https://github.com/user-attachments/assets/efbdae22-636c-4a33-ac3f-6725dfb3c395" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155629" src="https://github.com/user-attachments/assets/bf245b79-b87d-4e7a-b39e-ba23ca4a9f0b" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155659" src="https://github.com/user-attachments/assets/7c2fdca0-ddac-43c0-9ae6-6cc5d4325a57" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155713" src="https://github.com/user-attachments/assets/13e54966-5133-46d1-877b-24a6ff65f32a" />
Firebase Database
<img width="1920" height="1200" alt="Screenshot 2025-10-27 160037" src="https://github.com/user-attachments/assets/28ad776b-a875-489c-8d2b-a1a4fa5e1ca3" />
Appointments
<img width="1920" height="1200" alt="Screenshot 2025-10-27 155950" src="https://github.com/user-attachments/assets/464b7c2f-d282-471b-b682-333e5af105b4" />
Doctors
<img width="1920" height="1200" alt="Screenshot 2025-10-27 160116" src="https://github.com/user-attachments/assets/0c35568a-3cc3-40a7-8d61-f3db05cd7c81" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 160132" src="https://github.com/user-attachments/assets/fd93b0eb-c465-4f45-864a-ee478c6bf4d4" />
Patients
<img width="1920" height="1200" alt="Screenshot 2025-10-27 160150" src="https://github.com/user-attachments/assets/2bfc2a14-d81a-4794-aa75-dd00962d6bd1" />
<img width="1920" height="1200" alt="Screenshot 2025-10-27 160520" src="https://github.com/user-attachments/assets/9f9efeea-0586-475b-878f-ca7d1e6245b4" />













