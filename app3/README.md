# APP 3 || Astrum: Unbound

The Game will be a top-down game with the at least 3 levels. The game's focus is for the player to kill enemies and complete puzzles to advance. The player will also get better weapons.

## Requirements

- [ ] Player

  - [x] Has 3 lives

    - [ ] Game Over after losing all lives

  - [x] Character Selection

    - [x] 2+ Different Characters (just sprite difference)
    - [x] Character Selection Menu

  - [x] Animation

    - [x] Idle
    - [x] Walking
    - [x] Melee

  - [x] Player respawn at the beginning of the level

  - [x] Player Interaction

    - [x] Doesn't pass through wall, floor, obstacle
    - [x] Losses health and gets knocked back when touching an enemy

- [x] Item

  These items will help the user to complete the level

  - [x] HP
  - [x] MP

- [ ] Player Class

  Upgrading the character select to have different classes

  - [x] Warrior

    - [x] Sword
    - [x] Arrow/Bullet
    - [x] Deal more close range damage
    - [x] Deal less long range damage

  - [x] Mage

    - [x] Staff
    - [x] Spells
    - [x] Deal less close range damage
    - [x] Deal more long range damage

- [x] Top-Down Game

  - [x] Game Camera should follow the player

- [ ] Levels

  - [ ] 2+ Levels
  - [x] Must have start and end points
  - [x] Next Level unlocks after all enemies are killed
  - [ ] At least 1 environmental hazard that injures

- [ ] UI

  - [x] Health Bar
  - [x] Life
  - [x] Time
  - [x] Number of Enemies
  - [x] Initial Instruction

    - Probably some kind of dialog buble

- [x] Menu

  - [x] Main Menu

    - [x] Start
    - [x] Leaderboard
    - [x] Quit

  - [x] Pause Menu

    - [x] Continue
    - [x] Restart
    - [x] Quit

- [x] Restart gracefully

- [x] Combat

  - [x] Melee
  - [x] Range

- [x] Enemy

  - [x] 2 Type of Enemies

    - [x] Different Attacks
    - [x] Different Health
    - [x] Different Damage

  - [x] Should go after player when they are close

- [ ] Save Game Progress

  - [ ] Save Game
  - [ ] Load Game

- [ ] Game Over

  - [ ] After dying 3 times

  - [ ] Game Over Screen

    - [ ] Start from beginning
    - [ ] Main Menu
    - [ ] Quit

- [x] Death Screen

  - [x] You Died Screen

  - [x] Respawn

    - [x] Respawn Player to start of level

    - [x] Player lose 1 life

  - [x] Return to Main Menu

- [x] Score

  - [x] Score based on Time
  - [x] Save score to leaderboard
