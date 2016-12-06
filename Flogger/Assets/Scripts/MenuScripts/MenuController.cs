using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public AudioSource source;
    public AudioClip menuMusic;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(menuMusic);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
