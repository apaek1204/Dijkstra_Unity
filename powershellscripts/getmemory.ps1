Get-Process | Select-Object Name,@{Name='WorkingSet';Expression={($_.WorkingSet/1KB)}} | select-string "ConsoleApplication2"

