using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : BTNode
{
    private List<BTNode> _children = new List<BTNode>();

    public SequenceNode(List<BTNode> children)
    {
        _children = children;
    }

    public override NodeState Tick()
    {
        foreach(var child in _children)
        {
            NodeState result = child.Tick();
            if (result != NodeState.Success)
                return result;
        }
        return NodeState.Success;
    }
}
