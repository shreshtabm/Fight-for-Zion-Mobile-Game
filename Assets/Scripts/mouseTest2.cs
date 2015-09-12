using UnityEngine;
using System.Collections;

public class mouseTest2 : MonoBehaviour {

	bool getObj, moveObj;
	int count;
	public Vector3 newPosition, targetDir, newDir, origPosition;
	GameObject tCube;
	// Use this for initialization
	void Start () {
		getObj = false;
		moveObj = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if(hit.collider.gameObject.name == "Panzer_II_Ausf_F") {

					tCube = hit.collider.gameObject;
					Debug.Log("tCube.name = " + tCube.name);
					origPosition = tCube.transform.position;
					Debug.Log("origPosition = " + origPosition);
					getObj = true;
				}
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hitTarget;
			Ray rayTarget = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(rayTarget, out hitTarget) && hitTarget.collider.gameObject.name != "tPanzer_II_Ausf_F")
			{
				newPosition = hitTarget.point;
				Debug.Log("newPosition = " + newPosition);
				moveObj = true;

			}
		}

		if(getObj == true && moveObj == true) {
			if(newPosition != tCube.transform.position) {
				newPosition.y = 7;
				targetDir = newPosition - tCube.transform.position;
				float step = 20 * Time.deltaTime;

				newDir = Vector3.RotateTowards (tCube.transform.forward, targetDir, step, 0.0F);
				tCube.transform.rotation = Quaternion.LookRotation (newDir);
				tCube.transform.position = Vector3.MoveTowards (tCube.transform.position, newPosition, step);
			}
			else if(tCube.transform.position == newPosition) {
				getObj = false;
				moveObj = false;
			}
		
		}




	}
}
