using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
	
	public Sword sword;
	public int damage;
	public string type;
	public int kills;
	void Update(){
		sword = new Sword(damage,type,kills);
	}
}
public class Sword {
	public int damage;
	public string type;
	public int kills;

	public Sword(int dmg,string typ, int kls){
		damage = dmg;
		type = typ;
		kills = kls;
	}
}
