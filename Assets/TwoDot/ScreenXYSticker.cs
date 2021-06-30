using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.InputSystem.Layouts;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class ScreenXYSticker : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    private int moveDirection = 0;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));
        moveDirection = 0;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out m_PointerDownPos);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out var position);
        var delta = position - m_PointerDownPos;
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) && moveDirection == 0)
        {
            moveDirection = 1;
        }
        if (Mathf.Abs(delta.x) < Mathf.Abs(delta.y) && moveDirection == 0)
        {
            moveDirection = -1;
        }

        if (moveDirection < 0)
        {
            delta = Vector2.ClampMagnitude(delta, movementRange);
            var newPos = new Vector2(0, delta.y);
            ((RectTransform)transform).anchoredPosition = m_StartPos + (Vector3)newPos;
            SendValueToControl(newPos / movementRange);
        }
        else
        {
            delta = Vector2.ClampMagnitude(delta, movementRange);
            var newPos = new Vector2(delta.x, 0);
            ((RectTransform)transform).anchoredPosition = m_StartPos + (Vector3)newPos;
            SendValueToControl(newPos / movementRange);
        }



    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ((RectTransform)transform).anchoredPosition = m_StartPos;
        SendValueToControl(Vector2.zero);
        moveDirection = 0;
    }

    private void Start()
    {
        m_StartPos = ((RectTransform)transform).anchoredPosition;
    }

    public float movementRange
    {
        get => m_MovementRange;
        set => m_MovementRange = value;
    }

    [FormerlySerializedAs("movementRange")]
    [SerializeField]
    private float m_MovementRange = 50;

    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string m_ControlPath;

    private Vector3 m_StartPos;
    private Vector2 m_PointerDownPos;

    protected override string controlPathInternal
    {
        get => m_ControlPath;
        set => m_ControlPath = value;
    }
}

