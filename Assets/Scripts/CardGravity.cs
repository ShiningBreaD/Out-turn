using UnityEngine;

public class CardGravity : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 defaultPosition;
    private bool isCardAtDefaultPosition = true;

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

        float zRotation = Mathf.Abs(transform.position.x * 5.5f);
        zRotation = SetDirectionOfRotation(zRotation);
        Quaternion desiredIncline = Quaternion.Euler(transform.position.x, transform.position.y, zRotation);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredIncline, Time.deltaTime * 3);
        transform.position = Camera.main.ScreenToWorldPoint(desiredPosition) + offset;
    }

    private void OnMouseUp()
    {
        isCardAtDefaultPosition = true;
    }

    private void ReturnToDefaultPosition()
    {
        Quaternion defaultQuaternion = Quaternion.Euler(Vector3.zero);

        transform.position = Vector3.Lerp(transform.position, defaultPosition, Time.deltaTime * 6);
        transform.rotation = Quaternion.Lerp(transform.rotation, defaultQuaternion, Time.deltaTime * 6);
    }

    private float SetDirectionOfRotation(float rotation)
    {
        return transform.position.x <= 0 ? rotation : rotation * -1;
    }
}
