# Introduction

This project is a test to evaluate my hard skills in Game Development and in
particular the following pillars : code **architecture**, code **readability**, code
**performance**, and **game feel**. The project must have 10 hours maxes of work.


<br/>

# Test approaching

## Before begin
First, I read all the technical test document and i imagine how can be the game, at the same time i download the unity version needed, and start to create a git project.
I see in the zip file that the project already made, with a .gitignore and some asset and prefab inside.

<br/>

## On test started
When I start the project, I directly use **Toggl** to track my time work. *(Toggl Track is a time tracking software)*

<br/>

### 1. Player Movement  
To start, I implemented the ***player movement***. This is the foundation for all future code structure, including **attack mechanics**, equipping a **weapon**, changing **statistics**, and **targeting an enemy**.  

It was a great starting point for me.  

I focused on making this system smooth and adaptable. I linked it with the **UIJoystick** to control movement speed, direction, and whether the player is moving or staying idle.  

> **Technical description:**  
> In the new Unity Input System, I configured various movement values using the **UIJoystick**. These values control the current speed and direction, with a range between 0 and 1.  
> This allows the player to move both slowly and quickly. By integrating this with an **animation blend tree**, the player’s movements feel much smoother! I also added small thresholds to avoid weird rotations, improving both movement and attack control.  

---
<br/>

### 2. Weapon and Enemy  
Once the ***player movement*** was complete, I moved on to implementing the weapon and attack system. I started by creating a flexible weapon system with a well-structured hierarchy to support not just swords, but also **bows**, **guns**, **throwing objects**, and more.  

I made the system adaptable so that not only the player, but also enemies and other entities can use weapons. I also added a **weapon spawner**, allowing the player to pick up their first weapon.  

Next, I implemented a very basic enemy. I created a manager to control the number of enemies on the map, their positions, and their proximity distance to the player.  

With this setup, I was able to rotate the player to face the nearest enemy.  

Finally, I added a **health system** that can be applied to any entity.  
For example, if an enemy picks up a weapon and attacks the player, the system handles it seamlessly!  

---
<br/>

### 3. Polishing and Making It Visually Fun  
Once everything was functional, I focused on testing, fixing bugs, and polishing the game. I added:  
- **More enemies**  
- **Particle effects**  
- **Code cleanup and comments**  

This final phase ensured the game felt more enjoyable and visually appealing.  
