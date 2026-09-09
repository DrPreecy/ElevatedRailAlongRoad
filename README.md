# CS1 Elevated Rail Along Road — MVP

A deliberately small Cities: Skylines 1 mod project.

## Goal

Build one useful tool:

1. Player selects an existing road/path segment chain.
2. Player chooses an elevated rail network.
3. Player chooses height and optional horizontal offset.
4. The mod creates a railway following the selected road geometry.
5. The road itself is not replaced or modified.

The tool should feel like a small quality-of-life utility, not a new infrastructure framework.

## Local build setup

This project targets .NET Framework 4.7.2 and references Cities: Skylines 1 assemblies from the installed game directory.

On this computer, the verified managed-assembly directory is:

```text
E:\SteamLibrary\steamapps\common\Cities_Skylines\Cities_Data\Managed
```

The project requires these files from that directory:

- `ICities.dll`
- `Assembly-CSharp.dll`
- `ColossalManaged.dll`
- `UnityEngine.dll`

Install Visual Studio Build Tools or Visual Studio with MSBuild and the .NET Framework 4.7.2 targeting/developer pack. Then, in PowerShell, set the assembly location and build:

```powershell
$env:CS1_MANAGED_DIR = "E:\SteamLibrary\steamapps\common\Cities_Skylines\Cities_Data\Managed"
dotnet build .\ElevatedRailAlongRoad.csproj
```

If `dotnet` is unavailable, build the project with the installed `MSBuild.exe` after setting the same environment variable.

## Non-goals

Do **not** build, in this MVP:

- an AI transit planner
- a station planner
- a custom road generator
- procedural station throats
- automatic cargo/passenger routing
- custom meshes or textures
- a new network asset system
- a dependency on Road Builder / Adaptive Networks
- a large abstraction framework
- custom rendering unless needed for a simple preview

## Existing tools expected to remain useful

This mod is designed to complement rather than replace:

- Move It
- Network Multitool
- Node Controller Renewal
- Network Anarchy
- Intersection Marking Tool
- Railway 2 / other user-installed railway networks

## MVP user flow

1. Open tool from a small toolbar/button.
2. Click `Select Road`.
3. Select a connected chain of road segments.
4. Choose a rail `NetInfo`.
5. Set:
   - Height, default 12 m
   - Horizontal offset, default 0 m
6. Show a simple preview if reasonably easy.
7. Click `Create`.
8. Create elevated rail nodes and segments following the source geometry.
9. Support Undo for the most recent creation.

## Important design rule

The road and railway remain **separate networks**.

Do not attempt to make a combined road+rail asset.

## First success criterion

A straight two-segment road can be selected and a compatible elevated railway is generated above it at +12 m without modifying the road.

Then extend to curves and longer chains.
