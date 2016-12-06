using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	const int ladoQuadrado = 1;

    // Vidas
    public int vidas;

	// Velocidade do sapo, em unidades por segundo
	public float velocidade = 2;
	public float velocidadeDelta = 0.5f;

	// Rotações padrão pra cada lado, pra não ter que criar sempre
	static Vector3 cima = new Vector3 (0, 0, 180);
	static Vector3 baixo = new Vector3 (0, 0, 0);
	static Vector3 esquerda = new Vector3 (0, 0, -90);
	static Vector3 direita = new Vector3 (0, 0, 90);

	// Variáveis do movimento
	private Rigidbody2D rb;
	private Vector2 anterior;
	private Vector2 indoPara;
	private Vector2 segue; // Vetor seguindo uma tartaruga ou tronco
	private float tempoPulou;

	// Começo da fase, pra voltar ao morrer
	// Note que em qualquer lugar que ele Startar vira começo da fase,
	// rolando usar em prefab
	private Vector2 comecoDaFase;

	// Video, pra pedir pra falar
	public GameObject video;

	// With Lasers!
	public GameObject laserPrefab;
	public int laser = 0;

    public GameObject[] HUD = new GameObject[3];

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		segue = Vector2.zero;
		comecoDaFase = anterior = indoPara = rb.position;
        HUD[0] = GameObject.Find("Text");
        HUD[1] = GameObject.Find("Clock");
        HUD[2] = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update () {
		if (anterior == indoPara) {
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
				
			if (deltaX != 0 || deltaY != 0) {
				indoPara = anterior + new Vector2 (deltaX, deltaY);
				tempoPulou = Time.time;
				GetComponent<Animator> ().SetTrigger ("Pulou");
			}
		}
		if (laser > 0 && Input.GetButtonDown ("Fire1")) {
			Instantiate (laserPrefab, transform, false);
			laser--;
		}
	}

	void FixedUpdate () {
		var cam = Camera.main;
		if (cam.pixelRect.Contains (cam.WorldToScreenPoint (rb.position))) {
			// fração de movimento, se passar de 1 é porque cabou
			var frac = (Time.time - tempoPulou) * velocidade;
			if (frac < 1) {
				rb.MovePosition (Vector2.Lerp (anterior, indoPara, frac));
			} else {
				indoPara += segue;
				anterior = indoPara;
				rb.MovePosition (anterior);
			}
		// saiu da tela: morre, VWAHAHAHAHA!
		} else {
			Morre ();
		}
    }

	/// Volta pro começo da fase, perdendo uma vida
	private void Morre () {
		transform.position = anterior = indoPara = comecoDaFase;
		GetComponent<AudioSource> ().Play ();
		video.GetComponent<VideoController> ().pedeSom ("morte");
		vidas--;
		if (vidas <= 0) {
			print ("CABOOOOOU");
		}
	}

	void OnTriggerEnter2D (Collider2D outro) {
		if (outro.gameObject.CompareTag ("SobreRio")) {
			segue = new Vector2 (outro.GetComponent<Movement> ().velocidade * Time.fixedDeltaTime, 0f);
		} else if (outro.gameObject.CompareTag ("PowerUp")) {
			outro.GetComponent<IPowerUp> ().run (this);
			Destroy (outro.gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D outro) {
		// Morre se encostou em inimigo e NÃO tá seguindo tronco/tartaruga (pro rio)
		if (outro.gameObject.CompareTag ("Inimigo") && segue == Vector2.zero) {
			print ("bateu em " + outro.gameObject.name);
			Morre ();
		}
	}

	void OnTriggerExit2D (Collider2D outro) {
		if (outro.gameObject.CompareTag ("SobreRio")) {
			segue = Vector2.zero;
		}
	}
}
