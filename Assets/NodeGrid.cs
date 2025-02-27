using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{

    public RectTransform rect_transform;
    public int grid_x;
    public int grid_y;
    private Node[,] node_grid;
    public Node start;
    public Node goal;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        rect_transform = GetComponent<RectTransform>();
        node_grid = new Node[grid_y, grid_x];
        for(int r = 0; r < grid_y; r++) {
            for(int c = 0; c < grid_x; c++) {
                node_grid[r, c] = new Node(new Vector2(radius * (2 * c + 1), radius * (2 * r + 1)));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pathing_Round() {
        
    }
}
