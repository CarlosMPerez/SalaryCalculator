## PRIVATE REPOSITORY WITH MY SOLUTION TO RYANAIR'S HIRING TEST ##

The program should be written using **test driven development**.

We are looking for the solution to be well factored and to adhere to the SOLID principles.

-------------------------------------------------------------

Write a program which can be used to calculate the take home pay for employees based on their location.
The application should be a console app which prompts the user for the hourly rate and hours worked for the employee.
 
    Please enter the hours worked:
    Please enter the hourly rate:
    Please enter the employee’s location:
 
The program will output their gross along with a list of deductions along with a net amount.
 
    Employee location: Ireland
 
    Gross Amount: €x
 
    Less deductions
 
    Income Tax : €x
    Universal Social Charge: €x
    Pension: €x
    Net Amount: €x
 
## Requirements
 
As a payroll user I would like to see a gross amount calculation for an employee’s salary.

- Given the employee is paid €10 per hour, when the employee works 40 hours, the Gross amount is €400
 
As a payroll user I would like to see deductions charged for employees located in Ireland

- Given the employee is located in Ireland, income tax at a rate of 25% for the first €600 and 40% thereafter
- Given the employee is located in Ireland, a Universal social charge of 7% is applied for the first €500 euro and 8% thereafter
- Given the employee is located in Ireland, a compulsory pension contribution of 4% is applied
 
As a payroll user I would like to see deductions charged for employees located in Italy

- Given the employee is located in Italy, income tax at a flat rate of 25% is applied
- Given the employee is located in Italy, an INPS contribution of 9.19% is applied
 
As a payroll user I would like to see deductions charged for employees located in Germany

- Given the employee is located in Germany, income tax at a rate of 25% is applied on the first €400 and 32% thereafter
- Given the employee is located in Germany, a compulsory pension contribution of 2% is applied