using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower2Script : MonoBehaviour {
	
	
	public GameObject tower2Fire;
	private Vector3 firePoint;
	
	private GameObject FB;
	private float bulletSpawner = 0;
	private float newTimerExistPeriod = 3;
	public List <Transform> Enemies;
	
	// Use this for initialization
	void Start () {
		//Enemies = new List<Transform>();
		firePoint = new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z);
		
		//FB = (GameObject)Instantiate(tower2Fire, firePoint, Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {
		Enemies = new List<Transform>();
		int range = 1200;
		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
		
		foreach(GameObject _Enemy in ItemsInList)
		{
		    var dist = (transform.position - _Enemy.transform.position).sqrMagnitude; 
		    if (dist < range){
				Enemies.Add(_Enemy.transform);
			}  
		}
		bulletSpawner += Time.deltaTime;
		
		if (Enemies[0] != null && bulletSpawner > newTimerExistPeriod)
		{
			FB = (GameObject)Instantiate(tower2Fire, firePoint, Quaternion.identity);
			bulletSpawner = 0;
		}
		
	}
}
