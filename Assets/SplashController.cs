using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        var musicPlayer = GameObject.Find("Music Player");
        DontDestroyOnLoad(musicPlayer);
    }

    void Start () {
        Invoke("LoadFirstLevel", 3f);
	}
	
	// Update is called once per frame
	void LoadFirstLevel () {
        SceneManager.LoadScene(1);
	}
}
