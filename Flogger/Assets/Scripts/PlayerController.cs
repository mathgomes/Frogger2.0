using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	const int ladoQuadrado = 1;

	// Update is called once per frame
	void Update () {
		var h = 0f;
		var v = 0f;
		if (Input.GetKeyDown (KeyCode.UpArrow)) v += 1;
		if (Input.GetKeyDown (KeyCode.DownArrow)) v -= 1;
		if (Input.GetKeyDown (KeyCode.LeftArrow)) h -= 1;
		if (Input.GetKeyDown (KeyCode.RightArrow)) h += 1;


		transform.Translate (h * ladoQuadrado, v * ladoQuadrado, 0);
	}
}
