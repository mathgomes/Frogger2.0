using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TartarugaSubmerge : MonoBehaviour {
	
	private Animator anim;

	// Tempos dentro e fora d'água
	public float tempoFora;
	public float tempoDentro;

	// Variáveis adicionais pro controle da submersão/emersão
	private bool dendagua = false;
	private float timer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (dendagua && timer > tempoDentro) {
			anim.SetTrigger ("Emerge");
			tag = "SobreRio";
			dendagua = false;
			timer = 0;
		} else if (!dendagua && timer > tempoFora) {
			anim.SetTrigger ("Mergulha");
			tag = "Inimigo";
			dendagua = true;
			timer = 0;
		}
	}
}
