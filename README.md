# Sln2NMake

## Introduction
This project was an attempt to learn lexing and parsing using F#, FsLex, and FsYacc  and generate usable NMake-compatible makefiles. The project grew out of frustration with the Visual Studio build system (that I was working with at the time). My team was used to build its software through Visual Studio everywhere, even on integration systems. This meant that in order to build the source code on new machines, you had to install Visual Studio 2008 (or was it 2010) on the target machine... and that implied that you had to go through IT getting permissions because licensing requirements. It also meant obscene amount of time waiting around for visual studio to launch and build. I considered MSBuild, but for some reason I could not get it to work with the stock conversion tools. 

I got to the point where I had begun to parse Solution files and was toying around with ideas on how to parse vcproj and vcsharpproj files. I stopped because I moved on to another job in another organization. 

I am putting this up here, just to preserve it and hoping someone might find it useful. 

