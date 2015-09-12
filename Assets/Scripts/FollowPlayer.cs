using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
	
	private Transform player;		// Reference to the player.
	
	
	void Awake ()
	{
		// Setting up the reference.
		if (transform.parent != null) {
						player = transform.parent;
				} else
						player = null;
	}
	
	void Update ()
	{
		// Set the position to the player's position with the offset.
		if (player != null) {
						transform.position = player.position + offset;
				} 
		else 
						Destroy (this);
	}
}
