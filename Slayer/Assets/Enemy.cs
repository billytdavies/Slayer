using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	GameObject Player;
	Rigidbody2D rb;
	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine(Launch());
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	IEnumerator Launch(){
		yield return new WaitForSeconds(Random.Range(0,0.5f));
		Vector3 dir = (Player.transform.position-gameObject.transform.position).normalized;
		rb.AddForce(dir*25);
		StartCoroutine(Launch());
	}
}
