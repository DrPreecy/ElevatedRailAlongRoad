# Codex Task Order

Codex should work in this order and stop expanding scope.

## Task 1 — Verify build assumptions
- inspect project
- identify exact CS1 assemblies required
- make the project compile with local assembly references
- document setup

## Task 2 — Minimal mod load
- implement `IUserMod`
- implement loading extension if needed
- log successful initialization

## Task 3 — Prefab discovery
- enumerate loaded train/rail network prefabs
- produce a safe filter
- avoid hard-coded workshop IDs

## Task 4 — Read one selected road segment
- implement selection prototype
- log node IDs and positions

## Task 5 — Create one rail segment
- straight segment only
- +12 m default elevation
- rollback on failure

## Task 6 — Connected chain
- deduplicate shared generated nodes
- preserve ordering

## Task 7 — Lateral offset
- implement local perpendicular offset

## Task 8 — Curves
- best-effort curve matching
- keep code understandable

## Task 9 — UI
- minimal controls only

## Task 10 — Undo
- remove only objects created by the last run

At every step:
- compile
- keep changes small
- do not build future features
