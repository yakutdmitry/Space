using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
                Debug.Log("Box Detected");
            }

        }

        Debug.DrawRay(RayOrigin, rayDirection * rayDistance, Color.red);
    }
}
