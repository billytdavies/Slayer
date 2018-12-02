using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class SwordHUD : MonoBehaviour {
	public GameObject Player;
	void Update(){
		if(Input.GetKey(KeyCode.LeftShift)){
			gameObject.GetComponent<Image>().enabled = true;
			foreach (Image panel in gameObject.transform.GetComponentsInChildren<Image>())
			{
				panel.enabled = true;
			}
			foreach (Image panel in gameObject.transform.GetComponentsInChildren<Image>())
			{
				panel.enabled = true;
			}
			foreach (TMP_Text panel in gameObject.transform.GetComponentsInChildren<TMP_Text>())
			{
				panel.enabled = true;
			}
		} else {
			gameObject.GetComponent<Image>().enabled = false;
			foreach (Image panel in gameObject.transform.GetComponentsInChildren<Image>())
			{
				panel.enabled = false;
			}
			foreach (Image panel in gameObject.transform.GetComponentsInChildren<Image>())
			{
				panel.enabled = false;
			}
			foreach (TMP_Text panel in gameObject.transform.GetComponentsInChildren<TMP_Text>())
			{
				panel.enabled = false;
			}
		}
		for (int i = 0; i < 3; i++){
			gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].damage.ToString() + " DMG";
			gameObject.transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].knockback.ToString() + " KB";
			gameObject.transform.GetChild(i).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].kills.ToString() + " KLS";
			gameObject.transform.GetChild(i).GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].type;
			string[] affixes = Player.GetComponent<Player>().swords[i].affixes;
			gameObject.transform.GetChild(i).GetChild(0).GetChild(4).GetComponent<TMP_Text>().text = affixes[0] + Environment.NewLine + affixes[1] + Environment.NewLine + affixes[2];
			gameObject.transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = Player.GetComponent<Player>().swords[i].image;
		}
	}
}
