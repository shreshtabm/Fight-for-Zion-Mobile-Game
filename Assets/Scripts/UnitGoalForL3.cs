using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitGoalForL3 : MonoBehaviour {
	
	public GameObject HPBar, explosion, spawnExplosion;
	public Button gameOverMsg;
	bool ifGameOver;
	Vector3 firePos;

	void Start () {
		ifGameOver = false;
		firePos = new Vector3 (this.transform.position.x+10, this.transform.position.y+30, this.transform.position.z);
	}
	
	void OnTriggerEnter(Collider c) {
		Debug.Log ("c.name = " + c.name);

		if(c.tag == "Enemy" && HPBar != null) {
			HPBar.GetComponent<UIBarScript>().NewValue -= 0.01f;
			spawnExplosion = (GameObject)Instantiate(explosion, firePos, explosion.transform.rotation);

			GameObject.Destroy(c.gameObject);
			if(c.name == "Boss(Clone)") {
				Time.timeScale = 0;
				gameOverMsg.gameObject.SetActive (true);
				ifGameOver = true;
			}
		}

	}
	
	private void OnGUI() {
		if(HPBar.GetComponent<UIBarScript>().NewValue <= 0 && ifGameOver == false) {
			Time.timeScale = 0;
			gameOverMsg.gameObject.SetActive (true);
			ifGameOver = true;
		}	

	}

	public void gameOverAct() {
		Time.timeScale = 1;
		//Application.LoadLevel("Menu");
		Application.LoadLevel("MainMenu");
	}


	

}

