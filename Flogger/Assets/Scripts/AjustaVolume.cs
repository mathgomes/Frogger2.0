using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AjustaVolume : MonoBehaviour {

	public AudioMixer mixer;

	public void SetSfxVol (float novo) {
		mixer.SetFloat ("sfxVol", novo);
	}

	public void SetMusicaVol (float novo) {
		mixer.SetFloat ("musicaVol", novo);
	}

	public void SetVideoVol (float novo) {
		mixer.SetFloat ("videoVol", novo);
	}
}
