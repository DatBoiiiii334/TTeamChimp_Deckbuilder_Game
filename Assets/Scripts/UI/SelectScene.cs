using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    public string sceneDestination;

    public void GoToScene()
    {
        if (sceneDestination != null)
        {
            SceneManager.LoadScene(sceneDestination);
        }
    }
}
