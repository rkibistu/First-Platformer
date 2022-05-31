
# Shopping Day

	Shopping Day is a 2D Platformer. 
	The main character tries to find her wife who is gone to shopping. But the way to shop is a bit 
	to long... And his wife is nowhere. Can you help him to find his wife?
	
## START MENU
	Canvas contains 2 GameObjects: MainMenu & SelectLevel.
	The game starts in the Start Menu scene which show 3 buttons:
		- Play (start the game at level 1)
		- Select Level (select the level you want to play)
			+ the levels are lock at start, you have to unlock them by playing
			+ open ShoppingDaySettings/playerDetails, delete everything and write "6" to unlock all of them
		- Quit (quit the game)
	I set methods to be executed when buttons are pressed using OnClick() event from inspector.
	Play and Quit call methods from the script MainMenu.cs. Select Level button disable MainMenu
	game object and enable SelectLevel game object and reveals a button for each level unlocked,
	so the player can select the level to play.
	Levels have to be unlocked. There is a file ShoppingDaySettings/playerDetails.txt which contains 
	a number that tell the last level unlocked. Every button from SelectLevel game object has the 
	script LevelSelector.cs. This script sets the button active or inactive using the file mentioned
	when the game starts (button index <= level in file -> active).
	
	
## WORLD CREATION
	The game world(background, ground, decorations) has been created using 2D Tilemap Editor.
	Every scene has a game object called Grid. This contains the tiles that build the world.
	The tiles are divided into categories because every one needs specific setup:
		- Ground - limits the movement of the player.
			+ tiles from Ground are not interactive
			+ physics don't affect them
			+ rigidbody material has 0 friction so the player is not slowed down when jumping/falling 
				while running into walls
		- Platforms - tiles that permit partial movement through them
			+ the build in component Platform Effector 2D is setup and allow oone way collisions
			+ player can stand on the platforms and jumps through one from below, collisions are detected
				only from above
			+ a layer mask is set so the only gameobject which collide with platforms are tagged with
				"Player" or "Enemy"
			+ when the 'down arrow' key si pressed, the collisions mask is changed for a short
				time. Collisions are not detected for game objects tagged "Player" -> player can fall 
				through platform. The change is made using PlatformsReverseCollider.cs script which
				detects input, change layer mask and keep a timer to go back to inital settings.
		- Background 
			+ contains diffrent game object. Each one has diffrent order in layer for correct rendering
		- Decoratives - not interactive, just for design
			+ these tiles have diffrent sizes so there are more tilemaps, each one with diffrent positions, 
				taking care that the alingment with other tiles to be alright.
	
	I used animated tiles for waterfall and some candles. These are made using 2D Tilemap Extras package.
	All animated tiles can be found in Assets\Prefabs\LevelDesign\AnimatedTiles.
	
	MOVING PLATFORMS
	
	
## COLLECTABLE OBJECTS

	COINS
	Coins are collectable objects that represents the score of the player. 
	Animator -> for rotation animation
			 -> Coin_Pickup animation is enabled after a collision with the player. It is set an event 
		which destroy the game object at the end of the pickup aniamtion 
	Audio Source -> picking up sound
	CoinPickUp.cs script -> detects collisions. If collider is tagged as "Player", the coin is
		destroyed and a method from Player is called so the score is changed. The method is from
		PlayerStatsHandler class which keep track of coins and health of the player.
						-> it keep track of the value of the coin; coins spawned from treasures are
		better.
		
	HEALTH POTION
	Collectable objects that can heal the player.
	The rotation effect is made using a courutine which rotate the object on Y axis.
	If a collision with a player is detected -> a method is called (like coin), player is healed,
		start courutine wich play a sound, wait for the sound to end and destroy the game object.
	
## INTERACTIVE OBJECTS

	SPIKES
	
	TRAPS
	
	LOOTBOX
	
	FINISH POINT OF LEVEL
	
	SIGNS
	
	BUTTONS & DOORS
	
### Documentation should continue...
	
### ENEMIES

### BOSS FIGHT

### LEVEL LOADER

### PLAYER
	

 !!! IMPORTANT !!!
To unlock all levels
	-> Open ShoppingDaySettings/playerDetails, delete everything and write "6".
	
	
	
