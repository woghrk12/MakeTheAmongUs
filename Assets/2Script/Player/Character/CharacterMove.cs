using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Animator anim;
    private Rigidbody2D rigid;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //MoveByMouse();
        MoveByKeyboard();
    }

    private void SetWalkAnimation( bool value)
    {
        anim.SetBool("isWalk", value);
    }

    private void MoveByMouse()
    {
        bool isWalk = Input.GetMouseButton(0);

        Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)).normalized;
        
        if (isWalk)
        {
            transform.position += dir * speed * Time.deltaTime;
        }
        
        SetWalkAnimation(isWalk);
    }

    private void MoveByKeyboard()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isWalk = horizontal != 0 || vertical != 0;

        Vector3 dir = Vector3.ClampMagnitude(new Vector3(horizontal, vertical, 0f), 1f);

        if(isWalk)
        {
            transform.position += dir * speed * Time.deltaTime;
        }

        SetWalkAnimation(isWalk);
    }

    
}
