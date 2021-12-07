using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 mousePos;
    public float moveSpeed;
    public Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
       // Vector3 _input = new Vector3()
        if (Input.GetMouseButton(0)) {

            
            //Debug.Log("GREEEEEN");
            mousePos = Input.mousePosition;
            _rigidbody.MovePosition(mousePos);
            //mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            // this.transform.position = Vector2.Lerp(this.transform.position, mousePos, moveSpeed);
        }
    }
}
