using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Sprite backgroundCardImage;
    [SerializeField] private GameObject gameOverPanel;

    public List<Button> cardButtonList = new List<Button>();

    public Sprite[] pictures;

    public List<Sprite> cardButtons = new List<Sprite>();


    bool firstGuess, secondGuess;

    int correctGuessesCount;
    int gameGuesses;

    int firstGuessIndex, secondGuessIndex;
    string firstGuessCardName, secondGuessCardName;



    private void Awake()
    {
        pictures = Resources.LoadAll<Sprite>("Cards");
    }


    // Start is called before the first frame update
    void Start()
    {
        //Get all button in scene with tag 'Button'
        GetButtons();

        //Add Listeners
        AddCardListener();

        //Get Pictures
        GetPictures();

        Shuffle(cardButtons);

        //Get Matching pair count
        gameGuesses = Global.level / 2;

    }


    private void GetPictures()
    {
        int index = 0;

        for( int i = 0; i < Global.level; i++)
        {
            if(index == Global.level/2)
            {
                index = 0;
            }

            cardButtons.Add(pictures[index]);
            index++;

        }
    }


    private void AddCardListener()
    {
        foreach (Button card in cardButtonList)
        {
            card.onClick.AddListener(() => CardFlipped(card));
        }
    }


    private void CardFlipped(Button card)
    {

        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(card.name);
            firstGuessCardName = cardButtons[firstGuessIndex].name;
            cardButtonList[firstGuessIndex].image.sprite = cardButtons[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(card.name);
            secondGuessCardName = cardButtons[secondGuessIndex].name;
            cardButtonList[secondGuessIndex].image.sprite = cardButtons[secondGuessIndex];

            Global.guessesCount++;

            StartCoroutine(DealWithMatchingCards());
        }
    }



    IEnumerator DealWithMatchingCards()
    {
        yield return new WaitForSeconds(1.5f);

        if (firstGuessCardName == secondGuessCardName)
        {
            yield return new WaitForSeconds(1.5f);

            cardButtonList[firstGuessIndex].interactable = false;
            cardButtonList[secondGuessIndex].interactable = false;

            cardButtonList[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            cardButtonList[secondGuessIndex].image.color = new Color(0, 0, 0, 0);



            CheckIfGameIsComplete();

        }
        else
        {
            cardButtonList[firstGuessIndex].image.sprite = backgroundCardImage;
            cardButtonList[secondGuessIndex].image.sprite = backgroundCardImage;
        }

        yield return new WaitForSeconds(0.5f);

        firstGuess = false;
        secondGuess = false;

    }


    private void CheckIfGameIsComplete()
    {

        correctGuessesCount++;

        if (correctGuessesCount == gameGuesses)
        {
            gameOverPanel.SetActive(true);

        }

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


    private void Shuffle(List<Sprite> cardList)
    {
        for ( int i = 0; i < cardList.Count; i++)
        {
            Sprite tempCard = cardList[i];
            int randomInt = Random.Range(i, cardList.Count);
            cardList[i] = cardList[randomInt];
            cardList[randomInt] = tempCard;
        }
    }
}
