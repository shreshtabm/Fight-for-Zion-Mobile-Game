 using UnityEngine;
 using System.Collections;
 
 public class turn : MonoBehaviour 
 {
     public GameObject target;
     public Vector3 targetPoint;
     public Quaternion targetRotation;
 
     void Start () 
     {
      //   target = GameObject.FindWithTag("Enemy");


     }
 
     void Update()
     {
				Debug.Log ("turn!!");
				target = GameObject.FindWithTag ("Enemy");
				if (target != null) {

						targetPoint = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
						targetRotation = Quaternion.LookRotation (targetPoint, Vector3.up);
						transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * 4.0f);
				}
		}
 }