﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    static class Constants
    {
        //Random
        public static Random rand = new Random();

        //Player Settings
        public const int playerBaseHP = 5;
        public const int playerBaseShield = 5;
        public const int playerBaseAttack = 2;
        public const int playerXPThreshold = 25;
        public static Tile playerSprite = new Tile('@', ConsoleColor.White, ConsoleColor.Black);

        //Enemy Settings
        public const int EnemySightRange = 7;
        public const int EnemyAmount = 50;

        //ShopKeep Settings
        public const int ShopKeepAmount = 2;
        public const int shopKeepBaseHP = 10;
        public const int shopKeepBaseAttack = 5;
        public static Tile shopKeepSprite = new Tile('¢', ConsoleColor.DarkYellow, ConsoleColor.Black);
        public const string shopKeepName = "Shop Keep";

        //Shop Price Settings
        public const int healthPotionCost = 8;
        public const int shieldRepairCost = 4;
        public const int ATKBuffCost = 12;

        //Slime Settings
        public const int slimeBaseHP = 1;
        public const int slimeBaseAttack = 1;
        public const int slimeXP = 1;
        public const int slimeGold = 1;
        public static Tile slimeSprite = new Tile('O', ConsoleColor.Cyan, ConsoleColor.Black);
        public const string slimeName = "Slime";

        //Goblin Settings
        public const int goblinBaseHP = 5;
        public const int goblinBaseAttack = 2;
        public const int goblinXP = 5;
        public const int goblinGold = 5;
        public static Tile goblinSprite = new Tile('X', ConsoleColor.DarkGreen, ConsoleColor.Black);
        public const string goblinName = "Goblin";

        //Kobold Settings
        public const int koboldBaseHP = 3;
        public const int koboldBaseAttack = 1;
        public const int koboldXP = 2;
        public const int koboldGold = 3;
        public static Tile koboldSprite = new Tile('X', ConsoleColor.DarkRed, ConsoleColor.Black);
        public const string koboldName = "Kobold";

        //Boss Settings
        public const int bossBaseHP = 150;
        public const int bossBaseAttack = 3;
        public static Tile bossSprite = new Tile('M', ConsoleColor.DarkRed, ConsoleColor.Black);
        public const string bossName = "Boss";

        //Item Settings
        public const int itemAmount = 50;
        public const int bossItemAmount = 10;
        public const int healAmount = 3;
        public const int ATKBuffAmount = 1;
        public const int shieldRepairAmount = 3;
        public static Tile healSprite = new Tile('+', ConsoleColor.Green, ConsoleColor.Black);
        public static Tile ATKSprite = new Tile('*', ConsoleColor.Red, ConsoleColor.Black);
        public static Tile ShieldRepairSprite = new Tile('#', ConsoleColor.Blue, ConsoleColor.Black);
        public const string healName = "Health Potion";
        public const string ATKBuffName = "ATK Buff";
        public const string ShieldRepairName = "Shield Repair";

        //Map Settings
        public const ConsoleColor mapColor = ConsoleColor.DarkGray;
        public const int mapHeight = 5;
        public const int mapWidth = 5;
        public const int roomHeight = 13;
        public const int roomWidth = 13;
        public const int BossRoomWidth = 15;
        public const int BossRoomHeight = 15;
        public const int BossFloor = 3;
        public const int RoomsPerCategory = 4;

        //Cam Settings
        public const int camSize = 15;

        //Render Settings
        public const int rendWidth = 35;
        public const int rendHeight = 50;
        public const ConsoleColor borderColor = ConsoleColor.White;
        public const ConsoleColor BGColor = ConsoleColor.Black;

        //HUD Settings
        public const int hudWidth = 33;
        public const int messageBoxHeight = 2;
        public const int statsHeight = 9;
        public const string playerStatsList = "Player|HP: 1/2|SHLD: 3/4|ATK: 5|LVL: 6|XP: 7/8|FLOOR: 9/0|GOLD: $";
        public const string enemyStatsList = "HP: 1|ATK: 2|XP: 3|GOLD: 4";
        public const string shopList = "1: HP Potion !g|2: Shield @g|3: ATK Buff #g|E key to leave";

        //Exit Settings
        public static Tile exitSprite = new Tile('¤', ConsoleColor.Yellow, ConsoleColor.Black);

        //Quest Strings
        public const string killEnemiesString = "kill 10 enemies";
        public const string loseShieldString = "lose your shield";
        public const string killBossString = "kill the boss";
        public const string buyFromShopString = "buy from shop";
        public const string pickUpItemsString = "get 10 items";

        //Quest Conditions
        public const int enemiesToKill = 10;
        public const int itemsToGet = 10;
    }
}
