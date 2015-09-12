using UnityEngine;
using System.Collections;

public class recycleOnTower : MonoBehaviour {

	GameObject canvas0, circlePlate0, moneyButton, coinBar, towerManager;
	public GameObject dockPlane;
	public bool moneyButtonOn;

	void Start () {
		canvas0 = this.transform.GetChild (1).gameObject;
		moneyButton = canvas0.transform.GetChild (2).gameObject;
		coinBar = GameObject.FindGameObjectWithTag ("CoinBar");
		towerManager = GameObject.FindGameObjectWithTag ("towerManager");

		moneyButton.SetActive (false);
		moneyButtonOn = false;
	}

	void OnTriggerEnter(Collider c){
		if(c.name == "planeForTowerTest") {
			//Debug.Log("GOT PLANE!!!!!!!!!");
			dockPlane = c.gameObject;
		}
	}

	public void setMoneyAct() {
		moneyButton.SetActive (true);
		moneyButtonOn = true;
	}

	public void setMoneyGone() {
		moneyButton.SetActive (false);
		moneyButtonOn = false;
	}

	public void toMoney() {

		if(dockPlane != null) {
			dockPlane.GetComponent<checkIfSpawnTower>().ifTowerAlready = false;
		}

		towerManager.GetComponent<recycleTower> ().disableAllMoney ();
		if(this.name == "tower1ForL3(Clone)") {
			coinBar.GetComponent<UIBarScript>().NewValue += 0.05f;
		}
		else if(this.name == "tower4ForL3(Clone)") {
			coinBar.GetComponent<UIBarScript>().NewValue += 0.1f;
		}
		else if(this.name == "tower5ForL3(Clone)") {
			coinBar.GetComponent<UIBarScript>().NewValue += 0.15f;
		}
		else if(this.name == "tower6ForL3(Clone)") {
			coinBar.GetComponent<UIBarScript>().NewValue += 0.2f;
		}

		GameObject.Destroy (this.gameObject);
	}

	void Update () {
	
	}
}
