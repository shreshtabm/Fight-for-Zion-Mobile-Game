using UnityEngine;
using System.Collections;

public class turnForL3 : MonoBehaviour {
	public GameObject target;
	Vector3 targetDir, newDir;
	//public Collider[] enemyWithinRange;
	//List<GameObject> enemyList = new List<GameObject>();


	void Start () {

	}
	

	void Update () {
		//target = GameObject.FindWithTag ("Enemy");
		if(this.transform.GetComponentInParent<ZionScriptForL3> ().enemyList.Count > 0) {
			target = this.transform.GetComponentInParent<ZionScriptForL3> ().enemyList[0];
		}
		if (target != null) {
			targetDir = target.transform.position - transform.position;
			targetDir.y = transform.forward.y;
			newDir = Vector3.RotateTowards (transform.forward, targetDir, 10*Time.deltaTime, 0.0F);
			transform.rotation = Quaternion.LookRotation (newDir);
		}
	}
}
