using System.Collections;
using System.Collections.Generic;

public enum StatsEnum {Agility, Cunning, Spirit, Strength, Lore, Luck,
	Initiative, Combat, Grit, Ranged, Melee,
	Health, CurHealth,
	Sanity, CurSanity,
	Corruption, Resistance,
	Defense, Willpower}

[System.Serializable]
public class Stats
{
	public string Name = "Testing McTesty";
	public string PicturePath = "";

	public List<string> Keywords = new List<string>();

	//Skills
	public int Agility = 1;
	public int Cunning = 1;
	public int Spirit = 1;
	public int Strength = 1;
	public int Lore = 1;
	public int Luck = 1;

	//Combat
	public int Initiative = 3;
	public int Combat = 2;
	public int Grit = 2;
	public int Ranged = 4;
	public int Melee = 4;

	//Defenses
	public int Health = 12;
	public int CurHealth = 0;
	public int Sanity = 12;
	public int CurSanity = 0;
	public int Resistance = 5;
	public int Corruption = 0;
	public int Defense = 4;
	public int Willpower = 4;

}

