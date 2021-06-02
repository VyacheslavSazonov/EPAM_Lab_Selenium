Feature: NwApp


Scenario: CreateNewProduct

	Given I open "http://localhost:5000" url
	When I login with name "user" and password "user"	
	And I click on button send
	And I click on button All Products
	And I click on button Create New
	And I fill field for create new product
	And I click on button send product
	And I click on new test product
	Then all field should be filled correct



Scenario: DeleteProduct

	Given I open "http://localhost:5000" url
	When I login with name "user" and password "user"	
	And I click on button send
	And I click on button All Products
	And I click on button Remove test product
	Then test product should be remove