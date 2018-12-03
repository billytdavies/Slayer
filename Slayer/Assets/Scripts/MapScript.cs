using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MapScript : MonoBehaviour {
	public GameObject Player;
	Sword basic;
	public GameObject[] Rooms;
	public Sprite basicsword;
	public GameObject sacrafice;
	Altar[] Altars;
	GameObject activeAltar;
	void Start(){
		basic = new Sword(5, "Sword", 0, 0, new string[3], basicsword);
		
		int[] usedNums = new int[Rooms.Length];
		Instantiate(Rooms[0],transform.position,Quaternion.identity);
		for (int i = 1; i < Rooms.Length; i++){
			Wrong:
			int rand = Random.Range(1,Rooms.Length);
			foreach (int l in usedNums){
				if(l==rand){
					goto Wrong;
				}
			}
			var room = Instantiate(Rooms[rand],new Vector3(transform.position.x,transform.position.y+i*18,transform.position.z),Quaternion.identity);
			room.transform.parent = transform;
			usedNums[i] = rand;
		}
		Altars = GetComponentsInChildren<Altar>();
	}


	public void one(){
		Player.GetComponent<Player>().hp += Player.GetComponent<Player>().swords[0].kills;
		Player.GetComponent<Player>().Score += Player.GetComponent<Player>().swords[0].kills;
		Player.GetComponent<Player>().swords[0] = basic;
		Time.timeScale = 1;
		hide();

		if(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1).GetChild(0).tag!="Altar"){
			Destroy(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1).gameObject);
		}
		
	}
	public void two(){
		Player.GetComponent<Player>().hp += Player.GetComponent<Player>().swords[1].kills;
		Player.GetComponent<Player>().Score += Player.GetComponent<Player>().swords[1].kills;
		Player.GetComponent<Player>().swords[1] = basic;
		Time.timeScale = 1;
		hide();

		if(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1).GetChild(0).tag!="Altar"){
			Destroy(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1).gameObject);
		}
		
	}
	public void three(){
		Player.GetComponent<Player>().hp += Player.GetComponent<Player>().swords[2].kills*3;
		Player.GetComponent<Player>().Score += Player.GetComponent<Player>().swords[2].kills;
		Player.GetComponent<Player>().swords[2] = basic;
		Time.timeScale = 1;
		hide();
		if(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1).GetChild(0).tag!="Altar"){
			Destroy(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1).gameObject);
		}

		
	}

	/*
	GameObject Findaltar(){
		activeAltar = Altars[0].gameObject;
		foreach (Altar alt in Altars){
			if(Vector3.Distance(Player.transform.position,activeAltar.transform.position)<Vector3.Distance(Player.transform.position,alt.gameObject.transform.position)){
				activeAltar = alt.gameObject;
			}
		}
		return activeAltar
	}
	*/
	void hide(){
	foreach (Image panel in sacrafice.GetComponentsInChildren<Image>())
        {
            panel.enabled = false;
        }
        foreach (Image panel in sacrafice.GetComponentsInChildren<Image>())
        {
            panel.enabled = false;
        }
        foreach (TMP_Text panel in sacrafice.GetComponentsInChildren<TMP_Text>())
        {
            panel.enabled = false;
        }
	}
}
