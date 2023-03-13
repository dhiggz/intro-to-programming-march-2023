# Resetting your Angular Application

You can, of course, just copy stuff from my project from time to time.

Also I'm going to turn on Live Share (more on that in a bit).

BUT, if you really want to just start over:

1. Have me push my code.
2. Do the steps here [](./how-to-sync-your-fork.md) and pull down the changes.
3. Kill the Angular Development Server (that terminal window, hit Ctrl+C real hard).
4. CLOSE Visual Studio Code.
5. Using Windows Explorer (Windows Key + E), DELETE your project. It's huge. It will take a while.
6. Copy my project over.
7. Open your new fresh project in Visual Studio Code (e.g. `c:\dev\intro-to-programming-march-2023\frontend`)
8. Open an integrated terminal Ctrl+Backtick
9. Type `npm install` (this will recreate node-modules)
10. Type `ng serve -o`
11. Party!