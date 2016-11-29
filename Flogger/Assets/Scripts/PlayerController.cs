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

		// Não translada se for sair da tela
		var cam = Camera.main;
		if (cam.pixelRect.Contains (cam.WorldToScreenPoint (transform.position + new Vector3 (deltaX, deltaY)))) {
			transform.Translate (deltaX, deltaY, 0, Space.World);
		}
    }
}
