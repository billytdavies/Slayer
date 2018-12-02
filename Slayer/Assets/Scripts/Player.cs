using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour {
	public Sprite defaultimg;
	Rigidbody2D rb; 
	Animator animator;
	public GameObject SwordDisplay;
	public Sword[] swords;
	public Sword newSword;
	GameObject newSwordObject;
	public int currentSword;
	public GameObject Panel;
	// Use this for initialization
	void Start () {
		animator = gameObject.transform.GetChild(1).GetComponent<Animator>();
		currentSword = 0;
		rb = gameObject.GetComponent<Rigidbody2D>();
		swords = new Sword[3] {new Sword(10,"Jeff",3,defaultimg),new Sword(10,"Jeff",3,defaultimg),new Sword(10,"Jeff",3,defaultimg)};
		Panel.GetComponent<Image>().enabled = false;
		hide();

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
		/* 
		int hor = 0;
		int ver = 0;
		if(Input.GetKey(KeyCode.LeftArrow)){
			hor-=1;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			hor+=1;
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			ver+=1;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			ver-=1;
		}
		..int angle = 1;
		if(hor > 0){
			angle *=-1;
		}
		angle *= Mathf.Abs(ver-2)*45;
		if(hor == 0){
			if(ver == 0){
				angle = 0;
			} if(ver == -1){
				angle = 180;
			} if (ver == 1){
				angle = 0;
			}
		}
		*/
		
		//transform.GetChild(1).Rotate= Camera.main.ScreenToWorldPoint(Input.mousePosition);


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
		if(Other.gameObject.tag == "Sword"&&Other.gameObject.tag!="Enemy"){
			Time.timeScale=0;
			Panel.GetComponent<Image>().enabled = true;
			show();
			
			newSword = Other.gameObject.GetComponent<SwordScript>().sword;
	

			newSwordObject = Other.gameObject;
		}
	}
	
	public void one(){
		SwordSwap(newSwordObject.GetComponent<SwordScript>(), swords[0]);
		swords[0] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide();
		rb.velocity = new Vector2(0,0);
	}
	public void two(){
		SwordSwap(newSwordObject.GetComponent<SwordScript>(), swords[1]);
		swords[1] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide();
		rb.velocity = new Vector2(0,0);
	}
	public void three(){
		SwordSwap(newSwordObject.GetComponent<SwordScript>(), swords[2]);
		swords[2] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide();
		rb.velocity = new Vector2(0,0);
	}
	public void SwordSwap(SwordScript a, Sword b){
		a.damage = b.damage;
		a.type = b.type;
		a.kills = b.kills;
		a.image = b.image;
	}
	void hide(){
		foreach (Image panel in Panel.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = false;
		}
		foreach (Image panel in Panel.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = false;
		}
		foreach (TMP_Text panel in Panel.transform.GetComponentsInChildren<TMP_Text>())
		{
			panel.enabled = false;
		}
	}
	void show(){
		foreach (Image panel in Panel.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = true;
		}
		foreach (Image panel in Panel.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = true;
		}
		foreach (TMP_Text panel in Panel.transform.GetComponentsInChildren<TMP_Text>())
		{
			panel.enabled = true;
		}
	}
}