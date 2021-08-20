using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using ExtensionMethods;

public class FlowerPlotGrid : MonoBehaviour
{

    public GameObject flowerPlotPrefab;
    public Vector2Int gridSize;
    public GameManager gameManager;

    private Grid grid;

    private Dictionary<Vector2Int, FlowerPlot> flowerPlots = new Dictionary<Vector2Int, FlowerPlot>();

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Grid>();
        flowerPlots = new Dictionary<Vector2Int, FlowerPlot>(gridSize.x * gridSize.y);

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 localPos = grid.GetCellCenterWorld(new Vector3Int(x, y, 0));

                GameObject flowerPlotGO = Instantiate(flowerPlotPrefab, localPos, Quaternion.identity, transform);
                FlowerPlot flowerPlot = flowerPlotGO.GetComponent<FlowerPlot>();
                flowerPlot.coordinates = new Vector2Int(x, y);
                flowerPlot.gameManager = gameManager;

                flowerPlots.Add(new Vector2Int(x, y), flowerPlot);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AdvanceDay()
    {
        BreedOrGrowAll();
        UnwaterAll();
    }

    private void UnwaterAll()
    {
        foreach (FlowerPlot flowerPlot in flowerPlots.Values)
        {
            flowerPlot.SetIsWatered(false);
        }
    }

    private void BreedOrGrowAll()
    {
        Dictionary<Vector2Int, FlowerPlot> filledFlowerPlots = flowerPlots
            .Where(e => e.Value.ContainsFlower())
            .ToDictionary(e => e.Key, e => e.Value);

        List<Vector2Int> unableToBreedThisRound = new List<Vector2Int>();

        // foreach (FlowerPlot filledPlot in filledFlowerPlots.Values)
        // {
        //     print("FILLED: " + filledPlot.coordinates);
        //     print("CAN GROW?: " + filledPlot.CanGrow());
        // }

        Dictionary<Vector2Int, FlowerPlot> breedableFlowerPlots = filledFlowerPlots
            .Where(e => e.Value.CanPollinate())
            .ToDictionary(e => e.Key, e => e.Value);

        Dictionary<Vector2Int, FlowerPlot> growableFlowerPlots = filledFlowerPlots
            .Where(e => e.Value.CanGrow())
            .ToDictionary(e => e.Key, e => e.Value);

        // first, try to breed flowers that are eligible
        // flowers can only breed with other flowers that can breed
        foreach (KeyValuePair<Vector2Int, FlowerPlot> entry in breedableFlowerPlots.Shuffle())
        {
            Vector2Int location = entry.Key;
            FlowerPlot flowerPlot = entry.Value;

            // print("BREEDABLE: " + flowerPlot.coordinates);

            PlantedFlower plantedFlower = flowerPlot.plantedFlower;
            FlowerItem flowerItem = flowerPlot.plantedFlower.flowerItem;

            Dictionary<Vector2Int, FlowerPlot> filledNeighbors = breedableFlowerPlots
                .Where(e => e.Key.IsNeighboring(location))
                .ToDictionary(e => e.Key, e => e.Value);

            // print(string.Format("we are {0}", location));
            // print(string.Format("neighbors are {0}", string.Join(",", filledNeighbors.Select(e => e.Key.ToString()))));

            foreach (KeyValuePair<Vector2Int, FlowerPlot> neighbor in filledNeighbors.Shuffle())
            {
                Vector2Int neighborLocation = neighbor.Key;
                FlowerPlot neighborFlowerPlot = neighbor.Value;

                PlantedFlower neighborPlantedFlower = neighborFlowerPlot.plantedFlower;
                FlowerItem neighborFlowerItem = neighborFlowerPlot.plantedFlower.flowerItem;

                bool willTryToBreedWithThisNeighbor = !unableToBreedThisRound.Contains(neighborLocation) &&
                    neighborFlowerItem.speciesType == flowerItem.speciesType &&
                    Random.value < plantedFlower.pollinationChance;

                if (willTryToBreedWithThisNeighbor)
                {
                    List<Vector2Int> emptyNeighbors = flowerPlots
                        .Where(e => e.Key.IsNeighboring(location) && e.Key.IsNeighboring(neighborLocation) && !e.Value.ContainsFlower())
                        .Select(e => e.Key)
                        .ToList();

                    if (emptyNeighbors.Count > 0)
                    {
                        Vector2Int emptyNeighbor = emptyNeighbors.RandomElement();

                        unableToBreedThisRound.Add(location);
                        unableToBreedThisRound.Add(neighborLocation);

                        print(string.Format("breeding {0} with {1} into {2}", location, neighborLocation, emptyNeighbor));

                        flowerPlots[emptyNeighbor].AddFlower(new FlowerItem(flowerItem.speciesType, flowerItem.genome.Cross(neighborFlowerItem.genome), GrowthStage.Seedling));
                        unableToBreedThisRound.Add(emptyNeighbor);
                    }
                }
            }
        }

        // next, grow flowers that are eligible
        foreach (KeyValuePair<Vector2Int, FlowerPlot> entry in growableFlowerPlots)
        {
            Vector2Int location = entry.Key;
            FlowerPlot flowerPlot = entry.Value;

            PlantedFlower plantedFlower = flowerPlot.plantedFlower;

            plantedFlower.AdvanceGrowthStage();
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
