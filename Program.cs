using System;
using System.Collections.Generic;

namespace SearchAlgorithms {

    class Program {

        public static int Main() {

            char[] characters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
            
            int[] numbers = [12, 4, 3, 6, 7, 5, 8, 2, 11, 14, 67, 54, 32, 89, 71, 93, 42, 41, 63, 72, 75, 76, 82, 83, 19, 17];
            
            // creating start node and node network
            Node startnode = TreeFactory.CreateNodeTree(6, characters, numbers);
            
            // doing depth-first search
            DepthFirstSearch searchInit = new DepthFirstSearch(startnode);
            searchInit.Search([12]);
            searchInit.DFSLogger();

            // doing breadth-first search
            BreadtFirstSearch searchBreadth = new BreadtFirstSearch(startnode);
            searchBreadth.Search(['a']);
            searchBreadth.BFSLogger();
            
            return 0;
        }
        
    }
    
}
