using UnityEngine;
using System.Collections;

namespace FMG
{

	public class AudioVolume : MonoBehaviour {
		private float m_initalVol;
		void Awake () {
			if(audio)
			{
				m_initalVol = audio.volume;
			}
			updateVolume();
		}


		public void updateVolume () {
			if(audio)
			{
				audio.volume = PlayerPrefs.GetFloat("AudioVolume",1) * m_initalVol;
			}
		}
	}
}