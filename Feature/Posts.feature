Feature: Posts
	

Scenario: Get all posts 
Given I have made a API request to get posts 
Then I see list of posts  with status OK


Scenario Outline: Get specified post
Given I have made a API request to get all posts for <postNumber>
Then I see post  with status OK
Examples: 
 | postNumber |  
 | 1          | 

	
Scenario Outline: Get all comments on specified post 
Given I have made a API request to get comments on post <postNumber>
Then I see list of comments on specified post  with status 'OK'

Examples: 
 | postNumber |  
 | 1          | 
