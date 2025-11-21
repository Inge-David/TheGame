using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 4f;

    public float jumpSpeed = 5f;

    public Animator animator;

    private Rigidbody2D rb;

    private bool isGrounded;

    private bool ganaste = false;

    public void SetGanaste(bool value)
    {
        ganaste = value;
    }

    public bool GetGanaste()
    {
        return ganaste;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal") ;

        animator.SetFloat("move", velocidadX * velocidad);

        if(velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 posicion = transform.position;

        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        animator.SetBool("ground", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
