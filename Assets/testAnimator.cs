using UnityEngine;
using System.Collections;

public class testAnimator : MonoBehaviour {
	
	public Animator anim;
	public float Speed;
	public int count;
	public Collider[] objWithinRange;
	private Vector3 firePoint;
	public Collider targetGlobal;
	public float distance;
	public bool fight;


	void Start () {
		count = 0;
		anim = GetComponent<Animator>();
		anim.SetFloat ("Speed", 2.0f);
		distance = 0;
		fight = false;
	}

	public void searchTarget() {
		objWithinRange = Physics.OverlapSphere (this.transform.position, 20);
		if (objWithinRange == null)
			return;
		for(int i = 0; i < objWithinRange.Length; i++) {
			if(objWithinRange[i].tag == "Tank") {
				targetGlobal = objWithinRange[i];
				distance = Vector3.Distance(this.transform.position, targetGlobal.transform.position);
				if(distance < 20) {
					anim.SetBool ("fight", true);
					GetComponent<AstarAI> ().speed = 3;
				}
				else {
					anim.SetBool ("fight", false);
					GetComponent<AstarAI> ().speed = 20;

				}
			}
		}
	}


	void Update () {
		searchTarget ();
	}
}
