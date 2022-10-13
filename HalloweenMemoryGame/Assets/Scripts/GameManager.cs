using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Sprite backgroundCardImage;

    public List<Button> cardButtonList = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        //Get all button in scene with tag 'Button'
        GetButtons();

    }


    private void GetButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag(Global.BUTTON_TAG);

        for (int i = 0; i < buttons.Length; i++)
        {
            cardButtonList.Add(buttons[i].GetComponent<Button>());
            cardButtonList[i].image.sprite = backgroundCardImage;
        }

    }


}
