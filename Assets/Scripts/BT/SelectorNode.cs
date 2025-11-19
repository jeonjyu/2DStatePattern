using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : BTNode
{
    private List<BTNode> _children = new List<BTNode>();

    public SelectorNode(List<BTNode> children)
    {
        _children = children;
    }

    public override NodeState Tick()
    {
        foreach (var child in _children)
        {
            NodeState result = child.Tick();
            if (result != NodeState.Failure)
                return result;
        }
        return NodeState.Failure;
    }
}
