Didn't want to pay $20, chance for more hands-on with WPF/MVVM

Will take a bitwarden CSV and analyze it for you (delete the file after done for safety)
Shows which passwords have been found in breaches, and which are duplicates in a easy-to-see format.

Uses HaveIBeenPwned API to determine breached passwords. 
plain-text passwords are not sent, only first 5 of the SHA-1 hash.
As of writing the API is not rate limited for passwords, but it will try and compact similar-prefix hashes to reduce API calls.
