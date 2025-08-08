<strong>Cobra</strong>

Collection of Unity Utilities

<details> <summary><strong>Table of Contents</strong></summary>

    Overview

    Systems

    Materials

    Tools

    Editor Tools

    Utilities

    Hotkey Reference

    License
</details>

<strong>Overview</strong>

Cobra is a modular collection of Unity systems, tools, and utilities aimed at streamlining common game development tasks. Each component is designed to work independently, with minimal setup and clear extension points.

<details> <summary><strong>Audio</strong></summary>

Simplifies sound playback and volume control.

    Different Sound Data Types
    Simple | Advanced | Complex

    Music Manager w/ Playlists

    Sound Manager w/ Object Pooled Emitters

</details> <details> <summary><strong>Command</strong></summary>

Implements the Command Pattern for queued or reversible logic.

    Command Execution

    Undo/Redo Functionality

</details> <details> <summary><strong>Event</strong></summary>

Extremely robust versatile event broadcasting system.

    Different Event Types
    Parameterless | Strongly Typed | Generic

    Static Bus Station

</details> <details> <summary><strong>Illion</strong></summary>

Massive number container and display system.

    NOT YET IMPLEMENTED

</details> <details> <summary><strong>Lifetime</strong></summary>

Controls lifespan of objects.

    Different Lifetime Types
    Standard | Event | Pool

</details> <details> <summary><strong>Menu</strong></summary>

Handles menu navigation logic.

    Page Transitions

    Backtracking

    Save Functionality

    Multiple Components
    Fullscreen | Graphics | Keybinding | Resolution | Volume

</details> <details> <summary><strong>Object Pool</strong></summary>

Reusable object management.

    Simple Summoning

    Return-to-pool Logic Interfacing

</details> <details> <summary><strong>Optional</strong></summary>

Custom Optional type for value/missing state handling.

    Unity-friendly

    Null-safe Logic

</details> <details> <summary><strong>Scene Transition</strong></summary>

Handles loading and fading between scenes.

    Scene Arrival

    Scene Departure

    Custom Scene Transitioning Override Capabilities

</details> <details> <summary><strong>Singleton</strong></summary>

Base class and helpers for single-instance components.

    Auto-Instantiation

    Persistent or Scene-limited

    Editor Error Calls

</details> <details> <summary><strong>Timers</strong></summary>

Timers and delays.

    Multiple Types
    Countdown | Frequency | Stopwatch

    Alarm Notification

    Auto Updating

</details> <details> <summary><strong>Vector Casts</strong></summary>

Helper extensions for easy vector to vector type casting

    3D - 2D + vis-a-versa
    Int - Float + vis-a-versa

    Math Functionality

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