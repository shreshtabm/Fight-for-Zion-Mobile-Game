using UnityEngine;
using System.Collections;

public class SampleAngent : MonoBehaviour {

	public Transform target, target1, target2;
	NavMeshAgent agent;
	int randNum;


	void Start () {
		agent = GetComponent<NavMeshAgent>();

		randNum = Random.Range (1, 10);

		if(randNum >= 5) {
			//target = GameObject.Find("target1").transform;
			target = GameObject.Find("Target").transform;

		}
		else {
			//target = GameObject.Find("target2").transform;
			target = GameObject.Find("Target").transform;

		}
		//targetPosition = target.transform.position;

	}

	void OnTriggerEnter(Collider c) {
		if(c.name == "target1") {
			Debug.Log("target1!!!!!!!!!!!!!!!!!!!!");
			target = GameObject.Find("Target").transform;
			//targetPosition = target.transform.position;
			//seeker.StartPath (transform.position,targetPosition, OnPathComplete);
		}
		if(c.name == "target2") {
			Debug.Log("target2!!!!!!!!!!!!!!!!!!!!");
			target = GameObject.Find("Target").transform;
			//targetPosition = target.transform.position;
			//seeker.StartPath (transform.position,targetPosition, OnPathComplete);
		}
	}

	void Update () {
		agent.SetDestination (target.position);
	}
}
