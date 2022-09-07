using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] MovementSO movement;

    private Rigidbody2D rigid;

    float curVelocity = 0;
    Vector2 curDirection;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Movement(Vector2 input)
    {
        if (input.sqrMagnitude > 0)
        {
            if (Vector2.Dot(input, curDirection) < 0)
            {
                curVelocity = 0;
            }
            curDirection = input.normalized;
        }
        curVelocity = CalculateSpeed(input);
    }

    private float CalculateSpeed(Vector2 moveInput)
    {
        if (moveInput.sqrMagnitude > 0)
        {
            curVelocity += movement.accel * Time.deltaTime;
        }
        else
        {
            curVelocity -= movement.deAccel * Time.deltaTime;
        }

        return Mathf.Clamp(curVelocity, 0, movement.speed);
    }

    private void FixedUpdate()
    {
        rigid.velocity = curDirection * curVelocity;
    }

    public void StopImmediatelly()
    {
        curVelocity = 0;
        rigid.velocity = Vector2.zero;
    }


}
