# Numbers to words translator

## Requirements
1. Translation is for positive integer values between 0 and 9999
1. Translation is required for English language only
1. To be written using C#
1. Any type of UI for the translator is permitted

## Additional optional requirements
1. Translation can be extended to apply to decimal values, limited to 2 decimal places

## Testing
1. When converting zero, the output should be zero
1. When input is 1234, the output should be one thousand, two hundred and thirty-four
1. Special cases where "missing" elements should be handled correctly:
  1. When the input is 1001, the output should be one thousand and one
  1. When the input is 2300, the output should be two thousand, three hundred

## UI Details
1. A console application is used as the interface
1. Enter any number to attempt to perform a translation.
  1. Any attempt to enter a value outside the accepted default range of 0-9999 shall display an error message
  1. Any attempt to enter a blank input shall display an error message
  1. Any attempt to enter values containing decimals shall display an error message
  1. Any attempt to enter non-numeric values shall display an error message
1. Terminate the application by typing `quit` in the prompt