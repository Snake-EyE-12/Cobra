Cobra

Collection of Unity Utilities
Table of Contents

    Overview

    Installation

    Systems

    Materials

    Tools

    Editor Tools

    Utilities

    Hotkey Reference

    License

Overview

Cobra is a modular collection of Unity systems, tools, and utilities aimed at streamlining common development tasks. Each component is designed to work independently, with minimal setup and clear extension points.
Installation

Option 1: Git URL (Unity Package Manager)
Add the following to your manifest.json:

"com.yourcompany.cobra": "https://github.com/yourcompany/Cobra.git"

Option 2: Asset Folder
Download or clone this repository into your project's Assets/ folder.
Systems

Each system is self-contained and can be used independently.
<details> <summary><strong>Audio</strong></summary>

Simplifies sound playback and volume control.

    One-shot and looping audio playback

    3D spatial support

    Global volume and mute controls

</details> <details> <summary><strong>Command</strong></summary>

Implements the Command Pattern for queued or reversible logic.

    Command queue

    Undo/redo functionality

    Batch execution

</details> <details> <summary><strong>Event</strong></summary>

Lightweight event broadcasting system.

    Custom event definitions

    Global or local dispatching

    Decouples logic across systems

</details> <details> <summary><strong>Illion</strong></summary>

(Description of what this system does)
</details> <details> <summary><strong>Lifetime</strong></summary>

Controls lifespan of objects.

    Auto-destroy after delay

    Conditional cleanup

    Pool-compatible

</details> <details> <summary><strong>Menu</strong></summary>

Handles menu navigation logic.

    Page transitions

    Stack-based flow

    Input blocking

</details> <details> <summary><strong>Object Pool</strong></summary>

Reusable object management.

    Supports MonoBehaviours and prefabs

    Return-to-pool logic

    Lazy initialization

</details> <details> <summary><strong>Optional</strong></summary>

Custom Optional type for value/missing state handling.

    Unity-friendly

    Null-safe logic paths

</details> <details> <summary><strong>Scene Transition</strong></summary>

Handles loading and fading between scenes.

    Async support

    Screen fade

    Event hooks

</details> <details> <summary><strong>Singleton</strong></summary>

Base class and helpers for single-instance components.

    Auto-instantiation

    Persistent or scene-limited

    Thread-safe base

</details> <details> <summary><strong>Timers</strong></summary>

Timers and delays.

    One-shot and repeating timers

    Callback support

    Time-scale aware

</details> <details> <summary><strong>Vector Casts</strong></summary>

Helper functions for directional physics.

    Cast along direction vectors

    Custom angle and distance options

</details>
Materials
Name	Description
Full Friction	High drag, prevents sliding
No Friction	Low drag, useful for smooth motion
Tools
Global Asset

    Easily create and access global ScriptableObject references.

    Useful for managers, settings, or shared runtime state.

Editor Tools
Initial File Creation

    Template-based script and folder generation.

    Standardizes feature/module setup.

Hotkeys
Action	Shortcut
Maximize Play	Alt + P
Inspector Debug Mode	Alt + D
Inspector Lock	Shift + Q
Utilities
Math Functions

    Decibel Conversion: 20 * log10(value)

    Chance Evaluation: Chance(percent) returns true at given probability

    LayerMask Tools: Bitmask utility helpers

Extensions

    LineRenderer: auto-path generation, chaining, etc.

    GameObject: find/toggle/set-active helpers

Game Basics

    Pause/resume logic

    Application quit shortcut

Curve

    Evaluate or preview AnimationCurve programmatically

Console Clearing

    Editor-only utility to clear Unity console from code

Hotkey Reference

Unity hotkey symbols:
Symbol	Meaning
%	Ctrl
#	Shift
&	Alt
License

MIT License. Free to use, modify, and distribute.