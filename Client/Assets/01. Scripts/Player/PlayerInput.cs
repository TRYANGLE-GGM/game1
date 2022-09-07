using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] UnityEvent<Vector2> OnMovementKey;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        OnMovementKey?.Invoke(new Vector2(x,y));
    }
}
