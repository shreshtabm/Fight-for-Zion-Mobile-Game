using UnityEngine;
using System.Collections;
using System.Threading;

public class countDefeat : MonoBehaviour {

	static public int defeatedEnemy;
	public bool wind;
	public Rect windowRect; 

	void Start () {
		defeatedEnemy = 0;
		wind = true;
	}

	private void OnGUI() {
		if(defeatedEnemy >= 15 && wind == true) {
			windowRect = GUI.Window (0, new Rect(Screen.width*2/6, Screen.height*2/6, Screen.width/3, Screen.height/3), DoMyWindow, "You Win!!");
			Time.timeScale = 0;
		}	
	}

	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (windowRect.width/3, windowRect.height/3, windowRect.width/3, windowRect.height/3), "OK")) {
			wind = false;
			Time.timeScale = 1;
			if(Application.loadedLevelName == "scene") {
				Application.LoadLevel("Level2");
			}
			else if(Application.loadedLevelName == "Level2") {
				//Application.LoadLevel("Menu");
				Application.LoadLevel("MainMenu");
			}
		}
	}

	void Update () {
		Debug.Log ("defeatedEnemy = " + defeatedEnemy);
	}
}
