using UnityEngine;
using System.Collections;

public class Unitspawn_Golem : MonoBehaviour {
	
	public Transform target;
	public GameObject Robot_Kyle;
	
	public float spawnTime = .1f;
	float spawnTimeLeft = .1f;
	
	// Update is called once per frame
	void Update () {
		if(spawnTimeLeft <= 0) {
			GameObject go = (GameObject)Instantiate(Robot_Kyle, transform.position, transform.rotation);
			go.GetComponent<AstarAI>().target = target;
			spawnTimeLeft = spawnTime;
		}
		else {
			spawnTimeLeft -= Time.deltaTime;
		}
	}
}
