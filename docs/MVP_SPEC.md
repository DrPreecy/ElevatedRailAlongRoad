## Problem

In Cities: Skylines 1, building an elevated railway precisely over a road is repetitive:
- draw the road
- switch to railway
- manually match the alignment
- fix curves
- correct height
- correct lateral offset
- repeat

The MVP removes only this repeated alignment work.

## Functional requirements

### FR-01 — Road chain selection
The user can select one or more connected road segments.

### FR-02 — Railway prefab selection
The user can choose an available railway `NetInfo` that can be used in elevated form.

Do not hard-code Railway 2. Prefer discovering compatible loaded network prefabs.

### FR-03 — Height
User can specify vertical offset in meters.

Default:
`12`

Initial reasonable range:
`4–40`

### FR-04 — Horizontal offset
User can specify a lateral offset relative to the road centerline.

Default:
`0`

Initial reasonable range:
`-32–32`

### FR-05 — Generation
The tool creates railway nodes/segments following the road chain.

The source road remains unchanged.

### FR-06 — Curves
For curved road segments, generated railway should visually follow the same geometry as closely as the game API reasonably allows.

Do not spend excessive effort on perfect mathematical equivalence in v0.1.

### FR-07 — Undo
The tool stores the IDs of newly created nodes/segments for the latest operation and can remove them.

### FR-08 — Error handling
Do not crash the game if:
- selection is invalid
- segments are disconnected
- prefab is missing
- node creation fails
- segment creation fails

Log a useful error and show a concise UI message.

---

# Technical constraints

- Cities: Skylines 1
- C#
- Visual Studio Code friendly
- Build outside the game
- Prefer minimal dependencies
- Do not use Harmony unless actually required
- Do not depend on Road Builder or Adaptive Networks
- Avoid coupling to specific Workshop asset IDs
- Use the game's loaded prefab data where possible
- Keep the implementation small enough to understand manually

---

# Geometry strategy

Use the selected road network only as a geometric reference.

For every selected source segment:

1. Read start node and end node.
2. Read source positions.
3. Read segment direction/control information where accessible.
4. Add vertical offset.
5. Apply lateral offset perpendicular to local travel direction.
6. Reuse/create corresponding rail nodes.
7. Create rail segments between them.

For the first version:
- straight roads first
- then curves
- then mixed chains

Do not block the MVP on perfect curve reconstruction.

---

# Suggested implementation order

## Step 1
Compile a minimal CS1 mod and write a log line when enabled.

## Step 2
Enumerate loaded railway `NetInfo` prefabs and log them.

## Step 3
Select one road segment and read:
- segment ID
- start node
- end node
- positions

## Step 4
Create one elevated rail segment above one straight road segment.

## Step 5
Connected multi-segment chain.

## Step 6
Basic curves.

## Step 7
Tiny UI.

## Step 8
Undo.

Do not skip directly to a polished UI before geometry creation works.

---

# Acceptance tests

## Test A — Straight road
Given:
- one straight road segment
- height 12
- offset 0

Expected:
- rail segment centered above road
- road unchanged

## Test B — Two connected segments
Expected:
- continuous rail
- no duplicate rail node at shared road node

## Test C — Offset
Given offset +5 m:
- railway is visibly shifted to one side

## Test D — Curved road
Expected:
- railway follows approximately the road curve
- no obvious 90-degree kink

## Test E — Undo
Expected:
- generated rail from last operation disappears
- source road remains

## Test F — Invalid prefab
Expected:
- operation aborts safely
- no crash
- concise error shown/logged
