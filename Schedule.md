## 48‑Hour Game Jam Schedule (with two 7‑hour sleep breaks)

Key rules to follow
- MVP first: target a single core mechanic plus 2–3 supporting features (menu, 1 level, basic enemies/obstacles).
- Timebox decisions and prototyping. If a prototype fails in its timebox, switch to the safest alternative.
- Daily checkpoints (every few hours) and full team syncs at major milestones.
- Programmers split into feature streams; avoid parallel work on the same system unless pair‑programming is planned.
- Artists deliver iteratively: block out roughs first, polish only when gameplay is locked.
- Audio works mainly after core mechanic is locked, with short deliverables early (SFX placeholders, one theme loop).
- Freeze scope at 15:00. From 15:00–17:00 only fix critical bugs and submit.

Branching:
- main for release (do not touch!)
- develop (from main) for merging in features 
- _feature_ (from develop) for ongoing work
- player (from develop) -> movement, camera, interact
- level (from develop) -> level scene, first assets, layout
- menu (from develop) -> main menu scene
- hud (from develop) -> into level scene

Day 1 — 17:00–23:00 (6h)
- 17:00–18:00 — Kickoff & rapid concept (60 min): pick core mechanic, create 1‑page design doc, MUST/SHOULD/MAY list. Lead decides final scope.
- 18:00–20:00 — High‑level prototyping & tech check (120 min): core mechanic prototype, repo/setup, placeholders; artists make rough level/character silhouettes; audio confirms placeholders.
- 20:00–23:00 — Narrow design & vertical slice plan (3h): finalize MVP specs, assign owners, create vertical slice plan. Checkpoint at 23:00: basic playable loop with placeholders.

Night 1 Sleep — 23:00–06:00 (7h)

Day 2 — 06:00–23:00 (17h)
- 06:00–18:00 — Core implementation sprint A (12h):
  - Programmers: core mechanic polish, enemy/obstacle behavior, UI skeleton, build/pipeline tasks split as before.
  - Artists: blockout level and character sheets; produce low‑poly/placeholders.
  - Audio: draft theme loop + key SFX placeholders.
  - Checkpoints every 4 hours; aim for 60–120s playable loop.
- 18:00–18:30 — Team sync & scope trim (30 min): cut SHOULD/MAY that threaten MVP.
- 18:30–23:00 — Core implementation sprint B (4.5h of this block before sleep):
  - Programmers: continue polish, integrate art, level logic.
  - Artists: finalize level concept art, start in‑engine assets prioritized for MVP.
  - Audio: refine loop and SFX bank.
  - Short demos at end of shift (22:30–23:00).

Night 2 Sleep — 23:00–06:00 (7h)

Day 3 — 06:00–17:00 (11h)
- 06:00–10:30 — Playtest & iterate (4.5h):
  - Full team plays current build; collect critical bugs, balance notes.
  - Programmers triage top issues; artists implement quick visual tweaks.
- 10:30–14:30 — Feature completion & polish (4h):
  - Finish MUST features (menu, scoring, one complete level).
  - Artists polish in‑scene assets used in MVP; audio finalizes loop/SFX.
  - Programmers stabilize and optimize.
- 14:30–15:00 — QA pass & platform build tests (0.5h): quick platform build check; prioritize showstoppers.
- 15:00–17:00 — Freeze, test final build & upload (2h):
  - Feature freeze at 15:00. Only critical bug fixes allowed.
  - Run final export, verify, prepare submission package (build, icon, screenshots, description) and upload before 17:00.

Task ownership and scope control remain as in the original plan. Short checklist to have by 15:00:
- Playable build with core mechanic.
- One complete level with win/lose condition.
- Functional UI/menu flow.
- Audio loop + key SFX integrated.
- Final exportable build and submission assets.

If you want, I can produce a downloadable timetable (CSV) with these exact wall‑clock timestamps.
