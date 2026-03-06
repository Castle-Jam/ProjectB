Tips for using this design doc
- Keep it concise: this page is for fast alignment and scope control — update only when a change affects the MVP.
- Use the MUST/SHOULD/MAY lists to decide tradeoffs; freeze MAYs early.
- Assign an owner for each MUST item and a 2‑hour timebox for any new experiment.
- Use placeholders for art/audio until gameplay is locked; artists polish only owned assets.
- When in doubt, ask: “Does this change the core loop?” If no, deprioritize.

## Design Document

Title: Goat Slayer (Project B)
Topic: Goat

One‑line pitch
- "A 3D isometric goat cheese making game, with defending against evil devil goats at night."

Core loop (what the player does, repeatedly)
- Make cheese with minigames during the day or optional at night.
- Defend against evil devil goats at night.

Target platforms
- Primary: PC (Windows)
- Secondary: Linux / macOS

Players
- Single player

Controls (draft)
- Movement: WASD
- Interact/Attack: Left click

## UI
Main menu:
- Pretty
- Play
- Quit
HUD:
- Milk & Cheese counter
- Time (Day/Night)
- Simple controls tutorial in corner

Core mechanic (must be prototyped first)
- Example: Momentum‑based movement with short dash and jump that interacts with level geometry.

Win/Lose conditions
- Win: Complete level objective (reach end / collect N beacons) within time or lives.
- Lose: Time runs out or player HP depletes.

Visual & audio style (brief)
- Visual: Low‑poly + stylized lighting OR realistic with simple PBR (pick one).
- Audio: Day looping theme and night looping theme.

MUST (required for MVP — assign owners)
- Core gameplay
    - Prototype and implement core mechanic (movement, jump, dash) — Owner: Programmer A
    - Player camera (third‑person or first‑person, responsive) — Owner: Programmer B
    - Basic collision & physics tuning — Owner: Programmer C
- Level
    - One complete playable 3D level/blockout with path and obstacles — Owner: Artist A / Programmer D
    - Level logic: spawn points, checkpoints, objective triggers — Owner: Programmer D
- Enemies/Obstacles
    - One enemy type or obstacle with simple behavior (patrol/triggered) — Owner: Programmer E
- UI
    - Main menu, pause, HUD with health/time/objective — Owner: Programmer F / Artist B
- Audio
    - One looped background track integrated + 6 key SFX (jump, land, hit, enemy death, pickup, UI click) — Owner: Audio (part‑time) / Programmer G
- Build & submission
    - Exportable build, icon, 3 screenshots, short description — Owner: Programmer G / Artist B
- Project infrastructure
    - Repository, scene organization, input mapping, basic build pipeline — Owner: **Max**

SHOULD (important but cuttable)
- Polished player model + basic animations (idle/run/jump) — Owner: Artist B
- Extra enemy behavior (attack pattern or ranged attack) — Owner: Programmer E
- Simple environmental props and basic lighting polish — Owner: Artist A
- Score or simple progression/leaderboard screen — Owner: Programmer F
- Sound variations for enemy/player (hit, death) beyond the 6 key SFX — Owner: Audio

MAY (nice‑to‑have; defer early)
- Additional level or branching paths
- Secondary mechanic (e.g., weapon, grappling hook)
- Advanced shaders, particle-heavy VFX
- Full character customization or unlocks
- Localization and multiple resolution UI layouts

Obvious 3D technical tasks (draft checklist)
- Unity project setup: scenes, layers, tags, input mappings
- Player controller: character controller, gravity, slopes, grounded check
- Camera system: follow, collision avoidance, smoothing
- Level blockout: modular pieces, nav markers, collision meshes
- Asset pipeline: FBX import settings, texture compression, prefabs
- Animation: animator controller, blend trees (if animated)
- Physics: rigidbody settings, collision matrix, physics materials
- Lighting: baked vs real‑time decisions, light probes
- UI in world & screen space: canvases, anchors, scaling
- Audio integration: audio mixer groups, 2D/3D sound settings
- Performance basics: occlusion, LODs, texture atlases
- Build & QA: platform build settings, profiler checks, crash handling

Risks & mitigation (brief)
- Over‑scope risk: mitigate by freezing MAYs and strict timeboxing for SHOULDs.
- Art delay: use modular placeholders; artists produce low→medium fidelity in priority order.
- Build issues: maintain a nightly/regular export checklist and one dev owns final builds.

Metrics for "done" (MVP quality)
- Playable loop is stable for 3 consecutive runs with no crashes.
- Core mechanic feels responsive (no major input lag or physics bugs).
- Level can be completed from start to finish with objective clear.
- Build exports successfully and includes required submission assets.

Notes / To fill in later
- Specific asset names and file paths
- Exact owner assignment matching your team names
- Detailed task breakdown with estimated hours per task
- Art/animation style references and audio temp GUIDs
