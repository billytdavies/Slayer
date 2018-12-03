using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Boss : MonoBehaviour {
	public GameObject player;
	public GameObject win;
	public GameObject lose;
	bool isAggro;
	public int health;
	Rigidbody2D rb;
	void Start(){
		Hide(win);
		Hide(lose);
		isAggro = false;
		rb= gameObject.GetComponent<Rigidbody2D>();
	}
	public void Hide (GameObject panel) {
		Time.timeScale = 1;
		panel.GetComponent<Image>().enabled = false;
		foreach (Image Pan in panel.GetComponentsInChildren<Image>())
		{
			Pan.enabled = false;
		}
		foreach (Image Pan in panel.GetComponentsInChildren<Image>())
		{
			Pan.enabled = false;
		}
		foreach (TMP_Text Pan in panel.GetComponentsInChildren<TMP_Text>())
		{
			Pan.enabled = false;
		}
	}
	public void Show (GameObject panel){
		Time.timeScale = 0;
		panel.GetComponent<Image>().enabled = true;
		foreach (Image Pan in panel.GetComponentsInChildren<Image>())
		{
			Pan.enabled = true;
		}
		foreach (Image Pan in panel.GetComponentsInChildren<Image>())
		{
			Pan.enabled = true;
		}
		foreach (TMP_Text Pan in panel.GetComponentsInChildren<TMP_Text>())
		{
			Pan.enabled = true;
		}
	}
	
	void Update () {
		if(Vector3.Distance(transform.position,player.transform.position)<10&&!isAggro){
			if(player.GetComponent<Player>().Score>30){
				Show(win);
				isAggro = true;
			} else {
				Show(lose);
				StartCoroutine(Launch());
				isAggro = true;
			}
		}
		
	}
	IEnumerator Launch(){
		yield return new WaitForSeconds(1);
		Vector3 dir = (player.transform.position-gameObject.transform.position).normalized;
		rb.AddForce(dir*350);
		StartCoroutine(Launch());
	}
	void OnTriggerEnter2D(Collider2D Other){
		if(Other.transform.tag == "Sword"){
			health -= player.GetComponent<Player>().swords[player.GetComponent<Player>().currentSword].damage;
			player.GetComponent<Player>().UpgradeSword();
		}
		if(health<=0){
			player.GetComponent<Player>().UpgradeSword();
			player.GetComponent<Player>().UpgradeSword();
			player.GetComponent<Player>().UpgradeSword();
			player.GetComponent<Player>().swords[player.GetComponent<Player>().currentSword].kills +=1;
			Destroy(gameObject);
			Destroy(gameObject.transform.parent.GetChild(0).GetChild(0).gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D Other){
		if(Other.transform.tag == "Player"){
			player.GetComponent<Player>().hp -= 15;
		}
	}
}
