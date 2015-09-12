using UnityEngine;
using System.Collections;

public class healthOnEnemy : MonoBehaviour {
	Vector2 vec;
	public Texture lifeBarBehindTex;
	public Texture lifeBarTex;
	public float lifeRatio, fullHealth, currentHealth;
	public float lifeHeight = 10; 
	public float lifeBackgroundWidth=50;
	float lifeWidth;

	
	public Texture manaBarBehindTex;
	public Texture manaBarTex;
	float manaRatio;
	public float manaHeight = 10; 
	public float manaBackgroundWidth=50;
	float manaWidth;

	public GameObject coinBar;
	public Animator anim;
	public bool ifDeath;
	public float reduceSpeedTime = 0f;
	public float fireBurnTime = 0f;
	public GameObject fireObj;
	public float origSpeed;

	void Start () {

		coinBar = GameObject.FindGameObjectWithTag ("CoinBar");
		ifDeath = false;
		reduceSpeedTime = 0f;
		fireBurnTime = 0f;

		if (this.name == "Robots_Prowler(Clone)") {
			fullHealth = 200f;
			currentHealth = 200f;
			lifeRatio = currentHealth/fullHealth;
			lifeWidth=lifeRatio*lifeBackgroundWidth;
		}
		else if (this.name == "Troll(Clone)") {
			fullHealth = 150;
			currentHealth = 150f;
			lifeRatio = currentHealth/fullHealth;
			lifeWidth=lifeRatio*lifeBackgroundWidth;
		}
		else if (this.name == "golemForL3(Clone)") {
			anim = GetComponent<Animator>();

			fullHealth = 120f;
			currentHealth = 120f;
			lifeRatio = currentHealth/fullHealth;
			lifeWidth=lifeRatio*lifeBackgroundWidth;
		}
		else if(this.name == "PA_WarriorForL3(Clone)") {
			fullHealth = 80f;
			currentHealth = 80f;
			lifeRatio = currentHealth/fullHealth;
			lifeWidth=lifeRatio*lifeBackgroundWidth;
		}
		else if(this.name == "Boss(Clone)") {
			fullHealth = 700f;
			currentHealth = 700f;
			lifeRatio = currentHealth/fullHealth;
			lifeWidth=lifeRatio*lifeBackgroundWidth;
		}

	}
	
	void Update () {
		lifeRatio = currentHealth/fullHealth;
		lifeWidth=lifeRatio*lifeBackgroundWidth;
		if (currentHealth <= 0 && ifDeath == false) {
			coinBar.GetComponent<UIBarScript>().NewValue += 0.1f;
			countDefeatForL3.defeatedEnemy++;
			if(anim != null) {
				anim.SetBool("death", true);
			}
			if(this.name == "Boss(Clone)") {
				countDefeatForL3.defeatedEnemy += 100;
			}


			ifDeath = true;

			GameObject.Destroy(this.gameObject);
		}

		if(reduceSpeedTime > 0) {
			reduceSpeedTime -= Time.deltaTime;
		}
		else if(reduceSpeedTime < 0) {
			recoverSpeed();
			reduceSpeedTime = 0;
		}



	}



	void OnTriggerEnter(Collider c){

		if(c.name != "fireTail") {
			if (c.tag == "Bullet" || c.name == "My_bullet(Clone)" || c.tag == "Bullet") {
				GameObject.Destroy (c.gameObject);
			}
		}

//		if (c.tag == "Bullet" || c.name == "My_bullet(Clone)" || c.name == "Laser(Clone)" || c.name == "tank_bomb(Clone)" && currentHealth > 0) {
//			currentHealth -= 50f;
//		} 

		if(currentHealth > 0) {
			if(c.name == "My_bulletForL3(Clone)") {
				currentHealth -= 10f;
			}
			else if(c.name == "Laser2(Clone)") {
				currentHealth -= 20f;
			}
			else if(c.name == "fireTail") {
				currentHealth -= 10f;
			}
			else if(c.name == "bulletWhityBomb(Clone)") {
				currentHealth -= 5f;
				reduceSpeedTime = 3f;
				reduceSpeed();
			}
		
			if(this.name == "Boss(Clone)") {
				if(c.gameObject.GetComponent<crazy>().enabled == true && c.name == "PA_WarriorForL3(Clone)") {
					currentHealth -= 100f;
				}
			}
		
		}




	}

	void reduceSpeed() {
		if(this.GetComponent<wayPointForEnemy>().enabled == true) {
			this.GetComponent<wayPointForEnemy>().speed = 5f;
		}
		else if(this.GetComponent<wayPointForEnemy2>().enabled == true) {
			this.GetComponent<wayPointForEnemy2>().speed = 5f;
			if(this.name == "Boss(Clone)") {
				this.GetComponent<wayPointForEnemy2>().speed = 1f;
			}
		}
		else if(this.GetComponent<wayPointForEnemy3>().enabled == true) {
			this.GetComponent<wayPointForEnemy3>().speed = 5f;
		}
		else if(this.GetComponent<wayPointForEnemy4>().enabled == true) {
			this.GetComponent<wayPointForEnemy4>().speed = 5f;
		}
	}

	void recoverSpeed() {
		if(this.GetComponent<wayPointForEnemy>().enabled == true) {
			this.GetComponent<wayPointForEnemy>().speed = 10f;
		}
		else if(this.GetComponent<wayPointForEnemy2>().enabled == true) {
			this.GetComponent<wayPointForEnemy2>().speed = 10f;
			if(this.name == "Boss(Clone)") {
				this.GetComponent<wayPointForEnemy2>().speed = 2.5f;
			}
		}
		else if(this.GetComponent<wayPointForEnemy3>().enabled == true) {
			this.GetComponent<wayPointForEnemy3>().speed = 10f;
		}
		else if(this.GetComponent<wayPointForEnemy4>().enabled == true) {
			this.GetComponent<wayPointForEnemy4>().speed = 10f;
		}
	}


	void OnGUI()
	{
		if (lifeRatio > 0 && lifeRatio <= 1) {
		vec=Camera.main.WorldToScreenPoint(transform.position);
		if(this.name == "Robots_Prowler(Clone)") {
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+90),lifeBackgroundWidth,lifeHeight),lifeBarBehindTex,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+90),lifeWidth,lifeHeight),lifeBarTex,ScaleMode.StretchToFill);
			GUI.Label(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+95),lifeBackgroundWidth,lifeHeight*2),//"hello");
			          currentHealth+"/"+fullHealth);
		}
		else if(this.name == "Troll(Clone)") {
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+60),lifeBackgroundWidth,lifeHeight),lifeBarBehindTex,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+60),lifeWidth,lifeHeight),lifeBarTex,ScaleMode.StretchToFill);
			GUI.Label(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+65),lifeBackgroundWidth,lifeHeight*2),//"hello");
			          currentHealth+"/"+fullHealth);
		}
		else if(this.name == "golemForL3(Clone)") {
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+70),lifeBackgroundWidth,lifeHeight),lifeBarBehindTex,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+70),lifeWidth,lifeHeight),lifeBarTex,ScaleMode.StretchToFill);
			GUI.Label(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+75),lifeBackgroundWidth,lifeHeight*2),//"hello");
			          currentHealth+"/"+fullHealth);
		}
		else if(this.name == "PA_WarriorForL3(Clone)") {
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+60),lifeBackgroundWidth,lifeHeight),lifeBarBehindTex,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+60),lifeWidth,lifeHeight),lifeBarTex,ScaleMode.StretchToFill);
			GUI.Label(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+65),lifeBackgroundWidth,lifeHeight*2),//"hello");
			          currentHealth+"/"+fullHealth);
		}
		else if(this.name == "Boss(Clone)") {
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+60),lifeBackgroundWidth,lifeHeight),lifeBarBehindTex,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+60),lifeWidth,lifeHeight),lifeBarTex,ScaleMode.StretchToFill);
			GUI.Label(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+65),lifeBackgroundWidth,lifeHeight*2),//"hello");
			          currentHealth+"/"+fullHealth);
		}

		

		}
	}
	
}
