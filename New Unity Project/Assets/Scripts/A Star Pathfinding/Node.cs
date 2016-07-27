using UnityEngine;
using System.Collections;

public class Node{
	public bool isValidLoc;
	public Vector3 location;

	public Node(bool valid, Vector3 worldLoc){
		isValidLoc = valid;
		location = worldLoc;
	}
}
