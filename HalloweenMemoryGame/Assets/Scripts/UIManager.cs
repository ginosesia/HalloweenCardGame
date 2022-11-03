using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI score;


    private void Update()
    {
        score.text = $"It took you {Global.guessesCount} guesses to complete the game.";
    }


    public void LevelSelectButton()
    {
        SceneManager.LoadScene(Global.LEVEL_SELECT_SCENE);
    }

}
