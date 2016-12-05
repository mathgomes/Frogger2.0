using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaUp : MonoBehaviour, IPowerUp {
	public void run (PlayerController player) {
		player.vidas++;
	}
}
