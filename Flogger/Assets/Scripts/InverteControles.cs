using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverteControles : MonoBehaviour, IPowerUp {
	/// Tempo que a inversão de controle dura, em segundos
	public float tempoAteCabar;

	public void run (PlayerController player) {
		player.InverteControles (tempoAteCabar);
	}
}
