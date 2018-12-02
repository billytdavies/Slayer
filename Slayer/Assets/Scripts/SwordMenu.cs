using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SwordMenu : MonoBehaviour {
	public GameObject Player;

	void Update()
    {
        if (gameObject.GetComponent<Image>().IsActive()) { UpdateChoices(); }
		if(Input.GetKey("escape")){CloseMenu();}
    }

    public void CloseMenu()
    {
		Time.timeScale = 1;
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

    private void UpdateChoices(){
		for (int i = 0; i < 3; i++){
			gameObject.transform.GetChild(i).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].damage.ToString() + " DMG";
			gameObject.transform.GetChild(i).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].knockback.ToString() + " KB";
			gameObject.transform.GetChild(i).GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].kills.ToString() + " KLS";
			gameObject.transform.GetChild(i).GetChild(1).GetChild(3).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].type;
			string[] affixes = Player.GetComponent<Player>().swords[i].affixes;
			gameObject.transform.GetChild(i).GetChild(1).GetChild(4).GetComponent<TMP_Text>().text = affixes[0] + Environment.NewLine + affixes[1] + Environment.NewLine + affixes[2];
			gameObject.transform.GetChild(i).GetChild(3).GetComponent<Image>().sprite = Player.GetComponent<Player>().swords[i].image;
		}

		for (int i = 0; i < 3; i++){
			gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().newSword.damage.ToString() + " DMG";
			gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().newSword.knockback.ToString() + " KB";
			gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().newSword.kills.ToString() + " KLS";
			gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().newSword.type;
			string[] affixes = Player.GetComponent<Player>().newSword.affixes;
			gameObject.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(4).GetComponent<TMP_Text>().text = affixes[0] + Environment.NewLine + affixes[1] + Environment.NewLine + affixes[2];
			gameObject.transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<Image>().sprite = Player.GetComponent<Player>().newSword.image;
		}
    }
}
