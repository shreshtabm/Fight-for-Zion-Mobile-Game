using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Statuscheck : MonoBehaviour {

	public Scrollbar Status;
	public float health = 100f;
	
	// Use this for initialization
	
	public void Damage(float value)
	{
		health -= value;
		Status.size = health / 100f;
	}
}
