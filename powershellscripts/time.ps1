$Stopwatch = [system.diagnostics.stopwatch]::startNew()
& ".\ConsoleApplication2.exe"

$Stopwatch.Stop()
$Stopwatch.ElapsedMilliseconds

