using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TartarugaSubmerge : MonoBehaviour {
	
	private Animator anim;
	private BoxCollider2D coll;

	// Tempos dentro e fora d'água
	public float tempoFora;
	public float tempoDentro;

	// Variáveis adicionais pro controle da submersão/emersão
	private bool dendagua = false;
	private float timer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		coll = GetComponent<BoxCollider2D> ();
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (dendagua && timer > tempoDentro) {
			anim.SetTrigger ("Emerge");
			tag = "SobreRio";
			dendagua = false;
			coll.isTrigger = true;
			timer = 0;
		} else if (!dendagua && timer > tempoFora) {
			anim.SetTrigger ("Mergulha");
			tag = "Inimigo";
			dendagua = true;
			coll.isTrigger = false;
			timer = 0;
		}
	}
}
