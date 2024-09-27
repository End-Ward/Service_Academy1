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





Current UPDATE:
Register function fixed
Account Creation function implemented
Routing fixed
Password requirement updated
At least one lowercase letter (a-z).
At least one uppercase letter (A-Z).
At least one digit (0-9).
At least one non-alphanumeric character (special characters like !@#$%^&*, etc.).
A minimum length of 8 characters.

