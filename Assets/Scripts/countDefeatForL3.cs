using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;


public class countDefeatForL3 : MonoBehaviour {
	
	static public int defeatedEnemy;
	public Button victoryMsg;
	bool ifVictory;

	void Start () {
		defeatedEnemy = 0;
		ifVictory = false;
	}
	
	private void OnGUI() {
		if(defeatedEnemy >= 100 && ifVictory == false) {
			Time.timeScale = 0;
			victoryMsg.gameObject.SetActive (true);
			ifVictory = true;	
		}	
	}

	public void victoryAct() {
		Time.timeScale = 1;
		//Application.LoadLevel("Menu");
		Application.LoadLevel("MainMenu");
	}

	
	void Update () {
	}

}



