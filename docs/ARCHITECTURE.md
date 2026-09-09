# Minimal Architecture

Keep this intentionally small.

```text
src/
  Mod.cs
  LoadingExtension.cs
  ElevatedRailTool.cs
  SelectionState.cs
  RailNetworkResolver.cs
  RailGeometry.cs
  RailCreator.cs
  SimpleUI.cs
```

## Responsibilities

### Mod.cs
- mod name / description
- settings registration if needed

### LoadingExtension.cs
- initialize and dispose runtime tool

### ElevatedRailTool.cs
- coordinates selection -> preview -> create

### SelectionState.cs
- selected source segment IDs
- validation that chain is connected

### RailNetworkResolver.cs
- enumerate loaded railway `NetInfo`
- validate selected prefab

### RailGeometry.cs
- transform road node positions into rail positions
- vertical offset
- lateral offset
- curve direction helpers

### RailCreator.cs
- create nodes
- create segments
- rollback partial creation if possible

### UndoState.cs
- remember last generated node/segment IDs
- remove last creation

### SimpleUI.cs
Only:
- select road
- rail dropdown
- height
- horizontal offset
- create
- undo

Do not introduce service locators, dependency injection frameworks,
event buses, plugin systems, repositories, command frameworks, or a
large settings architecture for this MVP.
