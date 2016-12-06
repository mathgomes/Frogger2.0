using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IspaunerDePowerUpDown : MonoBehaviour {

	public GameObject[] powerupdowns;
	public float tempoTentarSpawnar;
	public float chance;

	private float timer;

	void Start () {
		timer = tempoTentarSpawnar;
		chance = Mathf.Clamp01 (chance);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			if (Random.value < chance) {
				var escolha = powerupdowns[Random.Range (0, powerupdowns.Length)];
				var pos = Camera.main.ViewportToWorldPoint (new Vector3 (Random.value, Random.value));
				pos.z = 0;
				Instantiate (escolha, pos, Quaternion.identity);
			}
			timer = tempoTentarSpawnar;
		}
	}
}
