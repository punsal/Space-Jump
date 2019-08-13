# Space Jump

## Overview

Space Jump is a hyper-casual game. Throw the ball in to hoops to score. Right now project is under development.

## Software Design

### States

#### Idle State

- Game Manager triggers at the start of game
- Waits for a "tap" to trigger **Spawn State**

#### Spawn State

- Creates a platform based on "ball"s position then triggers **Play State**
- **In future may spawns another platforms**

#### Play State

- Waits for player input to interact with "ball"
- **Play State has three potential switches :**
  - If player succeeds to put "ball" in **next** "hoop" then state triggers **Spawn State** again
  - If player puts "ball" in same "hoop" again then *do nothing*
  - If player fails to perform one the former situations, it means "ball" has to be fallen,  then state triggers **Fail State**

#### Fail State

- **Future Plans :** *Currently game continues to Game Over State* 
  - Player chooses to watch an ad to continue at where they failed
  - Player chooses to continue to **Game Over State**

#### Game Over State

- Waits for a "tap" to trigger **Spawn State**

## User Interface (Doozy UI)

Under the Main Canvas, there is three Views to follow game UI.

### Hierarchy

#### Canvas

​		Nothing special to report. 

​		**Render Mode :** Screen Space - Camera

​		**UI Scale Mode :** Scale with Screen Size *(w : 1080, h : 1920) x match : 0.5*

#### Views

##### Main UI

​			A button to start game, and an image to show logo.

##### Game UI

​			A text to count game score.

##### Game Over UI

​			Two text, one to show best score, other to show after game score.

## Conditions

### Success Conditions

- If player succeeds to put "ball" into "hoop" then it is success.

#### Success Variations

- If "ball" does not collide with any edge of "hoop" then it is **perfect success**. *+2 points* 
- If "ball" does collide with any edge of "hoop"  then it is **regular success**. *+1 points*

### Fail Conditions

- If player drops "ball" under current "hoop" then it **failure**.

#### Fail Variations

Nothing to report right now. It must be discussed later.

## Cases

Cases demonstrates what options player have, how player acts; what game presents and how game reacts to player. 

### Game Start

At Main UI, game will presents an action to player to start game. Player have two options:

- Press screen to start game
- Press **back button** to exit game

If player chooses to start game then trigger Spawn State.

### Game Run

At Game UI, game will presents a behavior to player to interact with game.

- Drag from starting any point on screen to add force on "ball"
  - If player manages to perform *perfect success* or *regular success* then respawn a platform to continue game
  - If player fails, hold game and ask player two options
    - Watch an ad to continue
    - Go to Game Over UI

At Game UI if player presses **back button** then pause the game. *(What will happen when game is paused?)*

### Game Over

At Game Over UI, game will presents *best score* and *last game score* to player.
