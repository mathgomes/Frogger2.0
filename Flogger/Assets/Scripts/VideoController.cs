using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour {

	// sonzinhos possíveis
	public AudioClip[] sonsMorte;
	public AudioClip[] sonsGanha;
	public AudioClip[] sonsRand;

	// Anima
	Animator anim;
	AudioSource source;
	float tempo;

	void Start () {
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}

	AudioClip getRand (AudioClip[] vet) {
		return vet[Random.Range (0, vet.Length)];
	}

	void Update () {
		tempo -= Time.deltaTime;
		anim.SetFloat ("Tempo", tempo);
	}

	public void pedeSom (string categoria) {
		AudioClip som = null;
		if (categoria == "morte") {
			som = getRand (sonsMorte);
		} else if (categoria == "ganha") {
			som = getRand (sonsGanha);
		} else if (categoria == "rand") {
			som = getRand (sonsRand);
		}

		if (som) {
			source.PlayOneShot (som);
			anim.SetTrigger ("Comeca");
			tempo = som.length;
		} else {
			throw new KeyNotFoundException ("Categoria inválida de sons do video: " + categoria);
		}
	}
}
