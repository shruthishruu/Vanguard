**Bullet Hell Shooter Game Script**

**Vision**

To create a Bullet Hell Shooter game using MonoGame in C# by applying object-oriented principles and design patterns, such as the Factory Pattern and other patterns, to spawn game elements. 

**Game Flow:** 

The game will span approximately 3 minutes and will have multiple phases, including regular phases, a mid-boss fight, additional grunts, and a final boss attack.

**Game Phases:** 

1. **Regular Phase with Grunts** 
1. **Mid-Boss Attack** 
1. **Additional Grunts** 
1. **Final Boss Attack** 

**Features**

**Scorecard:** 

- **Display Features:** 
- Player’s score 
- Remaining player health 
- Time remaining in each phase 
- Option to start or exit the game 
- **Scoring System:** 
- Regular Enemy A & B: **10 points** per hit 
- First Boss: **50 points** per hit 
- Final Boss: **80 points** per hit 

**Character Descriptions**

**Player:** 

- **Initial Health:** 100 HP 
- **Lives:** 3 lives 
- **Movement:** The player can move in all 8 directions (up, down, left, right, and diagonals). 
- **Player Death:** 
- When the player's health reaches 0, they lose 1 life.
- The player can respawn, blinking twice or thrice to indicate revival.
- Upon losing all 3 lives, the game ends. 
- **Attacks:** 
- **Weapon:** Single bullet type for all attacks. 
- **Hit Points:** Regular enemies (A & B) and bosses have different scoring for hits: 
- Regular enemies: 10 points per hit. 
- First Boss: 50 points per hit. 
- Final Boss: 80 points per hit. 
- **Game Over Condition:** Player loses all 3 lives. 

**Enemies & Bosses**

**Regular Enemy A:** 

- **Appearance Time:** First attack appears around **00:03** and remains until **00:30**. 
- **Count:** 4-5 enemies. 
- **Movement Pattern:** Moves in a basic diagonal direction. 
- **Attack Pattern:** Fires bullets diagonally towards the player. These bullets are easy to dodge. 

**First Boss:** 

- **Appearance Time:** Appears at **00:35**. 
- **Health:** Takes **3 hits** to defeat. 
- **Attack Pattern:** 
- Fires bullets in two patterns: 
- **Vertical pattern** (up and down). 
- **Horizontal pattern** (left and right). 
- **Points:** 50 points per hit. 
- **Attack Duration:** Engages with the player for about **50 seconds**. 
- **Exit:** If not defeated in **50 seconds**, the boss will exit or disappear. 

**Regular Enemy B / Additional Grunts:** 

- **Appearance Time:** Appears at **00:80** (1 minute and 20 seconds). 
- **Count:** 5-8 enemies. 
- **Movement Pattern:** Same as Regular Enemy A, moves in basic diagonal patterns.
- **Attack Pattern:** Fires bullets diagonally, similar to Regular Enemy A. 
- **Duration:** These enemies will stay on screen for **30 seconds** or until defeated. 

**Final Boss:** 

- **Appearance Time:** Appears at **1:50** (1 minute and 50 seconds). 
- **Health:** Takes 5 hits to defeat (multiple stages).
- **Attack Stages:** 
- **Stage 1:** Fires bullets diagonally. 
- **Stage 2:** Fires bullets from left to right. 
- **Stage 3:** Fires bullets from up to down. 
- **Stage 4:** Fires in multiple random directions. 
- **Points:** 80 points per hit. 
- **Duration:** The player has **50 seconds** to defeat the Final Boss. 

**Game Phases & Timing**

**Phase 1: Regular Grunts** 

- **Start Time:** 00:03 (3 seconds after player entry) 
- **End Time:** 00:33 (30 seconds of gameplay) 
- **Enemies:** 4-5 Regular Enemy A 
- **Attack Style:** Diagonal bullet patterns, easy to dodge
- **Transition:** 3-second gap after enemy exit 

**Phase 2: First Boss Fight** 

- **Start Time:** 00:36 (3 seconds after Regular Enemy A exit) 
- **End Time:** 01:26 (50 seconds of gameplay) 
- **Boss:** First Boss 
- **Attack Style:** Vertical and horizontal bullet patterns
- **Objective:** Defeat the First Boss (3 hits needed) 
- **Transition:** 3-second gap after boss exit 

**Phase 3: Additional Grunts (Regular Enemy B)** 

- **Start Time:** 01:29 (3 seconds after First Boss exit) 
- **End Time:** 02:00 (31 seconds of gameplay) 
- **Enemies:** 5-8 Regular Enemy B / Additional Grunts 
- **Attack Style:** Diagonal bullet patterns, increased difficulty
- **Transition:** 3-second gap after enemy exit 

**Phase 4: Final Boss Fight** 

- **Start Time:** 02:03 (3 seconds after Additional Grunts exit) 
- **End Time:** 02:53 (50 seconds of gameplay) 
- **Boss:** Final Boss (multiple stages) 
- **Attack Style:** Random direction bullet firing 
- **Objective:** Defeat the Final Boss (multiple stages, each requiring a series of hits)
- **Transition:** The game ends after this phase, with no additional enemies.
