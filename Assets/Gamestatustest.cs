using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Gamestatustest : MonoBehaviour {


		
		public static Scrollbar Status;
		public static float health = -100f;
	    public GameObject goal;

		public static void Damage(float value)
		{
			health += value;
			Status.size = health / 100f;
		}

}
