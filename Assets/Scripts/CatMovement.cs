using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField]private int jarakPandang;
    public float speed = 5f;
    public Transform movePoint;
    public LayerMask obstacle, Floor_Crossroad;
    private Vector2 dest = Vector2.zero;
    public float tileSize = 1f;
    [SerializeField]private int currentState = 0;
    [SerializeField]private int lastState = 0;
    [SerializeField]private Vector2 lastPos = new Vector2();
    [SerializeField]List<int> dirAvailable = new List<int>();
    private Vector2 upTile, rightTile, downTile, leftTile;

    private void Start() {
        jarakPandang = 3;
        // Debug.Log(PossibleDir()[0] + ", " + PossibleDir()[1]);
        dest = (Vector2)transform.position;
    }
    private void Update() {
        // meetDog(Vector2.up);
        // Debug.DrawLine((Vector2)transform.position + Vector2.up, (Vector2)transform.position + jarakPandang*Vector2.up, Color.red);
        
        if (Vector2.Distance(transform.position, movePoint.position) <= 0.05f) {
            upTile = (Vector2)movePoint.position + new Vector2(0f, tileSize);
            rightTile = (Vector2)movePoint.position + new Vector2(tileSize, 0f);
            downTile = (Vector2)movePoint.position + new Vector2(0f, -tileSize);
            leftTile = (Vector2)movePoint.position + new Vector2(-tileSize, 0f);
            
            dirAvailable = PossibleDir(upTile, rightTile, downTile, leftTile);
            if (dirAvailable.Count > 2) {
                int a = currentState + 2;
                if (a > 3) {
                    a = 0;
                }
                dirAvailable.Remove(a);
                lastState = currentState;
                int x = Random.Range(0, dirAvailable.Count);
                movePoint.position = MovePointDirection(dirAvailable[x]);
                // Debug.DrawLine((Vector2)transform.position + Direction(x), (Vector2)transform.position + jarakPandang*Direction(x), Color.red);
                // Debug.DrawLine((Vector2)transform.position + (Vector2)movePoint.position, (Vector2)transform.position + jarakPandang*(Vector2)movePoint.position, Color.red);
            }
            else {
                if (IsValid(upTile) && currentState != 2) {
                    movePoint.position = upTile;
                    lastState = currentState;
                    currentState = 0;
                }
                else {
                    if (IsValid(rightTile) && currentState != 3) {
                        movePoint.position = rightTile;
                        lastState = currentState;
                        currentState = 1;
                    }
                    else {
                        if (IsValid(downTile) && currentState != 0) {
                            movePoint.position = downTile;
                            lastState = currentState;
                            currentState = 2;
                        }
                        else {
                            if (IsValid(leftTile) && currentState != 1) {
                                movePoint.position = leftTile;
                                lastState = currentState;
                                currentState = 3;
                            }
                        }
                    }
                }
            }
            
            if (MeetDog(Vector2.up)) {
                if (IsValid(downTile)) {
                    movePoint.position = downTile;
                    lastState = currentState;
                    currentState = 2;
                }
            }
            if (MeetDog(Vector2.right)) {
                if (IsValid(leftTile)) {
                    movePoint.position = leftTile;
                    lastState = currentState;
                    currentState = 3;
                }
            }
            if (MeetDog(Vector2.down)) {
                if (IsValid(upTile)) {
                    movePoint.position = upTile;
                    lastState = currentState;
                    currentState = 0;
                }
            }
            if (MeetDog(Vector2.left)) {
                if (IsValid(rightTile)) {
                    movePoint.position = rightTile;
                    lastState = currentState;
                    currentState = 1;
                }
            }
        }
        transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)movePoint.position, speed*Time.deltaTime);
    }
    private bool IsValid(Vector2 dir) {
        return !Physics2D.OverlapCircle(dir, 0.2f, obstacle);
    }
    private bool MeetDog(Vector2 dir) {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos + jarakPandang*dir);
        if (hit && hit.transform.tag == "Player") {
            Debug.Log((pos + jarakPandang*dir).ToString());
            Debug.Log("KETEMU PLAYER");
            return true;
        }
        return false;
    }
    private Vector2 MovePointDirection(int i) {
        if (i == 0) {
            currentState = 0;
            return (Vector2)movePoint.position + new Vector2(0f, tileSize);
        }
        else if (i == 1) {
            currentState = 1;
            return (Vector2)movePoint.position + new Vector2(tileSize, 0f);
        }
        else if (i == 2) {
            currentState = 2;
            return (Vector2)movePoint.position + new Vector2(0f, -tileSize);
        }
        else {
            currentState = 3;
            return (Vector2)movePoint.position + new Vector2(-tileSize, 0f);
        }
    }
    private Vector2 Direction(int i) {
        if (i == 0) {
            return Vector2.up;
        }
        else if (i == 1) {
            return Vector2.right;
        }
        else if (i == 2) {
            return Vector2.down;
        }
        else {
            return Vector2.left;
        }
    }
    private List<int> PossibleDir(Vector2 up, Vector2 right, Vector2 down, Vector2 left) {
        List<int> nextState = new List<int>() {0, 1, 2, 3};
        if (!IsValid(up)) {
            nextState.Remove(0);
        }
        if (!IsValid(right)) {
            nextState.Remove(1);
        }
        if (!IsValid(down)) {
            nextState.Remove(2);
        }
        if (!IsValid(left)) {
            nextState.Remove(3);
        }
        // Debug.Log(nextState.Count);
        return nextState;
    }
}
