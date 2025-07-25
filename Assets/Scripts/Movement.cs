using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D = null;
    [SerializeField] private float speed = 100.0f;
    //[SerializeField] private float angleDirection = 270f;
    [SerializeField] private Vector2 direction = new Vector2(-1, 0);
    [SerializeField] private float time = 0.0f;
    [SerializeField] private float energy = 100.0f;
    [SerializeField] private float totalDistance = 0.0f;
    [SerializeField] private float directionWaitTime = 1.0f;
    [SerializeField] private bool movementEnabled = true;
    [SerializeField] private bool roamEnabled = false;

    void Start()
    {
        Time.timeScale = 2;
        // Radius is always 2, direction is always within a 2x2 circle
        //float angleInRadians = angleDirection * Mathf.Deg2Rad;
        //print(angleInRadians);
        //float sinX = Mathf.Sin(angleInRadians);
        //print(sinX);
        //float sinY = Mathf.Cos(angleInRadians);
        //print(sinY);
        //float x = 1 * (Mathf.Sin(angleInRadians));
        //float y = 1 * (Mathf.Cos(angleInRadians));
        //direction = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        if (movementEnabled)
        {
            if (energy > 0)
            {
                if (roamEnabled)
                {
                    if (directionWaitTime <= 0) // LERP
                    {
                        // Direction
                        int angle = Random.Range(-180, 1);
                        if (angle < 0)
                        {
                            angle += 360;
                        }

                        float angleInRadians = angle * Mathf.Deg2Rad;

                        print(angle);

                        // Radius is always 2, direction is always within a 2x2 circle
                        float x = 1 * Mathf.Sin(angleInRadians);
                        float y = 1 * Mathf.Cos(angleInRadians);
                        direction = new Vector2(x, y);

                        directionWaitTime = .3f;
                    }
                }

                // Movement
                rigidBody2D.linearVelocity = direction * speed;

                // Others
                energy -= Time.deltaTime * (speed / 10.0f);
                totalDistance += Time.deltaTime * speed;
                directionWaitTime -= Time.deltaTime;
                time += Time.deltaTime;
            }
            else
            {
                //rigidBody2D.linearVelocity = new Vector2(0, 0) * 0;
                rigidBody2D.Sleep();
                movementEnabled = false;
            }
        }
    }
}
