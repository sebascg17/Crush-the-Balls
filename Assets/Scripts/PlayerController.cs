using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1000f;
    private float zBound = 10;
    private bool onGround = true; // Comienza en el suelo
    private Rigidbody playerRb;

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontalInput, 0, verticalInput);
        //transform.Translate(movimiento * moveSpeed * Time.deltaTime);

        playerRb.AddForce(movimiento * moveSpeed, ForceMode.Force);
        //playerRb.AddForce(Vector3.forward * moveSpeed * verticalInput);
        //playerRb.AddForce(Vector3.right * moveSpeed * horizontalInput);
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
    }



    private void OnCollisionEnter ( Collision collision )
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
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
            Destroy(other.gameObject);
            // Aquí puedes agregar lógica para manejar la recogida de power-ups
            Debug.Log("Power-up recogido.");
        }
    }
}
