using UnityEngine;

public class Move2DObject : MonoBehaviour
{
    [SerializeField] private GameObject square;

    private float positionX, positionY;

    private void Update()
    {
        MoveWithFinger();
    }

    private void MoveWithFinger()
    {
        if (Input.GetMouseButton(0))
        {
            positionX = Input.mousePosition.x;
            positionY = Input.mousePosition.y;

            square.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(positionX, positionY, 0));

            square.transform.position = new Vector3(square.transform.position.x, square.transform.position.y + 0.7f, 0);
        }
    }

    private void MoveWithFinger3D()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * 4);
            }
        }
    }
}
