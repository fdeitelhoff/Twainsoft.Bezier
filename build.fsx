#r @"packages\FAKE\tools\FakeLib.dll"

open Fake

RestorePackages()

let outputDir = "./output"
let buildDir = outputDir + "/build"
let version = "0.4"

Target "Clean" (fun _ -> 
    CleanDirs [buildDir]
)

Target "BuildLibrary" (fun _ ->
    !! "./src/**/*.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "Building app: "
)

"Clean"
    ==> "BuildLibrary"

RunTargetOrDefault "BuildLibrary"
