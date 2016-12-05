using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadeDown : MonoBehaviour, IPowerUp {
	public void run (PlayerController player) {
		player.velocidade -= player.velocidadeDelta;
	}
}
