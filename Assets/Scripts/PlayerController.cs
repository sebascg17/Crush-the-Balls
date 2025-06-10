using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1000f;
    private float zBound = 10;
    private float xBound = 18;
    private bool onGround = true; // Comienza en el suelo
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;

    void Start ()
    {
        playerRb = GetComponent<Rigidbody>(); 
    }

    void Update ()
    {
        MovePlayer();
        JumpPlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontalInput, 0, verticalInput);

        playerRb.AddForce(movimiento * moveSpeed, ForceMode.Force);
        //transform.Translate(movimiento * moveSpeed * Time.deltaTime);
    }

    void JumpPlayer ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //onGround = false; // Suponemos que deja el suelo al saltar
    }

    void ConstrainPlayerPosition ()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.x);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.x);
        }
    }



    private void OnCollisionEnter ( Collision collision )
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            AudioSource enemyAudio = collision.gameObject.GetComponent<AudioSource>();
            if (enemyAudio != null)
            {
                enemyAudio.Play();
            }
            // Aquí puedes agregar lógica para manejar colisiones con obstáculos
            Debug.Log("Colisión con Enemigo detectada.");
        }
    }

    private void OnCollisionExit ( Collision collision )
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
    private void OnTriggerEnter ( Collider other )
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            AudioSource powerupAudio = other.gameObject.GetComponent<AudioSource>();
            if (powerupAudio != null)
            {
                powerupAudio.Play();
            }

            // Espera un poco antes de destruir para que el sonido se escuche
            Destroy(other.gameObject, 0.1f);
        }
    }
}
