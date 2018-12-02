using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpot : MonoBehaviour {
	public GameObject Sword;
	string[] names;
	public Sprite[] pics;
	void Start () {
		names = new string[] {"Slayer","Killer","Slasher","Stabber","Fury","Deathbringer","Hney"};
		var srdobj = Instantiate(Sword,transform.position,Quaternion.identity);
		srdobj.GetComponent<SwordScript>().kills = Random.Range(0,3);
		srdobj.GetComponent<SwordScript>().type = names[Random.Range(0,names.Length)];
		srdobj.GetComponent<SwordScript>().damage = Random.Range(5,25);
		srdobj.GetComponent<SwordScript>().image = pics[Random.Range(0,pics.Length)];
	}
}
