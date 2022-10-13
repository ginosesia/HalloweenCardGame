using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{

    [SerializeField] private Transform gameBoard;
    [SerializeField] private GameObject cardButton;



    private void Awake()
    {
        for(int i = 0; i < Global.level; i++)
        {
            GameObject button = Instantiate(cardButton);
            button.name = $"{i}";
            button.transform.SetParent(gameBoard, false);
        }
    }
}
