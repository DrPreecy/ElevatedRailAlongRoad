# Prompt for Codex

You are working on a Cities: Skylines 1 C# mod in this repository.

Read these files first, in this order:

1. `README.md`
2. `docs/MVP_SPEC.md`
3. `docs/ARCHITECTURE.md`
4. `docs/CODEX_TASKS.md`
5. existing files in `src/`

## Core goal

Build a **small quality-of-life mod** that creates a separate elevated railway
following the geometry of selected existing road segments.

The road remains untouched.

The first useful behavior is:

> Select one straight road segment -> choose a loaded rail network ->
> set height to 12 m -> create one rail segment centered above the road.

Only after that works should the implementation expand to connected segment
chains, offsets, curves, minimal UI, and Undo.

## Critical scope rule

DO NOT turn this into a general infrastructure framework.

Do not implement:
- AI transit planning
- station planning
- procedural station throats
- custom road generation
- cargo/passenger route logic
- custom meshes/textures
- Road Builder integration
- Adaptive Networks integration
- large dependency injection architecture
- event buses
- plugin frameworks
- custom asset pipelines
- arbitrary "future-proof" abstractions

If a feature is not required by `docs/MVP_SPEC.md`, do not build it.

## Technical behavior

Use the selected road only as a geometry reference.

Create a completely separate railway network above it.

Prefer loaded `NetInfo` discovery rather than hard-coding Workshop asset IDs.

Target CS1 / Unity APIs actually available in the locally referenced assemblies.
Do not invent method signatures from memory.

Before using a game API:
1. inspect the local assembly/type if necessary,
2. confirm the actual signature,
3. then implement it.

## Working method

Proceed in very small steps.

For each step:

1. Inspect the relevant code/API.
2. State what you are changing.
3. Make the smallest implementation.
4. Build the project.
5. Fix compile errors.
6. Summarize exactly what now works.
7. Do not move to the next major feature unless the current step compiles.

Start with `docs/CODEX_TASKS.md` Task 1.

## Code quality

Prioritize:
- understandable code
- safe failure
- minimal dependencies
- no game crashes
- useful debug logging
- rollback/cleanup where practical

Avoid premature abstraction.

For the first geometry implementation, straight segments are enough.
Curves are explicitly a later step.

## Important

If local CS1 references are not configured, do not guess paths.

Tell me exactly what environment variable or `.csproj` path needs to be set,
then continue with everything that can still be prepared safely.

When you encounter an unknown CS1 API call, inspect the referenced assemblies
or existing compatible local code rather than hallucinating a solution.

Begin now by auditing the repository and making Task 1 compile-ready.
