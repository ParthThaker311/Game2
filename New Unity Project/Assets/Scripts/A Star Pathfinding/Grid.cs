using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public Vector2 gridWorldSize;
	public float nodeRadius;
	public LayerMask unwalkableMask;
	Node[,] nodes;
	float nodeDiameter;
	int nodesInGridX, nodesInGridY;
	void Start(){
		nodeDiameter = nodeRadius;
		nodesInGridX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
		nodesInGridY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
		CreateGrid();
	}

	void CreateGrid(){
		nodes = new Node[nodesInGridX, nodesInGridY];
		Vector3 gridBotLeft = this.transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
		for (int x = 0; x < nodesInGridX; x++) {
			for (int y = 0; y < nodesInGridY; y++) {
				Vector3 currentLoc = gridBotLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				bool validLoc = !(Physics.CheckSphere (currentLoc, nodeRadius,unwalkableMask));
				nodes [x, y] = new Node (validLoc, currentLoc);
			}
		}
	}
	void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, gridWorldSize);
		if(nodes!=null){
			Debug.Log(nodes.Length);
			foreach(Node n in nodes){
				Gizmos.color = (n.isValidLoc) ? Color.white : Color.red;
				Gizmos.DrawCube (n.location, Vector3.one * (nodeDiameter - .1f));
			}
		}
	}
}
