using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower2Fire : MonoBehaviour {
	
	public Vector3 targetPoint;
    public Quaternion targetRotation;
	//Private Elements
	//private Vector3 forwardVect;
	private float timeForFire = 0;
	// private float speedFire = 70;
	private float fireBallExistPeriod = 2; 
	
	//Public Elements
	
	public List <Transform> Enemies;
	public Transform SelectedTarget;
	
	
	
	// Use this for initialization
	void Start () {
		
		//forwardVect = Vector3.forward;
		
		SelectedTarget = null;
		Enemies = new List<Transform>();
		// AddEnemiesToList();
		
		
	}
	
	public void AddEnemiesToList()
	{   
		int range = 1200;
		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
		
		foreach(GameObject _Enemy in ItemsInList)
		{
			var dist = (transform.position - _Enemy.transform.position).sqrMagnitude; 
			if (dist < range){
				AddTarget(_Enemy.transform);
			}  
			//AddTarget(_Enemy.transform);
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
		//bool isEmpty = !Enemies.Any();
		if(SelectedTarget == null && Enemies.Count != 0)
		{
			//DistanceToTarget();
			SelectedTarget = Enemies[0];
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if (GameObject.FindGameObjectsWithTag("Enemy") !=null) {
			
			AddEnemiesToList ();
			//bool isEmpty = !Enemies.Any();
			if (Enemies.Count != 0){
				TargetedEnemy();
				if (SelectedTarget != null) {
					targetPoint = new Vector3 (SelectedTarget.transform.position.x, transform.position.y, SelectedTarget.transform.position.z) - transform.position;
					targetRotation = Quaternion.LookRotation (targetPoint, Vector3.up);
					transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * 100.0f);
					
					float dist = Vector3.Distance (SelectedTarget.transform.position, transform.position);
					//if(dist <150)
					//{
					transform.position = Vector3.MoveTowards (transform.position, SelectedTarget.position, 60 * Time.deltaTime);
					//}
				}
				
				timeForFire += Time.deltaTime;
				// this.gameObject.transform.Translate(forwardVect * speedFire * Time.deltaTime, Space.Self);
				
				
				if (timeForFire > fireBallExistPeriod)
				{
					
					timeForFire = 0;
					GameObject.Destroy(this.gameObject);
					
				} 
			}
		}
	}
}
