using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
	
	public Sword sword;
	public int damage;
	public string type;
	public int kills;
	public int knockback;
	public string[] affixes;
	public Sprite image;

	void Update(){
		sword = new Sword(damage,type,kills,knockback,affixes,image);
		gameObject.GetComponent<SpriteRenderer>().sprite = image;
	}
}
public class Sword {
	public int damage;
	public string type;
	public int kills;
	public int knockback;
	public Sprite image;
	public string[] affixes;
	public Sword(int dmg,string typ, int kls,int KB,string[] afx,Sprite img){
		damage = dmg;
		type = typ;
		kills = kls;
		knockback = KB;
		image = img;
		affixes = afx;
	}
}
