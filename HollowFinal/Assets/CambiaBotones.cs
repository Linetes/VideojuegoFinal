using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CambiaBotones : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        if (scene == "Salir")
            Application.Quit();
        SceneManager.LoadScene(scene);
        
    }
}