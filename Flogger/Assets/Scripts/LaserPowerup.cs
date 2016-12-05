using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPowerup : MonoBehaviour, IPowerUp {
	public void run (PlayerController player) {
		player.laser++;
	}
}
