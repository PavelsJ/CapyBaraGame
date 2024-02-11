using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObject : MonoBehaviour
{
    public EnemyAI enemy;
    
    public float grabRadius = 0.5f;
    public Transform rayPosition;
    public Transform grabPosition;
    public LayerMask interactableLayer;
    public InputActionReference pickupAction;

    private GameObject heldObject;
    private bool isHolding = false;

    void Start()
    {
        pickupAction.action.Enable();
        pickupAction.action.started += _ => OnPickup();
    }
    
    void OnDisable()
    {
        pickupAction.action.Disable();
        pickupAction.action.started -= _ => OnPickup();
    }
    void OnPickup()
    {
        if (!isHolding)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(rayPosition.position, Vector2.right, grabRadius, interactableLayer);
            if (hitInfo.collider != null)
            {
                GameObject hitObject = hitInfo.collider.gameObject;
                HoldObject(hitObject);
            }
        }
        else if (isHolding)
        {
            DropObject();
        }
    }

    void HoldObject(GameObject obj)
    {
        heldObject = obj;
        Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        heldObject.transform.position = grabPosition.position;
        heldObject.transform.SetParent(transform);
        isHolding = true;
        
        enemy.StartChasingPlayer(transform);
    }

    void DropObject()
    {
        Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
        heldObject.transform.SetParent(null);
        heldObject = null;
        isHolding = false;
        
    }
}
