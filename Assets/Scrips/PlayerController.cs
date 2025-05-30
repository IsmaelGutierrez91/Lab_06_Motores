using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerPreferences")]
    Rigidbody _componentRigidbody;
    [SerializeField] float playerSpeed;
    private float horizontalX;
    private float horizontalZ;
    public static event Action OnReachGoal;
    public static event Action OnNpcInteraction;
    private void Awake()
    {
        _componentRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _componentRigidbody.linearVelocity = new Vector3(horizontalX * playerSpeed, _componentRigidbody.linearVelocity.y, horizontalZ * playerSpeed);
    }
    public void OnMovementX(InputAction.CallbackContext context)
    {
        horizontalX = context.ReadValue<float>();
    }
    public void OnMovementZ(InputAction.CallbackContext context)
    {
        horizontalZ = context.ReadValue<float>();
    }
    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        OnNpcInteraction?.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            OnReachGoal?.Invoke();
        }
    }
}
