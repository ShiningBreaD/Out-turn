using UnityEngine;
using UnityEngine.UI;

public class TimeState : MonoBehaviour
{
    private int year = 2000;
    private int daysInPower = 1;

    [SerializeField] private Text yearUI;
    [SerializeField] private Text daysInPowerUI;

    private enum TimeType { days = 0, years = 1 }

    public void IncreaseDaysInPower(int addedDays)
    {
        int addedYears = 0;

        daysInPower += addedDays;
        addedYears += (daysInPower - addedYears * 365) / 365;
        year += addedYears;

        yearUI.text = year + "";

        if (addedYears == 1)
        {
            daysInPowerUI.text = addedYears + " year and " +  (daysInPower - addedYears * 365) + " days in power";
            return;
        }
        else if (addedYears > 0)
        {
            daysInPowerUI.text = addedYears + " years and " + (daysInPower - addedYears * 365) + " days in power";
        }
        else
        {
            daysInPowerUI.text = daysInPower + " days in power";
        }
    }
}
