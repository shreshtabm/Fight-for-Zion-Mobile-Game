using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBall : MonoBehaviour {

	private float timeForFire = 0;
	private float fireBallExistPeriod = 2; 
	public List <Transform> Enemies;
	public Transform SelectedTarget;

	// Use this for initialization
	void Start () {
		SelectedTarget = null;
		Enemies = new List<Transform>();		
	}
	
	public void AddEnemiesToList()
	{   
	    int range = 10000;
		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
		
		foreach(GameObject _Enemy in ItemsInList)
		{
		    var dist = (transform.position - _Enemy.transform.position).sqrMagnitude; 
		    if (dist < range){
				AddTarget(_Enemy.transform);
			}  
		}
	}
	
	
	public void AddTarget(Transform enemy)
	{
		Enemies.Add(enemy);
	}
	
	public void DistanceToTarget()
	{
		Enemies.Sort(delegate( Transform t1, Transform t2){ 
			if(t1==null || t2==null) return 9999999;
			else
			return Vector3.Distance(t1.transform.position,transform.position).CompareTo(Vector3.Distance(t2.transform.position,transform.position)); 
		});
		
	}
	
	public void TargetedEnemy() 
	{
		if(SelectedTarget == null && Enemies.Count != 0)
		{
			SelectedTarget = Enemies[0];
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if (GameObject.FindGameObjectsWithTag("Enemy") !=null) {
		
			AddEnemiesToList ();
			if (Enemies.Count != 0){
				TargetedEnemy();
				if (SelectedTarget != null) {
						float dist = Vector3.Distance (SelectedTarget.transform.position, transform.position);
						transform.position = Vector3.MoveTowards (transform.position, SelectedTarget.position, 60 * Time.deltaTime);
						
				}
		
				timeForFire += Time.deltaTime;
		
				if (timeForFire > fireBallExistPeriod)
				{
					timeForFire = 0;
					GameObject.Destroy(this.gameObject);
			
				} 
			}
		}
	}
}
