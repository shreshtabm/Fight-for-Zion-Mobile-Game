using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin_Management : MonoBehaviour {
	public static float coins = 120, oldCoins = 0;
	public Scrollbar coin_S;
	public Text Coin_No;
	public RectTransform coinTransform;

	void Start() {
		//Total 140
		coins = 60;
		oldCoins = 0;
		coinTransform.position = new Vector3(coinTransform.position.x - 80, coinTransform.position.y, coinTransform.position.z);
		Debug.Log ("coinTransform.rect.width" + coinTransform.rect.width);
		oldCoins = coins;
	}

	void Update () {
		if(coins != oldCoins && coins <= 140) {
			float error = coins - oldCoins;
			coinTransform.position = new Vector3(coinTransform.position.x + error, coinTransform.position.y, coinTransform.position.z);
			oldCoins = coins;
		}
		if(coins > 140) {
			coins = 140;
		}

	}
}
