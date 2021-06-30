using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private Transform dotOne;
    [SerializeField] private Transform dotTwo;
    private Vector3 originalDotOnePos;
    private Vector3 originalDotTwoPos;
    private Vector3 originalPos;

    void Start()
    {
        originalDotOnePos = dotOne.localPosition;
        originalDotTwoPos = dotTwo.localPosition;
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        dotMove();
    }

    private Vector2 m_Move;

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
        // print(m_Move);
    }

    private void dotMove()
    {

        Vector2 move = new Vector2();

        move.y = 0;
        move.x = (m_Move.x > 0) ? m_Move.x : (m_Move.x*2);
        dotOne.localPosition = originalDotOnePos - (Vector3)move * speed;
        dotTwo.localPosition = originalDotTwoPos + (Vector3)move * speed;

        move.y = 0;
        move.x = m_Move.y;
        transform.localPosition = originalPos + (Vector3)move * speed;

    
}
}
