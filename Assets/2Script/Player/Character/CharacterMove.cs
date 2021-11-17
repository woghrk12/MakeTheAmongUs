using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        MoveByMouse();
    }

    private void MoveByMouse()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)).normalized;
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}
