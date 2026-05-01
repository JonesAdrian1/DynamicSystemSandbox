# Dynamic Systems Sandbox (Unity C#)

A systems-driven simulation built in Unity that demonstrates how backend architecture patterns can be applied to gameplay systems.

This project focuses on emergent behavior through decoupled systems, event-driven communication, and a deterministic simulation loop rather than hardcoded game logic.

---

## What This Is

Dynamic Systems Sandbox is a lightweight simulation where entities (NPCs) operate based on state, rules, and system interactions.

Instead of scripting behaviors directly, the system allows behavior to emerge from:

* State changes (hunger, energy, etc.)
* System interactions
* Event-driven communication

The goal is to model gameplay as a set of interacting systems rather than isolated features.

---

## Why I Built This

I’ve spent most of my career building distributed backend systems in C#, focusing on scalability, reliability, and system design.

This project explores how those same principles apply to gameplay engineering:

* Decoupled systems instead of tightly coupled logic
* Event-driven communication instead of direct dependencies
* Simulation loops instead of request/response cycles

In short: treating gameplay like a real-time distributed system.

---

## Core Architecture

### Event-Driven System

A centralized event bus enables communication between systems without tight coupling.

Examples:

* Entity state changes trigger downstream behaviors
* World events propagate across multiple systems

This mirrors pub/sub patterns commonly used in backend systems.

---

### Tick-Based Simulation Loop

The simulation runs on a deterministic update loop independent of rendering.

This allows:

* Predictable system behavior
* Clear separation between simulation and presentation
* Easier debugging and extensibility

Conceptually similar to a server-side game loop or real-time processing system.

---

### Systems-Driven Design

Behavior is not hardcoded. Systems operate on entity state and drive outcomes.

Current systems include:

* Hunger system
* Energy system
* Decision system (rule-based AI)

This enables:

* Emergent behavior
* Easy addition of new systems
* Scalable complexity without rewriting logic

---

### Entity Model

Entities are lightweight and data-driven:

* State is stored separately from logic
* Systems operate on shared state

This keeps the architecture modular and extensible.

---

### Debug and Validation Tooling

The project includes debug visibility into:

* Entity state changes
* Active decisions
* Event flow

This supports testing, validation, and rapid iteration.

---

## Technical Highlights

* Unity (C#)
* Event-driven architecture
* Tick-based simulation loop
* Rule-based AI / decision systems
* Decoupled system design
* Debug-first development approach

---

## What This Demonstrates

This project is intended to showcase:

* Systems-driven gameplay design
* Strong separation of concerns
* Scalable architecture in Unity
* Application of backend engineering patterns to game development
* Ability to operate independently and design complete systems end-to-end

---

## What I Would Build Next

* Client/server synchronization layer (authoritative simulation)
* Save/load system for persistent world state
* ECS-based refactor for performance scaling
* More complex AI behaviors (goals, priorities, planning)
* Expanded world systems and interactions

---

## Repository

https://github.com/JonesAdrian1/DynamicSystemSandbox
