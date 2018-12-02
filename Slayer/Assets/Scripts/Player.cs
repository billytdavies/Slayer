using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
	int hp;
	public int Score;
	public GameObject deathMessage;
	public GameObject hpobject;
	public Sprite defaultimg;
	Rigidbody2D rb; 
	public GameObject SwordDisplay;
	public Sword[] swords;
	public Sword newSword;
	GameObject newSwordObject;
	public int currentSword;
	public GameObject Panel;
	// Use this for initialization
	void Start () {
		hide(deathMessage);
		hp=100;
		currentSword = 0;
		rb = gameObject.GetComponent<Rigidbody2D>();
		swords = new Sword[3] {new Sword(10,"Jeff",3,2,new string[3]{"+1","+3","+6"},defaultimg),new Sword(10,"Jeff",3,2,new string[3],defaultimg),new Sword(10,"Jeff",3,2,new string[3],defaultimg)};
		Panel.GetComponent<Image>().enabled = false;
		hide(Panel);

		SwordDisplay.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
		SwordDisplay.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
		SwordDisplay.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Attack();
		UpdateGUI();
	}
	void UpdateGUI(){
		hpobject.GetComponent<TMP_Text>().text = "HP:" + hp.ToString();

		if(currentSword==0){
			SwordDisplay.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
			SwordDisplay.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
			SwordDisplay.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
		}
		if(currentSword==1){
			SwordDisplay.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
			SwordDisplay.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
			SwordDisplay.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
		}
		if(currentSword==2){
			SwordDisplay.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
			SwordDisplay.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
			SwordDisplay.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = true;
		}
		for (int i = 0; i < 3; i++){
			SwordDisplay.transform.GetChild(i).GetComponent<Image>().sprite = swords[i].image; 
		}
		
	}

	void Attack(){
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 5.23f;

			Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.GetChild(1).position);
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;

			float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			transform.GetChild(1).rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		if(Input.GetKeyDown(KeyCode.Mouse1)){
			currentSword++;
			if(currentSword == 3){
				currentSword = 0;
			}
		}
	}
	void Move(){
		
		float Hor = Input.GetAxisRaw("Horizontal");
		float Ver = Input.GetAxisRaw("Vertical");
		
		rb.AddForce(new Vector2(Hor,Ver));}
	void OnCollisionEnter2D(Collision2D Other){
		if(Other.transform.tag=="Enemy"){
			hp-=5;
			if(hp <= 0 ){
				Time.timeScale = 0;
				show(deathMessage);
			}
		}
		if(Other.gameObject.tag == "Sword"&&Other.gameObject.tag!="Enemy"){
			Time.timeScale=0;
			Panel.GetComponent<Image>().enabled = true;
			show(Panel);
			newSword = Other.gameObject.GetComponent<SwordScript>().sword;
			newSwordObject = Other.gameObject;
		}
	}



	public void one(){
		SwordSwap(newSwordObject.GetComponent<SwordScript>(), swords[0]);
		swords[0] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide(Panel);
		rb.velocity = new Vector2(0,0);
	}


	public void two(){
		SwordSwap(newSwordObject.GetComponent<SwordScript>(), swords[1]);
		swords[1] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide(Panel);
		rb.velocity = new Vector2(0,0);
	}

	public void three(){
		SwordSwap(newSwordObject.GetComponent<SwordScript>(), swords[2]);
		swords[2] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide(Panel);
		rb.velocity = new Vector2(0,0);
	}
	public void SwordSwap(SwordScript a, Sword b){
		a.damage = b.damage;
		a.type = b.type;
		a.kills = b.kills;
		a.image = b.image;
		a.knockback = b.knockback;
		a.affixes = b.affixes;
	}
	void hide(GameObject element){
		foreach (Image panel in element.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = false;
		}
		foreach (Image panel in element.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = false;
		}
		foreach (TMP_Text panel in element.transform.GetComponentsInChildren<TMP_Text>())
		{
			panel.enabled = false;
		}
	}
	void show(GameObject element){
		foreach (Image panel in element.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = true;
		}
		foreach (Image panel in element.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = true;
		}
		foreach (TMP_Text panel in element.transform.GetComponentsInChildren<TMP_Text>())
		{
			panel.enabled = true;
		}
	}
	public void Quit(){
		Application.Quit();
	}
	public void Restart(){
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}
}