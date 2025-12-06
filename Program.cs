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
            List<object> resultDFS = DFS(startnode, [12]);
            List<Cell> resultCells = (List<Cell>)resultDFS[0];
            List<Cell[]> resultPaths = (List<Cell[]>)resultDFS[1];
            
            Console.WriteLine("DFS:");
            
            foreach (Cell item in resultCells) {
                Console.Write("\tCell: " + item.NodeID + " \tCharacter: " + item.Character + "\tNumber: " + item.Value + "\n");
            }
            foreach (Cell[] path in resultPaths) {
                Console.Write("Path to answer: ");
                path.Reverse();
                foreach (Cell entry in path) {
                    Console.Write("-" + entry.NodeID);
                }
                Console.Write("\n");
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

        private static List<object> DFS(Node startPoint, int[] searchInts, Stack<Cell>? pathStack = null, List<Cell[]>? listOfMatchingPaths = null) {
            
            // Add a stack to hold the path to the selected nodes
            Stack<Cell> pathToMatch;
            
            if(pathStack == null) {
                pathToMatch = new Stack<Cell>(6);
            }else {
                pathToMatch = pathStack;
            }
            
            List<Cell[]> pathList;
            
            if(listOfMatchingPaths == null) {
                pathList = new List<Cell[]>();
            }else {
                pathList = listOfMatchingPaths;
            }

            pathToMatch.Push(new Cell(startPoint.NodeID, startPoint.Character, startPoint.Value));
            
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
                    Cell[] resultingPath = [];
                    Array.Resize(ref resultingPath, pathToMatch.Count);
                    pathToMatch.CopyTo(resultingPath, 0);
                    pathList.Add(resultingPath);
                }
            }
            
            for (int i = 0; i < startPoint.Children.Count; i++) {
                List<object> results = DFS(startPoint.Children[i], searchInts, pathToMatch, pathList);
                List<Cell> childArray = (List<Cell>)results[0];
                pathList = (List<Cell[]>)results[1];
                
                if(childArray.Count > 0) {
                    resultCells.AddRange(childArray);
                }
            }
            
            pathToMatch.Pop();

            return new List<object>(){resultCells, pathList};
            
        }
        
        private static List<object> DFS(Node startPoint, char[] searchChars, Stack<Cell>? pathStack = null, List<Cell[]>? listOfMatchingPaths = null) {
            
            // Add a stack to hold the path to the selected nodes
            Stack<Cell> pathToMatch;
            
            if(pathStack == null) {
                pathToMatch = new Stack<Cell>(6);
            }else {
                pathToMatch = pathStack;
            }
            
            List<Cell[]> pathList;
            
            if(listOfMatchingPaths == null) {
                pathList = new List<Cell[]>();
            }else {
                pathList = listOfMatchingPaths;
            }

            pathToMatch.Push(new Cell(startPoint.NodeID, startPoint.Character, startPoint.Value));
            
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
                    Cell[] resultingPath = [];
                    Array.Resize(ref resultingPath, pathToMatch.Count);
                    pathToMatch.CopyTo(resultingPath, 0);
                    pathList.Add(resultingPath);
                }
            }
            
            for (int i = 0; i < startPoint.Children.Count; i++) {
                List<object> results = DFS(startPoint.Children[i], searchChars, pathToMatch, pathList);
                List<Cell> childArray = (List<Cell>)results[0];
                pathList = (List<Cell[]>)results[1];
                
                if(childArray.Count > 0) {
                    resultCells.AddRange(childArray);
                }
            }
            
            pathToMatch.Pop();

            return new List<object>(){resultCells, pathList};

        }
    }
}
