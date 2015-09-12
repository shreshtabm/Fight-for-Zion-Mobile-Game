using UnityEngine;
using System.Collections;

public class killExplosion : MonoBehaviour {

	float timeToKill = 2f;

	void Start () {
		timeToKill = 2f;
	}
	
	void Update () {

		timeToKill -= Time.deltaTime;
		if(timeToKill <= 0) {
			GameObject.Destroy(this.gameObject);
		}
	
	}
}
