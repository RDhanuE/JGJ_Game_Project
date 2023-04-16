using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask obstacle, Floor_Crossroad;
    public float tileSize = 1f;
    private Vector3 lastDirection;
    public GameObject Pacman;
    // Start is called before the first frame update
    void Start()
    {
        lastDirection = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            Vector3 upTile = movePoint.position + new Vector3(0f, tileSize, 0f);
            Vector3 rightTile = movePoint.position + new Vector3(tileSize, 0f, 0f);
            Vector3 downTile = movePoint.position + new Vector3(0f, -tileSize, 0f);
            Vector3 leftTile = movePoint.position + new Vector3(-tileSize, 0f, 0f);
            
            if (Physics2D.OverlapPoint(transform.position, Floor_Crossroad)){
                if (lastDirection == Vector3.up || lastDirection == Vector3.down){
                    if(transform.position.x >= Pacman.transform.position.x && !Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), 0.2f, obstacle)){
                        movePoint.position = leftTile;
                        lastDirection = Vector3.left;
                    }
                    else if(transform.position.x < Pacman.transform.position.x && !Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), 0.2f, obstacle)){
                        movePoint.position = rightTile;
                        lastDirection = Vector3.right;
                    }
                    else if(lastDirection == Vector3.down){
                        movePoint.position = downTile;
                        lastDirection = Vector3.down;
                    }
                    else if(lastDirection == Vector3.up){
                        movePoint.position = upTile;
                        lastDirection = Vector3.up;
                    }
                }
                else if (lastDirection == Vector3.right || lastDirection == Vector3.left){
                    if(transform.position.y >= Pacman.transform.position.y && !Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 1), 0.2f, obstacle)){
                        movePoint.position = downTile;
                        lastDirection = Vector3.down;
                    }
                    else if(transform.position.y < Pacman.transform.position.y && !Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + 1), 0.2f, obstacle)){
                        movePoint.position = upTile;
                        lastDirection = Vector3.up;
                    }
                    else if(lastDirection == Vector3.right){
                        movePoint.position = rightTile;
                        lastDirection = Vector3.right;
                    }
                    else if(lastDirection == Vector3.left){
                        movePoint.position = leftTile;
                        lastDirection = Vector3.left;
                    }
                }
            } else {
            UpdateDestinationTile(upTile, leftTile, downTile, rightTile);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    private void UpdateDestinationTile(Vector3 upTile, Vector3 leftTile, Vector3 downTile, Vector3 rightTile)
    {
        if (lastDirection != Vector3.down && !Physics2D.OverlapCircle(upTile, 0.2f, obstacle))
        {
            movePoint.position = upTile;
            lastDirection = Vector3.up;
        }
        else if (lastDirection != Vector3.right && !Physics2D.OverlapCircle(leftTile, 0.2f, obstacle))
        {
            movePoint.position = leftTile;
            lastDirection = Vector3.left;
        }
        else if (lastDirection != Vector3.up && !Physics2D.OverlapCircle(downTile, 0.2f, obstacle))
        {
            movePoint.position = downTile;
            lastDirection = Vector3.down;
        }
        else if (lastDirection != Vector3.left && !Physics2D.OverlapCircle(rightTile, 0.2f, obstacle))
        {
            movePoint.position = rightTile;
            lastDirection = Vector3.right;
        }
    }
}
