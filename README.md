# 🪨 ROCKED UP
### A 2D Survival Dodging Game by Wyatt Cosby  
**Course:** CS 583 - 3D Game Programming  
**Engine:** Unity (2D Project)  

---


## Changes from Original Design Document
The final version of Rocked Up was simplified from the original concept to ensure a polished minimum viable product. Originally, the game featured a 3-minute survival 
sequence followed by a boss fight with a rock golem, multiple attack types, weapon progression (punch, rock throw, and glock), and health pickups. The final implementation 
focuses on a single 90-second survival round with continuous falling rocks and ground-based “rock goomba” enemies that can be stomped to destroy. Combat weapons and the boss 
fight were removed to reduce scope and prioritize core gameplay polish—movement, jumping, collision detection, health tracking, sound feedback, and game state transitions 
(pause, win, lose).


---

## 🎮 GAME OVERVIEW
**Rocked Up** is a 2D survival game where you must avoid falling rocks and ground enemies for 90 seconds.  
Use precise movement and timing to dodge hazards, maintain your health, and survive until the timer runs out.  
Each round is short, challenging, and designed for quick replays.

---

## 🕹️ CONTROLS
| Action | Key |
|:-------|:----|
| Move Left / Right | **A / D** |
| Jump | **Spacebar** |
| Pause / Resume | **Escape** |
| Restart (Game Over) | **R** |

---

## 💥 GAMEPLAY DETAILS
- **Objective:** Survive for **90 seconds** while avoiding falling rocks and “rock goombas.”  
- **Health:**  
  - Starts at **40 HP**  
  - Rock/goomba hit = **10 HP** damage  
  - Stomping on a “rock goomba” destroys it without taking damage  
- **Win Condition:** Survive until timer reaches 0  
- **Lose Condition:** Health reaches 0  
- **Audio Feedback:**  
  - Distinct sounds for jumping, damage, and death  

---

## ⚙️ TECHNICAL DETAILS
**Unity Version:** 2022.3 or newer (URP not required)  
**Programming Language:** C#  
**Key Systems Implemented:**
- Rigidbody2D physics-based movement and jumping  
- Randomized rock spawning system  
- Health and UI tracking  
- Pause, restart, and game state management  
- AudioManager for SFX and background music  

---

##CREDITS
- Wyatt Cosby, CS 583-03, Fall 2025.
- Sound Assets:
  https://assetstore.unity.com/packages/audio/sound-fx/voices/damage-sounds-male-npc-player-audio-pack-285385
  https://assetstore.unity.com/packages/audio/sound-fx/rpg-essentials-sound-effects-free-227708
