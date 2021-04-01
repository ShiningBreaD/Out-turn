using UnityEngine;

public class CardSetUpManager : MonoBehaviour
{
    [SerializeField] private string leftSwipeChoice, rightSwipeChoice;
    [SerializeField] private string description;
    [SerializeField] private string speakerName;
    [SerializeField] private int daysOfExecution;
    [SerializeField] private Sprite npc;
    public ChangedIndicatorsInfo leftChoice;
    public ChangedIndicatorsInfo rightChoice;

    public void SetUpCard(CardInteractionManager cardInteractionManager)
    {
        cardInteractionManager.leftSwipeChoice.text = leftSwipeChoice;
        cardInteractionManager.rightSwipeChoice.text = rightSwipeChoice;
        cardInteractionManager.description.text = description;
        cardInteractionManager.speakerName.text = speakerName;
        cardInteractionManager.npc.sprite = npc;
    }
}
