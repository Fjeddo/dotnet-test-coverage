param (    
    [string] $testCsProj,
    [string] $outputFolder='.\coverage-report'
)

dotnet test $testCsProj --collect:"XPlat Code Coverage" --results-directory .\TestResults
reportgenerator "-reports:./TestResults/**/coverage.cobertura.xml" "-targetdir:$outputFolder" "-reporttypes:HtmlInline"
