# APP 3 || Astrum: Unbound

The Game will be a top-down game with the at least 3 levels. The game's focus is for the player to kill enemies and complete puzzles to advance. The player will also get better weapons.

## Requirements

- [ ] Player

  - [ ] Has 3 lives

    - [ ] Game Over after losing all lives

  - [x] Character Selection

    - [x] 2+ Different Characters (just sprite difference)
    - [x] Character Selection Menu

  - [ ] Animation

    - [x] Idle
    - [x] Walking
    - [x] Melee
    - [ ] Range
    - [ ] Damage
    - [ ] Death

  - [x] Player respawn at the beginning of the level

  - [x] Player Interaction

    - [x] Doesn't pass through wall, floor, obstacle
    - [x] Losses health and gets knocked back when touching an enemy

- [x] Top-Down Game

  - [x] Game Camera should follow the player

- [ ] Levels

  - [ ] 3+ Levels
  - [ ] Must have start and end points
  - [ ] Next Level unlocks after all enemies are killed
  - [ ] 1~2 puzzle per level
  - [ ] At least 2 environmental hazard that injures

- [ ] UI

  - [x] Health Bar
  - [x] Life
  - [x] Time
  - [ ] Number of Enemies
  - [ ] Skills/Item
  - [ ] Initial Instruction

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

- [ ] Combat

  - [x] Melee
  - [ ] Range

- [ ] Enemy

  - [ ] 3 Type of Enemies

    - [ ] Different Attacks
    - [ ] Different Health
    - [ ] Different Damage

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

- [ ] Death Screen

  - [ ] You Died Screen

  - [ ] Respawn

    - [ ] Respawn Player to start of level

    - [ ] Player lose 1 life

  - [ ] Return to Main Menu

  - [ ] Quit

- [ ] Score

  - [ ] Score based on Time
  - [ ] Save score to leaderboard

## Possible Additions

- [ ] Mana and Spell

  - [ ] 2+ different spell instead of normal range attack

  - [ ] Player can switch spells

- [ ] Inventory

  - [ ] Player inventory
  - [ ] Equip items

- [x] Item

  These items will help the user to complete the level

  - [x] HP
  - [x] MP

- [ ] Player Class

  Upgrading the character select to have different classes

  - [x] Warrior

    - [x] Sword
    - [ ] Arrow/Bullet
    - [x] Deal more close range damage
    - [ ] Deal less long range damage

  - [x] Mage

    - [x] Staff
    - [ ] Spells
    - [x] Deal less close range damage
    - [ ] Deal more long range damage
