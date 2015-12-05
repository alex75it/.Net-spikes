Feature: Connection
	In order to work with the database
	As a client
	I want to connect to it

@connection
Scenario: Connect to test database works
	Given connection server is "localhost" and port is 27101	
	And I use the user "alex" with the password "aaa" on the database "admin"	
	When I try to connect to "test" database
	Then there are no errors


@connection
Scenario: Connect to test database return error with wrong credentials
	Given connection server is "localhost" and port is 27101	
	And I use the user "fake_user" with the password "aaa" on the database "admin"	
	When I try to connect to "test" database
	Then return an error
