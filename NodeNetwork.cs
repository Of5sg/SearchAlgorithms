namespace SearchAlgorithms;

using System.Collections.Generic;

public class Node {
    public readonly char Character;
    public readonly int Value;
    public Node? Parent;
    public List<Node> Children = [];
    
    public Node(char character, int value, Node? parent) {
        Character = character;
        Value = value;
        Parent = parent;
    }
    
}

public class TreeFactory {
    
    public static Node CreateNodeTree(int LayerDepth, char[] widthElements, int[] numbers) {

        Node EntryNode = new Node('?', 0, null);

        List<Node> currentLayerNodes = new List<Node>();
        List<Node> bottomLayerNodes = new List<Node>();
        
        currentLayerNodes.Add(EntryNode);

        int icount = 0;
        
        for (int i = 0; i < LayerDepth; i++) {

            foreach (Node node in currentLayerNodes) {

                Node child1 = new Node(
                    widthElements[(icount % widthElements.Length)],
                    numbers[(icount++ % numbers.Length)],
                    node
                    );
                Node child2 = new Node(
                    widthElements[(icount % widthElements.Length)],
                    numbers[(icount++ % numbers.Length)],
                    node
                    );

                node.Children.Add(child1);
                node.Children.Add(child2);
                
                bottomLayerNodes.Add(child1);
                bottomLayerNodes.Add(child2);

            }

            currentLayerNodes = bottomLayerNodes;

            bottomLayerNodes = [];
            
        }

        return EntryNode;
        
    }
    
}