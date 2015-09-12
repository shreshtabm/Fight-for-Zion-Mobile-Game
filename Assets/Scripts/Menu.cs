using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public Texture2D background, LOGO;
	//for buttons
	public Texture2D iconPlay,newIconPlay,newOption,newAbout,newQuit,newResolution,newBack,newVolume;
	public Texture2D pressIconPlay,pressOption,pressAbout,pressQuit,pressResolution,pressBack;
	
	public bool DragWindow = false;
	public string levelToLoadWhenClickedPlay = "";
	public string[] AboutTextLines = new string[0];
	public GUIStyle style = new GUIStyle ();
	public GUIStyle style2 = new GUIStyle ();
	
	public Texture menuTexture;
	
	private string clicked = "", MessageDisplayOnAbout = "About \n ";
	private Rect WindowRect = new Rect((Screen.width/3), Screen.height/4, Screen.width/3, (Screen.height*4/5));
	private float volume = 1.0f;
	
	private void Start()
	{
		for (int x = 0; x < AboutTextLines.Length;x++ )
		{
			MessageDisplayOnAbout += AboutTextLines[x] + " \n ";
		}
		MessageDisplayOnAbout += "Press Esc To Go Back";
	}
	
	private void OnGUI()
	{
		
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "about")
			GUI.DrawTexture(new Rect((Screen.width / 2) -45, 50, 100, 40), LOGO);
		
		if (clicked == "")
		{
			WindowRect = GUI.Window(0, WindowRect, menuFunc, ""); //main menu
			//WindowRect = GUI.Window(0, WindowRect, menuFunc, menuTexture);
			
		}
		else if (clicked == "options")
		{
			WindowRect = GUI.Window(1, WindowRect, optionsFunc, "");//option
		}
		else if (clicked == "about")
		{
			GUI.Box(new Rect (0,0,Screen.width,Screen.height), MessageDisplayOnAbout);
		}else if (clicked == "resolution")
		{
			GUILayout.BeginVertical();
			for (int x = 0; x < Screen.resolutions.Length;x++ )
			{
				if (GUILayout.Button(Screen.resolutions[x].width + "X" + Screen.resolutions[x].height))
				{
					Screen.SetResolution(Screen.resolutions[x].width,Screen.resolutions[x].height,true);
				}
			}
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Back"))
			{
				clicked = "options";
			}
			GUILayout.EndHorizontal();
		}
	}
	
	private void optionsFunc(int id)
	{
		
		GUI.skin.button.normal.background = newResolution;
		GUI.skin.button.hover.background = pressResolution;
		GUI.skin.button.active.background = pressResolution;
		//-------------------resolution button----------------------
		
		//if (GUILayout.Button(""))
		if(GUI.Button (new Rect ((WindowRect.width*3)/40, WindowRect.height/80, (WindowRect.width*8/9), (WindowRect.height/4)-5), ""))
		{
			clicked = "resolution";
		}
		
		//GUI.skin.box.normal.background = newVolume;
		//-----------------volume button------------------------
		//GUILayout.Box("Volume");
		GUILayout.Box("Volume");
		volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
		AudioListener.volume = volume;
		
		GUI.skin.button.normal.background = newBack;
		GUI.skin.button.hover.background = pressBack;
		GUI.skin.button.active.background = pressBack;
		//---------------------back button------------------------
		//if (GUILayout.Button(""))
		if (GUI.Button (new Rect (-2, WindowRect.height/2, WindowRect.width, (WindowRect.height/4)-5), ""))
		{
			clicked = "";
		}
		//		if (DragWindow)
		//			GUI.DragWindow(new Rect (0,0,Screen.width,Screen.height));
	}
	
	private void menuFunc(int id)
	{
		GUI.skin.button.normal.background = newIconPlay;
		GUI.skin.button.hover.background = pressIconPlay;
		GUI.skin.button.active.background = pressIconPlay;
		//if (GUI.Button (new Rect (10, 20, 290, 90), ""))
		
		//-------------play button ------------------
		//if (GUI.Button (new Rect ((WindowRect.width*3)/140, WindowRect.height/25, WindowRect.width, WindowRect.height/4), ""))
		if (GUI.Button (new Rect ((WindowRect.width*3)/40, WindowRect.height/80, (WindowRect.width*8/9), (WindowRect.height/4)-5), ""))
		{
			//Application.LoadLevel ("scene");
			Application.LoadLevel ("Map");

		}
		
		GUI.skin.button.normal.background = newOption;
		GUI.skin.button.hover.background = pressOption;
		GUI.skin.button.active.background = pressOption;
		//if(GUI.Button (new Rect (-5, 100, 320, 80), ""))
		
		//--------------options button-----------------
		if (GUI.Button (new Rect (0, WindowRect.height/4, WindowRect.width, (WindowRect.height/4)-5), ""))
		{
			clicked = "options";
			
		}
		GUI.skin.button.normal.background = newAbout;
		GUI.skin.button.hover.background = pressAbout;
		GUI.skin.button.active.background = pressAbout;
		//if (GUI.Button(new Rect(-5,170,320,80),""))
		//--------------about button----------------------
		if (GUI.Button (new Rect (-2, WindowRect.height/2, WindowRect.width, (WindowRect.height/4)-5), ""))
		{
			clicked = "about";
		}
		
		GUI.skin.button.normal.background = newQuit;
		GUI.skin.button.hover.background = pressQuit;
		GUI.skin.button.active.background = pressQuit;
		//if (GUI.Button(new Rect(10,260,300,80),""))
		//--------------quit button----------------------
		if (GUI.Button (new Rect ((WindowRect.width*3)/30, (3*WindowRect.height)/4, (WindowRect.width*8/9), (WindowRect.height/4)-5), ""))
		{
			Application.Quit();
		}
		if (DragWindow)
			GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
		
	}
	
	
	
	/*	private void menuFunc(int id)
	{

		if (GUILayout.Button("Play Game", style))
		{
			Application.LoadLevel("scene");
		}
		if (GUILayout.Button("Options",  style))
		{
			clicked = "options";
		}
		if (GUILayout.Button("About",  style))
		{
			clicked = "about";
		}
		if (GUILayout.Button("Quit Game",  style))
		{
			Application.Quit();
		}
		if (DragWindow)
			GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
	}
	*/
	private void Update()
	{
		if (clicked == "about" && Input.GetKey (KeyCode.Escape))
			clicked = "";
	}
}
