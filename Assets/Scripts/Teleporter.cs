using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject teleportPoint;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TELEPORTED");
        Player.transform.position = teleportPoint.transform.position;
    }
}
