# hackernews-dotnet

Command line application that outputs the top posts from HackerNews in JSON
Requirements: https://gist.github.com/lucamartinetti/01b2d3b05cd19a42e2d494202a951175

## How To Run
In `hackernews-dotnet/src/hackernews/bin/Release/netcoreapp2.0` choose the OS you are running.

e.g. if you are running Ubuntu go to `ubuntu-x64/publish` dir and run:
 `./hackernews --posts $n`
 where n is an integer from 0 to 100 

Alternatively if the OS you are running is not listed in the directory mentioned above and you already have .NET sdk installed (or if you don't but willing to do so) you should run:
`dotnet --posts $n` from the `hackernews-dotnet/src/hackernews` dir.


## Improvements
   - Unit tests && comments :)
   - run in Docker
