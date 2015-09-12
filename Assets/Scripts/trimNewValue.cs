using UnityEngine;
using System.Collections;

public class trimNewValue : MonoBehaviour {

	public UIBarScript coinUIBarScript;

	void Start () {
		coinUIBarScript = this.gameObject.GetComponent<UIBarScript> ();
	}
	
	void Update () {
		if(coinUIBarScript.NewValue > 1) {
			coinUIBarScript.NewValue = 1;
		}
		else if(coinUIBarScript.NewValue < 0) {
			coinUIBarScript.NewValue = 0;
		}
	}
}
