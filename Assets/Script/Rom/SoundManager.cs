using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public string AutoPlay = "";
    public StringClipDictionary Songs;

    private AudioSource _source;

	// Use this for initialization
	void Awake ()
    {
		if (Instance != null)
        {
            Destroy(this);
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _source = GetComponent<AudioSource>();

        if (AutoPlay != "")
            StartMusic(AutoPlay);
	}

    public void StartMusic(string songName)
    {
        AudioClip clip;
        Songs.TryGetValue(songName, out clip);

        if (clip == null)
        {
            Debug.LogWarning("Tried to play an inexistant song : " + songName);
            return;
        }

        _source.clip = clip;
        _source.Play();
    }
}
