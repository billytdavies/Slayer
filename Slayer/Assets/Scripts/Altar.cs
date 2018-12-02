using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Altar : MonoBehaviour {
	GameObject sacrafice;
	GameObject canvas;
	GameObject Player;

	
	void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        sacrafice = canvas.transform.GetChild(5).gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");

        sacrafice.GetComponent<Image>().enabled = false;
        hide();
    }

    private void hide()
    {
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

    void OnCollisionEnter2D (Collision2D Other) {
		if(Other.transform.tag=="Player"){
			Time.timeScale = 0;

			sacrafice.GetComponent<Image>().enabled = true;

			foreach (Image panel in sacrafice.GetComponentsInChildren<Image>())
			{
				panel.enabled = true;
			}
			foreach (Image panel in sacrafice.GetComponentsInChildren<Image>())
			{
				panel.enabled = true;
			}
			foreach (TMP_Text panel in sacrafice.GetComponentsInChildren<TMP_Text>())
			{
				panel.enabled = true;
			}

			for (int i = 0; i < 3; i++)
			{
				sacrafice.transform.GetChild(i).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].damage.ToString() + " DMG";
				sacrafice.transform.GetChild(i).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].knockback.ToString() + " KB";
				sacrafice.transform.GetChild(i).GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].kills.ToString() + " KLS";
				sacrafice.transform.GetChild(i).GetChild(1).GetChild(3).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].type;
				string[] affixes = Player.GetComponent<Player>().swords[i].affixes;
				sacrafice.transform.GetChild(i).GetChild(1).GetChild(4).GetComponent<TMP_Text>().text = affixes[0] + Environment.NewLine + affixes[1] + Environment.NewLine + affixes[2];
				sacrafice.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Player.GetComponent<Player>().swords[i].image;
			}
		}
	}

}
