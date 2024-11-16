using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int batteryCount = 0;
    public int finalBatteryCount = 0;
    public GameObject teleporter;
    public GameObject finalTeleporter;

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
        
        if(finalBatteryCount >= 2)
        {
            finalTeleporter.SetActive(true);
        }

        if(finalBatteryCount < 2)
        {
            finalTeleporter.SetActive(false);
        }
    }
}
