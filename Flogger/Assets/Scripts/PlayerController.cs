using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	const int ladoQuadrado = 1;

	// Rotações padrão pra cada lado, pra não ter que criar sempre
	static Vector3 cima = new Vector3 (0, 0, 180);
	static Vector3 baixo = new Vector3 (0, 0, 0);
	static Vector3 esquerda = new Vector3 (0, 0, -90);
	static Vector3 direita = new Vector3 (0, 0, 90);

	private Rigidbody2D rb;
	private Vector2 move = Vector2.zero;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

    // Update is called once per frame
    void Update () {
		var deltaX = 0;
		var deltaY = 0;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			deltaY = ladoQuadrado;
			transform.eulerAngles = cima;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			deltaY = -ladoQuadrado;
			transform.eulerAngles = baixo;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			deltaX = -ladoQuadrado;
			transform.eulerAngles = esquerda;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			deltaX = ladoQuadrado;
			transform.eulerAngles = direita;
		}


		move.x += deltaX;
		move.y += deltaY;
	}

	void FixedUpdate () {	
		// Não translada se for sair da tela
		var cam = Camera.main;
		if (cam.pixelRect.Contains (cam.WorldToScreenPoint (rb.position + move))) {
			rb.MovePosition (rb.position + move);
			//transform.Translate (deltaX, deltaY, 0, Space.World);
		}
		move = Vector2.zero;
    }

	void OnCollisionEnter2D (Collision2D outro) {
		Debug.Log ("Bateu ");
	}
}
