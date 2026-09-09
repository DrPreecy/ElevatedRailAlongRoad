# Implementation placeholders

The following classes are intentionally **not** preimplemented:

- `ElevatedRailTool`
- `RailNetworkResolver`
- `RailGeometry`
- `RailCreator`
- `SimpleUI`

Reason: these depend on the exact CS1 game assemblies/API signatures available
in the user's local installation. Codex should inspect the referenced assemblies
rather than inventing API calls from memory.

The source files included here only establish the smallest safe project direction.
