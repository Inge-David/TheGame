using System.Collections;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().SetGanaste(true);
        }
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
