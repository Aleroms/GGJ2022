using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private Transform cameraTransform;

    private CharacterController characterController;

    private void Start() 
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        Vector3 forward = (cameraTransform.position - cameraTransform.position).normalized;
        forward.y = 0;
        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

        float moveAxisX = movementSpeed * Input.GetAxis("Horizontal");
        float moveAxisY = movementSpeed * Input.GetAxis("Vertical");
        Vector3 movement = forward * moveAxisX + right * moveAxisX;

        characterController.Move(movement);
    }
}
