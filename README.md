# Monte Carlo Budget Simulation

## Installation on Mac
Assuming that you already have Mono with FSharp installed and in your
path, the repository includes the [Paket](http://fsprojects.github.io/Paket/index.html) bootstrapper to take care of
the rest. 

To download the Paket manager and install the required NuGet
dependencies declared in the `paket.dependencies` file, run:

    mono .paket/paket.bootstrapper.exe
    mono .paket/paket.exe install

## Installation of Windows

Change the dependency from the NuGet package `FSharp.Charting.Gtk` to
`FSharp.Charting` and use the Microsoft .NET runtime.



