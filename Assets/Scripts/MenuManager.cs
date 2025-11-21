using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("Inicio");
    }

    // Update is called once per frame
    public void SalirGame()
    {
        Debug.Log("salir..");
        Application.Quit();
    }
}
