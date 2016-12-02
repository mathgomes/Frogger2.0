using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Velocidade do veículo, em unidades por segundo (use valores negativos pra ir pa esquerda)
	public float velocidade = 1;

	// Posição X das bordas laterais, se passar da borda final, volta pra outra
	// Note que tanto faz se indo pra direita ou esquerda, essa borda DEVE ser positiva
	public float xBorda = 10;

	// Ao começar, inverte o sprite se for pra esquerda
	void Start () {
		if (velocidade < 0) {
			GetComponent<SpriteRenderer> ().flipX = true;
		}
	}

    void Update() {
		float sinal = Mathf.Sign (velocidade);
		if (sinal * transform.position.x > xBorda) {
			transform.Translate (-2 * sinal * xBorda, 0, 0);
		} else {
			transform.Translate (velocidade * Time.deltaTime, 0, 0);
		}
    }
}
