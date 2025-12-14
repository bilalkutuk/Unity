using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float upperBound = 1.15f;
    [SerializeField] float lowerBound = -1.15f;

    InputAction moveAction;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void OnEnable()
    {
        moveAction?.Enable();
    }

    void OnDisable()
    {
        moveAction?.Disable();
    }

    void Update()
    {
        float yInput = moveAction.ReadValue<Vector2>().y;

        Vector3 pos = transform.position;
        pos.y += yInput * moveSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, lowerBound, upperBound);

        transform.position = pos;
    }
}
