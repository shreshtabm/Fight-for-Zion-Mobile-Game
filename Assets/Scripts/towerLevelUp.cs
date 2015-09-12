using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class towerLevelUp : MonoBehaviour {

	int Level;
	GameObject canvas0, circlePlate0, levelUpButton;
	bool playLevelUpAnim;
	public GameObject coinBar;
	public AudioSource levelUpAudio;

	void Start () {
		Level = 0;
		canvas0 = this.transform.GetChild (1).gameObject;
		circlePlate0 = canvas0.transform.GetChild (0).gameObject;
		levelUpButton = canvas0.transform.GetChild (1).gameObject;
		coinBar = GameObject.FindGameObjectWithTag ("CoinBar");
		levelUpButton.SetActive (false);
		playLevelUpAnim = false;

	}

	public void LevelUp() {
		//if(Coin_Management.coins >= 20) {
		if(coinBar.GetComponent<UIBarScript>().NewValue >= 0.5) {
			coinBar.GetComponent<UIBarScript>().NewValue -= 0.5f;
			levelUpAudio.Play();
			if(this.GetComponent<ZionScriptForL3>() != null) {

				if(this.name == "tower1ForL3(Clone)") {
					this.GetComponent<ZionScriptForL3>().newTimerExistPeriod -= 1f;
					this.GetComponent<ZionScriptForL3>().biggerT1 = true;
				}
				else if(this.name == "tower4ForL3(Clone)") {
					this.GetComponent<ZionScriptForL3>().newTimerExistPeriod -= 1f;
					this.GetComponent<ZionScriptForL3>().biggerT4 = true;
				}
				else if(this.name == "tower5ForL3(Clone)") {
					this.transform.GetChild(2).GetComponent<turnForL3T5>().burnTime -= 1f;
					this.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
					this.transform.GetChild(2).transform.GetChild(0).gameObject.transform.localEulerAngles = new Vector3(0, 250, 0);
					this.transform.GetChild(2).transform.GetChild(1).gameObject.transform.localEulerAngles = new Vector3(0, 290, 0);
				}
				else if(this.name == "tower6ForL3(Clone)") {
					this.GetComponent<ZionScriptForL3>().newTimerExistPeriod -= 1f;
					this.GetComponent<ZionScriptForL3>().biggerT6 = true;
				}
			}
			Debug.Log("SPAWN!!!");
			Level++;


			circlePlate0.GetComponent<Image> ().fillAmount = 0;
			switch(Level) {
				case 0: {
					circlePlate0.GetComponent<Image>().color = Color.white;
					break;	
				}
				case 1: {
					circlePlate0.GetComponent<Image>().color = Color.yellow;
					break;
				}
				case 2: {
					circlePlate0.GetComponent<Image>().color = Color.green;
					break;
				}
				case 3: {
					circlePlate0.GetComponent<Image>().color = Color.blue;
					break;
				}
			}
			playLevelUpAnim = true;
		}
	}

	void Update () {

		if(playLevelUpAnim == false) {
			circlePlate0.GetComponent<Image> ().fillAmount = 1;
		}

		if(playLevelUpAnim == true) {
			circlePlate0.GetComponent<Image> ().fillAmount += Time.deltaTime*0.5f;
		}
		if(circlePlate0.GetComponent<Image> ().fillAmount >= 1) {
			//circlePlate0.GetComponent<Image> ().fillAmount = 1;
			playLevelUpAnim = false;
		}

		if(coinBar.GetComponent<UIBarScript>().NewValue >= 0.5 && Level < 1) {
		//if(coinBar.GetComponent<UIBarScript>().NewValue >= 0.5) {
			if(this.GetComponent<recycleOnTower>().dockPlane != null && this.GetComponent<recycleOnTower>().moneyButtonOn == false) {
				levelUpButton.SetActive (true);
			}
			else if (this.GetComponent<recycleOnTower>().moneyButtonOn == true) {
				levelUpButton.SetActive (false);
			}
		}
		else {
			levelUpButton.SetActive (false);
		}
	}
}
