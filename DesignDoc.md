Tips for using this design doc
- Keep it concise: this page is for fast alignment and scope control - update only when a change affects the MVP.
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
- Sprint: Shift
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
- Win: Make 20 cheese wheels.
- Lose: Time runs out OR player HP depletes OR all goats turned evil.

Visual & audio style (brief)
- Visual: Low‑poly + stylized lighting OR realistic with simple PBR (pick one).
- Audio: Day looping theme and night looping theme.

MUST (required for MVP - assign people)
- Core gameplay
    - Prototype and implement core mechanic (movement, jump, dash) - **Noah, Konsti**
    - Player camera (third‑person isometric) - **Noah, Konsti**
    - Goat milking - **Konsti**
    - Cheese making (interact with machines) - **Seli**   
    - Goat chases player - **?**
- Level
    - One complete playable 3D level and obstacles - **Viki?/Lea?/Nadine?, Seli**
    - Level logic: spawn points, checkpoints, objective triggers - **Julian**
- Enemies/Obstacles
    - One enemy type or obstacle with simple behavior (patrol/triggered) - **Julian?**
- UI
    - Main menu, pause, HUD with health/time/items - **Don? / Nadine?**
- Audio
    - One looped background track integrated + 6 key SFX (jump, land, hit, enemy death, pickup, UI click) - **Philipp, Don?**
- Build & submission
    - Exportable build, icon, 3 screenshots, short description - **Max, Lea**
- Project infrastructure
    - Repository, scene organization, input mapping, basic build pipeline - Owner: **Max**

SHOULD (important but cuttable)
- Polished player model + basic animations (idle/run/jump) - **Nadine**
- Extra enemy behavior (charge attack) - **Nadine?, ?**
- Simple environmental props and basic lighting polish - **Lea, Don**
- Sound variations for enemy/player (hit, death) SFX - **Phlipp, ?**

MAY (nice‑to‑have; defer early)
