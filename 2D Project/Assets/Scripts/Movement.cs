using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask obstacle;
    private bool isWalking;
    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, movePoint.position) == 0)
        {
            if (Input.GetAxisRaw("Horizontal") != 0f && Input.GetAxisRaw("Vertical") == 0f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, obstacle))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Input.GetAxisRaw("Vertical") != 0f && Input.GetAxisRaw("Horizontal") == 0f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, obstacle))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    if (Input.GetAxisRaw("Vertical") == -1){
                    }
                    else {
                    }
                }   
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        isWalking = transform.position != movePoint.position;
    }
    public bool IsWalking() {
        return isWalking;
    }
}
