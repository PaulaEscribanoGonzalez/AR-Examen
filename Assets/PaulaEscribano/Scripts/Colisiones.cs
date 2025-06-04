using UnityEngine;
using UnityEngine.SceneManagement;

public class Colisiones : MonoBehaviour
{
    [Header("Menú UI que se muestra al entrar en una zona")]
    public GameObject menuUI;

    private int sceneIndex = -1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con: " + other.gameObject.name);

        if (other.gameObject.name == "Zona1")
        {
            sceneIndex = 1;
            menuUI.SetActive(true);
        }
        else if (other.gameObject.name == "Zona2")
        {
            sceneIndex = 2;
            menuUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Salida de colisión con: " + other.gameObject.name);

        if (other.gameObject.name == "Zona1" || other.gameObject.name == "Zona2")
        {
            menuUI.SetActive(false);
            sceneIndex = -1;
        }
    }

    // Cambia a la escena correspondiente (Zona1 = 1, Zona2 = 2)
    public void changeScene()
    {
        if (sceneIndex >= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("Índice de escena no válido. No se puede cambiar de escena.");
        }
    }

    // Vuelve siempre a la escena inicial (índice 0)
    public void returnToMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
