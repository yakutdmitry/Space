using UnityEngine;

public class BatteryKey : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Movable")
        {
            gameManager.batteryCount += 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Movable")
        {
            if(col.tag == "Movable")
            {
                gameManager.batteryCount -= 1;
            }
        }
    }
}
