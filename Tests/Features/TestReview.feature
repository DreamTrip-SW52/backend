Feature: Test Review

A short summary of the feature

@tag1
Scenario: [Add review]
	Given The user with ID 5
	And The package 4
	When The user enters to add a review and it is verified that he did not write a review previously
	Then The user can add a review
@tag2
Scenario: [Modify review]
	Given The user with ID 5
	And The package 3
	When The user enters to add a review and it is verified that he did not write a review previously
	Then The user can not add a review
