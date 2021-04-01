using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    [SerializeField] private Image changeSign;
    [SerializeField] private Image filler;

    private bool isAnimationRun;
    private float totalValueOfFiller;

    public enum changeSignState { small = 0, large = 1 }

    private void Update()
    {
        if (isAnimationRun)
            Animate();
    }

    public void SetChangeSign(float degreeOfVisibility, changeSignState state)
    {
        changeSign.color = new Color(changeSign.color.r, changeSign.color.g, changeSign.color.b, Mathf.Abs(degreeOfVisibility));

        if (state == changeSignState.small)
            changeSign.transform.localScale = new Vector3(0.6f, 0.6f, 1);
        else
            changeSign.transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    public void SetFiller(float addNumber)
    {
        totalValueOfFiller = filler.fillAmount + addNumber;
        isAnimationRun = true;
    }

    private void Animate()
    {
        filler.fillAmount = Mathf.Lerp(filler.fillAmount, totalValueOfFiller, Time.deltaTime * 3);
        if (Mathf.Approximately(filler.fillAmount, totalValueOfFiller))
            isAnimationRun = false;
    }
}
