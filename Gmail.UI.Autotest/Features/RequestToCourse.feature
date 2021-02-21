Feature: Request to course
	Description: This feature will test Request to course

Background:
	Given I have navigated to QALight page

@Test @Smoke
Scenario Outline: Checking Request to course
	When click at Request to course button
	Then verify that <FooterName> is shown

	Examples:
		| FooterName             |
		| Напрямки навчання      |
		| Напрямки бла-бла-блАаА |

@Test @Regressions
Scenario Outline: Checking smth
	When click at Request to course button
	Then verify that <FooterName> is shown

	Examples:
		| FooterName             |
		| Напрямки навчання      |
		| Напрямки навчання      |
		| Напрямки какие-то      |