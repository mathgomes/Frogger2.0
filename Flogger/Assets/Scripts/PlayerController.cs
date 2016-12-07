using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	const int ladoQuadrado = 1;
	const int cenaGameOver = 5;

    //
    public GameObject score;
    public GameObject lives;

	// Velocidade do sapo, em unidades por segundo
	public float velocidade = 2;
	public float velocidadeDelta = 0.5f;

	// Rotações padrão pra cada lado, pra não ter que criar sempre
	static Vector3 cima = new Vector3 (0, 0, 180);
	static Vector3 baixo = new Vector3 (0, 0, 0);
	static Vector3 esquerda = new Vector3 (0, 0, -90);
	static Vector3 direita = new Vector3 (0, 0, 90);

	// Variáveis do movimento
	public Rigidbody2D rb;
	private Vector2 anterior;
	private Vector2 indoPara;
	private float tempoPulou;
	// Variável de SobreRio
	private Vector2 segue; // Vetor seguindo uma tartaruga ou tronco
	private uint sobreRioAninhado = 0;

	public bool inverte = false; // Inverte os controle, se pegar o powerdown
	public float timer;

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
        lives = GameObject.Find("Lives");
        score = GameObject.Find("Score");
        rb = GetComponent<Rigidbody2D> ();
		segue = Vector2.zero;
		comecoDaFase = anterior = indoPara = rb.position;
        HUD[0] = GameObject.Find("Text");
        HUD[1] = GameObject.Find("Clock");
        HUD[2] = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update () {
		timer -= Time.deltaTime;
		if (anterior == indoPara) {
			var deltaX = 0;
			var deltaY = 0;
			Vector3 direcao = Vector3.zero;
			var andou = false;
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				deltaY = ladoQuadrado;
				direcao = cima;
				andou = true;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				deltaY = -ladoQuadrado;
				direcao = baixo;
				andou = true;
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				deltaX = -ladoQuadrado;
				direcao = esquerda;
				andou = true;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				deltaX = ladoQuadrado;
				direcao = direita;
				andou = true;
			}
			// Muda a direção, se moveu e não tá com controle invertido
			if (!inverte && andou) {
				transform.eulerAngles = direcao;
			}
				
			if (deltaX != 0 || deltaY != 0) {
				indoPara = anterior + (inverte ? -1 : 1) * new Vector2 (deltaX, deltaY);
				tempoPulou = Time.time;
				GetComponent<Animator> ().SetTrigger ("Pulou");
			}
		}
		if (inverte && timer <= 0) {
			DesinverteControles ();
		}
		if (laser > 0 && Input.GetButtonDown ("Fire1")) {
			Instantiate (laserPrefab, transform, false);
			laser--;
		}
	}

	public void InverteControles (float duracao) {
		inverte = true;
		timer = duracao;
		rb.freezeRotation = false;
		rb.angularVelocity = 270;
	}
	void DesinverteControles () {
		inverte = false;
		rb.freezeRotation = true;
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
		PlayerInfoGlobal.vidas--;
		sobreRioAninhado = 0;
		if (PlayerInfoGlobal.vidas <= 0) {
			SceneManager.LoadScene(cenaGameOver);
        }
	}

	void OnTriggerEnter2D (Collider2D outro) {
		if (outro.gameObject.CompareTag ("SobreRio")) {
			segue = new Vector2 (outro.GetComponent<Movement> ().velocidade * Time.fixedDeltaTime, 0f);
			sobreRioAninhado++;
		} else if (outro.gameObject.CompareTag ("PowerUp")) {
			outro.GetComponent<IPowerUp> ().run (this);
			Destroy (outro.gameObject);
		// passou de fase! Parabéns =]
		} else if (outro.gameObject.CompareTag ("FimDaFase")) {
			PlayerInfoGlobal.pontos += 100;
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		// esmaece o video do Flogger, pro player saber q q tacon teseno
		} else if (outro.gameObject.CompareTag ("Video")) {
			var renderers = outro.gameObject.GetComponentsInChildren<SpriteRenderer> ();
			foreach (var ren in renderers) {
				ren.color = new Color (1, 1, 1, 0.5f);
			}
			print ("oie");
		}
	}

	/// Sai do SobreRio (tartaruga/tronco). Só pra não ter código duplicado =P	
	void SobreRioMaisNao () {
		sobreRioAninhado--;
		if (sobreRioAninhado == 0) {
			segue = Vector2.zero;
		}
	}
	void OnTriggerStay2D (Collider2D outro) {
		// Morre se encostou em inimigo e NÃO tá seguindo tronco/tartaruga (pro rio)
		if (outro.gameObject.CompareTag ("Inimigo")) {
			if (segue == Vector2.zero) {
				print ("bateu em " + outro.gameObject.name);
				Morre ();
			} else if (outro.name == "Tartaruga") {
				SobreRioMaisNao ();
			}
		}
	}

	void OnTriggerExit2D (Collider2D outro) {
		if (outro.gameObject.CompareTag ("SobreRio")) {
			SobreRioMaisNao ();
		} else if (outro.gameObject.CompareTag ("Video")) {
			var renderers = outro.gameObject.GetComponentsInChildren<SpriteRenderer> ();
			foreach (var ren in renderers) {
				ren.color = new Color (1, 1, 1, 1);
			}
			print ("tchau");
		}
	}
}
