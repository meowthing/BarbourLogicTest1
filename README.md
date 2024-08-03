# Barbour Logic test 1
- Moved Account into its own file to separate concerns
- Repository class to house data manipulation logic
- Interface created to allow different repositories adhering to interface to swap in with existing one
- Consolidated reusable operations into their own methods so I don't have to modify the same logic in several places
- Tests were written to test repository functions, not Console debugging (wanted to test this as an additional piece but couldn't figure out how to achieve this in Nunit)
- Console was moved to its own class to detech from static Main runpoint while I was investigating how to test the Console through Nunit, not strictly a necessary architectural change