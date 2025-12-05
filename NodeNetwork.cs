namespace SearchAlgorithms;

using System.Collections.Generic;

public class Node {
    public readonly char Character;
    public readonly int Value;
    public Dictionary<string, Node?> Connections = new Dictionary<string, Node?>();

    public Node(char character, int value, Node? parent, Node? child1, Node? child2) {
        Character = character;
        Value = value;
        Connections["Up"] = parent;
        Connections["dl"] = child1;
        Connections["dr"] = child2;
    }
    
}

public class TreeFactory {
    
    public static Node CreateNodeTree(int LayerDepth, char[] widthElements, int[] numbers) {

        Node EntryNode = new Node('?', 0, null, null, null);

        List<Node> currentLayerNodes = new List<Node>();
        List<Node> bottomLayerNodes = new List<Node>();
        
        currentLayerNodes.Add(EntryNode);

        int icount = 0;
        
        for (int i = 0; i < LayerDepth; i++) {

            foreach (Node node in currentLayerNodes) {

                Node child1 = new Node(
                    widthElements[(icount % widthElements.Length)],
                    numbers[(icount++ % numbers.Length)],
                    node,
                    null,
                    null
                    );
                Node child2 = new Node(
                    widthElements[(icount % widthElements.Length)],
                    numbers[(icount++ % numbers.Length)],
                    node,
                    null,
                    null
                    );

                node.Connections["dl"] = child1;
                node.Connections["dr"] = child2;
                
                bottomLayerNodes.Add(child1);
                bottomLayerNodes.Add(child2);

            }

            currentLayerNodes = bottomLayerNodes;

            bottomLayerNodes = [];
            
        }

        return EntryNode;
        
    }
    
}