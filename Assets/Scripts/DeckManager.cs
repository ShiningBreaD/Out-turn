using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance { get; set; }

    [SerializeField] private Indicator[] indicators;
    [SerializeField] private CardSetUpManager[] setUps;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    public enum Indicators { Ecology = 0, Finans = 1, Socium = 2, Collaboration = 3 }

    public CardSetUpManager GetRandomCardSetUp()
    {
        int index = Random.Range(0, setUps.Length);
        return setUps[index];
    }

    public void SetChangeSignOfIndicators(float degreeOfVisibility, ChangedIndicatorsInfo leftChoice, ChangedIndicatorsInfo rightChoice)
    {
        DeckManager.Indicators[] rightIndicators = rightChoice.indicatorsWhichChanged;
        Indicator.ChangeSignState[] rightStates = rightChoice.statesOfChangedIndicators;

        DeckManager.Indicators[] leftIndicators = leftChoice.indicatorsWhichChanged;
        Indicator.ChangeSignState[] leftStates = leftChoice.statesOfChangedIndicators;

        if (degreeOfVisibility <= 0)
        {
            for (int i = 0; i < rightIndicators.Length; i++)
            {
                this.indicators[(int)rightIndicators[i]].SetChangeSign(degreeOfVisibility, rightStates[i]);
            }

            if (degreeOfVisibility < 0)
                for (int i = 0; i < leftIndicators.Length; i++)
                    if (leftIndicators[i] != rightIndicators[i])
                        this.indicators[(int)leftIndicators[i]].SetChangeSign(0, leftStates[i]);
        }

        if (degreeOfVisibility >= 0)
        {
            for (int i = 0; i < leftIndicators.Length; i++)
            {
                this.indicators[(int)leftIndicators[i]].SetChangeSign(degreeOfVisibility, leftStates[i]);
            }

            if (degreeOfVisibility > 0)
                for (int i = 0; i < rightIndicators.Length; i++)
                    if (leftIndicators[i] != rightIndicators[i])
                        this.indicators[(int)rightIndicators[i]].SetChangeSign(0, rightStates[i]);
        }
    }

    public void SetFillersOfIndicators(ChangedIndicatorsInfo confirmedChoice)
    {
        DeckManager.Indicators[] indicators = confirmedChoice.indicatorsWhichChanged;
        float[] addedNumbers = confirmedChoice.addedNumbers;

        for (int i = 0; i < indicators.Length; i++)
        {
            this.indicators[(int)indicators[i]].SetFiller(addedNumbers[i]);
        }
    }

    public void SetChangeSighOfIndicatorsToZero()
    {
        for (int  i = 0; i < indicators.Length; i++)
        {
            indicators[i].SetChangeSignToZero();
        }
    }
}
