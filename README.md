# Moravia.Homework

Issues with the original code:

Actual errors:
- IDisposable variables are not disposed

User convenience issues:
- no interaction with UI (input source & target paths, write result and user-friendly errors)
- unhandled exceptions

Code issues:
- catching an exception and throwing a new one doesn't help anything + clears stack trace
- missing null-check on expected XML elements could result in NullReferenceException, which doesn't correctly describe the issue
- no reason for Document to be mutable
- inconsistent use of implicit/explicit types
- missing access modifiers
- some variable names are not adequate
