# TeamDataDragons
In the beginning we have a class called BankLogo. This exactly what it sounds like, a code for our logo. We created this using ASCII art.
The program is started in the main method when we call the method App() from class App, here the user is asked to log in. In the App() we created an object called BankUsers. We created both Admin and BankCustomer to be able to run the program.
The functionalities for log in is in the class called LogInManager. You have 3 attempts to log in and if you fail the program closes. 
Depending on if the user is a bankcustomer or admin, they are forwarded to the bank customer menu or admin menu.
Admin menu contains five choices depending on what you want to do, the menu is made using switch case.
We also created a class called UpdateCurrencyExchange with properties called Interest and ExchangeRate. It is updated through the Admin menu.
BankCustomer menu contains 9 choices depending on what you want to do, this menu is also made using switch case. We also have two lists for accounts and for loans.
Account class depends on the BankCustomer class. If the Bankcustomer class is removed the Account class won't function. Account class has multiple functionalities for each option.
Savings class and Loan class depends on the Account class (If Account class is removed the other classes won't function). These also have functionalities for each option depending on what the user wants to do.
We created an abstract class called AbstractUser. In this class we have a method called PrintInfo that shows the users information. BankCustomer class and Admin class inherit from AbstractUser.


We added coloring to our design through out the code.


UML länk: https://lucid.app/lucidchart/invitations/accept/inv_c2347e6b-2e33-4331-8893-936fe25adc59
