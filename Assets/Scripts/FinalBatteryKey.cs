using UnityEngine;

public class FinalBatteryKey : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Movable")
        {
            gameManager.finalBatteryCount += 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Movable")
        {
            if (col.tag == "Movable")
            {
                gameManager.finalBatteryCount -= 1;
            }
        }
    }
}

