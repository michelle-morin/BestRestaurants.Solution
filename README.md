# _Best Restaurants Tracker_

#### _MySQL & Entity Framework Core project for Epicodus_, _Mar. 18 2020_

#### By _**Michelle Morin, Alex Skreen, Todd Walraven**_

## Description

_This application allows users to keep track of restaurants, assign restaurants to different cuisines, and assign reviews to restaurants._

## Specifications:

| Specification | Example Input | Example Output |
| ------------- |:-------------:| -------------------:|
| Application creates instance of an Cuisine object | Cuisine newCuisine = new Cuisine(type) | new Cuisine object created |
| Application creates instance of an Restaurant object | Restaurant newRestaurant = new Restaurant(name, priceRange, cuisineId) | new Restaurant object created |
| Application creates instance of an Review object | Review newReview = new Review(title, description, restaurantId) | new Review object created |
| Application saves all new cuisines in database table named cuisines | new cuisine object instantiated | new cuisine object saved as row in database table |
| If user visits '/' root route, applications displays splash page with link to '/cuisines' and '/restaurants' | user visits '/' route | displays homepage |
| If user visits '/cuisines' route, applications displays all cuisines in database, each clickable to view all restaurants in the cuisine type | user visits '/cuisines' route | displays list of cuisine types |
| If user clicks "add new cuisine" link, application redirects to new cuisine form | user clicks "add new cuisine" link | application redirects to new cuisine form |
| If user visits '/cuisines/new', application shows new cuisine form | user visits '/cuisines/new' | application displays form for adding new cuisine |
| If user visits submits new cuisine form, application adds new cuisine to database and redirects to '/cuisines' | user submits form | application adds new cuisine to database and redirects to page showing all cuisines in database |
| If user visits '/cuisines/{id}', application displays all restaurants for that cuisine | user clicks on specific cuisine in list | application redirects to display all restaurants for that cuisine |
| If user clicks on restaurant name, application redirects to page displaying details for that restaurant | user clicks restaurant name | webpage redirects to page displaying name, price range, and reviews for restaurant |
| Application allows users to add review for a restaurant | user clicks "add review" | webpage redirects to form for adding review |

## Setup/Installation Requirements

### Install .NET Core

#### on macOS:
* _[Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download a .NET Core SDK from Microsoft Corp._
* _Open the file (this will launch an installer which will walk you through installation steps. Use the default settings the installer suggests.)_

#### on Windows:
* _[Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp._
* _Open the .exe file and follow the steps provided by the installer for your OS._

#### Install dotnet script
_Enter the command ``dotnet tool install -g dotnet-script`` in Terminal (macOS) or PowerShell (Windows)._

### Clone this repository

_Enter the following commands in Terminal (macOS) or PowerShell (Windows):_
* ``cd desktop``
* ``git clone`` followed by the URL to this repository
* ``cd ToDoList.Solution``

_Confirm that you have navigated to the BestRestaurants.Solution directory (e.g., by entering the command_ ``pwd`` _in Terminal)._

_Run this application by entering the following command in Terminal (macOS) or PowerShell (Windows):_
* ``cd BestRestaurants``
* ``dotnet restore``
* ``dotnet build``
* ``dotnet run`` or ``dotnet watch run``

_To view/edit the source code of this application, open the contents of this directory in a text editor or IDE of your choice (e.g., to open all contents of the directory in Visual Studio Code on macOS, enter the command_ ``code .`` _in Terminal)._

## Technologies Used
* _Git_
* _C#_
* _.NET Core 2.2_
* _ASP.NET Core MVC_
* _dotnet script_
* _MySQL_
* _MySQL Workbench_

### License

*This webpage is licensed under the MIT license.*

Copyright (c) 2020 **_Michelle Morin, Todd Walraven, Alex Skreen_**