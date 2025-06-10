using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 20f; // Speed of the object
    //private PlayerController playerControllerScript;
    private float leftBound = -80f; // Left boundary for the object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        

        if (transform.position.z < leftBound && gameObject.CompareTag("Arboles"))
        {
            Destroy(gameObject);
        }
    }
}