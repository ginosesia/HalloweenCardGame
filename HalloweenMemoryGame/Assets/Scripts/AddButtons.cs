using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtons : MonoBehaviour
{

    [SerializeField] private Transform gameBoard;
    [SerializeField] private GameObject cardButton;

    [SerializeField] private RuntimeAnimatorController newController;



    private void Awake()
    {
        for(int i = 0; i < Global.level; i++)
        {
            GameObject button = Instantiate(cardButton);
            button.name = $"{i}";
            button.transform.SetParent(gameBoard, false);
            var buttonAnimator = button.GetComponent<Animator>();
            buttonAnimator.runtimeAnimatorController = newController;

            if (Global.level == Global.HARD_LEVEL)
            {
                gameBoard.GetComponent<GridLayoutGroup>().cellSize = new Vector2(120, 150);
            }
        }
    }
}