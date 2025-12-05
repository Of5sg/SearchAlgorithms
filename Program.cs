using System;
using System.Collections.Generic;

namespace SearchAlgorithms {

    class Program {
        
        public struct Cell {
            public int NodeID;
            public char Character;
            
            public Cell(int id, char character) {
                NodeID = id;
                Character = character;
            }
        }

        public static int Main() {

            char[] characters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
            
            int[] numbers = [12, 4, 3, 6, 7, 5, 8, 2, 11, 14, 67, 54, 32, 89, 71, 93, 42, 41, 63, 72, 75, 76, 82, 83, 19, 17];
            
            // creating start node and node network
            Node startnode = TreeFactory.CreateNodeTree(6, characters, numbers);
            
            // doing depth first search
            Cell[] resultDFS = DFS(startnode, [12, 7]);
            
            Console.WriteLine("DFS:");
            
            foreach (Cell item in resultDFS) {
                Console.Write("\tCell: " + item.NodeID + " \tCharacter: " + item.Character + "\n");
            }
            
            // doing breadth first search
            Cell[] resultBFS = BFS(startnode, [12, 7]);
            
            Console.WriteLine("BFS:");
            
            foreach (Cell item in resultBFS) {
                Console.Write("\tCell: " + item.NodeID + " \tCharacter: " + item.Character + "\n");
            }
            
            return 0;
        }
        
        private static Cell[] BFS(Node startPoint, int[] searchInts) {

            Cell[] resultChars = new Cell[0];
            
            List<Node> currentLayer = new List<Node>();
            List<Node> nextLayer = new List<Node>();

            currentLayer.Add(startPoint);

            do {

                foreach (Node node in currentLayer) {

                    for (int i = 0; i < searchInts.Length; i++) {

                        if (node.Value == searchInts[i]) {
                            Array.Resize(ref resultChars, resultChars.Length + 1);
                            resultChars[^1] = new Cell(node.NodeID, node.Character);
                        }

                    }

                    foreach (Node child in node.Children) {

                        nextLayer.Add(child);

                    }

                }

                currentLayer = nextLayer;
                nextLayer = [];

            } while (currentLayer.Count != 0);
            
            return resultChars;
        }

        private static Cell[] DFS(Node startPoint, int[] searchInts) {
            
            Cell[] resultCells = [];
            
            for (int i = 0; i < searchInts.Length; i++) {
                if (startPoint.Value == searchInts[i]) {
                    Array.Resize(ref resultCells, resultCells.Length + 1);
                    resultCells[^1] = new Cell(startPoint.NodeID, startPoint.Character);
                }
            }
            
            for (int i = 0; i < startPoint.Children.Count; i++) {
                Cell[] childArray = DFS(startPoint.Children[i], searchInts);
                
                if(childArray.Length > 0) {
                    int position = resultCells.Length;
                    // resize array to size of array + size of child array
                    Array.Resize(ref resultCells, resultCells.Length + childArray.Length);
                    foreach (Cell resCell in childArray) {
                        resultCells[position++] = resCell;
                    }
                }
            }

            return resultCells;

        }
    }
}
