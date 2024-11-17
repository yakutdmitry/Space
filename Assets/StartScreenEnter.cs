using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private string mainLevelSceneName = "Models test";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene(mainLevelSceneName); 
        }
    }
}
