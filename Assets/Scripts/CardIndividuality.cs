using UnityEngine;
using UnityEngine.UI;

public class CardIndividuality : MonoBehaviour
{
    private DeckManager deckManager;

    [SerializeField] public Text leftSwipeChoice, rightSwipeChoice;
    [SerializeField] private Text description;
    [SerializeField] private Text speakerName;
    [SerializeField] private ChangedIndicatorsInfo leftChoice;
    [SerializeField] private ChangedIndicatorsInfo rightChoice;

    private void Start()
    {
        deckManager = DeckManager.Instance;
    }

    public void ConfirmChoice(bool isChoiceLeft)
    {
        if (isChoiceLeft)
            deckManager.SetFillersOfIndicators(leftChoice);
        else
            deckManager.SetFillersOfIndicators(rightChoice);
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
        deckManager.SetChangeSignOfIndicators(degreeOfVisibility, leftChoice, rightChoice);
    }
}
