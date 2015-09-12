using UnityEngine;
using System.Collections;

public class Tower_spawn_1 : MonoBehaviour {
	public GameObject objects_to_spawn;
	public bool ifSpawn = false, ifClick = false;
	public Vector3 pos, newPosition1, nullPos;
	public bool tower_spawned=false;
	//
	public string wind = "no";
	public Rect windowRect; 
	void OnGUI() {
		if (wind == "yes") {
			windowRect = GUI.Window (0, new Rect(200, 100, 200, 80), DoMyWindow, "Not Enough Coins");
		}
		if (wind == "no")
			;
		
	}
	
	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (60, 30, 80, 20), "OK")) {
			wind = "no";
		}
		
	}
	//




	void Start () {
		nullPos = new Vector3 (0, 0, 0);
		objects_to_spawn = GameObject.Find ("tower1");		
	}

	public Vector3 getPosition() {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitTarget;
			Ray rayTarget = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayTarget, out hitTarget);
			newPosition1 = hitTarget.point;
			newPosition1.y = 7;
			pos = new Vector3 (newPosition1.x, newPosition1.y, newPosition1.z);
			Debug.Log("pos!!!!!!!!!!!!!!!!!!!!! = " + pos);
			Debug.Log("Dimag kharabbbbbbbbb");
			return pos;
		}
		else {
			pos = new Vector3(0, 0, 0);
			return pos;
		}
	}

	public void spawn_object(Vector3 pos) {

		if (Coin_Management.coins < 200) {
			wind = "yes";
			//Coin_Management.coins -= 20;
		} 
		else {

				//Vector3 pos = new Vector3 (30, 3, 0);
				GameObject obj = (GameObject)Instantiate (objects_to_spawn, pos, transform.rotation);
				Coin_Management.coins -= 200;
				tower_spawned=true;


		}
	}



	void Update () {
		Debug.Log("Tower spwned now");
		if(getPosition() != nullPos && ifClick == false) {
			if (!tower_spawned) {
				spawn_object(getPosition());
				Debug.Log("Tower spwned now");
			}else{
				Debug.Log("Tower aleady spwned");
			}

			//spawn_object(newPosition1);

		}
	}
}
