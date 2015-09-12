using UnityEngine;
using System.Collections;

public class Health_decrease : MonoBehaviour {
	public float health=100f, cleanObjTime;
	public GameObject ui_display;
	public GameObject explosion;
	public Animator anim;
	public bool ifDeath;

	void Start () {
		anim = GetComponent<Animator>();
		cleanObjTime = 0;
		ifDeath = false;
	}

	void OnTriggerEnter(Collider c){

//		if (c.name!="level_geometry" && c.name!="UnitGoal") {
//			GameObject.Destroy (c.gameObject);
//		}


		if (c.tag == "Bullet" || c.name == "My_bullet(Clone)" || c.tag == "Bullet") {
			GameObject.Destroy (c.gameObject);
		}
		//if (c.name!="level_geometry" && c.name!="UnitGoal" && ui_display.transform.localScale.x > 0) {
		//if (c.name == "My_bullet(Clone)" || c.name == "Laser2(Clone)" || c.name == "tank_bomb(Clone)" && ui_display.transform.localScale.x > 0) {
		if (c.tag == "Bullet" || c.name == "My_bullet(Clone)" || c.name == "Laser(Clone)" || c.name == "tank_bomb(Clone)" && ui_display.transform.localScale.x > 0) {
			Vector3 temp;
			temp = ui_display.transform.localScale;
			temp.x -= 0.20f;

			ui_display.transform.localScale = temp;
			if (temp.x <= 0) {
				countDefeat.defeatedEnemy++;
				Coin_Management.coins+=5;
				Vector3 hitScale = transform.localScale;
				Vector3 pos = transform.position;
				pos.y = 5;
				transform.position = pos;
				if(Application.loadedLevelName == "scene") {
					GetComponent<AstarAI> ().speed = 0;
				}
				else if(Application.loadedLevelName == "Level2") {
					GetComponent<AStarAI_Level2> ().speed = 0;
				}
				if(anim != null) {
					anim.SetBool("death", true);
				}
				ifDeath = true;
			}
		} 
		else {
			//Coin_Management.coins += 20;
		}			
		
	}

	void Update() {
		if(ifDeath == true) {
			cleanObjTime += Time.deltaTime;
			Debug.Log("DEAD!!!!!!!!!!!!!!!!!!!");
			if(cleanObjTime > 1) {
				Destroy(this.gameObject);
			}
		}
	}

}
