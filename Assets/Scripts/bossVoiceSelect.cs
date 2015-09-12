using UnityEngine;
using System.Collections;

public class bossVoiceSelect : MonoBehaviour {

	public AudioSource voice0, voice1, voice2, voice3, voice4, voice5, voice6;
	int randNum, preRandNum;
	float speakTime = 3f;

	void Start () {
		speakTime = 3f;
		preRandNum = 10;
	}

	void resetVoice() {
		voice0.enabled = false;
		voice1.enabled = false;
		voice2.enabled = false;
		voice3.enabled = false;
		voice4.enabled = false;
		voice5.enabled = false;
		voice6.enabled = false;
	}

	void Update () {
		speakTime -= Time.deltaTime;

		if(speakTime <= 0) {
			resetVoice();
			randNum = Random.Range(0, 7);

			if(randNum == 0 && preRandNum != 0) {
				voice0.enabled = true;
			}
			else if(randNum == 1 && preRandNum != 1) {
				voice1.enabled = true;
			}
			else if(randNum == 2 && preRandNum != 2) {
				voice2.enabled = true;
			}
			else if(randNum == 3 && preRandNum != 3) {
				voice3.enabled = true;
			}
			else if(randNum == 4 && preRandNum != 4) {
				voice4.enabled = true;
			}
			else if(randNum == 5 && preRandNum != 5) {
				voice5.enabled = true;
			}
			else if(randNum == 6 && preRandNum != 6) {
				voice6.enabled = true;
			}


			preRandNum = randNum;

			speakTime = 7f + Random.Range(0, 3);
		}
	
	}
}
