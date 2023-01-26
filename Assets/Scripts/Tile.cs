using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private GameObject transparentTowerPrefab;

    private GameObject transparentTower;
    private GridManager gridManager;
    private Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start()
    {
        if (gridManager != null)
        {
            if (!isPlaceable)
            {
                coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
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
