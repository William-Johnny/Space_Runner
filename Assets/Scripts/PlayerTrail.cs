using UnityEngine;
using System.Collections.Generic;

public class PlayerTrail : MonoBehaviour
{

    [SerializeField] float lifetime = 0.5f;
    [SerializeField] float minDistance = 0.2f;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 offset;
    [SerializeField] LineRenderer line;

    List<Vector3> points = new List<Vector3>();
    Queue<float> spawnTimes = new Queue<float>();

    void AddPoint(Vector3 position) {
        points.Insert(0, position);
        spawnTimes.Enqueue(Time.time);
    }

    void RemovePoint () {
        spawnTimes.Dequeue();
        points.RemoveAt(points.Count - 1);
    }

    void Update () {
        while(spawnTimes.Count > 0 && spawnTimes.Peek() + lifetime < Time.time)
            RemovePoint();

        
        // array c'est avec une longeur déterminé.
        Vector3 diff = velocity * Time.deltaTime;
        for (int i = 0; i < points.Count; i++) {
            points[i] += diff;
        }

        if (points.Count == 0  || Vector3.Distance(transform.position, points[0]) >= minDistance) {
            AddPoint(transform.position + offset);

            line.positionCount = points.Count;
            line.SetPositions(points.ToArray());
        }
    }
}
