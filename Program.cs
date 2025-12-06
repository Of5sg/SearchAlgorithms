using System;
using System.Collections.Generic;

namespace SearchAlgorithms {

    class Program {
        
        public struct Cell {
            public int NodeID;
            public char Character;
            public int Value;
            
            public Cell(int id, char character, int value) {
                NodeID = id;
                Character = character;
                Value = value;
            }
        }

        public static int Main() {

            char[] characters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
            
            int[] numbers = [12, 4, 3, 6, 7, 5, 8, 2, 11, 14, 67, 54, 32, 89, 71, 93, 42, 41, 63, 72, 75, 76, 82, 83, 19, 17];
            
            // creating start node and node network
            Node startnode = TreeFactory.CreateNodeTree(6, characters, numbers);
            
            // doing depth-first search
            List<Cell> resultDFS = DFS(startnode, [12, 4]);
            
            Console.WriteLine("DFS:");
            
            foreach (Cell item in resultDFS) {
                Console.Write("\tCell: " + item.NodeID + " \tCharacter: " + item.Character + "\tNumber: " + item.Value + "\n");
            }
            
            // doing breadth-first search
            Cell[] resultBFS = BFS(startnode, ['c', 'd']);
            
            Console.WriteLine("BFS:");
            
            foreach (Cell item in resultBFS) {
                Console.Write("\tCell: " + item.NodeID + " \tCharacter: " + item.Character + "\tNumber: " + item.Value + "\n");
            }
            
            return 0;
        }
        
        // ---------- BFS ----------
        
        private static Cell[] BFS(Node startPoint, int[] searchInts) {

            Cell[] resultChars = new Cell[0];

            Queue<Node> nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(startPoint);

            Node node;
            
            do {

                node = nodeQueue.Dequeue();
                
                for (int i = 0; i < searchInts.Length; i++) {

                    if (node.Value == searchInts[i]) {
                        Array.Resize(ref resultChars, resultChars.Length + 1);
                        resultChars[^1] = new Cell(node.NodeID, node.Character, node.Value);
                    }

                }

                foreach (Node child in node.Children) {
                    
                    nodeQueue.Enqueue(child);
                    
                }

            } while (nodeQueue.Count > 0);
            
            return resultChars;
        }
        
        private static Cell[] BFS(Node startPoint, char[] searchChars) {

            Cell[] resultChars = new Cell[0];

            Queue<Node> nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(startPoint);

            Node node;
            
            do {

                node = nodeQueue.Dequeue();
                
                for (int i = 0; i < searchChars.Length; i++) {

                    if (node.Character == searchChars[i]) {
                        Array.Resize(ref resultChars, resultChars.Length + 1);
                        resultChars[^1] = new Cell(node.NodeID, node.Character, node.Value);
                    }

                }

                foreach (Node child in node.Children) {
                    
                    nodeQueue.Enqueue(child);
                    
                }

            } while (nodeQueue.Count > 0);
            
            return resultChars;
        }
        
        // ---------- DFS ----------

        private static List<Cell> DFS(Node startPoint, int[] searchInts) {
            
            List<Cell> resultCells = new List<Cell>();
            
            for (int i = 0; i < searchInts.Length; i++) {
                
                if (startPoint.Value == searchInts[i]) {
                    resultCells.Add(
                        new Cell(
                            startPoint.NodeID, 
                            startPoint.Character, 
                            startPoint.Value
                            )
                        );
                }
            }
            
            for (int i = 0; i < startPoint.Children.Count; i++) {
                List<Cell> childArray = DFS(startPoint.Children[i], searchInts);
                
                if(childArray.Count > 0) {
                    resultCells.AddRange(childArray);
                }
            }

            return resultCells;

        }
        
        private static List<Cell> DFS(Node startPoint, char[] searchChars) {
            
            List<Cell> resultCells = new List<Cell>();
            
            for (int i = 0; i < searchChars.Length; i++) {
                
                if (startPoint.Character == searchChars[i]) {
                    resultCells.Add(
                        new Cell(
                            startPoint.NodeID, 
                            startPoint.Character, 
                            startPoint.Value
                        )
                    );
                }
            }
            
            for (int i = 0; i < startPoint.Children.Count; i++) {
                List<Cell> childArray = DFS(startPoint.Children[i], searchChars);
                
                if(childArray.Count > 0) {
                    resultCells.AddRange(childArray);
                }
            }

            return resultCells;

        }
    }
}
