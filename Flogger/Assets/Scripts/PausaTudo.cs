using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaTudo : MonoBehaviour, IPowerUp {
	public GameObject pausePrefab;

	public void run (PlayerController player) {
		Instantiate (pausePrefab);
	}
}
