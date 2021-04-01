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
        if (degreeOfVisibility < 0)
        {
            DeckManager.Indicators[] indicators = rightChoice.indicatorsWhichChanged;
            Indicator.changeSignState[] states = rightChoice.statesOfChangedIndicators;

            for (int i = 0; i < indicators.Length; i++)
                this.indicators[(int)indicators[i]].SetChangeSign(degreeOfVisibility, states[i]);
        }
        else
        {
            DeckManager.Indicators[] indicators = leftChoice.indicatorsWhichChanged;
            Indicator.changeSignState[] states = leftChoice.statesOfChangedIndicators;

            for (int i = 0; i < indicators.Length; i++)
                this.indicators[(int)indicators[i]].SetChangeSign(degreeOfVisibility, states[i]);
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
}
