namespace SearchAlgorithms;


public class Node {
    private char Value;
    private Dictionary<string, Node?> Connections;

    public Node(char value, Node Parent, Node child1, Node child2) {
        Value = value;
        Connections["Up"] = Parent;
        Connections["dl"] = child1;
        Connections["dr"] = child2;
    }
    
}

public class TreeFactory {


    public Node CreateNodeTree(int LayerDepth, int widthPerLayer, char[] widthElements) {

        Node EntryNode = new Node('?', null, null, null);






        return EntryNode;
        
    }
    
    
}

public class NodeNetwork {
    
    
    
    
    
}