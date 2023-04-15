using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask obstacle;
    public float tileSize = 1f;

    private Vector3 lastDirection;
    public GameObject Pacman;

    // Start is called before the first frame update
    void Start()
    {
        lastDirection = Vector3.up; // start moving up
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            UpdateDestinationTile();
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        transform.rotation = movePoint.rotation;
    }

    private void UpdateDestinationTile()
    {
        Vector3 upTile = movePoint.position + new Vector3(0f, tileSize, 0f);
        Vector3 rightTile = movePoint.position + new Vector3(tileSize, 0f, 0f);
        Vector3 downTile = movePoint.position + new Vector3(0f, -tileSize, 0f);
        Vector3 leftTile = movePoint.position + new Vector3(-tileSize, 0f, 0f);

        if (lastDirection != Vector3.down && !Physics2D.OverlapCircle(upTile, 0.2f, obstacle))
        {
            movePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            movePoint.position = upTile;
            lastDirection = Vector3.up;
        }
        else if (lastDirection != Vector3.right && !Physics2D.OverlapCircle(leftTile, 0.2f, obstacle))
        {
            movePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
            movePoint.position = leftTile;
            lastDirection = Vector3.left;
        }
        else if (lastDirection != Vector3.up && !Physics2D.OverlapCircle(downTile, 0.2f, obstacle))
        {
            movePoint.rotation = Quaternion.Euler(0f, 0f, 180);
            movePoint.position = downTile;
            lastDirection = Vector3.down;
        }
        else if (lastDirection != Vector3.left && !Physics2D.OverlapCircle(rightTile, 0.2f, obstacle))
        {
            movePoint.rotation = Quaternion.Euler(0f, 0f, -90f);
            movePoint.position = rightTile;
            lastDirection = Vector3.right;
        }
    }
}
