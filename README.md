# Step-by-step to gain test coverage reports in .NET
We are going to:
- Create an sln
- Create a classlib to test
- Create a test project (xunit)
- Run the tests
- Create the test report

> This description is a seven (7) step thing, where the steps are spread out below.

All using the dotnet cli, to make it easy to migrate to Azure Devops yaml etc.

> Let's assume powershell or similar ready, dotnet cli installed etc.

## The setup process

1. Create an sln, in the current folder <br>
    `dotnet new sln`
2. Create a classlib <br>
    `dotnet new classlib -o TheClassLib`
3. Create a test project (xunit) <br>
    `dotnet new xunit -o TheClassLib.Tests`
4. Add projects to the sln <br>
    `dotnet sln add TheClassLib` <br>
    `dotnet sln add TheClassLib.Tests`

Now it is time to look into the Tests cs-proj file:
```xml
...
<ItemGroup>
  ...
  <PackageReference Include="coverlet.collector" Version="3.1.0" />
  ...  
</ItemGroup>  
...
```

This, the `coverlet.collector`, is the nuget enabling the correct test coverage collector. In this case it is added by the dotnet template xunit, in step 3 above. To add it to an existing test project, install the nuget (https://www.nuget.org/packages/coverlet.collector/).

> Now, take a look at Class1.cs in the classlib project.

> Then, take a look att UnitTest1.cs in the tests project.

All set to run tests and generate reports.

## Gather coverage info and generate report
5. To gain the coverage data, run: <br>
    `dotnet test --collect:"XPlat Code Coverage"`

This should return something like this:
```
> dotnet test --collect:"XPlat Code Coverage"
...
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Attachments:
  D:\Develop\Lab\dotnet-test-coverage\TheClassLib.Tests\TestResults\1a3c6563-97ba-4e5d-9415-dae7ad242812\coverage.cobertura.xml
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: < 1 ms - TheClassLib.Tests.dll (net6.0)
```

> The **coverage.cobertura.xml** is the file to generate the report from.

The report is generated using `ReportGenerator`, https://github.com/danielpalme/ReportGenerator. 

6. Install the `ReportGenerator` tool by: <br>
    `dotnet tool install -g dotnet-reportgenerator-globaltool`

7. Run the report generator: <br>
    `reportgenerator "-reports:./**/coverage.cobertura.xml" "-targetdir:./testreport"`

This should output something like this:
```
> reportgenerator "-reports:./**/coverage.cobertura.xml" "-targetdir:./testreport"

2021-12-09T08:05:31: Arguments
2021-12-09T08:05:31:  -reports:./**/coverage.cobertura.xml
2021-12-09T08:05:31:  -targetdir:./testreport
2021-12-09T08:05:31: Writing report file './testreport\index.html'
2021-12-09T08:05:31: Report generation took 0,3 seconds
```
The generated html "site" is located in the `testreport` folder.

**That's it!**