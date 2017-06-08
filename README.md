# AsosRefactor
I went through the project applied SOLID principles where possible and improved maintainance.
I didn't have enough time to removed the hard coded strings or create types for the different type of clients in the CreditLimit Validator.
I was able to create interfaces for Company, Customer, CompanyRepository and also put the validation logic into validator classes. 
The customer service class is easier to read, however other classes could use more refactoring.

There are also some simple tests for the validation logic around credit limits, there would also need to tests around Customer, Company etc.
