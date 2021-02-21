Feature: SentFolder
	Description: This feature will test sent folder

Background:
	Given I have navigated to Gmail page

@Test
Scenario Outline: Checking send folder
	When click at Compose button from sidebar
	And populate hanna@gmail.com as recipient, my_own@gmail.com as CC, <topic> as subject, <msg> as message body	
	And open Sent folder from sidebar
	Then save first 10 subjects at Sent folder

	Examples:
		| topic        | msg          |
		| Nice weather | Best regards |