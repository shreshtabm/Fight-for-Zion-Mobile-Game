using UnityEngine;
using System.Collections;

public class buttonManager : MonoBehaviour {

	public void selectScene(int stage) {
		Debug.Log ("stage = " + stage);
		if(stage == 0) {
			Application.LoadLevel ("scene");
		}
		if(stage == 1) {
			Application.LoadLevel ("Level2");
		}
		if(stage == 2) {
			Application.LoadLevel ("Level3");
		}
	}

}
