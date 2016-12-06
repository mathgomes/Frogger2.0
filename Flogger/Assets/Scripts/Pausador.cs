using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausador : MonoBehaviour {

	public float timer;

	void Start () {
		// pausa geral
		var objs = GameObject.FindObjectsOfType<Movement> ();
		foreach (var o in objs) {
			o.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			// despausa geral
			var objs = GameObject.FindObjectsOfType<Movement> ();
			foreach (var o in objs) {
				o.enabled = true;
			}
			Destroy (gameObject);
		}
	}
}
