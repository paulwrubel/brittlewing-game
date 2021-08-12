using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using ExtensionMethods;

public class FlowerPlotGrid : MonoBehaviour
{

    public GameObject flowerPlotPrefab;
    public Vector2Int gridSize;

    private Grid grid;

    private Dictionary<Vector2Int, FlowerPlot> flowerPlots = new Dictionary<Vector2Int, FlowerPlot>();

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Grid>(); flowerPlots = new Dictionary<Vector2Int, FlowerPlot>(gridSize.x * gridSize.y);


        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 localPos = grid.GetCellCenterWorld(new Vector3Int(x, y, 0));

                GameObject flowerPlotGO = Instantiate(flowerPlotPrefab, localPos, Quaternion.identity, transform);
                FlowerPlot flowerPlot = flowerPlotGO.GetComponent<FlowerPlot>();
                flowerPlot.coordinates = new Vector2Int(x, y);

                flowerPlots.Add(new Vector2Int(x, y), flowerPlot);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BreedAll()
    {
        List<Vector2Int> notAbleToBreed = new List<Vector2Int>();
        foreach (KeyValuePair<Vector2Int, FlowerPlot> entry in flowerPlots.Shuffle())
        {
            Vector2Int location = entry.Key;
            FlowerPlot flowerPlot = entry.Value;
            if (!flowerPlot.ContainsFlower() || notAbleToBreed.Contains(location))
            {
                continue;
            }

            List<FlowerPlot> filledNeighbors = GetFilledNeighbors(location);
            foreach (FlowerPlot filledNeighbor in filledNeighbors.Shuffle())
            {
                if (notAbleToBreed.Contains(filledNeighbor.coordinates))
                {
                    continue;
                }
                if (filledNeighbor.flower.species == flowerPlot.flower.species)
                {
                    List<Vector2Int> emptyNeighbors = GetEmptyNeighbors(location);
                    if (emptyNeighbors.Count > 0)
                    {
                        Vector2Int emptyNeighbor = emptyNeighbors.RandomElement();
                        notAbleToBreed.Add(location);
                        notAbleToBreed.Add(filledNeighbor.coordinates);
                        print(string.Format("breeding {0} with {1} into {2}", location, filledNeighbor.coordinates, emptyNeighbor));
                        flowerPlots[emptyNeighbor].AddFlower(flowerPlot.flower.species, flowerPlot.flower.genome.Cross(filledNeighbor.flower.genome));
                        notAbleToBreed.Add(emptyNeighbor);
                    }
                }
            }
        }

    }

    private List<FlowerPlot> GetFilledNeighbors(Vector2Int location)
    {
        List<FlowerPlot> neighbors = new List<FlowerPlot>();
        for (int x = location.x - 1; x <= location.x + 1; x++)
        {
            for (int y = location.y - 1; y <= location.y + 1; y++)
            {
                Vector2Int neighborLocation = new Vector2Int(x, y);
                if (flowerPlots.ContainsKey(neighborLocation) && location != neighborLocation && flowerPlots[neighborLocation].ContainsFlower())
                {
                    neighbors.Add(flowerPlots[neighborLocation]);
                }
            }
        }
        return neighbors;
    }

    private List<Vector2Int> GetEmptyNeighbors(Vector2Int location)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();
        for (int x = location.x - 1; x <= location.x + 1; x++)
        {
            for (int y = location.y - 1; y <= location.y + 1; y++)
            {
                Vector2Int neighborLocation = new Vector2Int(x, y);
                if (flowerPlots.ContainsKey(neighborLocation) && location != neighborLocation && !flowerPlots[neighborLocation].ContainsFlower())
                {
                    neighbors.Add(neighborLocation);
                }
            }
        }
        return neighbors;
    }
}
