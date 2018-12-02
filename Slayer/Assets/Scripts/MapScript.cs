using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {

	public GameObject[] Rooms;

	void Start(){
		int[] usedNums = new int[Rooms.Length];
		Instantiate(Rooms[0],transform.position,Quaternion.identity);
		for (int i = 1; i < Rooms.Length; i++){
			Wrong:
			int rand = Random.Range(1,Rooms.Length);
			foreach (int l in usedNums){
				if(l==rand){
					goto Wrong;
				}
			}
			Instantiate(Rooms[rand],new Vector3(transform.position.x,transform.position.y+i*18,transform.position.z),Quaternion.identity);
			usedNums[i] = rand;
		}
	}
}
