using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int batteryCount = 0;
    public GameObject teleporter;

    void Update()
    {
        if(batteryCount >= 3)
        {
            teleporter.SetActive(true);
        }

        if(batteryCount < 3)
        {
            teleporter.SetActive(false);
        }
    }
}
