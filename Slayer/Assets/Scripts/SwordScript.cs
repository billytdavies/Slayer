using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
	
	public Sword sword;
	public int damage;
	public string type;
	public int kills;
	public Sprite image;

	void Update(){
		sword = new Sword(damage,type,kills,image);
	}
}
public class Sword {
	public int damage;
	public string type;
	public int kills;
	public Sprite image;
	public Sword(int dmg,string typ, int kls, Sprite img){
		damage = dmg;
		type = typ;
		kills = kls;
		image = img;
	}
}
