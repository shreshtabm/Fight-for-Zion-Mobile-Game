using UnityEngine;
using System.Collections;
using System.Threading;

public class Game_buttons : MonoBehaviour {
	//PAUSE BUTTON
	public string buttonToken = "Resumed";
	public const string pausedToken = "Paused";
	public const string ResumedToken = "Resumed";


	private void OnGUI()
	{
		//PAUSE
		switch (buttonToken) {
				//If the Game is Paused show the Resume Button
				case pausedToken:
						{
			if(GUI.Button(new Rect((Screen.width+500)/2+20 , Screen.height / 2-120,80, 20),"RESUME")) {
										buttonToken = ResumedToken;
				                        Time.timeScale = 1;
								}
								break;
						}
				//If the Game is Not Paused show the Pause Button
				case ResumedToken:
						{
			if(GUI.Button(new Rect((Screen.width+500)/2+20 , Screen.height / 2-120,80, 20),"PAUSE2")) {
										buttonToken = pausedToken;
										Time.timeScale = 0;	
								}
								break;
						}
				}

		//QUIT
		if(GUI.Button(new Rect((Screen.width+500)/2+20 , Screen.height / 2-90,80, 20),"QUIT")) {
			Application.LoadLevel("Menu");
		}
		   

	}

}



