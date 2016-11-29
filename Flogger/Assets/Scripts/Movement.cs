using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Velocidade do veículo, em unidades por segundo (use valores negativos pra ir pa esquerda)
	public float velocidade = 1;

    void Update() { 
        transform.Translate (velocidade * Time.deltaTime, 0, 0);
    }
}
