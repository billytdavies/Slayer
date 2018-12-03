using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Exit : MonoBehaviour {
	public GameObject win;

	void Start(){
		win.GetComponent<Image>().enabled = false;
		foreach (Image panel in win.GetComponentsInChildren<Image>())
		{
			panel.enabled = false;
		}
		foreach (Image panel in win.GetComponentsInChildren<Image>())
		{
			panel.enabled = false;
		}
		foreach (TMP_Text panel in win.GetComponentsInChildren<TMP_Text>())
		{
			panel.enabled = false;
		}
	}
	void OnCollisionEnter2D(Collision2D Other){
		if(Other.transform.tag == "Player"){
			win.GetComponent<Image>().enabled = true;
			foreach (Image panel in win.GetComponentsInChildren<Image>())
			{
				panel.enabled = true;
			}
			foreach (Image panel in win.GetComponentsInChildren<Image>())
			{
				panel.enabled = true;
			}
			foreach (TMP_Text panel in win.GetComponentsInChildren<TMP_Text>())
			{
				panel.enabled = true;
			}
		}
	}
}
