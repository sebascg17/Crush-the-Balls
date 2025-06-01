using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform player; // Asigna el jugador en el Inspector
    private float fixedY;
    public float offsetZ = 5f; // Distancia fija en el eje Z 

    void Start ()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.Find("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogError("Player not found.");
        }

        fixedY = transform.position.y; // Mantener altura constante
    }

    void LateUpdate ()
    {
        if (player == null) return;

        Vector3 newPosition = new Vector3(player.position.x, fixedY, player.position.z + offsetZ);
        transform.position = newPosition;
    }
}

