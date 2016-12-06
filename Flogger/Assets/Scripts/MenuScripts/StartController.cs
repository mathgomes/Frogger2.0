using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

    // Carrega a cena do jogo pelo indice apresentado na build
    public void LoadByIndex( int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
