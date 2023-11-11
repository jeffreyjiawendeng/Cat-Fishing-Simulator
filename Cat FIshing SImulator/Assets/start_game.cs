using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script is executing");
        // PlayGame();
    }
    public void ButtonPressed(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}
