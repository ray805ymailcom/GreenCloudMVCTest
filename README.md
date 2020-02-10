# GreenCloudMVCTest
Raymond Nunez

This is an ASP.NET Core(v 2.1) MVC web application with following functionality.

1) If the user submits a number divisible by 3, display the word “Green” under the textbox.

2) If the input is a number divisible by 5, display the word “Cloud”.

3) If it is divisible by both 3 and 5, display “Green Cloud”, 

Otherwise, display the number entered.

If the input is not a positive whole number, display an appropriate error message.
a) If text entered is not a positive whole number or non-numeric string, displays "Please enter positive whole number".
b) If nothing is entered and user presses submit, displays "Please enter positive whole number".
c) To prevent user from entering numbers greater than the max 32-bit Integer value, string entered is validated to check if its no longer than 9 digits.

Main Components:
Views/Home/NumberForm.cshtml: Webpage where user enters number and posts to the NumberForm action in HomeController. Also, displays below the textbox appropriate result of form submission.  Also, displays any error messages. Minimized logic as much as possible in html page per View definition.
Controllers/HomeController.cs: Receives request from form post, returns result into the ViewBag depending on what user entered (if data validation passes in model), and returns back to the View.
Models/UserInput:  Class that declares the variable that will hold what the user entered as a string.  Also, data validation using DataAnnotation is added here.

Project GreenCloud.MVC.MVCSamplePage.Test project inside solution has Unit Tests to test controller and data validation.
