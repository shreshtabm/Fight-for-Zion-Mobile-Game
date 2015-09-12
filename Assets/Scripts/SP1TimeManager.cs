using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SP1TimeManager : MonoBehaviour {

	public GameObject dotLineCircle, SP1Button;
	float timeForChangeColor;
	public bool resetTime;

	void Start () {
		dotLineCircle = this.transform.GetChild (0).gameObject;
		SP1Button = this.transform.GetChild (1).gameObject;
		timeForChangeColor = 0;
		this.transform.GetChild(1).GetComponent<Button>().interactable = false;
		resetTime = false;
	}

	
	void Update () {
		if(dotLineCircle.GetComponent<Image> ().fillAmount < 1) {
			this.transform.GetChild(1).GetComponent<Button>().interactable = false;
			if(this.name == "SuperPower1") {
				dotLineCircle.GetComponent<Image> ().fillAmount += Time.deltaTime*0.01f;
			}
			else if(this.name == "SuperPower2") {
				dotLineCircle.GetComponent<Image> ().fillAmount += Time.deltaTime*0.02f;
			}
		}
		if(dotLineCircle.GetComponent<Image> ().fillAmount >= 1) {
			dotLineCircle.GetComponent<Image> ().fillAmount = 1;
			timeForChangeColor += Time.deltaTime;
			if(timeForChangeColor > 0 && timeForChangeColor < 0.5) {
				SP1Button.GetComponent<Image>().color = Color.green;
			}
			else if(timeForChangeColor >= 0.5 && timeForChangeColor < 1) {
				SP1Button.GetComponent<Image>().color = Color.white;
			}
			else {
				timeForChangeColor = 0;
			}
			this.transform.GetChild(1).GetComponent<Button>().interactable = true;
		}
		if(resetTime == true) {
			dotLineCircle.GetComponent<Image> ().fillAmount = 0;
			SP1Button.GetComponent<Image>().color = Color.white;
			resetTime = false;
		}

	}
}
