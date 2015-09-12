using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBallTank : MonoBehaviour {
	
	
	//Private Elements
	//private Vector3 forwardVect;
	private float timeForFire = 0;
	// private float speedFire = 70;
	private float fireBallExistPeriod = 2; 
	public GameObject test;
	//Public Elements
	
	public List <Transform> Enemies;
	public int test2 = 1;
	public Transform SelectedTarget2;
	public Vector3 error, newTargetPosition, targetDir, newDir;
	public GameObject fireLocation;

	// Use this for initialization
	void Start () {
		fireLocation = GameObject.Find ("2cm_kwk38");
		transform.position = fireLocation.transform.position;
	}

	void Update () {
		if(SelectedTarget2 != null) {
			transform.position = Vector3.MoveTowards (transform.position, SelectedTarget2.position, 100 * Time.deltaTime);
		}
		timeForFire += Time.deltaTime;		
		if (timeForFire > fireBallExistPeriod || SelectedTarget2 == null) {
				timeForFire = 0;
				GameObject.Destroy(this.gameObject);
		}
	}
}
