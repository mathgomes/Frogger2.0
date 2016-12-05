using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadeUp : MonoBehaviour, IPowerUp {
	public void run (PlayerController player) {
		player.velocidade += player.velocidadeDelta;
	}
}
