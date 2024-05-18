using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class BugReproduction2 : MonoBehaviour
{
    private void OnEnable()
    {
        AstarPath.active.AddWorkItem(() =>
        {
            GridGraph gridGraph = AstarPath.active.data.gridGraph; 
            GridNodeBase[] nodes = gridGraph.nodes;
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].Tag = new PathfindingTag((uint)Random.Range(1, 4));
                nodes[i].Walkable = false;
            }
            gridGraph.RecalculateAllConnections();
        });
    }
    
    private void Start()
    {
        var guo1 = new GraphUpdateObject(new Bounds(new Vector3(40, 0, 40), new Vector3(20, 1, 20)))
        {
            resetPenaltyOnPhysics = false
        };
        AstarPath.active.UpdateGraphs(guo1);
        
        var guo2 = new GraphUpdateObject(new Bounds(new Vector3(40, 0, -40), new Vector3(20, 1, 20)))
        {
            resetPenaltyOnPhysics = false
        };
        AstarPath.active.UpdateGraphs(guo2);
        
        var guo3 = new GraphUpdateObject(new Bounds(new Vector3(-40, 0, -40), new Vector3(20, 1, 20)))
        {
            resetPenaltyOnPhysics = false
        };
        AstarPath.active.UpdateGraphs(guo3);

        var guo4 = new GraphUpdateObject(new Bounds(new Vector3(-40, 0, 40), new Vector3(20, 1, 20)))
        {
            resetPenaltyOnPhysics = false
        };
        AstarPath.active.UpdateGraphs(guo4);
    }
}
