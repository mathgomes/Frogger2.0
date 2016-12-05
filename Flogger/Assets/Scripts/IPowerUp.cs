using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Classe base para powerups. O importante é só ter a função "run" =]
public interface IPowerUp {
	void run (PlayerController player);
}
