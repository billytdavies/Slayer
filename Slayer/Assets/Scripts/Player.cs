using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
	public int hp;
	public int Score;
	public GameObject deathMessage;
	public GameObject hpobject;
	Rigidbody2D rb; 
	public GameObject SwordDisplay;
	public Sword[] swords;
	public Sword newSword;
	GameObject newSwordObject;
	public int currentSword;
	public GameObject Panel;
	//Body,HeadArmWalking
	public Sprite[] bodyparts;
	//Body,HeadArmWalking
	public Sprite[] bodypartsL;
	int walkcounter;

	public Sprite[] swordpics;
	public Sprite[] swordpicsL;



	// Use this for initialization
	void Start () {
		hide(deathMessage);
		hp=100;
		currentSword = 0;
		rb = gameObject.GetComponent<Rigidbody2D>();
		swords = new Sword[3] {new Sword(8,"Sword",0,3,new string[3],swordpics[0]),new Sword(4,"Axe",0,8,new string[3],swordpics[7]),new Sword(15,"Pike",0,0,new string[3],swordpics[6])};
		Panel.GetComponent<Image>().enabled = false;
		hide(Panel);

		SwordDisplay.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
		SwordDisplay.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
		SwordDisplay.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Attack();
		Move();
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
			
			if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x<transform.position.x){
				transform.GetChild(2).GetComponent<SpriteRenderer>().sprite=bodypartsL[1];
				transform.GetChild(1).localPosition = new Vector3(-0.28f,0.15f,0);
			} else {
				transform.GetChild(2).GetComponent<SpriteRenderer>().sprite=bodyparts[1];
				transform.GetChild(1).localPosition = new Vector3(0.28f,0.15f,0);
			}
				transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = swords[currentSword].image;

			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 5.23f;

			Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.GetChild(1).position);
		
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;

			float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			transform.GetChild(1).transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		if(Input.GetKeyDown(KeyCode.Mouse1)){
			currentSword++;
			if(currentSword == 3){
				currentSword = 0;
			}
		}
	}


	public void UpgradeSword(){
		int rand = Random.Range(0,2);
		if(rand==0){
			swords[currentSword].damage++;
		} else if(rand ==1){
			swords[currentSword].knockback++;
		}
		if(swords[currentSword].knockback+swords[currentSword].damage>25){
			Sprite spr = swords[currentSword].image;
			for (int i = 0; i < swordpics.Length; i++)
			{
				if(spr == swordpics[i]){
					swords[currentSword].image = swordpicsL[i];
				}
			}
			swords[currentSword].affixes[0] = "Legendary";
		}
	}






	void Move(){

		if(rb.velocity.magnitude < 1){
			rb.velocity = new Vector3(0,0,0);
		}



		int facing;
		if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x<transform.position.x){
				facing = -1;
			}else{
				facing = 1;
		}

		if(rb.velocity.magnitude>0){
			walkcounter++;
		} else {
			walkcounter=0;
			if(facing == -1){
				gameObject.GetComponent<SpriteRenderer>().sprite = bodypartsL[0];
			}else{
				gameObject.GetComponent<SpriteRenderer>().sprite = bodyparts[0];
			}
		}
		 
		
		
		if(walkcounter==5){
			if(facing== 1){
				gameObject.GetComponent<SpriteRenderer>().sprite = bodyparts[3];

			} else {
				gameObject.GetComponent<SpriteRenderer>().sprite = bodypartsL[2];
			}
		}	
		if(walkcounter==10){
			if (facing == 1) {
				gameObject.GetComponent<SpriteRenderer>().sprite = bodyparts[0];

			} else {
				gameObject.GetComponent<SpriteRenderer>().sprite = bodypartsL[0];
			}
			walkcounter = 0;
		}
	

		float Hor = Input.GetAxisRaw("Horizontal");
		float Ver = Input.GetAxisRaw("Vertical");
		
		rb.AddForce(new Vector2(Hor,Ver));
	}
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