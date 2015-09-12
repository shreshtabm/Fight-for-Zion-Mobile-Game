using UnityEngine;
using System.Collections;

public class GUI_Temp : MonoBehaviour {
	public GameObject objects_to_spawn, objects_to_spawn2;
	public bool ifSpawn, ifClick;
	public Vector3 pos, newPosition1, nullPos;
	public Rect windowRect; 
	public bool wind;
	
	public string buttonToken = "Resumed";
	public const string pausedToken = "Paused";
	public const string ResumedToken = "Resumed";
	
	public bool tower1, tower2;
	
	void Start () {
		nullPos = new Vector3 (0, 0, 0);
		tower1 = false;
		tower2 = false;
		ifClick = false;
		wind = false;
		ifSpawn = false;
	}
	
	private void OnGUI()
	{
		//owRect = GUI.ow (0, new Rect(200, 100, 200, 80), DoMyow, "Not Enough Coins");
		
		if(GUI.Button(new Rect((Screen.width+500)/2+250 , Screen.height / 2-150,150, 50),"TOWER 1")) {
			ifClick = true;
			//objects_to_spawn = GameObject.Find ("tower1");
			if(Coin_Management.coins >= 20) {
				tower1 = true;
				ifSpawn = true;
			}
			else {
				wind = true;
				ifSpawn = false;
			}
		}
		
		if(GUI.Button(new Rect((Screen.width+500)/2+250 , Screen.height / 2-80, 150, 50),"TOWER 2")) {
			ifClick = true;
			//objects_to_spawn = GameObject.Find ("tower2");
			
			if(Coin_Management.coins >= 20) {
				ifSpawn = true;
				tower2 = true;
			}
			else {
				wind = true;
				ifSpawn = false;
			}
		}
		
		if(GUI.Button(new Rect((Screen.width+500)/2+250 , Screen.height/2 -10, 150, 50),"PAUSE")) {
			Time.timeScale = 0;	
		}
		
		if(GUI.Button(new Rect((Screen.width+500)/2+250 , Screen.height/2 +60, 150, 50),"RESUME")) {
			Time.timeScale = 1;	
		}
		
		if(GUI.Button(new Rect((Screen.width+500)/2+250 , Screen.height/2 +130,150, 50),"QUIT")) {
			//Application.LoadLevel("Menu");
			Application.LoadLevel("MainMenu");

		}
		
		if (wind == true) {
			windowRect = GUI.Window (0, new Rect(Screen.width*2/6, Screen.height*2/6, Screen.width/3, Screen.height/3), DoMyWindow, "Not Enough Coins");
		}
	}
	
	void DoMyWindow(int windowID) {
		Debug.Log ("Screen.width*2/6 = " + Screen.width*2/6);
		if (GUI.Button (new Rect (windowRect.width/3, windowRect.height/3, windowRect.width/3, windowRect.height/3), "OK")) {
			wind = false;
		}
	}
	
	public void towerDelete() {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitTarget;
			Ray rayTarget = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayTarget, out hitTarget);
			newPosition1 = hitTarget.point;
			newPosition1.y = 7;
			pos = new Vector3 (newPosition1.x, newPosition1.y, newPosition1.z);
			
			if (hitTarget.collider.gameObject.name == "tower1(Clone)") {
				Collider[] colliders;
				if((colliders = Physics.OverlapSphere(pos, 20f)).Length > 1)
				{
					foreach(var collider in colliders)
					{
						if(collider.gameObject.name=="planeForTower"){
							if(collider.gameObject.GetComponent<checkIfSpawnTower>().ifTowerAlready == true) {
								collider.gameObject.GetComponent<checkIfSpawnTower>().ifTowerAlready=false;
							}
						}
						
					}
				}
				GameObject obj = (GameObject)hitTarget.collider.gameObject;
				GameObject.Destroy (obj);
				Coin_Management.coins += 20;
			}
			if (hitTarget.collider.gameObject.name == "tower2(Clone)") {
				Collider[] colliders;
				if((colliders = Physics.OverlapSphere(pos, 20f)).Length > 1)
				{
					foreach(var collider in colliders)
					{
						if(collider.gameObject.name=="planeForTower"){
							if(collider.gameObject.GetComponent<checkIfSpawnTower>().ifTowerAlready == true) {
								collider.gameObject.GetComponent<checkIfSpawnTower>().ifTowerAlready=false;
							}
						}
						
					}
				}
				GameObject obj = (GameObject)hitTarget.collider.gameObject;
				GameObject.Destroy (obj);
				Coin_Management.coins += 20;
			}
		}
	}
	
	public void getPosition() {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitTarget;
			Ray rayTarget = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayTarget, out hitTarget);
			newPosition1 = hitTarget.point;
			newPosition1.y = 7;
			pos = new Vector3 (newPosition1.x, newPosition1.y, newPosition1.z);
			ifClick = false;
			
			if(hitTarget.collider.gameObject.name == "planeForTower") {
				Vector3 pos_mat=hitTarget.collider.gameObject.transform.position;
				pos_mat.y=7;
				if(hitTarget.collider.gameObject.GetComponent<checkIfSpawnTower>().ifTowerAlready == false) {
					spawn_object(pos_mat);
					Coin_Management.coins -= 20;
					hitTarget.collider.gameObject.GetComponent<checkIfSpawnTower>().ifTowerAlready = true;
				}
			}
		}
		else {
			pos = new Vector3(0, 0, 0);
		}
	}
	
	public void spawn_object(Vector3 pos) {
		if(ifSpawn == true) {
			//GameObject obj = (GameObject)Instantiate (objects_to_spawn, pos, transform.rotation);
			if(tower1 == true) {
				GameObject obj = (GameObject)Instantiate (objects_to_spawn, pos, objects_to_spawn.transform.rotation);
				obj.AddComponent<BoxCollider>();
				tower1 = false;
			}
			if(tower2 == true) {
				GameObject obj = (GameObject)Instantiate (objects_to_spawn2, pos, objects_to_spawn2.transform.rotation);
				obj.AddComponent<BoxCollider>();
				tower2 = false;
			}
			ifSpawn = false;
		}
	}	
	
	void Update () {
		//towerDelete ();
		if (ifClick == true) {
			getPosition ();
		} else {
			Debug.Log("Already spawned");
		}
		//SAMI-RISTRICT THE SPAWNING TO ONE TOWER-END
		
	}
	
}
