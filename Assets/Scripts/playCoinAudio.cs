using UnityEngine;
using System.Collections;

public class playCoinAudio : MonoBehaviour {

	float stopTime = 3f;

	void Start () {
		this.gameObject.GetComponent<AudioSource> ().Play ();

	}
	
	void Update () {

		if(stopTime > 0) {
			stopTime -= Time.deltaTime;
		}
//		else if(stopTime <= 0) {
//			this.GetComponent<playCoinAudio>().enabled = false;
//		}
//	
	}
}
