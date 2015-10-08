using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//The player object
public class Player {
	public string Name;
	public int Health;
	public int Attack;
	public int Defense;
	public int Mana;
	public int HealthMax;
	public int ManaMax;
	public int Gold;
	public int Potion;
	public int SpecialValue;
	public int SpecialAttack;
	public int ManaCost;
	public int FireballLow;
	public int FireballHigh;
	public int Elixer;
	public int Key;
	public Player (string name, int health, int attack, int defense, int mana, int healthMax, int manaMax, int gold, int potion, int specialValue,
	int specialAttack, int manaCost, int fireballHigh, int fireballLow, int elixer) {
		Name = name;
		Health = health;
		Attack = attack;
		Defense = defense;
		Mana = mana;
		HealthMax = healthMax;
		ManaMax = manaMax;
		Gold = gold;
		Potion = potion;
		SpecialValue = specialValue;
		SpecialAttack = specialAttack;
		ManaCost = manaCost;
		FireballLow = fireballLow;
		FireballHigh = fireballHigh;
		Elixer = elixer;
	}
}
//The enemy object
public class Enemy {
	public string Name;
	public int Health;
	public int Attack;
	public int Defense;
	public int Loot;
	public Enemy (string name, int health, int attack, int defense, int loot) {
		Name = name;
		Health = health;
		Attack = attack;
		Defense = defense;
		Loot = loot; 
		
	}
}
//Each enemy object
public class CastleLayout : MonoBehaviour {
	
	Player player = new Player ("name", 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
	Enemy bat = new Enemy ("Bat", 10, 3, 0, 150);
	Enemy fox = new Enemy ("Fox", 15, 3, 1, 300);
	Enemy ogre = new Enemy ("Ogre", 25, 5, 4, 400);
	Enemy wolf = new Enemy ("Wolf", 30, 9, 0, 500);
	Enemy bear = new Enemy ("Bear", 40, 7, 3, 600);
	Enemy zorgon = new Enemy ("Zorgon", 55, 9, 3, 700);
	Enemy dragon = new Enemy ("Dragon", 80, 11, 5, 99999);
//each text object
	public Text text;
	public Text text2;
	public Text text3;
	public Text text4;
	public Text text5;
	public Text text6;
	public Text text7;
	public Text text8;
	public Text text9;
	public Text text10;
	public Text text11;
//I used different stages to display the text. This is all of the stages that were used	
	private enum Stage {intro, intro2, intro3, intro4, choose, loss, start, door, main, front, back, kitchen, closet, upstairs, bat, batWin, fox, 
	foxWin, ogre, ogreWin, wolf, wolfWin, bear, bearWin, zorgon, zorgonWin, dragon, dragonWin, shop, noGold, haveItem, sword, sheild, ring, potion, 
	elixer, woodenChest, silverChest, goldenDoor, fairy, diamondHallway, spiralStairs, tower, fairyTwo, final, reward, finalTwo};
	private Stage myStage;
	private Stage tempStage;
//variables in the program that were used for various things
	int sword = 0;
	int sheild = 0;
	int ring = 0;
	int potion = 0;
	int elixer = 0;
	int fireballOne = 1;
	int fireballTwo = 1;
	int level = 1;
	int wooden = 0;
	int silver = 0;
	int golden = 0;
	int diamond = 0;
	int fairy = 0;
	int fairy2 = 0;
	int dragonFight = 0;
	int inventory = 0;
	int wolfFight = 0;
	
	

	// Use this for initialization
    // Starts the game
	void Start () {
		myStage = Stage.intro;
	}
	
	// Update is called once per frame


	void Update () {
		if (inventory == 1) {
			text7.text = "Inventory";
		}
		if (wooden == 1) {
			text11.text = "Wooden Key";
		}
		
		if (silver == 1) {
			text11.text = "Silver Key";
		}
		
		if (golden == 1) {
			text11.text = "Golden Key";
		}
		
		if (diamond == 1) {
			text.text = "Diamond Key";
		}
		
		if (level == 1) {
			text9.text = "Level: 1";
		}
		
		if (level == 2) {
			text9.text = "Level: 2";
			
		}
		
		if (level == 3) {
			text9.text = "Level: 3";
		}
		
		if (level == 4) {
			text9.text = "Level: 4";
			
		}
		
		if (level == 5) {
			text9.text = "Level: 5";
			
		}
		
		if (level == 6) {
			text9.text = "Level: 6";
			
		}
		
		if (level == 7) {
			text9.text = "Level: 7";
			
		}
		
		if (level == 8) {
			text9.text = "Level: 8";
			
		}
		//used to get random numbers for fireballs
		fireballOne = getRandom(player.FireballLow,player.FireballHigh);
		fireballTwo = getRandom(player.FireballLow,player.FireballHigh);
	    //if the player loses, this happens
		if (player.Health <= 0) {
			myStage = Stage.loss;
		}
		//displays the inventory
		text5.text = "Potion x " + potion + "\nElixer x " + elixer;
		//used to display the charater information
		text3.text = "Class:       " + player.Name + "\nHealth:      " + player.Health + "/" + player.HealthMax + "\nMana:       " + player.Mana + "/" + 
			player.ManaMax + "\nAttack:      " + player.Attack + "\n " + "\nDefense:   " + player.Defense + "\nGold:         " + player.Gold;
		if (player.SpecialValue == 1) {
			text10.text = "Special:    " + player.SpecialAttack;
		}
		else if (player.SpecialValue == 3) {
			text10.text = "Special:    " + player.SpecialAttack;
		}
		else if (player.SpecialValue == 2) {
			text10.text = "Special:    " + player.FireballLow + "/" + player.FireballHigh;
		}
		
	
		print (myStage);
		//this was used to determine which stage to display
		if (myStage == Stage.intro)					{stage_intro();}
		else if (myStage == Stage.intro2)			{stage_intro2();}
		else if (myStage == Stage.intro3)			{stage_intro3();}
		else if (myStage == Stage.intro4)			{stage_intro4 ();}
		else if (myStage == Stage.choose)			{stage_choose();} 
		else if (myStage == Stage.start)			{stage_start();}
		else if (myStage == Stage.door)				{stage_door();}
		else if (myStage == Stage.main)				{stage_main();}
		else if (myStage == Stage.front)			{stage_front();}
		else if (myStage == Stage.back)				{stage_back ();}
		else if (myStage == Stage.kitchen)			{stage_kitchen();}
		else if (myStage == Stage.upstairs)			{stage_upstairs();}
		else if (myStage == Stage.bat)				{stage_bat();}
		else if (myStage == Stage.fox)				{stage_fox ();}
		else if (myStage == Stage.batWin)			{stage_batWin();}
		else if (myStage == Stage.foxWin)			{stage_foxWin();}
		else if (myStage == Stage.shop)				{stage_shop();}
		else if (myStage == Stage.noGold)			{stage_noGold();}
		else if (myStage == Stage.haveItem)			{stage_haveItem();}
		else if (myStage == Stage.sword)			{stage_sword ();}
		else if (myStage == Stage.sheild)			{stage_sheild ();}
		else if (myStage == Stage.ring)				{stage_ring ();}
		else if (myStage == Stage.potion)			{stage_potion ();}
		else if (myStage == Stage.ogre)				{stage_ogre ();}
		else if (myStage == Stage.ogreWin)			{stage_ogreWin ();}
		else if (myStage == Stage.loss)				{stage_loss();}
		else if (myStage == Stage.wolf)				{stage_wolf ();}
		else if (myStage == Stage.wolfWin)			{stage_wolfWin ();}
		else if (myStage == Stage.bear)				{stage_bear ();}
		else if (myStage == Stage.bearWin)			{stage_bearWin ();}
		else if (myStage == Stage.zorgon)			{stage_zorgon ();}
		else if (myStage == Stage.zorgonWin)		{stage_zorgonWin ();}
		else if (myStage == Stage.dragon)			{stage_dragon ();}
		else if (myStage == Stage.dragonWin)		{stage_dragonWin ();}
		else if (myStage == Stage.elixer)			{stage_elixer ();}
		else if (myStage == Stage.woodenChest)		{stage_woodenChest ();}
		else if (myStage == Stage.silverChest)		{stage_silverChest ();}
		else if (myStage == Stage.goldenDoor)		{stage_goldenDoor ();}
		else if (myStage == Stage.closet)			{stage_closet();}
		else if (myStage == Stage.fairy)			{stage_fairy();}
		else if (myStage == Stage.diamondHallway)	{stage_diamondHallway();}
		else if (myStage == Stage.spiralStairs)		{stage_spiralStairs();}
		else if (myStage == Stage.tower)			{stage_tower();}
		else if (myStage == Stage.fairyTwo)			{stage_fairyTwo();}
		else if (myStage == Stage.final)			{stage_final();}
		else if (myStage == Stage.reward)			{stage_reward();}
		
		 
	
	}
	//instructions
	void stage_intro () {
		text7.text = "";
		text3.text = "";
		text5.text = "";
		text9.text = "";
		text.text = "Your stats will be displayed in the top left corner. The enemys will be displayed in the top right corner. Your inventory " +
		"is displayed on the right side. Your level is displayed on the top. Every emeny that you kill will give you a level. Every emeny gives you " +
		"different stats. Potions give 5 health, elixers will give 3 mana.\n\nPress Space to continue";
		
		if (Input.GetKeyDown (KeyCode.Space)) 			{myStage = Stage.intro2;}
	}
	void stage_intro2 () {
		text7.text = "";
		text3.text = "";
		text5.text = "";
		text9.text = "";
		text.text = "There are 3 classes in this game. Each one has speceial abilities and different stats." + 
		"The wizard starts out with: High Attack, low Defense, high mana and low health. The wizard's special ability will shoot " + 
		"two fireballs. Both will deal between 3 and 6 damage. Anytime the " +
		"wizard uses a potion, it will heal him for 7 instead of 5.\n\nPress Space to continue";
		
		if (Input.GetKeyDown (KeyCode.Space)) 			{myStage = Stage.intro3;}
	}
	void stage_intro3 () {
		text7.text = "";
		text3.text = "";
		text5.text = "";
		text9.text = "";
		text.text = "The archer starts out with: Medium Attack, medium Defense, medium mana, and high health. The archers special ability is a powerful " +
		"ranged attack. When using this attack, they enemy will not be able to reach the archer and dealing no damage. The archer also starts out with " +
		"200 extra gold.\n\nPress Space to continue";
		
		if (Input.GetKeyDown (KeyCode.Space))			{myStage = Stage.intro4;}
	}
	void stage_intro4 () {
		text7.text = "";
		text3.text = "";
		text5.text = "";
		text9.text = "";
		text.text = "The Warrior starts out with: Medium Attack, High Defense, low mana and high health. The warrior's special ability is downward thrust. This" +
		" powerful attack will ignore armour.\n\nPress Space to start the game";
		
		if (Input.GetKeyDown (KeyCode.Space)) 			{myStage = Stage.choose;}
			
	}	
	//choose a class
	void stage_choose () {
		inventory = 1;
		text.text = "Which class will you choose?\n\nPress B for a Brave Warrior\nPress P for a Powerful Wizard" +
					"\nPress S for a Swift Archer ";
		text2.text = " ";
		text3.text = " ";
		if (Input.GetKeyDown (KeyCode.B)) {
			player.Name = "Warrior";
			player.Gold = 300;
			player.Health = 30;
			player.Attack = 3;
			player.Defense = 2;
			player.Mana = 5;
			player.HealthMax = 25;
			player.ManaMax = 5 ;
			player.Potion = 5;
			player.SpecialValue = 1;
			player.SpecialAttack = 9;
			player.ManaCost = 3;
			player.Elixer = 3;
			player.Key = 0;
			myStage = Stage.start;
									
		}
		
		else if (Input.GetKeyDown (KeyCode.P)) {
			player.Name = "Wizard";
			player.Gold = 300;
			player.Health = 27;
			player.Attack = 3;
			player.Defense = 2;
			player.Mana = 10;
			player.HealthMax = 27;
			player.ManaMax = 10;
			player.Potion = 7;
			player.SpecialValue = 2;
			player.SpecialAttack = 1;
			player.ManaCost = 3;
			player.FireballLow = 3;
			player.FireballHigh = 6;
			player.Elixer = 3;
			player.Key = 0;
			myStage = Stage.start;
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {
			player.Name = "Archer";
			player.Gold = 500;
			player.Health = 30;
			player.Attack = 3;
			player.Defense = 1;
			player.Mana = 7;
			player.HealthMax = 25;
			player.ManaMax = 7;
			player.Potion = 5;
			player.SpecialValue = 3;
			player.SpecialAttack = 7;
			player.ManaCost = 3;
			player.Elixer = 3;
			player.Key = 0;
			myStage = Stage.start;
		}
	}
	//player loses
	void stage_loss () {
		text.text = "You have been defeated!";
		text4.text = "";
		text6.text = "";
		text8.text = "";
	}
	//starts the game
	void stage_start () {
		
		text.text = "You have arrived at the legendary castle. You've heard stories of the vast treasures within." + 
		"\n\nPress D to go in the Door\nPress F to search the Front yard\nPress G to Go around back";
		if (Input.GetKeyDown (KeyCode.D))				{myStage = Stage.door;}
		else if (Input.GetKeyDown (KeyCode.F)) 			{myStage = Stage.front;}
		else if (Input.GetKeyDown (KeyCode.G)) 			{myStage = Stage.back;}
	}
	
	void stage_door () {
	
		if (bat.Health > 0) {
		myStage = Stage.bat;
		}
		
		else
	
	
		/*text2.text = "Health: " + bat.Health + "\nAttack: " + bat.Attack + "\nDefense: " + bat.Defense;
		text.text = "You have encountered a bat!\n\nPress A to Attack";
		
		if (Input.GetKeyDown (KeyCode.A)) {
			text.text = "You have attacked the " + bat.Name + " for " + playerAttack (player.Attack, bat.Defense, bat.Health)+ " damage.\n" +
			"The " + bat.Name + "a attacks you for " + enemyAttack (bat.Attack, player.Defense, player.Health) + " damage.";
		}*/
	
		text.text = "You have entered in the front door.\n\nPress M to enter the Main room\nPress R to go back";
		text2.text = "";
		if (Input.GetKeyDown (KeyCode.M)) 				{myStage = Stage.main;}
		else if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.start;}
	
	}
	//fighting the bat
	void stage_bat () {
	
		text2.text = "Enemy:     " + bat.Name + "\nHealth:     " + bat.Health + "\nAttack:      " + bat.Attack + "\nDefense:   " + bat.Defense;
		text.text = "You have encountered a bat!\n\nPress A to Attack\nPress U to use a potion\nPress E to use Elixer\n\nPress R to Run away";
		if (player.SpecialValue == 1) {
			text8.text = "Press S to Downward thrust";
		}
		if (player.SpecialValue == 2) {
			text8.text = "Press S to cast a fireball";		
		}
		if (player.SpecialValue == 3 ) {
			text8.text = "Press S to make a ranged attack";
		}
		if (bat.Health <= 0) {
		myStage = Stage.batWin;
		}
			
		if (Input.GetKeyDown (KeyCode.A)) {
		
			if ((player.Attack - bat.Defense)<0) {
				text4.text = "You dealt 0 damage to the bat";
			} else {
				text4.text = "You have dealt " + (player.Attack - bat.Defense) + " damage to the bat";
				bat.Health = bat.Health - player.Attack + bat.Defense;
			}
			
			if ((bat.Attack - player.Defense)<0) {
				text6.text = "The bat dealt 0 damage to you";
			} else {
				text6.text = "The bat dealt " + (bat.Attack - player.Defense) + " damage to you";
				player.Health = player.Health - bat.Attack + player.Defense;
			}
		
		}
				
		else if (Input.GetKeyDown (KeyCode.U)) {
			text6.text = "";
			text4.text = "";
			if (potion < 1) {
			text4.text = "You do have have any potions";
			} else if (player.Health + player.Potion > player.HealthMax) {
			text4.text = "You have been fully healed";
			player.Health = player.HealthMax;
			potion--;
			} else {
				text4.text = "You have been healed by " + player.Potion;
				player.Health = player.Health + player.Potion;
				potion--;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			text6.text = "";
			text4.text = "";
			if (elixer < 1) {
			text4.text = "You do not have any Elixer";
			} else if (player.Mana + player.Elixer > player.ManaMax) {
			text4.text = "Your mana is completely full";
			player.Mana = player.ManaMax;
			elixer--;
			} else {
				text4.text = "Your mana has been increased by " + player.Elixer;
				player.Mana = player.Mana + player.Elixer;
				elixer--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {
			if (player.Mana < player.ManaCost) {
			text6.text = "";
			text4.text = "You do not have enought mana";
			}
			else if (player.SpecialValue == 1) {
				if ((player.SpecialAttack - bat.Defense)<0) {
					text4.text = "You dealt 0 damage to the bat";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack) + " damage to the bat";
					bat.Health = bat.Health - player.SpecialAttack;
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((bat.Attack - player.Defense)<0) {
					text6.text = "The bat dealt 0 damage to you";
				} else {
					text6.text = "The bat dealt " + (bat.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - bat.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 2) {
				if ((player.SpecialAttack - bat.Defense)<0) {
					text4.text = "You dealt 0 damage to the bat";
				} else {
					text4.text = "Fire ball one does " + fireballOne + " damage to the bat\nFire ball two does " + fireballTwo + " damage to the bat";
					bat.Health = bat.Health - (fireballOne + fireballTwo);
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((bat.Attack - player.Defense)<0) {
					text6.text = "The bat dealt 0 damage to you";
				} else {
					text6.text = "The bat dealt " + (bat.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - bat.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 3) {
				if ((player.SpecialAttack - bat.Defense) <0) {
					text4.text = "you dealt 0 damage to the bat";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - bat.Defense) + " damage";
					bat.Health = bat.Health - player.SpecialAttack + bat.Defense;
					text6.text = "The bat cannot reach you";
					player.Mana = player.Mana - player.ManaCost;
				}
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.R)) {
			myStage = Stage.start;
			text2.text = "";
			text4.text = "";
			text6.text = "";
			text8.text = "";
		}
		
	}
	//fighting the fox
	void stage_fox () {
		text.text = "You have encountered a fox!\n\nPress A to Attack\nPress U to Use a potion\nPress E to use Elixer\n\nPress R to Run away";
		if (player.SpecialValue == 1) {
			text8.text = "Press S to Downward Thrust";
		}
		if (player.SpecialValue == 2) {
			text8.text = "Press S to cast a Fireball";		
		}
		if (player.SpecialValue == 3 ) {
			text8.text = "Press S to make a Ranged Attack";
		}
		text2.text = "Enemy:     " + fox.Name + "\nHealth:     " + fox.Health + "\nAttack:      " + fox.Attack + "\nDefense:  " + fox.Defense;
		
		if (fox.Health <= 0) {
			myStage = Stage.foxWin;
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
		
			if ((player.Attack - fox.Defense)<0) {
				text4.text = "You dealt 0 damage to the fox";
			} else {
				text4.text = "You have dealt " + (player.Attack - fox.Defense) + " damage to the fox";
				fox.Health = fox.Health - player.Attack + fox.Defense;
			}
			
			if ((fox.Attack - player.Defense)<0) {
				text6.text = "The fox dealt 0 damage to you";
			} else {
				text6.text = "The fox dealt " + (fox.Attack - player.Defense) + " damage to you";
				player.Health = player.Health - fox.Attack + player.Defense;
			}
			
			/*player.Health = player.Health - fox.Attack + player.Defense;
			fox.Health = fox.Health - player.Attack + fox.Defense;
			
			text4.text = "You dealt " + (player.Attack - fox.Defense) + " damage to the fox.\n" +
				"The fox does " + (fox.Attack - player.Defense) + " damage to you.";*/
			
		}
		
		if (Input.GetKeyDown (KeyCode.U)) {
			text6.text = "";
			text4.text = "";
			if (potion < 1) {
				text4.text = "You do have have any Potions";
				
			} else if (player.Health + player.Potion > player.HealthMax) {
				text4.text = "You have been fully healed";
				player.Health = player.HealthMax;
				potion--;
			} else {
				text4.text = "You have been healed by " + player.Potion;
				player.Health = player.Health + player.Potion;
				potion--;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			text6.text = "";
			text4.text = "";
			if (elixer < 1) {
				text4.text = "You do not have any Elixer";
			} else if (player.Mana + player.Elixer > player.ManaMax) {
				text4.text = "Your mana is completely full";
				player.Mana = player.ManaMax;
				elixer--;
			} else {
				text4.text = "Your mana has been increased by " + player.Elixer;
				player.Mana = player.Mana + player.Elixer;
				elixer--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {
			if (player.Mana < player.ManaCost) {
				text6.text = "";
				text4.text = "You do not have enought mana";
				text8.text = "";
			}
			else if (player.SpecialValue == 1) {
				if ((player.SpecialAttack - fox.Defense)<0) {
					text4.text = "You dealt 0 damage to the fox";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack) + " damage to the fox";
					fox.Health = fox.Health - player.SpecialAttack;
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((fox.Attack - player.Defense)<0) {
					text6.text = "The fox dealt 0 damage to you";
				} else {
					text6.text = "The fox dealt " + (fox.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - fox.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 2) {
				if ((player.SpecialAttack - fox.Defense)<0) {
					text4.text = "You dealt 0 damage to the fox";
				} else {
					text4.text = "Fire ball one does " + fireballOne + " damage to the fox\nFire ball two does " + fireballTwo + " damage to the fox";
					fox.Health = fox.Health - (fireballOne + fireballTwo);
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((fox.Attack - player.Defense)<0) {
					text6.text = "The fox dealt 0 damage to you";
				} else {
					text6.text = "The fox dealt " + (fox.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - fox.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 3) {
				if ((player.SpecialAttack - bat.Defense) <0) {
					text4.text = "you dealt 0 damage to the fox";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - fox.Defense) + " damage";
					fox.Health = fox.Health - player.SpecialAttack + fox.Defense;
					text6.text = "The fox cannot reach you";
					player.Mana = player.Mana - player.ManaCost;
				}
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.R)) {
			myStage = Stage.main;
			text2.text = "";
			text4.text = "";
			text6.text = "";
			text8.text = "";
		}
	}
	//fighting the ogre
	void stage_ogre () {
		text.text = "You have encountered an orge!\n\nPress A to Attack\nPress U to Use a potion\nPress E to use Elixer\n\nPress R to Run away";
		if (player.SpecialValue == 1) {
			text8.text = "Press S to Downward Thrust";
		}
		if (player.SpecialValue == 2) {
			text8.text = "Press S to cast a Fireball";		
		}
		if (player.SpecialValue == 3 ) {
			text8.text = "Press S to make a Ranged Attack";
		}
		text2.text = "Enemy:     " + ogre.Name + "\nHealth:      " + ogre.Health + "\nAttack:      " + ogre.Attack + "\nDefense:  " + ogre.Defense;
		
		if (ogre.Health <=0) {
			myStage = Stage.ogreWin;
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
		
			if ((player.Attack - ogre.Defense)<0) {
				text4.text = "You dealt 0 damage to the ogre";
			} else {
				text4.text = "You have dealt " + (player.Attack - ogre.Defense) + " damage to the ogre";
				ogre.Health = ogre.Health - player.Attack + ogre.Defense;
			}
			
			if ((ogre.Attack - player.Defense)<0) {
				text6.text = "The ogre dealt 0 damage to you";
			} else {
				text6.text = "The ogre dealt " + (ogre.Attack - player.Defense) + " damage to you";
				player.Health = player.Health - ogre.Attack + player.Defense;
			}
			
		}
		
		
		else if (Input.GetKeyDown (KeyCode.U)) {
			text6.text = "";
			text4.text = "";
			if (potion < 1) {
				text4.text = "You do have have any potions";
			} else if (player.Health + player.Potion > player.HealthMax) {
				text4.text = "You have been fully healed";
				player.Health = player.HealthMax;
				potion--;
			} else {
				text4.text = "You have been healed by " + player.Potion;
				player.Health = player.Health + player.Potion;
				potion--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			text6.text = "";
			text4.text = "";
			if (elixer < 1) {
				text4.text = "You do not have any Elixer";
			} else if (player.Mana + player.Elixer > player.ManaMax) {
				text4.text = "Your mana is completely full";
				player.Mana = player.ManaMax;
				elixer--;
			} else {
				text4.text = "Your mana has been increased by " + player.Elixer;
				player.Mana = player.Mana + player.Elixer;
				elixer--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {
			if (player.Mana < player.ManaCost) {
				text6.text = "";
				text4.text = "You do not have enought mana";
				text8.text = "";
			}
			else if (player.SpecialValue == 1) {
				
				if ((player.SpecialAttack - ogre.Defense)<0) {
					text4.text = "You dealt 0 damage to the ogre";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - ogre.Defense) + " damage to the ogre";
					ogre.Health = ogre.Health - player.SpecialAttack + ogre.Defense;
					player.Mana = player.Mana - player.ManaCost;
				}
				
				
				if ((ogre.Attack - player.Defense)<0) {
					text6.text = "The ogre dealt 0 damage to you";
				} else {
					text6.text = "The ogre dealt " + (ogre.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - ogre.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 2) {
				
					text4.text = "Fire ball one does " + (fireballOne) + 
					" damage to the ogre\nFire ball two does " + fireballTwo + " damage to the ogre";
					ogre.Health = ogre.Health - (fireballOne + fireballTwo);
					player.Mana = player.Mana - player.ManaCost;
				
				
				if ((ogre.Attack - player.Defense)<0) {
					text6.text = "The ogre dealt 0 damage to you";
				} else {
					text6.text = "The ogre dealt " + (ogre.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - ogre.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 3) {
				if ((player.SpecialAttack - bat.Defense) <0) {
					text4.text = "you dealt 0 damage to the ogre";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - ogre.Defense) + " damage";
					ogre.Health = ogre.Health - player.SpecialAttack + ogre.Defense;
					text6.text = "The ogre cannot reach you";
					player.Mana = player.Mana - player.ManaCost;
				}
			}
		}
			
		
		else if (Input.GetKeyDown (KeyCode.R)) {
			myStage = Stage.main;
			text2.text = "";
			text4.text = "";
			text6.text = "";
			text8.text = "";
		}
	}
	//fighting the wolf
	void stage_wolf () {
		wolfFight = 1;
		text2.text = "Enemy:     " + wolf.Name + "\nHealth:     " + wolf.Health + "\nAttack:      " + wolf.Attack + "\nDefense:   " + wolf.Defense;
		text.text = "You have encountered a wolf!\n\nPress A to Attack\nPress U to use a potion\nPress E to use Elixer\n\nPress R to Run away";
		if (player.SpecialValue == 1) {
			text8.text = "Press S to Downward thrust";
		}
		if (player.SpecialValue == 2) {
			text8.text = "Press S to cast a fireball";		
		}
		if (player.SpecialValue == 3 ) {
			text8.text = "Press S to make a ranged attack";
		}
		if (wolf.Health <= 0) {
			myStage = Stage.wolfWin;
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
			
			if ((player.Attack - wolf.Defense)<0) {
				text4.text = "You dealt 0 damage to the wolf";
			} else {
				text4.text = "You have dealt " + (player.Attack - wolf.Defense) + " damage to the wolf";
				wolf.Health = wolf.Health - player.Attack + wolf.Defense;
			}
			
			if ((wolf.Attack - player.Defense)<0) {
				text6.text = "The wolf dealt 0 damage to you";
			} else {
				text6.text = "The wolf dealt " + (wolf.Attack - player.Defense) + " damage to you";
				player.Health = player.Health - wolf.Attack + player.Defense;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.U)) {
			text6.text = "";
			text4.text = "";
			if (potion < 1) {
				text4.text = "You do have have any potions";
			} else if (player.Health + player.Potion > player.HealthMax) {
				text4.text = "You have been fully healed";
				player.Health = player.HealthMax;
				potion--;
			} else {
				text4.text = "You have been healed by " + player.Potion;
				player.Health = player.Health + player.Potion;
				potion--;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			text6.text = "";
			text4.text = "";
			if (elixer < 1) {
				text4.text = "You do not have any Elixer";
			} else if (player.Mana + player.Elixer > player.ManaMax) {
				text4.text = "Your mana is completely full";
				player.Mana = player.ManaMax;
				elixer--;
			} else {
				text4.text = "Your mana has been increased by " + player.Elixer;
				player.Mana = player.Mana + player.Elixer;
				elixer--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {
			if (player.Mana < player.ManaCost) {
				text6.text = "";
				text4.text = "You do not have enought mana";
			}
			else if (player.SpecialValue == 1) {
				if ((player.SpecialAttack - wolf.Defense)<0) {
					text4.text = "You dealt 0 damage to the wolf";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack) + " damage to the wolf";
					wolf.Health = wolf.Health - player.SpecialAttack;
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((wolf.Attack - player.Defense)<0) {
					text6.text = "The wolf dealt 0 damage to you";
				} else {
					text6.text = "The wolf dealt " + (wolf.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - wolf.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 2) {
				if ((player.SpecialAttack - wolf.Defense)<0) {
					text4.text = "You dealt 0 damage to the wolf";
				} else {
					text4.text = "Fire ball one does " + fireballOne + " damage to the wolf\nFire ball two does " + fireballTwo + " damage to the wolf";
					wolf.Health = wolf.Health - (fireballOne + fireballTwo);
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((wolf.Attack - player.Defense)<0) {
					text6.text = "The wolf dealt 0 damage to you";
				} else {
					text6.text = "The wolf dealt " + (wolf.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - wolf.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 3) {
				if ((player.SpecialAttack - wolf.Defense) <0) {
					text4.text = "you dealt 0 damage to the wolf";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - wolf.Defense) + " damage";
					wolf.Health = wolf.Health - player.SpecialAttack + wolf.Defense;
					text6.text = "The wolf cannot reach you";
					player.Mana = player.Mana - player.ManaCost;
				}
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.R)) {
			myStage = Stage.start;
			text2.text = "";
			text4.text = "";
			text6.text = "";
			text8.text = "";
		}
		
	}
	//fighting the bear
	void stage_bear () {
	
		text2.text = "Enemy:     " + bear.Name + "\nHealth:     " + bear.Health + "\nAttack:      " + bear.Attack + "\nDefense:   " + bear.Defense;
		text.text = "You have encountered a bear!\n\nPress A to Attack\nPress U to use a potion\nPress E to use Elixer\n\nPress R to Run away";
		if (player.SpecialValue == 1) {
			text8.text = "Press S to Downward thrust";
		}
		if (player.SpecialValue == 2) {
			text8.text = "Press S to cast a fireball";		
		}
		if (player.SpecialValue == 3 ) {
			text8.text = "Press S to make a ranged attack";
		}
		if (bear.Health <= 0) {
			myStage = Stage.bearWin;
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
			
			if ((player.Attack - bear.Defense)<0) {
				text4.text = "You dealt 0 damage to the bear";
			} else {
				text4.text = "You have dealt " + (player.Attack - bear.Defense) + " damage to the bear";
				bear.Health = bear.Health - player.Attack + bear.Defense;
			}
			
			if ((bear.Attack - player.Defense)<0) {
				text6.text = "The bear dealt 0 damage to you";
			} else {
				text6.text = "The bear dealt " + (bear.Attack - player.Defense) + " damage to you";
				player.Health = player.Health - bear.Attack + player.Defense;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.U)) {
			text6.text = "";
			text4.text = "";
			if (potion < 1) {
				text4.text = "You do have have any potions";
			} else if (player.Health + player.Potion > player.HealthMax) {
				text4.text = "You have been fully healed";
				player.Health = player.HealthMax;
				potion--;
			} else {
				text4.text = "You have been healed by " + player.Potion;
				player.Health = player.Health + player.Potion;
				potion--;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			text6.text = "";
			text4.text = "";
			if (elixer < 1) {
				text4.text = "You do not have any Elixer";
			} else if (player.Mana + player.Elixer > player.ManaMax) {
				text4.text = "Your mana is completely full";
				player.Mana = player.ManaMax;
				elixer--;
			} else {
				text4.text = "Your mana has been increased by " + player.Elixer;
				player.Mana = player.Mana + player.Elixer;
				elixer--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {
			if (player.Mana < player.ManaCost) {
				text6.text = "";
				text4.text = "You do not have enought mana";
			}
			else if (player.SpecialValue == 1) {
				if ((player.SpecialAttack - bear.Defense)<0) {
					text4.text = "You dealt 0 damage to the bear";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack) + " damage to the bear";
					bear.Health = bear.Health - player.SpecialAttack;
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((bear.Attack - player.Defense)<0) {
					text6.text = "The bear dealt 0 damage to you";
				} else {
					text6.text = "The bear dealt " + (bear.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - bear.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 2) {
				if ((player.SpecialAttack - bear.Defense)<0) {
					text4.text = "You dealt 0 damage to the bear";
				} else {
					text4.text = "Fire ball one does " + fireballOne + " damage to the bear\nFire ball two does " + fireballTwo + " damage to the bear";
					bear.Health = bear.Health - (fireballOne + fireballTwo);
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((bear.Attack - player.Defense)<0) {
					text6.text = "The bear dealt 0 damage to you";
				} else {
					text6.text = "The bear dealt " + (bear.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - bear.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 3) {
				if ((player.SpecialAttack - bear.Defense) <0) {
					text4.text = "you dealt 0 damage to the bear";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - bear.Defense) + " damage";
					bear.Health = bear.Health - player.SpecialAttack + bear.Defense;
					text6.text = "The bear cannot reach you";
					player.Mana = player.Mana - player.ManaCost;
				}
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.R)) {
			myStage = Stage.main;
			text2.text = "";
			text4.text = "";
			text6.text = "";
			text8.text = "";
		}
		
	}
	//fighting the zorgon
	void stage_zorgon () {
	
		text2.text = "Enemy:     " + zorgon.Name + "\nHealth:     " + zorgon.Health + "\nAttack:      " + zorgon.Attack + "\nDefense:   " + zorgon.Defense;
		text.text = "You have encountered a zorgon!\n\nPress A to Attack\nPress U to use a potion\nPress E to use Elixer\n\nPress R to Run away";
		if (player.SpecialValue == 1) {
			text8.text = "Press S to Downward thrust";
		}
		if (player.SpecialValue == 2) {
			text8.text = "Press S to cast a fireball";		
		}
		if (player.SpecialValue == 3 ) {
			text8.text = "Press S to make a ranged attack";
		}
		if (zorgon.Health <= 0) {
			myStage = Stage.zorgonWin;
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
			
			if ((player.Attack - zorgon.Defense)<0) {
				text4.text = "You dealt 0 damage to the zorgon";
			} else {
				text4.text = "You have dealt " + (player.Attack - zorgon.Defense) + " damage to the zorgon";
				zorgon.Health = zorgon.Health - player.Attack + zorgon.Defense;
			}
			
			if ((zorgon.Attack - player.Defense)<0) {
				text6.text = "The zorgon dealt 0 damage to you";
			} else {
				text6.text = "The zorgon dealt " + (zorgon.Attack - player.Defense) + " damage to you";
				player.Health = player.Health - zorgon.Attack + player.Defense;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.U)) {
			text6.text = "";
			text4.text = "";
			if (potion < 1) {
				text4.text = "You do have have any potions";
			} else if (player.Health + player.Potion > player.HealthMax) {
				text4.text = "You have been fully healed";
				player.Health = player.HealthMax;
				potion--;
			} else {
				text4.text = "You have been healed by " + player.Potion;
				player.Health = player.Health + player.Potion;
				potion--;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			text6.text = "";
			text4.text = "";
			if (elixer < 1) {
				text4.text = "You do not have any Elixer";
			} else if (player.Mana + player.Elixer > player.ManaMax) {
				text4.text = "Your mana is completely full";
				player.Mana = player.ManaMax;
				elixer--;
			} else {
				text4.text = "Your mana has been increased by " + player.Elixer;
				player.Mana = player.Mana + player.Elixer;
				elixer--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {
			if (player.Mana < player.ManaCost) {
				text6.text = "";
				text4.text = "You do not have enought mana";
			}
			else if (player.SpecialValue == 1) {
				if ((player.SpecialAttack - zorgon.Defense)<0) {
					text4.text = "You dealt 0 damage to the zorgon";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack) + " damage to the zorgon";
					zorgon.Health = zorgon.Health - player.SpecialAttack;
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((zorgon.Attack - player.Defense)<0) {
					text6.text = "The zorgon dealt 0 damage to you";
				} else {
					text6.text = "The zorgon dealt " + (zorgon.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - zorgon.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 2) {
				if ((player.SpecialAttack - zorgon.Defense)<0) {
					text4.text = "You dealt 0 damage to the zorgon";
				} else {
					text4.text = "Fire ball one does " + fireballOne + " damage to the zorgon\nFire ball two does " + fireballTwo + " damage to the zorgon";
					zorgon.Health = zorgon.Health - (fireballOne + fireballTwo);
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((zorgon.Attack - player.Defense)<0) {
					text6.text = "The zorgon dealt 0 damage to you";
				} else {
					text6.text = "The zorgon dealt " + (zorgon.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - zorgon.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 3) {
				if ((player.SpecialAttack - zorgon.Defense) <0) {
					text4.text = "you dealt 0 damage to the zorgon";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - zorgon.Defense) + " damage";
					zorgon.Health = zorgon.Health - player.SpecialAttack + zorgon.Defense;
					text6.text = "The zorgon cannot reach you";
					player.Mana = player.Mana - player.ManaCost;
				}
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.R)) {
			myStage = Stage.main;
			text2.text = "";
			text4.text = "";
			text6.text = "";
			text8.text = "";
		}
		
	}
	//fighthing the dragon
	void stage_dragon () {
		dragonFight = 1;
		text2.text = "Enemy:     " + dragon.Name + "\nHealth:     " + dragon.Health + "\nAttack:      " + dragon.Attack + "\nDefense:   " + dragon.Defense;
		text.text = "The guardian Dragon has appeared!\n\nPress A to Attack\nPress U to use a potion\nPress E to use Elixer\n\nPress R to Run away";
		if (player.SpecialValue == 1) {
			text8.text = "Press S to Downward thrust";
		}
		if (player.SpecialValue == 2) {
			text8.text = "Press S to cast a fireball";		
		}
		if (player.SpecialValue == 3 ) {
			text8.text = "Press S to make a ranged attack";
		}
		if (dragon.Health <= 0) {
			myStage = Stage.dragonWin;
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
			
			if ((player.Attack - dragon.Defense)<0) {
				text4.text = "You dealt 0 damage to the dragon";
			} else {
				text4.text = "You have dealt " + (player.Attack - dragon.Defense) + " damage to the dragon";
				dragon.Health = dragon.Health - player.Attack + dragon.Defense;
			}
			
			if ((dragon.Attack - player.Defense)<0) {
				text6.text = "The dragon dealt 0 damage to you";
			} else {
				text6.text = "The dragon dealt " + (dragon.Attack - player.Defense) + " damage to you";
				player.Health = player.Health - dragon.Attack + player.Defense;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.U)) {
			text6.text = "";
			text4.text = "";
			if (potion < 1) {
				text4.text = "You do have have any potions";
			} else if (player.Health + player.Potion > player.HealthMax) {
				text4.text = "You have been fully healed";
				player.Health = player.HealthMax;
				potion--;
			} else {
				text4.text = "You have been healed by " + player.Potion;
				player.Health = player.Health + player.Potion;
				potion--;
			}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			text6.text = "";
			text4.text = "";
			if (elixer < 1) {
				text4.text = "You do not have any Elixer";
			} else if (player.Mana + player.Elixer > player.ManaMax) {
				text4.text = "Your mana is completely full";
				player.Mana = player.ManaMax;
				elixer--;
			} else {
				text4.text = "Your mana has been increased by " + player.Elixer;
				player.Mana = player.Mana + player.Elixer;
				elixer--;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.S)) {

			if (player.Mana < player.ManaCost) {
				text6.text = "";
				text4.text = "You do not have enought mana";
			}
			else if (player.SpecialValue == 1) {
				if ((player.SpecialAttack - dragon.Defense)<0) {
					text4.text = "You dealt 0 damage to the dragon";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack) + " damage to the dragon";
					dragon.Health = dragon.Health - player.SpecialAttack;
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((dragon.Attack - player.Defense)<0) {
					text6.text = "The dragon dealt 0 damage to you";
				} else {
					text6.text = "The dragon dealt " + (dragon.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - dragon.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 2) {
				if ((player.SpecialAttack - dragon.Defense)<0) {
					text4.text = "You dealt 0 damage to the dragon";
				} else {
					text4.text = "Fire ball one does " + fireballOne + " damage to the dragon\nFire ball two does " + fireballTwo + " damage to the dragon";
					dragon.Health = dragon.Health - (fireballOne + fireballTwo);
					player.Mana = player.Mana - player.ManaCost;
				}
				
				if ((dragon.Attack - player.Defense)<0) {
					text6.text = "The dragon dealt 0 damage to you";
				} else {
					text6.text = "The dragon dealt " + (dragon.Attack - player.Defense) + " damage to you";
					player.Health = player.Health - dragon.Attack + player.Defense;
				}
			}
			else if (player.SpecialValue == 3) {
				if ((player.SpecialAttack - dragon.Defense) <0) {
					text4.text = "you dealt 0 damage to the dragon";
				} else {
					text4.text = "You have dealt " + (player.SpecialAttack - dragon.Defense) + " damage";
					dragon.Health = dragon.Health - player.SpecialAttack + dragon.Defense;
					text6.text = "The dragon cannot reach you";
					player.Mana = player.Mana - player.ManaCost;
				}
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.R)) {
			myStage = Stage.main;
			text2.text = "";
			text4.text = "";
			text6.text = "";
			text8.text = "";
		}
		
	}
	//bat dies
	void stage_batWin () {
		text.text = "You have defeated the bat!\nYou have gained a level!\nMax health + 3\nMax mana + 1\nGold + 100\n\nPress Space to continue";
		
		text2.text = "";
		text4.text = "";
		text6.text = "";
		text8.text = "";
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			level++;
			player.HealthMax = player.HealthMax + 3;
			player.Health = player.Health + 3;
			player.ManaMax = player.ManaMax + 1;
			player.Mana = player.Mana + 1;
			player.Gold = player.Gold + 100;
			myStage = Stage.door;
		}
		
	}
	//fox dies
	void stage_foxWin () {
		text.text = "You have defeated the fox!\nYou have gained a level\nAttack + 1\nSpecial + 1\nDefense + 1!\nGold + 150\n\nPress Space to continue";
		
		text2.text = "";
		text4.text = "";
		text6.text = "";
		text8.text = "";
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			myStage = Stage.closet;
			level++;
			player.Attack = player.Attack + 1;
			player.SpecialAttack = player.SpecialAttack + 1;
			player.FireballHigh = player.FireballHigh + 1;
			player.FireballLow = player.FireballLow + 1;
			player.Defense = player.Defense + 1;
			player.Gold = player.Gold + 150;
		}
	}
	//ogre dies
	void stage_ogreWin () {
		text.text = "You have defeated the ogre!\nYou have gained a level!\nMax health + 3\nMax mana + 1\nGold + 400\n\nPress Space to continue";
		
		text2.text = "";
		text4.text = "";
		text6.text = "";
		text8.text = "";
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			myStage = Stage.kitchen;
			level++;
			player.HealthMax = player.HealthMax + 3;
			player.Health = player.Health + 3;
			player.ManaMax = player.ManaMax + 1;
			player.Mana = player.Mana + 1;
			player.Gold = player.Gold + 400;
		}
	
	}
	//wolf dies
	void stage_wolfWin () {
		text.text = "You have defeated the wolf!\nYou have gained a level\nAttack + 1\nSpecial + 1\nDefense + 1!\nGold + 500\n\nPress Space to continue";
		
		text2.text = "";
		text4.text = "";
		text6.text = "";
		text8.text = "";
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			myStage = Stage.diamondHallway;
			level++;
			diamond = 2;
			player.Attack = player.Attack + 1;
			player.SpecialAttack = player.SpecialAttack + 1;
			player.FireballHigh = player.FireballHigh + 1;
			player.FireballLow = player.FireballLow + 1;
			player.Defense = player.Defense + 1;
			player.Gold = player.Gold + 500;
		}
	}
	//bear dies
	void stage_bearWin () {
		text.text = "You have defeated the bear!\nYou have gained a level!\nMax health + 3\nMax mana + 1\nGold + 600\n\nPress Space to continue";
		
		text2.text = "";
		text4.text = "";
		text6.text = "";
		text8.text = "";
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			myStage = Stage.spiralStairs;
			level++;
			player.HealthMax = player.HealthMax + 3;
			player.Health = player.Health + 3;
			player.ManaMax = player.ManaMax + 1;
			player.Mana = player.Mana + 1;
			player.Gold = player.Gold + 600;
		}
	}
	//zorgon dies
	void stage_zorgonWin () {
		text.text = "You have defeated the mighty zorgon!\nYou have gained a level\nAttack + 1\nSpecial + 1\nDefense + 1!\n" + 
		"Gold + 700\n\nPress Space to continue";
		
		text2.text = "";
		text4.text = "";
		text6.text = "";
		text8.text = "";
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			myStage = Stage.final;
			level++;
			player.Attack = player.Attack + 1;
			player.SpecialAttack = player.SpecialAttack + 1;
			player.FireballHigh = player.FireballHigh + 1;
			player.FireballLow = player.FireballLow + 1;
			player.Defense = player.Defense + 1;
			player.Gold = player.Gold + 700;
		}
	
	}
	//dragon dies
	void stage_dragonWin () {
		myStage = Stage.reward;
		text2.text = "";
		text4.text = "";
		text6.text = "";
		text8.text = "";
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			myStage = Stage.reward;
			level++;
			player.HealthMax = player.HealthMax + 3;
			player.Health = player.Health + 3;
			player.ManaMax = player.ManaMax + 1;
			player.Mana = player.Mana + 1;
			player.Gold = 99999;
		}
	}	
	
	
	void stage_front () {
		text.text = "You see a little shack with a dwarf inside.\n\nPress I to investigate the dwarf\nPress R to return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.start;}
		else if (Input.GetKeyDown (KeyCode.I))			{myStage = Stage.shop;}
	}
	//used for the shop
	void stage_shop () {

		text.text = "Greetings Traveler! I have quality items for sale, but only if you are willing to pay!\n\n" + 
		"A: (Attack +2)          Sword of sharpness   [300 Gold]\n" +
		"B: (Defense +1)       Hardened Sheild        [250 Gold]\n" +
		"C: (Max Health +5)  Eternity Ring              [500 Gold]\n" +
		"D: (Health + " + player.Potion +")         Healing Potion           [150 Gold]\n" + 
		"E: (Mana + " + player.Elixer +")          Elixer                         [200 Gold]\n\nPress R to Return";
		
		if (Input.GetKeyDown (KeyCode.A)) {
			if (player.Gold < 300) {
				myStage = Stage.noGold;
			} 
			else if (sword == 0) {
				player.Attack = player.Attack + 2;
				player.Gold = player.Gold - 300;
				sword = 1;
				myStage = Stage.sword;
			}
			else
				myStage = Stage.haveItem;
		}
		
		else if (Input.GetKeyDown (KeyCode.B)) {
			if (player.Gold < 250) {
				myStage = Stage.noGold;
			} 
			else if (sheild == 0) {
				player.Defense = player.Defense + 1;
				player.Gold = player.Gold - 250;
				sheild = 1;
				myStage = Stage.sheild;
			}
			else
				myStage = Stage.haveItem;
		}
		
		else if (Input.GetKeyDown (KeyCode.C)) {
			if (player.Gold < 500) {
				myStage = Stage.noGold;
			} 
			else if (ring == 0) {
				player.HealthMax = player.HealthMax + 5;
				player.Health = player.Health + 5;
				player.Gold = player.Gold - 500;
				ring = 1;
				myStage = Stage.ring;
			}
			else
				myStage = Stage.haveItem;
		}
		
		else if (Input.GetKeyDown (KeyCode.D)) {
			if (player.Gold < 150) {
				myStage = Stage.noGold;
			} 
			else if (potion >= 0) {
				player.HealthMax = player.HealthMax + 5;
				player.Health = player.Health + 5;
				player.Gold = player.Gold - 150;
				potion++;
				myStage = Stage.potion;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.E)) {
			if (player.Gold < 200) {
				myStage = Stage.noGold;
			} 
			else if (elixer >= 0) {
				player.Gold = player.Gold - 200;
				elixer++;
				myStage = Stage.elixer;
			}
		}
		
		else if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.front;}		
	}
	//displays if there is not enough gold 
	void stage_noGold () {
		text.text = "You do not have enough gold.\n\nPress R to return.";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.shop;}
	}
	//Displays if the player already has the item
	void stage_haveItem () {
		text.text = "You already have that item.\n\nPress R to return.";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.shop;}
	}
	//displays whent the sword is bought
	void stage_sword () {
		text.text = "Your attack rating has been increased by 2!\n\nPress R to return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.shop;}
	}
	//displays if the shield is bought
	void stage_sheild () {
		text.text = "Your defense rating has been increased by 1!\n\nPress R to return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.shop;}
	}
	//displays if the ring is bought
	void stage_ring () {
		text.text = "Your Max Health has been increased by 5!\n\nPress R to Return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.shop;}
	}
	//displays if the potion is bought
	void stage_potion () {
		text.text = "You have purchased a potion!\n\nPress R to return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.shop;}
	}
	//displays if the elixer is bought
	void stage_elixer () {
		text.text = "You have purchased an Elixer\n\nPress R to return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.shop;}
	}
	
	void stage_main () {
		text.text = "You are now in the main room. You see a large golden door...\n\nPress I to inspect the door\nPress K to go into the kitchen\n" + 
		"Press C to search the closet\nPress U to go Upstairs" +
		"\nPress R to Return";
		if (Input.GetKeyDown (KeyCode.K))				{myStage = Stage.kitchen;}
		else if (Input.GetKeyDown (KeyCode.C))			{myStage = Stage.closet;}
		else if (Input.GetKeyDown (KeyCode.U))			{myStage = Stage.upstairs;}
		else if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.door;}
		else if (Input.GetKeyDown (KeyCode.I))			{myStage = Stage.goldenDoor;}
	}
	
	void stage_back () {
		text.text = "You have found a wooden chest, but it appears to be locked...\n\nPress R to return";
	
		if (wooden == 2) {
			text.text = "There is nothing else to see here\n\nPress R to Return";
			if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.start;}
		}
		
		else if (wooden == 1) {
			text.text = "You have found a wooden chest. Press U to use the Wooden Key!";
			if (Input.GetKeyDown (KeyCode.U))			{myStage = Stage.woodenChest;}
		}
	
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.start;}
		
		
	}
	
	void stage_woodenChest () {
		text.text = "You have found a potion!\nYou have found an elixer!\nYou have found a silver key!\n\nPress R to Return";
		if (Input.GetKeyDown (KeyCode.R))				{wooden=2;silver=1;potion++;elixer++;myStage = Stage.start;}
		
		else if (silver == 1) {
		text.text = "There is nothing else to see here\n\nPress R to Return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.start;}
		}
	}
	
	void stage_silverChest () {
	
		if (silver == 0) {
			text.text = "You have found a silver chest, but it appears to be locked...\n\nPress R to return";
		}
	
		text.text = "You have opened the silver chest!" +
		"You have found a breastplate of power!\nMax health + 4\nSpecial + 1\nAttack + 1\n\nPress R to return";
		
		if (Input.GetKeyDown (KeyCode.R)){
			silver = 2;
			golden = 1;
			myStage = Stage.kitchen;
			player.HealthMax = player.HealthMax + 5;
			player.Health = player.Health + 5;
			player.Attack = player.Attack + 1;
			player.SpecialAttack = player.SpecialAttack + 1;
			player.FireballLow = player.FireballLow + 1;
			player.FireballHigh = player.FireballHigh + 1;
		}
		
	}
	
	void stage_goldenDoor () {
		if (golden == 0) {
			text.text = "You try to open the door, but it appears the be locked...\n\nPress R to return";
			if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.main;}
		}
		else if (golden == 1) {
			myStage = Stage.fairy;
		}
	}
	
	void stage_fairy () {
		if (fairy == 1) {
			text.text = "There is nothing else to see here\n\nPress R to return";
			if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.main;}
		}
		else {
			text.text = "A magic fairy has appeared. She will grant you one wish!\nShe also gives you a dimond key!\n\nA: Attack + 5\nB: Defese + 3" +
			 "\nC: Max mana + 5\nD: Max health + 10";
			if (Input.GetKeyDown (KeyCode.A)) {
				player.Attack = player.Attack + 5;
				fairy = 1;
				diamond = 1;
				myStage = Stage.main;
			}
			else if (Input.GetKeyDown (KeyCode.B)) {
				player.Defense = player.Defense + 3;
				fairy = 1;
				diamond = 1;
				myStage = Stage.main;
			}
			else if (Input.GetKeyDown (KeyCode.C)) {
				player.ManaMax = player.ManaMax + 5;
				player.Mana = player.Mana + 5;
				fairy = 1;
				diamond = 1;
				myStage = Stage.main;
			}
			else if (Input.GetKeyDown (KeyCode.D)) {
				player.HealthMax = player.HealthMax + 10;
				player.Health = player.Health + 10;
				fairy = 1;
				diamond = 1;
				myStage = Stage.main;
			}
		}
	}
	
	void stage_kitchen () {
	
		if (ogre.Health > 0) {
			myStage = Stage.ogre;
		}
		else
		
		text.text = "You see a sliver chest, but it appears to be locked...\n\nPress R to return to the main room";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.main;}
		
		else if (silver == 1) {

			text.text = "You see a silver chest. Press U to Use the silver key!\n\nPress R to return to the main room";
			if (Input.GetKeyDown (KeyCode.U))			{myStage = Stage.silverChest;silver=2;}
			else if (Input.GetKeyDown (KeyCode.R))		{myStage = Stage.main;}	
		}
		else if (silver == 2 ) {
		text.text = "There is nothing else here in the kitchen\n\nPress R to Return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.start;}
		}
	}
	
	void stage_closet () {
	
	
		if (fox.Health > 0) {
			myStage = Stage.fox;
			player.Key = 1;
		}else {
			text.text = "You see a wooden key\n\nPress K to take the Key and return to the main room";
			if (Input.GetKeyDown (KeyCode.K))			{wooden=1;myStage = Stage.main;}
		}
		if (wooden >= 1) {
			text.text = "There is nothing else to see here\n\nPress R to return";
			if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.main;}
		} 
		
	}
	
	void stage_upstairs () {
	
		if (wolfFight == 1) {
			myStage = Stage.wolf;
		}
			

		text.text = "At the top of the stairs you see a diamond door, but it appears to be locked.\n\nPress R to return";
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.main;}
			
		else if (diamond == 1) {	
			text.text = "Press U to Use the Diamond key on the diamond door\nPress R to return downstairs";
			if (Input.GetKeyDown (KeyCode.U))			{myStage = Stage.wolf;}
			if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.main;}
		}
		else if (diamond == 2) {
			myStage = Stage.diamondHallway;
		}
	}
	
	void stage_diamondHallway () {
		if (bear.Health <= 0) {
			myStage = Stage.spiralStairs;
		}
		text.text = "You are in a diamond hallway.\n\nPress O to open the door at the end of the hall\nPress R to return downstairs";
		if (Input.GetKeyDown (KeyCode.O))				{myStage = Stage.bear;}
		if (Input.GetKeyDown (KeyCode.R))				{myStage = Stage.main;}
	}
	
	void stage_spiralStairs () {
		text.text = "You are now in the castles tower.\n\nPress C to Climb up the sprial staircase\nPress R to return downstairs";
		if (Input.GetKeyDown (KeyCode.C))				{myStage = Stage.tower;}
	}
	void stage_tower () {
		if (fairy2 == 0) {
			myStage = Stage.fairyTwo;
		}
		else if (zorgon.Health <= 0) {
			myStage = Stage.final;
		}
		else
			text.text = "At the top of the tower, you see a mighty zorgon guarding a door. There does not seem to be a way around the zorgon.\n\n" +
			"Press F to Fight the mighty zorgon\nPress R to return downstairs";
			if (Input.GetKeyDown (KeyCode.F))			{myStage = Stage.zorgon;}
			if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.main;}
	}
	
	void stage_final () {
		if (dragonFight == 1) {
			myStage = Stage.dragon;
		}
		text.text = "You've made it! Well done! Wait a minute... What's that sound!?\n\nPress Space to continue...";
		if (Input.GetKeyDown (KeyCode.Space))			{myStage = Stage.dragon;}
	}
	//Win the game
	void stage_reward () {
		text.text = "Congratulations, you have defeated the castle guardian! You now have more money than you could ever imagine!\n\nThanks for playing!";
	}
	
	void stage_fairyTwo () {
		if (fairy2 == 1) {
			text.text = "There is nothing else to see here\n\nPress R to return";
			if (Input.GetKeyDown (KeyCode.R))			{myStage = Stage.main;}
		}
		else {
			text.text = "The magic fairy has re-appeared! She will grant you one wish!\n\nA: Attack + 7\nB: Defense + 4" +
				"\nC:All Health and mana restored!";
			if (Input.GetKeyDown (KeyCode.A)) {
				player.Attack = player.Attack + 7;
				fairy2 = 1;
				myStage = Stage.tower;
			}
			else if (Input.GetKeyDown (KeyCode.B)) {
				player.Defense = player.Defense + 4;
				fairy2 = 1;
				myStage = Stage.tower;
			}
			else if (Input.GetKeyDown (KeyCode.C)) {
				player.Mana = player.ManaMax;
				player.Health = player.HealthMax;
				fairy2 = 1;
				myStage = Stage.tower;
			}
		}
	}
    //used to get a random number for the fireball
	static int getRandom (int a, int b) {
		int min = a;
		int max = b;
		
		int number = Random.Range(min, max);
		
		return number;
	}
}
