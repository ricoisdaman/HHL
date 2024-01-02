using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical }
    public MovementType movementType;
    public float moveSpeed = 2f;
    public float moveDistance = 3f;
    public bool enableVisibilityToggle = false;
    public float visibleDuration = 2f;
    public float invisibleDuration = 2f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingToEnd;
    private bool isVisible = true;
    private float visibilityTimer;

    void Start()
    {
        startPosition = transform.position;
        endPosition = movementType == MovementType.Horizontal ?
            new Vector3(startPosition.x + moveDistance, startPosition.y, startPosition.z) :
            new Vector3(startPosition.x, startPosition.y + moveDistance, startPosition.z);

        movingToEnd = true;
        visibilityTimer = visibleDuration;
        UpdateVisibility(true);
    }

    void Update()
    {
        MovePlatform();

        if (enableVisibilityToggle)
        {
            ToggleVisibility();
        }
    }

    void MovePlatform()
    {
        Vector3 targetPosition = movingToEnd ? endPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movingToEnd = !movingToEnd;
        }
    }

    void ToggleVisibility()
    {
        visibilityTimer -= Time.deltaTime;

        if (visibilityTimer <= 0)
        {
            isVisible = !isVisible;
            UpdateVisibility(isVisible);
            visibilityTimer = isVisible ? visibleDuration : invisibleDuration;
        }
    }

    void UpdateVisibility(bool visible)
    {
        // Adjust renderer visibility
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = visible;
        }

        // Adjust collider activity
        Collider collider = gameObject.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = visible;
        }
    }

}
