using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlotGrid : MonoBehaviour
{

    public GameObject flowerPlotPrefab;
    public Vector2Int gridSize;

    private Grid grid;

    private GameObject[,] flowerPlots;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Grid>();
        flowerPlots = new GameObject[gridSize.x, gridSize.y];


        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 localPos = grid.GetCellCenterWorld(new Vector3Int(x, y, 0));

                GameObject flowerPlotGO = Instantiate(flowerPlotPrefab, localPos, Quaternion.identity, transform);
                flowerPlotGO.GetComponent<FlowerPlot>().coordinates = new Vector2Int(x, y);

                flowerPlots[x, y] = flowerPlotGO;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
