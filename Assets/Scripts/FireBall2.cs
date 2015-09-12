using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBall2 : MonoBehaviour {
	
	
	//Private Elements
	//private Vector3 forwardVect;
	private float timeForFire = 0;
	// private float speedFire = 70;
	private float fireBallExistPeriod = 1; 
	public GameObject test;
	//Public Elements
	
	public List <Transform> Enemies;
	public int test2 = 1;
	public Transform SelectedTarget2;
	public Vector3 error, newTargetPosition, targetDir, newDir;

	// Use this for initialization
	void Start () {
		//forwardVect = Vector3.forward;
		//SelectedTarget = null;
		//Enemies = new List<Transform>();
		// AddEnemiesToList();
	}

	void Update () {
		if(SelectedTarget2 != null) {
			targetDir = SelectedTarget2.transform.position - transform.position;
			float step = 100 * Time.deltaTime;
			newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
			transform.rotation = Quaternion.LookRotation (newDir);
			transform.position = Vector3.MoveTowards (transform.position, SelectedTarget2.transform.position, step);
		}
		timeForFire += Time.deltaTime;		
		if (timeForFire > fireBallExistPeriod || SelectedTarget2 == null) {
				timeForFire = 0;
				GameObject.Destroy(this.gameObject);
		}
		
	}
}
