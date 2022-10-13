using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{


    public void Back()
    {
        SceneManager.LoadScene(Global.MENU_SCENE);
    }


    public void EasyLevel()
    {
        SceneManager.LoadScene(Global.GAME_SCENE);
        Global.level = Global.EASY_LEVEL;
    }

    public void MediumLevel()
    {
        SceneManager.LoadScene(Global.GAME_SCENE);
        Global.level = Global.MEDIUM_LEVEL;

    }


    public void HardLevel()
    {
        SceneManager.LoadScene(Global.GAME_SCENE);
        Global.level = Global.HARD_LEVEL;

    }


}
