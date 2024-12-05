# APP 3 || Astrum: Unbound

The Game will be a top-down game with the at least 3 levels. The game's focus is for the player to kill enemies and complete puzzles to advance. The player will also get better weapons.

## Notes

- Removed save game as it was no longer a feature that fit how the game's design

- Added Game Audio

  - BGM

- Any new features are bolded in [Requirements](#requirements)

## Assets

- [Monsters_Creatures_Fantasy](https://assetstore.unity.com/packages/2d/characters/monsters-creatures-fantasy-167949)

  - Used for the Enemy sprites

- [Evil Wizard 2](https://assetstore.unity.com/packages/2d/characters/evil-wizard-2-284501)

  - Used for the Mage Class sprite

- [Pixel Art Top Down - Basic](https://assetstore.unity.com/packages/2d/environments/pixel-art-top-down-basic-187605)

  - Used for tilemap, statue and sign game object

- [Pixel Adventure 1](https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360)

  - Used for spikes, bullets and fruits (HP and MP items)

- [Hero Knight - Pixel Art](https://assetstore.unity.com/packages/2d/characters/hero-knight-pixel-art-165188)

  - Used for the Hero/Warrior class sprite

- [Fantasy Skybox FREE](https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353)

  - Used for Title and Leaderboard Background

## Music/Audio

All music/Audio is from the YouTube Studio Audio Library

- Keys To Unravel

  - Main Menu, Character Select and Leaderboard BGM

- California King

  - Level 1 and GameEnd BGM

- Between The Spaces

  - Puzzle Room BGM

- Moving In The Shadows

  - Boss Room BGM

## Requirements

- [x] Player

  - [x] **Has 3 lives**

    - [x] Game Over after losing all lives

  - [x] **Character Selection**

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

- [x] **Item**

  These items will help the user to complete the level

  - [x] HP
  - [x] MP

- [x] **Player Class**

  Upgrading the character select to have different classes

  - [x] Warrior

    - [x] Sword
    - [x] Arrow/Bullet
    - [x] Deal more close range damage
    - [x] Deal less long range damage

    - [x] Increase close range resistance

  - [x] Mage

    - [x] Staff
    - [x] Spells
    - [x] Deal less close range damage
    - [x] Deal more long range damage

    - [x] Increase long range resistance

    - [x] Magic Bullet Destroys normal bullets

- [x] Top-Down Game

  - [x] Game Camera should follow the player

- [x] Levels

  - [x] 2+ Levels
  - [x] Must have start and end points
  - [x] Next Level unlocks after all enemies are killed
  - [x] At least 1 environmental hazard that injures

  - [x] Level 1 - simple combat

    - [x] 3+ enemies
    - [x] boss
    - [x] restricted areas
    - [x] move to next level
    - [x] Increase health and mana

  - [x] **Level 2 - puzzle**

    - [x] Simon says

    - [x] Gives a shield with 10 health

  - [x] **Level 3 - Final Boss**

    - [x] Boss

      - [x] Increased Damage

    - [x] 30 Health

- [x] UI

  - [x] Health Bar
  - [x] **Life**
  - [x] Time
  - [x] **Number of Enemies**
  - [x] **Initial Instruction**

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

    - [x] Bullets don't interact with each other unless it is magic bullet

- [x] Enemy

  - [x] 2 Type of Enemies

    - [x] Different Attacks
    - [x] Different Health
    - [x] Different Damage

  - [x] **Should go after player when they are close**

- [x] **Game Over**

  - [x] After dying 3 times

  - [x] Game Over Screen

    - [x] Restart
    - [x] Main Menu

- [x] **Death Screen**

  - [x] You Died Screen

  - [x] Respawn

    - [x] Respawn Player to start of level

    - [x] Player lose 1 life

  - [x] Return to Main Menu

- [x] Score

  - [x] Score based on Time
  - [x] Save score to leaderboard

- [x] Audio

  - [x] BGM
