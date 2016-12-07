using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Informações sobre o player, como vidas e pontuação
/// Sim, tudo global ^^
public class PlayerInfoGlobal {
	public static int vidas = 3;
	public static int pontos = 0;

	public static void ComecaJogo () {
		vidas = 3;
		pontos = 0;
	}
}
