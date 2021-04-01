using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardInteractionManager : MonoBehaviour
{
    private DeckManager deckManager;
    [SerializeField] private CardSetUpManager cardSetUpManager;
    [SerializeField] private bool isGameOverCard;

    public Text leftSwipeChoice, rightSwipeChoice;
    public Text description;
    public Text speakerName;
    public Image npc;

    private void Start()
    {
        deckManager = DeckManager.Instance;

        if (!isGameOverCard)
            cardSetUpManager = deckManager.GetNextCard();
        cardSetUpManager.SetUpCard(this);
    }

    public void ConfirmChoice(bool isChoiceLeft)
    {
        if (!isGameOverCard)
        {
            if (isChoiceLeft)
                deckManager.SetFillersOfIndicators(cardSetUpManager.leftChoice);
            else
                deckManager.SetFillersOfIndicators(cardSetUpManager.rightChoice);

            deckManager.timeState.IncreaseDaysInPower(cardSetUpManager.GetDaysOfExecution());

            cardSetUpManager = deckManager.GetNextCard();
            cardSetUpManager.SetUpCard(this);
            deckManager.SetChangeSighOfIndicatorsToZero();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ChangeUIVisibility(float degreeOfVisibility)
    {
        if (!isGameOverCard)
        {
            ChangeSwipeChoicesVisibility(degreeOfVisibility);
            ChangeIndicatorsVisibility(degreeOfVisibility);
        }
    }

    private void ChangeSwipeChoicesVisibility(float degreeOfVisibility)
    {
        if (degreeOfVisibility <= 0)
        {
            rightSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, Mathf.Abs(degreeOfVisibility));
            leftSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, 0);

            Outline outline = rightSwipeChoice.GetComponent<Outline>();
            outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, Mathf.Abs(degreeOfVisibility));
        }
        else
        {
            leftSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, degreeOfVisibility); ;
            rightSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, 0);

            Outline outline = rightSwipeChoice.GetComponent<Outline>();
            outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, degreeOfVisibility);
        }
    }

    private void ChangeIndicatorsVisibility(float degreeOfVisibility)
    {
        deckManager.SetChangeSignOfIndicators(degreeOfVisibility, cardSetUpManager.leftChoice, cardSetUpManager.rightChoice);
    }
}
