using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstSearch : MonoBehaviour
{
    public Node rootNode;
    public Node target;

    private void Start()
    {
        int stepCount = DFS(target);
        if (stepCount > -1)
        {
            Debug.Log(target.name + " was found in " + stepCount + "steps");
        }
        else
        {
            Debug.Log(target.name + "was not found");
        }
    }
    public int DFS(Node TargetNode)
    {
        Stack stack = new Stack(); //stack the nodes , the lasted one stacked is the next visited   
        List<Node> visitedNodes = new List<Node>(); //tracks the visited nodes

        stack.Push(rootNode); //push root node to stack

        while (stack.Count > 0) //while the stacks not empty
        {
            Node node = (Node)stack.Pop(); // get the last stacked node
            visitedNodes.Add(node); // visit node
            foreach (Node child in node.children) //loop through children of node
            {
                //if the child has not been visited or added to the stack
                if (visitedNodes.Contains(child) == false && stack.Contains(child) == false)
                {
                    if (child == TargetNode) //target node found
                    {
                        return visitedNodes.Count; //return number of visited nodes
                    }
                    stack.Push(child);
                }
            }
        }
        return -1;
    }
}
