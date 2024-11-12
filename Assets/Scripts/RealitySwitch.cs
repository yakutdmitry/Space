using System;
using UnityEngine;

public class RealitySwitch : MonoBehaviour
{
    [SerializeField] private bool _order;
    [SerializeField] private GameObject _reality1;
    [SerializeField] private GameObject _reality2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchReality();
        }
    }

    private void SwitchReality()
    {
        if (_order)
        {
            _reality1.SetActive(true);
            _reality2.SetActive(false);
            _order = false;
        }
        else if(!_order)
        {
            _order = true;
            _reality1.SetActive(false);
            _reality2.SetActive(true);
        }
    }
}
