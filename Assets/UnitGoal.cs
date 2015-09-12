using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitGoal : MonoBehaviour {
	public  Scrollbar status;
	public  float health = 0f;
	public Rect windowRect; 
	public bool wind;
	public RectTransform healthTransform;
	private float maxHealthX, minHealthX, damage; 

	void Start () {
		//healthTransform.position = new Vector3(healthTransform.position.x - 140, healthTransform.position.y, healthTransform.position.z);
		maxHealthX = healthTransform.position.x;
		//minHealthX = healthTransform.position.x - healthTransform.rect.width + 200;
		minHealthX = healthTransform.position.x - 120;

		//Debug.Log ("minHealthX = " + minHealthX);
		damage = 20;
		wind = true;
	}

	void OnTriggerEnter(Collider c) {
		healthTransform.position = new Vector3(healthTransform.position.x - damage, healthTransform.position.y, healthTransform.position.z);
		
		GameObject.Destroy(c.gameObject);
	}

	private void OnGUI() {
		//if(status.size >= 1 && wind == true) {
		if(healthTransform.position.x <= minHealthX && wind == true) {
			windowRect = GUI.Window (0, new Rect(Screen.width*2/6, Screen.height*2/6, Screen.width/3, Screen.height/3), DoMyWindow, "Game Over");

			Time.timeScale = 0;
		}	
	}

	void DoMyWindow(int windowID) {
		Debug.Log ("windowRect.width = " + windowRect.width);
		if (GUI.Button (new Rect (windowRect.width/3, windowRect.height/3, windowRect.width/3, windowRect.height/3), "OK")) {
			wind = false;
			Time.timeScale = 1;
			//Application.LoadLevel("Menu");
			Application.LoadLevel("MainMenu");
		}
	}


}
