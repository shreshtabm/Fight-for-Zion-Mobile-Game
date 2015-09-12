using UnityEngine;
using System.Collections;

public class animation_move : MonoBehaviour {
	
	private int state;
	public GameObject golem;
	
	public Transform target;
	public float spawnTime = 5f;
	float spawnTimeLeft = 5f;
	
	// Animation
	private Animator anim;
	private int animationState = 0; // 0: Default, walk 1: punch  2:hit
	
	// Use this for initialization
	void Start () {
		//animation.Play ("walk");
		anim.SetBool("walk", true);
		
		
	}
	
	// Update is called once per frame
	void Update () {



		//animation.Play ("walk");
		anim.SetBool("walk", true);
		if(spawnTimeLeft <= 0) {
			GameObject go = (GameObject)Instantiate(golem, transform.position, transform.rotation);
			go.tag = "Enemy";
			
			go.GetComponent<AstarAI>().target = target;
			spawnTimeLeft = spawnTime;
			//	anima();
		}
		else {
			spawnTimeLeft -= Time.deltaTime;
		}



		/*	if (state == 0)
		{
			anim.SetBool("walk", true);
		}
		else if (state == 1)
		{
			anim.SetBool("punch", true);
		}
		else if (state == 2)
		{
			anim.SetBool("hit", true);
		}*/
		
	}
	
	public void setAnimation(int state)
	{
		// 0: Default, walk  1: punch  2: hit
		if (state >= 0 && state <= 2) {
			this.state = state;
		}
		
	}
}

