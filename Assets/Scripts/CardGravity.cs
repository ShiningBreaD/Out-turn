using UnityEngine;

public class CardGravity : MonoBehaviour
{
    [SerializeField] private float swingSpeed;

    public CardInteractionManager cardIndividuality;

    private Vector3 offset;
    private Vector3 defaultPosition;
    private float zRotation;
    private bool isCardAtDefaultPosition = true;
    private bool isChoiceLeft;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        if (isCardAtDefaultPosition)
            ReturnToDefaultPosition();
    }

    private void OnMouseDown()
    {
        isCardAtDefaultPosition = false;

        offset = transform.position - 
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    private void OnMouseDrag()
    {
        Vector3 desiredPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);

        zRotation = Mathf.Abs(transform.position.x * 6.5f);
        zRotation = SetDirectionOfRotation(zRotation);
        Quaternion desiredIncline = Quaternion.Euler(transform.position.x, transform.position.y, zRotation);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredIncline, Time.deltaTime * swingSpeed);
        transform.position = Camera.main.ScreenToWorldPoint(desiredPosition) + offset;
        cardIndividuality.ChangeUIVisibility(zRotation / 4);
    }

    private void OnMouseUp()
    {
        isCardAtDefaultPosition = true;

        if (Mathf.Abs(zRotation) >= 7.5f)
            cardIndividuality.ConfirmChoice(isChoiceLeft);
    }

    private void ReturnToDefaultPosition()
    {
        Quaternion defaultQuaternion = Quaternion.Euler(Vector3.zero);

        transform.position = Vector3.Lerp(transform.position, defaultPosition, Time.deltaTime * 6);
        transform.rotation = Quaternion.Lerp(transform.rotation, defaultQuaternion, Time.deltaTime * 6);
        cardIndividuality.ChangeUIVisibility(0);
    }

    private float SetDirectionOfRotation(float rotation)
    {
        rotation = transform.position.x <= 0 ? rotation : rotation * -1;

        if (transform.position.x <= 0)
        {
            isChoiceLeft = true;
        }
        else
        {
            isChoiceLeft = false;
        }

        return rotation;
    }
}
