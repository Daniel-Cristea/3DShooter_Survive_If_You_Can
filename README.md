# 3DShooter Survive If You Can - Source Code

Survive if you can is a 3D shooter game where the objective is to kill as many enemies before the player loses all health.

## Download & Play the game

1. Download the game from this link: https://github.com/Daniel-Cristea/SurviveIfYouCan_exe.git
2. Double click on: Survive If You Can.exe
3. Have fun

## Game requirements

Implement a shooter in Unity with the following characteristics:

- The game camera can be any of the following first person/ 3rd person / top down
- The player will be able to move with WASD and will have 1 type of shooting
- On Left Mouse - The player will shoot similarly to a hand pistol
- The hand pistol will have a reload mechanic
- 2 types of enemies
- A melee enemy that runs to get close to the player to attack
- A ranged enemy that attacks the enemy from a distance within a maximum range, if the player is too far, the enemy will try too get in range to attack
- There will be a predefined number of each type of enemy spawned at any moment
- When an enemy dies another will be spawned in predefined spawn points
- The enemies, if they are too far from the player, will have a patrol behaviour
- If the player is close enough, they will chase the player and try to get in range to attack them
- The objective is to kill as many enemies before the player loses all health
- Every enemy kill will give the player points
- The UI will show the player's health, ammo and points
- The environment can be built using a simple plane for the floor and cubes for simple walls (the walls are indestructible)
- The enemies can be simple capsules
- When the player is killed all enemies will stop and a restart button will appear on the screen
- Clean code will be a massive plus

Optional requirements:

- If you have the time and will, you can download an asset pack with animations, and use that for the enemies.
- SFXs for different actions will be a plus
- Optimizations and/or polishing will be a plus
- No game breaking bugs will be a plus

## What was implemented in this game:
1. **The Player**:
- Moves with  <kbd>W</kbd>, <kbd>A</kbd>, <kbd>S</kbd> and <kbd>D</kbd>, and can go faster with <kbd>Left-Shift</kbd>
- Shoots with Left-Click, has only one type of gun with a reloading mechanism;
- Can zoom with Right-Click;
- Will recive points for every enemy killed; 

2. **The enemies** ( Ranged and Melee):
   Both types of enemies use the same algorithm, a Behavior Tree that allows dynamic transitions from one state to another.
   In order to get closer to the enemy, they use a navmesh agent;
  The states are:
- Attacking the enemy (shooting or using a bomb);
- Getting closer to the enemy (if the player is in the field of view, but to far to attack, the enemy will try too get in range to attack);
- Patroling (if they are too far from the player, will adopt a patrol behaviour)
  The main difference between the two enemies is that the weapons are different, the Melee type uses a bomb, while the Ranged type uses a gun. 
  The Attack task will adapt to the weapon that the enemy possess.
  
  2.1. **Ranged enemy**
  Skin: Turquoise capsule
  Weapon: hand gun
  Attack type: will get in the range to attack and will shot the player

  2.2. **Melee enemy** (Creeper)
  Skin: Creeper like body (created from small boxes with a creeper texture)
  Weapon: Bomb
  Attack type: will get in the range to attack and will explode in order to damage the player

3. **The map**:
   I used simple blocks to create indestructible walls and columns.
   ![Map](https://github.com/Daniel-Cristea/3DShooter_Survive_If_You_Can/assets/58855492/c6477b4e-c89d-4ed9-9b8e-6f43c1abee21)

4. **UI**:
   It shows:
  - The player's health, ammo and points;
  - The Reloading image when the gun is reloading;
  - The <kbd>R</kbd> button for reloading when the gun magazine goes empty;
  - The "Next wave in x seconds" sign when new enemies will apear on the map;

  Pause menu: 
  - can be activated at any time, using the <kbd>Esc</kbd> button;
  - has the following options: **Resume**, **Restart game** and **Quit**;

  End game menu
  - appears when the player dies;
  - has the following options: **Restart game** and **Quit**;

5. **SFXs**:
   - When the player shoots his gun, an yellow muzzle flash and a shooting sound will appear;
   - When the gun is reloading, or is empty and you try to shoot, a representative sound appears; 
   - When an enemy is shot, it will release red particles to show that it was hit;
   - A background music will play all the time;
