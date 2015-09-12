using UnityEngine;
using System.Collections;

public class swipeFun : MonoBehaviour {

	public float speed = 10f;

	void Start() {
		speed = 10f;
	}

	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
			transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
			//transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, 0, 0);
		}
	}

}

