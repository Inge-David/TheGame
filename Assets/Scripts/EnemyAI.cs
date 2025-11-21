using UnityEngine;

public class EnemyAI : MonoBehaviour

{
    public float radioBusqueda;
    public LayerMask capaPlayer;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float Speed = 2f;
    [SerializeField]
    private float Distance = 5f;
 
    private Rigidbody2D rb;

    private Vector2 puntoInicial;

    public bool mirandoDerecha;



    public Estados estadoActual;
    public enum Estados
    {
        Esperando,
        Siguiendo,
        Volviendo,
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        puntoInicial = transform.position;

    }

    // Update is called once per frame

    private void Update()
    {
        switch (estadoActual)
        {
            case Estados.Esperando:
                EstadoEsperando();
                break;
            case Estados.Siguiendo:
                EstadoSiguiendo();
                break;
            case Estados.Volviendo:
                EstadoVolviendo();
                break;
        }
    }
    private void EstadoEsperando()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaPlayer);
        if(playerCollider)
        {
            player = playerCollider.transform;

            estadoActual = Estados.Siguiendo;
        }
    }

    private void EstadoSiguiendo()
    {
        if(player == null)
        {
            estadoActual = Estados.Volviendo;
            return; 
        }

        transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);

        GirarObjetivo(player.position);
       
        if (Vector2.Distance(transform.position, puntoInicial) > Distance ||
                Vector2.Distance(transform.position, player.position) > Distance)
        {
            estadoActual = Estados.Volviendo;
            player = null;
        }
       
        
    }

    private void EstadoVolviendo()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntoInicial, Speed * Time.deltaTime);

        GirarObjetivo(puntoInicial);

        if(Vector2.Distance(transform.position, puntoInicial) < 0.1f)
        {
            estadoActual = Estados.Esperando;
        }
    }

    private void GirarObjetivo(Vector3 objetivo)
    {
        if(objetivo.x > transform.position.x && !mirandoDerecha)
        {
            Girar();
        }
        else if (objetivo.x < transform.position.x && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
        Gizmos.DrawWireSphere(puntoInicial, Distance);
    }





}

 
