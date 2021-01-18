Feature: Comments
	

Scenario Outline: Get all comments on specified post 
Given I have made a API request to get comments on post <postNumber>
Then I see list of comments on specified post  with status OK

Examples: 
 | postNumber |  
 | 1          | 


 Scenario Outline: Get comments on invalid post 
Given I have made a API request to get comments on post <postNumber>
Then I see list of comments on invalid post  with status NotFound

Examples: 
 | postNumber |  
 | 0          | 