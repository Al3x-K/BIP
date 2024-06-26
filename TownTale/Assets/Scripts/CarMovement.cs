using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public Vector2[] waypoints;   
    private int currentWaypointIndex = 0;  
    private Animator animator;  

    void Start()
    {
    
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0];
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveCar();
    }

    void MoveCar()
    {
        if (waypoints.Length == 0) return;  

        
        Vector2 target = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            Vector2 nextTarget = waypoints[currentWaypointIndex];
            Vector2 direction = nextTarget - (Vector2)transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
