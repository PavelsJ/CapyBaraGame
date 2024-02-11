using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    
    public float speed;
    public InputActionReference move;
    public Animator anim;
    private bool isFacingRight = false;

    void Start()
    {
        speed = 5f;
    }

    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        
        Vector3 movementDirection = move.action.ReadValue<Vector2>();
        anim.SetFloat("Speed", Mathf.Abs(movementDirection.x));
        movementDirection.Normalize();
        
        Vector3 newPosition = transform.position + new Vector3(movementDirection.x, movementDirection.y, 0f) * speed * Time.deltaTime;
        transform.position = newPosition;
        
        Flip(movementDirection.x);
    }
    
    private void Flip(float horizontalInput)
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

