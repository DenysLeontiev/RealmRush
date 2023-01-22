using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject transparentTowerPrefab;

    private GameObject transparentTower;

    public bool IsPlaceable { get { return isPlaceable; } }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            print(transform.name);
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }

    private void OnMouseOver()
    {
        if (isPlaceable)
        {
            if (transparentTower == null)
            {
                transparentTower = Instantiate(transparentTowerPrefab, transform.position, Quaternion.identity);
            }
            transparentTower.transform.position = transform.position;
        }
    }

    private void OnMouseExit()
    {
        Destroy(transparentTower);
    }
}
