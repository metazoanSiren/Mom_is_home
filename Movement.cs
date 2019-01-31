using System.Collections;
using UnityEngine;

public enum DIRECTION { UP, DOWN, LEFT, RIGHT}

public class Movement : MonoBehaviour {

    public Sprite south;
    public Sprite north;
    public Sprite east;
    public Sprite west;

    private bool canMove = true, moving = false;
    private int speed = 4, buttonCooldown = 0;
    private DIRECTION dir = DIRECTION.DOWN;
    private Vector3 pos;

    private void FixedUpdate()
    {
      
    }
    
	void Start () {	}
	
	// Update is called once per frame
	void Update () {
        buttonCooldown--;
        if (canMove)
        {
            pos = transform.position;
            Move();
        }

        if (moving)
        {
            if (transform.position == pos)
            {
                moving = false;
                canMove = true;

                Move();
            }
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }
	}

    private void Move()
    {
        if (buttonCooldown <= 0) {
            if (Input.GetKey(KeyCode.W))
            {         
                    if (dir != DIRECTION.UP)
                    {
                        buttonCooldown = 5;
                        dir = DIRECTION.UP;
                    }
                    else
                    {
                        canMove = false;
                        moving = true;
                        pos += Vector3.up;
                        gameObject.GetComponent<SpriteRenderer>().sprite = north;
                    }                
            }

           else if (Input.GetKey(KeyCode.S)) {
            
                    if (dir != DIRECTION.DOWN)
                    {
                        buttonCooldown = 5;
                        dir = DIRECTION.DOWN;
                    }
                    else
                    {
                        canMove = false;
                        moving = true;
                        pos += Vector3.down;
                        gameObject.GetComponent<SpriteRenderer>().sprite = south;
                    }         
            }
            else if (Input.GetKey(KeyCode.A))
            {
              
                    if (dir != DIRECTION.LEFT)
                    {
                        buttonCooldown = 5;
                        dir = DIRECTION.LEFT;
                    }
                    else
                    {
                        canMove = false;
                        moving = true;
                        pos += Vector3.left;
                        gameObject.GetComponent<SpriteRenderer>().sprite = west;
                    }
                      
            }
            else if (Input.GetKey(KeyCode.D))
            {
          
                    if (dir != DIRECTION.RIGHT)
                    {
                        buttonCooldown = 5;
                        dir = DIRECTION.RIGHT;
                    }
                    else
                    {
                        canMove = false;
                        moving = true;
                        pos += Vector3.right;
                        gameObject.GetComponent<SpriteRenderer>().sprite = east;
                    }
            }
        }
    }
}
