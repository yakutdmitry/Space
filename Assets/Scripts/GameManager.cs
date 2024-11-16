using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int batteryCount = 0;

    void Update()
    {
        if(batteryCount >= 3)
        {
            //do something
        }

        if(batteryCount < 3)
        {
            //do something
        }
    }
}
