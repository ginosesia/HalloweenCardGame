using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(Global.LEVEL_SELECT_SCENE);
    }

}
