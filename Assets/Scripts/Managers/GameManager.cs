using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    const string TYCOON_SCENE = "Tycoon";

    public void GoToMainScene()
    {
        ChangeScene(TYCOON_SCENE);
    }


    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
