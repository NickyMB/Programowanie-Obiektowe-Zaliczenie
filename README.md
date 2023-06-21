<pre>
██╗     ██╗██████╗ ██████╗ ██╗███████╗██╗   ██╗ 
██║     ██║██╔══██╗██╔══██╗██║██╔════╝╚██╗ ██╔╝ 
██║     ██║██████╔╝██████╔╝██║█████╗   ╚████╔╝  
██║     ██║██╔══██╗██╔══██╗██║██╔══╝    ╚██╔╝ 
███████╗██║██████╔╝██║  ██║██║██║        ██║  
╚══════╝╚═╝╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝        ╚═╝    
</pre>

## General Informations 

The project is a console application created as part of the "Fundamentals of Object-Oriented Programming" university course. <br/>The program reflects the basic and exemplary operation of the library system through various functions such as a registration and logging system or the ability to perform operations on data (available book resources). <br/>Due to project requirements, the program does not contain or use an external database.

## Construction Specification 
language: c# <br/>
language version: 10.0<br/>
sdk: dotnet-sdk<br/>
sdk version: 6.0<br/>

## Built-in program's functions 

<ul>
  <li>Creating account - register & login system</li>
  <li>Administrator account with additional previlages</li>
  <li>Displaying the dataset of books, authors and categories</li>
  <li>Searching for books from the dataset by title, isbn number, author data or category</li>
  <li>Displaying books that are unavailable (borrowed) and recently returned by the logged in user</li>
  <li>Displaying users that have account in a system </li>
  <li>Book lending and return system</li>
  <li>Displaying "My books" </li>
</ul>

## Implemented data structures 
<ul>
  <li>arrays</li>
  <li>lists</li>
  <li>dictionary</li>
</ul>

## Usage 

Program does not require and obtain any parameters (flags) to be called.<br/>
Run by: <br/>`$ dotnet run` command in project's folder.<br/>
Requires installed dotnet sdk v6.0

## Internal specification

Program is implemented with a structural paradigm.<br/>
User interace is separated from the program's logic.

