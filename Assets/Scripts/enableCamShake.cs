using UnityEngine;
using System.Collections;

public class enableCamShake : MonoBehaviour {

	public GameObject cam;

	public int zoom = 20;
	public float smooth = 5;
	public bool ifShakeDone;

	void Start () {
		ifShakeDone = false;
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		//cam.camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,zoom,Time.deltaTime*smooth);
	}

	void OnTriggerEnter(Collider c) {
		if(c.tag == "Enemy") {
			cam.transform.GetComponent<cameraShake> ().enabled = true;
			cam.transform.GetComponent<cameraShake> ().shake = 1;
		}
	}

	void Update() {

	}
}
