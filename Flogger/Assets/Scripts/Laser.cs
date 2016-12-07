using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public float distancia = 10;
	public float tempo = 1;

	void Start () {
		var ps = GetComponent<ParticleSystem> ();
		var main = ps.main;
		main.startLifetime = distancia / 10f;
		ps.Play ();
		// já marca sua saída no jogo
		Destroy (gameObject, tempo);
	}

	void FixedUpdate () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.forward, distancia);
		print (hit.collider);
		if (hit.collider != null && hit.collider.CompareTag ("Inimigo")) {
			Destroy (hit.collider.gameObject);
		}
	}
}
