using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    const string MAINSCENE = "Main";

    public void GoToMainScene()
    {
        ChangeScene(MAINSCENE);
    }


    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
