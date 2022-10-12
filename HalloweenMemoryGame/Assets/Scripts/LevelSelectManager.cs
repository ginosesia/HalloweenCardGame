using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{


    public void Back()
    {
        SceneManager.LoadScene(Global.MENU_SCENE);
    }

}
