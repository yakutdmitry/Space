using System;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private Transform holdPoint;
    private GameObject heldObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("BUTTON PRESSED");
            if (heldObject == null)
            {
                Debug.Log("its null");
                MoveObject();
            }
            else
            {
                Debug.Log("else");
                DropObject();
            }
        }
        
    }
    
    private void MoveObject()
    {
        Camera camera = Camera.main;

        Vector3 RayOrigin = camera.transform.position;
        Vector3 rayDirection = camera.transform.forward;

        Ray ray = new Ray(RayOrigin, rayDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Movable"))
            {
                Debug.Log("Detected");
                heldObject = hit.collider.gameObject;
                heldObject.transform.SetParent(holdPoint);
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        Debug.DrawRay(RayOrigin, rayDirection * rayDistance, Color.red);
        
    }

    private void DropObject()
    {
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
    }
}
