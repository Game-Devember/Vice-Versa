using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	//public AudioClip audio;
	private static MusicManager _instance;

	void Start()
	{
		InvokeRepeating("Music",0, 140);
		//PlayerPrefs.SetInt("MUSICINDEX",0);
		}
	void Update()
	{
		//PlayerPrefs.SetInt("MUSICINDEX",1);
		//if (PlayerPrefs.GetInt ("MUSICINDEX") == 1) {
						//gameObject.GetComponent<AudioSource> ().Stop ();
		//		}
	}
	public static MusicManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<MusicManager>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{

		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
	void Music()
	{
		//if (PlayerPrefs.GetInt ("MUSICINDEX") == 0) {
						gameObject.GetComponent<AudioSource> ().Play ();
		//		}
	}
}