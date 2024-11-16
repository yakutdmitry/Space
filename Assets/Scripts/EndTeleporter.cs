using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTeleporter : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }    
    }
   
}
