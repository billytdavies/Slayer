using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SwordMenu : MonoBehaviour {
	public GameObject Player;

	void Update(){
		UpdateChoices();
		if(Input.GetKey("escape")){
			Time.timeScale = 1;
			gameObject.GetComponent<Image>().enabled = false;
			foreach (Image panel in gameObject.transform.GetComponentsInChildren<Image>())
			{
				panel.enabled = false;
			}
			foreach (RawImage panel in gameObject.transform.GetComponentsInChildren<RawImage>())
			{
				panel.enabled = false;
			}
			foreach (TMP_Text panel in gameObject.transform.GetComponentsInChildren<TMP_Text>())
			{
				panel.enabled = false;
			}
		}
	}

    private void UpdateChoices(){
		for (int i = 0; i < 3; i++){
			gameObject.transform.GetChild(i).GetChild(2).GetComponent<TMP_Text>().text = Player.GetComponent<Player>().swords[i].type;
		}
    }
}
