using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour {
	Rigidbody2D rb; 
	Animator animator;
	public Sword[] swords;
	Sword newSword;
	GameObject newSwordObject;
	int currentSword;
	public GameObject Panel;
	// Use this for initialization
	void Start () {
		animator = gameObject.transform.GetChild(1).GetComponent<Animator>();
		currentSword = 0;
		rb = gameObject.GetComponent<Rigidbody2D>();
		swords = new Sword[3] {new Sword(10,"Jeff",3),new Sword(10,"Jeff",3),new Sword(10,"Jeff",3)};
		print(swords[0].type);
		print(swords[1].type);
		print(swords[2].type);
		Panel.GetComponent<Image>().enabled = false;
		hide();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Attack();
	}
	void Attack(){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			animator.SetBool("Click",true);
			
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			animator.SetBool("Click",false);
		}
		if(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z)).x<transform.position.x){
			gameObject.transform.localScale = new Vector3(-1,1,1);
		} else {gameObject.transform.localScale = new Vector3(1,1,1);}
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
		newSwordObject.GetComponent<SwordScript>().damage = swords[0].damage;
		newSwordObject.GetComponent<SwordScript>().type = swords[0].type;
		newSwordObject.GetComponent<SwordScript>().kills = swords[0].kills;
		swords[0] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide();
		rb.velocity = new Vector2(0,0);
	}
	public void two(){
		newSwordObject.GetComponent<SwordScript>().sword = swords[1];
		swords[1] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide();
		rb.velocity = new Vector2(0,0);
	}
	public void three(){
		newSwordObject.GetComponent<SwordScript>().sword = swords[2];
		swords[2] = newSword;
		Time.timeScale = 1;
		Panel.GetComponent<Image>().enabled = false;
		hide();
		rb.velocity = new Vector2(0,0);
	}

	void hide(){
		foreach (Image panel in Panel.transform.GetComponentsInChildren<Image>())
		{
			panel.enabled = false;
		}
		foreach (RawImage panel in Panel.transform.GetComponentsInChildren<RawImage>())
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
		foreach (RawImage panel in Panel.transform.GetComponentsInChildren<RawImage>())
		{
			panel.enabled = true;
		}
		foreach (TMP_Text panel in Panel.transform.GetComponentsInChildren<TMP_Text>())
		{
			panel.enabled = true;
		}
	}
}
