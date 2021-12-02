
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
	The worold
	
	
	

 !!! IMPORTANT !!!
To unlock all levels
	-> Open ShoppingDaySettings/playerDetails, delete everything and write "6".
	
	
	
