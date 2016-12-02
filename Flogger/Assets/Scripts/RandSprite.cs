using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandSprite : MonoBehaviour {

	public Sprite[] possibilidades;

	void Start () {
		var sprite = possibilidades[Random.Range (0, possibilidades.Length)];
		GetComponent<SpriteRenderer> ().sprite = sprite;
		GetComponent<BoxCollider2D> ().size = sprite.rect.size / sprite.pixelsPerUnit;
	}

}
