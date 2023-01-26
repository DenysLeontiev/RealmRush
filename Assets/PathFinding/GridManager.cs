using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour // stores the reference to all the Nodes in our world and organises it into a grid
{
    [SerializeField] private Vector2Int gridSize;
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                // print($"Coordinates: {grid[coordinates].coordinates} | {grid[coordinates].isWalkable}");
            }
        }
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / UnityEditor.EditorSnapSettings.move.x); // Move to Editor folder because it has to be ignored,otherwise the project wont build
        coordinates.y = Mathf.RoundToInt(position.z / UnityEditor.EditorSnapSettings.move.z);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 pos = new Vector3();
        pos.x = coordinates.x * UnityEditor.EditorSnapSettings.move.x; // Move to Editor folder because it has to be ignored,otherwise the project wont build
        pos.z = coordinates.y * UnityEditor.EditorSnapSettings.move.z;

        return pos;
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }
}
