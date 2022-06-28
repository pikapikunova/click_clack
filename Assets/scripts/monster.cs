using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class monster : MonoBehaviour, IPointerClickHandler
{
    protected int clickCount;
    protected float speed;
    protected Vector3 movement;
    protected Animator anim;
    protected Rigidbody rb;
    protected int rotationSpeed;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickCount--;
    }

    void Update()
    {
        if (clickCount == 0)
            Destroy(gameObject);
    }

    public void increaseClickCount(int taps)
    {
        if(taps > 0 && clickCount < 10 || taps < 0 && clickCount > 4)
            clickCount += taps;
    }

    private void MovementLogic()
    {

        if (movement.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * rotationSpeed);
        rb.velocity = Vector3.ClampMagnitude(movement, 1) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.rotation = Quaternion.Inverse(transform.rotation);
        movement = -movement;
    }

    void FixedUpdate()
    {
        MovementLogic();
    }

}
