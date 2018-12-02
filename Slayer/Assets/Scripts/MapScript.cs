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
	}
	public void one(){
		Player.GetComponent<Player>().swords[0] = basic;
		Time.timeScale = 1;
		hide();
		Destroy(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1));
	}
	public void two(){
		Player.GetComponent<Player>().swords[1] = basic;
		Time.timeScale = 1;
		hide();
		Destroy(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1));
	}
	public void three(){
		Player.GetComponent<Player>().swords[2] = basic;
		Time.timeScale = 1;
		hide();
		Destroy(transform.GetComponentInChildren<Altar>().gameObject.transform.parent.GetChild(1));
	}

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
