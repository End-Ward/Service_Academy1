After downloading the folder with the solution, go on Tools, then search for the NuGet Package Manager then click on Package Manager Console, in some cases you need to go to the directory before downloading the package so use the cd command, The command thread should be like this:



cd Service_Academy1
Install-Package Npgsql
Install-Package Microsoft.EntityFrameworkCore -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.0
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -Version 8.0.0
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 8.0.0
Install-Package AutoMapper -Version 13.0.1
Install-Package bootstrap -Version 5.3.3
Install-Package jQuery -Version 3.7.1
Install-Package Microsoft.AspNetCore.Identity.UI -Version 8.0.8
Install-Package Newtonsoft.Json -Version 13.0.3


	After Installing all these packages, go to Build then click Rebuild . After rebuilding the project go to Error List then check if there is any error, if there is no error and warning message proceed on running the program.

Here is the List of the seeded account if you want to access the other interfaces:

Admin
Email:admin@lms.com
Password:Admin@123

Instructor
Email:Instructor@lms.com
Password:Instructor@123

Trainee
Email:Student@lms.com
Password:Student@123



$TO TEST ALL PARTS COPY AND PASTE THE CODE BELOW TO PROGRAM.CS

----------------------------------------------------------
FOR HOME PAGE
----------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}"); 
app.Run();

----------------------------------------------------------
FOR INSTRUCTOR PAGE
----------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Instructor}/{action=InstructorDashboard}/{id?}"); 
app.Run();

----------------------------------------------------------
FOR ADMIN PAGE
----------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Dashboard}/{id?}"); 
app.Run();

----------------------------------------------------------
FOR TRAINEE PAGE
----------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trainee}/{action=MyLearning}/{id?}"); 
app.Run();



-----------------------------------------------------------------------------------
AS OF 19/9/2024 ALL PARTS OF HTML/CSS/JS THAT ARE CURRENTLY FINISHED IS IMPLEMENTED
-----------------------------------------------------------------------------------

#For more details of each folder for ease of navigation
    $Images contains the images used in the webpage
    $Models currently use came from the previous MVC

    $Controllers
        *AccountController controls any file under the Account Folder inside the Views Folder
        *AdminController controls any file under the Adming Folder inside the Views Folder
        *HomeController controls any file under the Home Folder inside the Views Folder
        *InstructorController controls any file under the Instructor Folder inside the Views Folder
        *ProgramCreateControl controls any file under the ProgramCreate Folder inside the Views Folder
        *raineeController controls any file under the Trainee Folder inside the Views Folder
    
    $CSS
        *AccountStyle controls any stylesheet of cshtmls under the Account Folder inside the Views Folder
        *AdminStyle controls any stylesheet of cshtmls under the Admin Folder inside the Views Folder
        *HomeStyle controls any stylesheet of cshtmls under the Home Folder inside the Views Folder
        *InstructorStyle controls any stylesheet of cshtmls under the Instructor Folder inside the Views Folder
        *ProgramStyle controls any stylesheet of cshtmls under the Program Folder inside the Views Folder
        *TraineeStyle controls any stylesheet of cshtmls under the Trainee Folder inside the Views Folder
        *GeneralStyle controls all stylesheet under _Layout.cshtml and _LayoutAdmin.cshtml under Shared Folder inside Views Folder
         *site.css is currently irrelevant

    $JAVASCRIPT
        *AccountStyle controls any stylesheet of cshtmls under the Account Folder inside the Views Folder
        *AdminScript controls any script of cshtmls under the Admin Folder inside the Views Folder
        *HomeScript controls any script of cshtmls under the Home Folder inside the Views Folder
        *InstructorScript controls any script of cshtmls under the Instructor Folder inside the Views Folder
        *TraineeScript controls any script of cshtmls under the Trainee Folder inside the Views Folder
        *site.js is currently irrelevant

    $VIEWS
        *Account contains the structure of all files regarding Account 
        *Admin contains the structure of all files regarding Admin 
        *Home contains the structure of all files regarding Home 
        *Instructor contains the structure of all files regarding Instructor 
        *ProgramCreate contains the structure of all files regarding ProgramCreate 
        *Trainee contains the structure of all files regarding Trainee 
        *Shared folder contains the general layout for header and footer of all cshtmls. (_Layout.cshtml is for all page except Admin while _LayoutAdmin.cshtml is for Admin Page)
   

 #REQUIRED PARTS THAT ARE STILL MISSING
    $Lesson View for Trainee to view the module (Reason Backend Not yet started)
    $More Narrowed Front End for Each Program offered by Extension Service in program Catalog (Reason Backend Not yet started)
    $Assessment View for Trainee to view the module (Reason Backend Not yet started)
    $Uploading of Materials for Instructor (Reason Backend Not yet started)
    $Certificate Page missing (Reason Backend Not yet started)
    

-----------------------------------------------------------------------------------
AS OF 28/9/2024 ACCOUNT LOGIN AND REGISTRATION BACKEND IS FINISHED
-----------------------------------------------------------------------------------
Current UPDATE:
Register function fixed
Account Creation function implemented
Routing fixed
Password requirement updated
	*At least one lowercase letter (a-z).
	*At least one uppercase letter (A-Z).
	*At least one digit (0-9).
	*At least one non-alphanumeric character (special characters like !@#$%^&*, etc.).
	*A minimum length of 8 characters.
Profile of user is displayed
Dashboards are currently connected to accounts and their landing pages
