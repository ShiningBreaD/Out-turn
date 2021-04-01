using UnityEngine;
using UnityEngine.UI;

public class CardInteractionManager : MonoBehaviour
{
    private DeckManager deckManager;
    [SerializeField] private CardSetUpManager cardSetUpManager;

    public Text leftSwipeChoice, rightSwipeChoice;
    public Text description;
    public Text speakerName;
    public Image npc;

    private void Start()
    {
        deckManager = DeckManager.Instance;

        cardSetUpManager = deckManager.GetRandomCardSetUp();
        cardSetUpManager.SetUpCard(this);
    }

    public void ConfirmChoice(bool isChoiceLeft)
    {
        if (isChoiceLeft)
            deckManager.SetFillersOfIndicators(cardSetUpManager.leftChoice);
        else
            deckManager.SetFillersOfIndicators(cardSetUpManager.rightChoice);
    }

    public void ChangeUIVisibility(float degreeOfVisibility)
    {
        ChangeSwipeChoicesVisibility(degreeOfVisibility);

        ChangeIndicatorsVisibility(degreeOfVisibility);
    }

    private void ChangeSwipeChoicesVisibility(float degreeOfVisibility)
    {
        if (degreeOfVisibility <= 0)
        {
            rightSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, Mathf.Abs(degreeOfVisibility));
            leftSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, 0);
        }
        else
        {
            leftSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, degreeOfVisibility);
            rightSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, 0);
        }
    }

    private void ChangeIndicatorsVisibility(float degreeOfVisibility)
    {
        deckManager.SetChangeSignOfIndicators(degreeOfVisibility, cardSetUpManager.leftChoice, cardSetUpManager.rightChoice);
    }
}
