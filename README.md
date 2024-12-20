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

To start I made only the player movement, it's the base of all the future code structure, like **attack mechanics**, pull **weapon** and change **statistics**, **target an enemy**.. 

It's a good start point for me.

So I try to made this very smoothly and adaptable, I link it with the UIJoystick to control the movement speed, the direction to go and if the player moves or just stays.

> Technical description : <sub> In the new input unity system, i set many movement value with the UIJoystick, to control the current speed, the direction, it's a value between 0 and 1.
> So the player can move slowly and fast, now apply it with an animation blend tree and the player are more smoothly ! Apply little tree shold for not have weird rotation and better attack/movement control and it's perfect !</sub>
