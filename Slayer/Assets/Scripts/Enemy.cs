using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	GameObject Player;
	public GameObject Particles;
	Rigidbody2D rb;
	public int health;
	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine(Launch());
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	IEnumerator Launch(){
		yield return new WaitForSeconds(Random.Range(0,2));
		Vector3 dir = (Player.transform.position-gameObject.transform.position).normalized;
		rb.AddForce(dir*25);
		StartCoroutine(Launch());
	}
	void OnTriggerEnter2D(Collider2D Other){
		if(Other.transform.tag == "Sword"){
			rb.AddForce((gameObject.transform.position-Player.transform.position).normalized*25);
			health -= Player.GetComponent<Player>().swords[Player.GetComponent<Player>().currentSword].damage;
		}
	}
	void Update(){
		if(health<=0){
			var ptks = Instantiate(Particles,new Vector3(transform.position.x,transform.position.y,transform.position.z+8),Quaternion.identity);
			Destroy(ptks,4);
			Destroy(gameObject);
		}
	}
}
