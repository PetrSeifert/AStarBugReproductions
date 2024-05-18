using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class BugReproduction1 : MonoBehaviour
{
    [SerializeField] private bool fixTagsReset;
    
    private void OnEnable()
    {
        AstarPath.active.AddWorkItem(() =>
        {
            GridGraph gridGraph = AstarPath.active.data.gridGraph; 
            GridNodeBase[] nodes = gridGraph.nodes;
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].Tag = new PathfindingTag((uint)Random.Range(1, 4));
            }
        });

        if (fixTagsReset)
        {
            AstarPath.active.AddWorkItem(() =>
            {
                GridGraph gridGraph = AstarPath.active.data.gridGraph; 
                /*GridNodeBase[] nodes = gridGraph.nodes;
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i].Walkable = false;
                }*/
                
                gridGraph.RecalculateAllConnections();
            });
        }
    }
    
    private void Start()
    {
        var guo = new GraphUpdateObject(new Bounds(new Vector3(0, 0, 0), new Vector3(100, 1, 100)))
        {
            resetPenaltyOnPhysics = false
        };
        AstarPath.active.UpdateGraphs(guo);
    }
}
