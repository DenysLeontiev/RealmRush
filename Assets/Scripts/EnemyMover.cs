using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [Range(0f, 5f)]
    [SerializeField] private float speed = 1f;

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.LookAt(waypoint.transform.position);
            Vector3 startingPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startingPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        gameObject.SetActive(false);
    }
}
