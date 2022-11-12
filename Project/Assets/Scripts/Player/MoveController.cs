using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float speed, moveSpeed = 4.5f;
    private float runSpeed;
    public Vector3 movePoint, axisRaw, axisFloat;
    public Animator animator;
    public LayerMask collidableLayer;

    private void Start()
    {
        runSpeed = 2 * moveSpeed;
        movePoint = transform.position;
    }

    private void FixedUpdate()
    {
        animator.SetBool("isMoving", transform.position != movePoint);
        animator.SetBool("isRunning", axisRaw.z == 1 && animator.GetBool("isMoving"));
        if (axisFloat.magnitude >= .9f || transform.position != movePoint || axisRaw.z == 1) 
        {
            Move();
        } 
        else LookAround();
        axisRaw = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Fire1"));
        axisFloat = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Move()
    {
        speed = axisRaw.z == 1 ? runSpeed : moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);
        if (transform.position.Equals(movePoint))
        {
            if (Mathf.Abs(axisRaw.y) == 1)
            {
                animator.SetFloat("Vertical", axisFloat.y);
                animator.SetFloat("Horizontal", 0);
                if (!Physics2D.OverlapCircle(movePoint + new Vector3(0f, axisRaw.y - .5f, 0f), .2f, collidableLayer))
                {
                    movePoint += new Vector3(0f, axisRaw.y, 0f);
                }
            }
            else if (Mathf.Abs(axisRaw.x) == 1)
            {
                animator.SetFloat("Horizontal", axisFloat.x);
                animator.SetFloat("Vertical", 0);
                if (!Physics2D.OverlapCircle(movePoint + new Vector3(axisRaw.x, -.5f, 0f), .2f, collidableLayer))
                {
                    movePoint += new Vector3(axisRaw.x, 0f, 0f);
                }
            }
        }
    }

    private void LookAround()
    {
        if (axisFloat.magnitude >= .01f)
        {
            animator.SetFloat("Horizontal", axisFloat.x);
            animator.SetFloat("Vertical", axisFloat.y);
        }
    }
}