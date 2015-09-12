using UnityEngine;
using System.Collections;

public class SP2_Crazy : MonoBehaviour {

	public Collider[] puppetWithinSearch;
	public bool enableFindPuppet = false;
	float timeToDestroy = 3f;

	void Start () {
		//enableFindPuppet = false;
		enableFindPuppet = true;
		timeToDestroy = 3f;
	}

	void searchPuppet() {
		puppetWithinSearch = Physics.OverlapSphere (this.transform.position, 50);
		if (puppetWithinSearch == null) {
			return;
		}
		for(int i = 0; i < puppetWithinSearch.Length; i++) {
			if(puppetWithinSearch[i].gameObject.tag == "Enemy" && puppetWithinSearch[i].gameObject.name != "Boss(Clone)") {
				Debug.Log("Enable Crazy!!!!!!!!!!!!!!!!!");
				puppetWithinSearch[i].gameObject.GetComponent<crazy>().enabled = true;
			}
		}
	}

	void Update () {
		if (enableFindPuppet == true) {
			//if(timeToDestroy > 0) {
			searchPuppet ();
			enableFindPuppet = false;
			//}
		}
		else if(timeToDestroy <= 0) {
			GameObject.Destroy(this.gameObject);
		}
		timeToDestroy -= Time.deltaTime;
		//}
	}
}
