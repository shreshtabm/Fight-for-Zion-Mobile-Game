using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

  float walkspeed =10;
  float gravity = 50;
  float rotationspeed  = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
	
		transform.position -= transform.forward*walkspeed*Time.deltaTime;
		
	}
}
