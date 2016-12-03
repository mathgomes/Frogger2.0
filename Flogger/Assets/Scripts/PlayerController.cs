using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	const int ladoQuadrado = 1;

	// Velocidade do sapo, em unidades por segundo
	public float velocidade = 2;

	// Rotações padrão pra cada lado, pra não ter que criar sempre
	static Vector3 cima = new Vector3 (0, 0, 180);
	static Vector3 baixo = new Vector3 (0, 0, 0);
	static Vector3 esquerda = new Vector3 (0, 0, -90);
	static Vector3 direita = new Vector3 (0, 0, 90);

	// Variáveis do movimento
	private Rigidbody2D rb;
	private Vector2 move = Vector2.zero;
	private Vector2 delta = Vector2.zero;
	private Vector2 segue = Vector2.zero; // Vetor seguindo uma tartaruga ou tronco

	// Começo da fase, pra voltar ao morrer
	// Note que em qualquer lugar que ele Startar vira começo da fase,
	// rolando usar em prefab
	private Vector2 comecoDaFase;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		comecoDaFase = rb.position;
	}

    // Update is called once per frame
    void Update () {
		if (move == Vector2.zero) {
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
			delta = move * velocidade * Time.fixedDeltaTime;
			if (move != Vector2.zero) {
				GetComponent<Animator> ().SetTrigger ("Pulou");
			}
		}
	}

	void FixedUpdate () {	
		// Não translada se for sair da tela
		var cam = Camera.main;
		if (cam.pixelRect.Contains (cam.WorldToScreenPoint (rb.position + move))) {
			rb.MovePosition (rb.position + delta + segue);
			move -= delta;
		} else {
			Morre ();
		}
    }

	/// Volta pro começo da fase, perdendo uma vida
	private void Morre () {
		transform.position = comecoDaFase;
		move = segue = Vector2.zero;
		GetComponent<AudioSource> ().Play ();
	}

	void OnCollisionEnter2D (Collision2D outro) {
		print ("bateu em " + outro.gameObject.name);
		if (outro.gameObject.CompareTag ("Inimigo")) {
			Morre ();
		}
	}

	void OnTriggerEnter2D (Collider2D outro) {
		segue = new Vector2 (outro.GetComponent<Movement> ().velocidade * Time.fixedDeltaTime, 0);
	}
	void OnTriggerExit2D (Collider2D outro) {
		segue = Vector2.zero;
	}
}
