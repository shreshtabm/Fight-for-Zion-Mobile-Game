using UnityEngine;
using System.Collections;

public class Tower_spawn_3 : MonoBehaviour {

	public GameObject objects_to_spawn;
	
	public void spawn_object()
	{
		Vector3 newPosition1;
		
		
		Vector3 pos = new Vector3 (30, 3, 10);
		GameObject obj = (GameObject)Instantiate (objects_to_spawn, pos, transform.rotation);
		Coin_Management.coins -= 200;
		/*{if (Input.GetMouseButtonDown (0)) {
						RaycastHit hitTarget;
						Ray rayTarget = Camera.main.ScreenPointToRay (Input.mousePosition);
						Physics.Raycast (rayTarget, out hitTarget);
						newPosition1 = hitTarget.point;
						newPosition1.y = 7;
						Vector3 pos = new Vector3 (newPosition1.x, newPosition1.y, newPosition1.z);

						
						GameObject obj = (GameObject)Instantiate (objects_to_spawn, pos, transform.rotation);
						/*if (Input.GetMouseButtonDown (0)) {
						RaycastHit hitTarget;
						Ray rayTarget = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast(rayTarget, out hitTarget);
						newPosition = hitTarget.point;
			             newPosition.y=7;
			GameObject obj = ( GameObject )Instantiate(objects_to_spawn, transform.position +newPosition, transform.rotation);

				}*/
		
	}

}
