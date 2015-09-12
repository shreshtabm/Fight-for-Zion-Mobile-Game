using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZionScriptForL3 : MonoBehaviour {
	
	public GameObject FireBall;
	private Vector3 firePoint;
	
	private GameObject FB;
	private float bulletSpawner = 0;
	public List <Transform> Enemies;
	
	//change
	public float newTimerExistPeriod;
	public bool tankSpawnBullet;
	public int bulletScale = 1;
	public float origBulletScale;
	public bool biggerT1 = false, biggerT4 = false, biggerT6 = false;

	public List<GameObject> enemyList = new List<GameObject>();
	public Collider[] enemyWithinSearch;
	public float checkTime = 0f;


	
	void Start () {
		bulletScale = 1;
		newTimerExistPeriod = 3f;
		Enemies = new List<Transform>();
		//firePoint = new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z);
		tankSpawnBullet = true;
		//FB = (GameObject)Instantiate(FireBall, firePoint, Quaternion.identity);
	}
	
	void searchEnemy() {
		enemyWithinSearch = Physics.OverlapSphere (this.transform.position, 60);
		if (enemyWithinSearch == null) {
			return;
		}
		for(int i = 0; i < enemyWithinSearch.Length; i++) {
			if(enemyWithinSearch[i].gameObject.tag == "Enemy") {
				enemyList.Add(enemyWithinSearch[i].gameObject);
			}
		}
		checkTime = 2f;
	}
	
	
	
	void Update () {
//		Enemies = new List<Transform>();
//		int range = 3000;
//		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
//		
//		foreach(GameObject _Enemy in ItemsInList)
//		{
//			var dist = (transform.position - _Enemy.transform.position).sqrMagnitude; 
//			if (dist < range){
//				Enemies.Add(_Enemy.transform);
//			}   
//		}

		if(checkTime <= 0) {
			enemyList.Clear();
			searchEnemy();
		}
		checkTime -= Time.deltaTime;
		bulletSpawner += Time.deltaTime;
		
		//if (bulletSpawner > newTimerExistPeriod)
		//if(Enemies[0] !=null && bulletSpawner > newTimerExistPeriod)
		if(enemyList.Count > 0 && bulletSpawner > newTimerExistPeriod)
		{
			if(enemyList[0] != null) {
				firePoint = this.transform.GetChild(0).transform.position;
				if(this.gameObject.name == "tower4ForL3(Clone)") {
					firePoint = new Vector3(firePoint.x, firePoint.y+20, firePoint.z);
				}
				if(this.gameObject.name == "tower6ForL3(Clone)") {
					firePoint = new Vector3(firePoint.x, firePoint.y+20, firePoint.z);
				}
				FB = (GameObject)Instantiate(FireBall, firePoint, Quaternion.identity);

				if(this.gameObject.name == "tower1ForL3(Clone)") {
					
					if(biggerT1 == true) {
						FB.transform.localScale = new Vector3(6f, 6f, 6f);
					}
					
					FB.GetComponent<FireBallL3>().SelectedTarget2 = enemyList[0].transform;
				}
				else if(this.gameObject.name == "tower4ForL3(Clone)") {
					if(biggerT4 == true) {
						FB.GetComponent<LineRenderer>().SetWidth(7, 7);
						FB.GetComponent<LineRenderer>().SetPosition(0, new Vector3(0, 0, -20));
						FB.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 20));
					}
					FB.GetComponent<FireBall2>().SelectedTarget2 = enemyList[0].transform;
				}
				else if(this.gameObject.name == "tower6ForL3(Clone)") {
					if(biggerT6 == true) {
						FB.GetComponent<ParticleSystem>().startSize = 30;
					}
					
					FB.GetComponent<FireBallL3>().SelectedTarget2 = enemyList[0].transform;
				}
				else if(this.gameObject.name == "2cm_kwk38") {
					Debug.Log("FIREBALL!!!!!!!!!!!!!!!!!!!!!!!");
					FB.GetComponent<FireBallTank>().SelectedTarget2 = enemyList[0].transform;
				}
				
				
				
				this.GetComponent<AudioSource>().enabled = true;
				this.gameObject.audio.Play();
				bulletSpawner = 0;

			}
			else {
				checkTime = 0;
			}

		}
		
	}
}
