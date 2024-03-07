using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.TextCore.Text;

public class PathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 0.05f;
    public float movementSpeed = 8f;
    public float startTime = 0;
    float timeTravelled = 0;
    float distanceTravelled = 0;
    public bool pathBreakDown = false;

    void Start()
    {
        if (pathCreator != null)
        {
            pathCreator.pathUpdated += OnPathChanged;
            timeTravelled = startTime;
        }
    }

    void Update()
    {
       
        
            if (pathCreator != null && !pathBreakDown)
            {
                timeTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtTime(timeTravelled, endOfPathInstruction);
                if (pathCreator.path.GetRotation(timeTravelled, endOfPathInstruction).x > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                Vector3 point = pathCreator.path.GetClosestPointOnPath(transform.position);
                Vector2 hareketYonu = (point - transform.position).normalized;
                transform.Translate(hareketYonu * speed * movementSpeed * Time.deltaTime);
                if (transform.position == point)
                {
                    pathBreakDown = false;
                }
            }
        

    }
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
    public float GetCurrentTimeTravelled()
    {
        return timeTravelled;
    }


}
