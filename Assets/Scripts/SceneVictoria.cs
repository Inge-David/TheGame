using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneVictoria : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.GetComponent<PlayerController>().GetGanaste() == true)
        {
            newScene("Victory");
        }
        
    }

    public void newScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
