# Unused project quarantine

This quarantine contains only clearly isolated legacy, copy, demo, or sample projects identified during the 2026-08-11 audit.

## Applied batch

- Projects outside `HIS.sln` audited: 42
- Projects quarantined: 8 across 7 isolated roots
- Tracked files moved: 116
- Approximate tracked size moved: 0.75 MB
- Active HIS project includes affected: 0
- External project references affected: 0
- Projects retained for further review: 34

The audit started with 42 project files that are not members of `HIS.sln`. Ambiguous business, database, utility, and alternative-solution projects were retained. A project was selected only when its purpose was clear from its name and structure, no active HIS project included files from its directory, and no project outside the selected directory referenced it.

The `Manifests` directory contains:

- `UnusedProjectAudit.csv`: classification of all 42 projects.
- `QuarantinePlan.csv`: original and proposed quarantine paths.
- `QuarantinedFiles.csv`: the moves actually applied, including Git blob hashes for restoration checks.

Restore any file by moving it from its recorded `QuarantinePath` back to `Path`.
