using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseImage : MonoBehaviour {
	public float playWaitTime = 1;
	public float hideWaitTime = 1;
	protected Image m_image;

	public AudioClip onPlayAC;
	public AudioClip onHideAC;

	public void Awake()
	{
		m_image = gameObject.GetComponent<Image>();

	}
	public virtual float play()
	{
		if(audio)
		{
			audio.PlayOneShot(onPlayAC);
		}

		if(m_image)
		{
			m_image.enabled=true;
		}
		return  playWaitTime;
	}
	
	public virtual float hide()
	{
		if(audio)
		{
			audio.PlayOneShot(onHideAC);
		}

		return hideWaitTime;
	}
}
