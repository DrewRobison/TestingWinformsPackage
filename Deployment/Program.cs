using static Bullseye.Targets;
using static SimpleExec.Command;



Target("build", () => RunAsync("dotnet", "build --configuration Release --nologo --verbosity quiet"));
Target("test", dependsOn: ["build"], () => RunAsync("dotnet", "test --configuration Release --no-build --nologo --verbosity quiet"));
Target("pack", dependsOn: ["test"], () => RunAsync("dotnet", "pack --configuration Release --no-build --nologo --verbosity quiet --output C:\\Users\\drewr\\LocalNuget"));
Target("default", dependsOn: ["test"]);

await RunTargetsAndExitAsync(args, ex => ex is SimpleExec.ExitCodeException);

/*
 * https://github.com/adamralph/bullseye.git
 * run from the command line
 * ex: C:\Users\drewr\source\repos\TestingWinformsPackage>dotnet run --project Deployment
 */