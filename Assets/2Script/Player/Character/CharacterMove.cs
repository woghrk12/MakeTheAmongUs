using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMovable = true;

    public bool IsMovable
    { 
        set
        {
            isMovable = value;
            if (!isMovable) SetWalkAnimation(isMovable);
        }
        get
        {
            return isMovable;
        }
    }

    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private PhotonView PV;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PV = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (PV.IsMine && isMovable)
        {
            Move();
        }
    }

    private void Move()
    {
        switch (PlayerSetting.controlMode)
        {
            case EControlMode.Mouse:
                MoveByMouse();
                break;

            case EControlMode.Keyboard:
                MoveByKeyboard();
                break;
        }
    }

    private void SetWalkAnimation(bool value)
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
            PV.RPC("ChangeFlipXRPC", RpcTarget.AllBufferedViaServer, dir);
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
            PV.RPC("ChangeFlipXRPC", RpcTarget.AllBufferedViaServer, dir);
        }

        SetWalkAnimation(isWalk);
    }

    [PunRPC]
    private void ChangeFlipXRPC(Vector3 dir)
    {
        bool curFlipX = spriteRenderer.flipX;
        spriteRenderer.flipX = (dir.x != 0) ? (dir.x < 0) : curFlipX;
    }
}
