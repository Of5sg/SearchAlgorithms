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
        
        public struct Search_Results {
            public List<Cell> resultCells;
            public List<Cell[]> resultPaths;
            
            public Search_Results(List<Cell> resCells, List<Cell[]> paths) {
                resultCells = resCells;
                resultPaths = paths;
            }
            
        }

        public static int Main() {

            char[] characters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
            
            int[] numbers = [12, 4, 3, 6, 7, 5, 8, 2, 11, 14, 67, 54, 32, 89, 71, 93, 42, 41, 63, 72, 75, 76, 82, 83, 19, 17];
            
            // creating start node and node network
            Node startnode = TreeFactory.CreateNodeTree(6, characters, numbers);
            
            
            
            // doing depth-first search
            Search_Results resultDFS = DFS(startnode, [12]);
            
            // Logging results of Depth-first search
            Console.WriteLine("DFS:");
            
            for (int i = 0; i < resultDFS.resultCells.Count; i++) {
                
                // Logging data for matching node
                Console.Write("\tNode: " + resultDFS.resultCells[i].NodeID + 
                              "\n\tCharacter: " + resultDFS.resultCells[i].Character + 
                              "\n\tNumber: " + resultDFS.resultCells[i].Value + "\n");
                
                // Logging the path to the answer
                Console.Write("\tPath to answer: ");
                resultDFS.resultPaths[i].Reverse();
                
                foreach (Cell entry in resultDFS.resultPaths[i]) {
                    Console.Write("-" + entry.NodeID);
                }
                
                Console.Write("\n\n");
                
            }

            // doing breadth-first search
            Cell[] resultBFS = BFS(startnode, ['c', 'd']);
            
            // logging resuts of Depth-first search
            Console.WriteLine("BFS:");
            
            foreach (Cell item in resultBFS) {
                Console.Write("\tNode: " + item.NodeID + " \tCharacter: " + item.Character + "\tNumber: " + item.Value + "\n");
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

        private static Search_Results DFS(Node startPoint, int[] searchInts, Stack<Cell>? pathStack = null, List<Cell[]>? listOfMatchingPaths = null) {
            
            
            // stack to hold the path to the current node
            Stack<Cell> pathToMatch;
                
                // initialize stack if it does not exist
            if(pathStack == null) {
                pathToMatch = new Stack<Cell>(6);
            }else {
                pathToMatch = pathStack;
            }
            
                // adding current node to the stack
            pathToMatch.Push(new Cell(startPoint.NodeID, startPoint.Character, startPoint.Value));
            
            
            
            // List of Cell arrays to hold the paths to matching Nodes
            List<Cell[]> pathList;
            
            if(listOfMatchingPaths == null) {
                pathList = new List<Cell[]>();
            }else {
                pathList = listOfMatchingPaths;
            }
            
            
            
            // the matching/resulting cells
            List<Cell> resultCells = new List<Cell>();
            
            
            for (int i = 0; i < searchInts.Length; i++) {
                
                if (startPoint.Value == searchInts[i]) {
                    // on match, add new Cell for current node
                    resultCells.Add(
                        new Cell(
                            startPoint.NodeID, 
                            startPoint.Character, 
                            startPoint.Value
                        )
                    );
                    
                    // on match copy current path to array
                    
                    Cell[] resultingPath = new Cell[pathToMatch.Count];
                    
                    pathToMatch.CopyTo(resultingPath, 0);
                    
                    // add array to list of matching paths
                    pathList.Add(resultingPath);
                }
            }
            
            for (int i = 0; i < startPoint.Children.Count; i++) {
                Search_Results results = DFS(startPoint.Children[i], searchInts, pathToMatch, pathList);

                pathList = results.resultPaths;
                
                if(results.resultCells.Count > 0) {
                    resultCells.AddRange(results.resultCells);
                }
            }
            
            // removing current node from the path stack
            pathToMatch.Pop();
            
            // return an instance of the results struct
            return new Search_Results(resultCells, pathList);
            
        }
        
        private static Search_Results DFS(Node startPoint, char[] searchChars, Stack<Cell>? pathStack = null, List<Cell[]>? listOfMatchingPaths = null) {
            
            
            // stack to hold the path to the current node
            Stack<Cell> pathToMatch;
                
                // initialize stack if it does not exist
            if(pathStack == null) {
                pathToMatch = new Stack<Cell>(6);
            }else {
                pathToMatch = pathStack;
            }
            
                // adding current node to the stack
            pathToMatch.Push(new Cell(startPoint.NodeID, startPoint.Character, startPoint.Value));
            
            
            
            // List of Cell arrays to hold the paths to matching Nodes
            List<Cell[]> pathList;
            
            if(listOfMatchingPaths == null) {
                pathList = new List<Cell[]>();
            }else {
                pathList = listOfMatchingPaths;
            }
            
            
            
            // the matching/resulting cells
            List<Cell> resultCells = new List<Cell>();
            
            
            for (int i = 0; i < searchChars.Length; i++) {
                
                if (startPoint.Character == searchChars[i]) {
                    // on match, add new Cell for current node
                    resultCells.Add(
                        new Cell(
                            startPoint.NodeID, 
                            startPoint.Character, 
                            startPoint.Value
                        )
                    );
                    
                    // on match copy current path to array
                    
                    Cell[] resultingPath = new Cell[pathToMatch.Count];
                    
                    pathToMatch.CopyTo(resultingPath, 0);
                    
                    // add array to list of matching paths
                    pathList.Add(resultingPath);
                }
            }
            
            for (int i = 0; i < startPoint.Children.Count; i++) {
                Search_Results results = DFS(startPoint.Children[i], searchChars, pathToMatch, pathList);

                pathList = results.resultPaths;
                
                if(results.resultCells.Count > 0) {
                    resultCells.AddRange(results.resultCells);
                }
            }
            
            // removing current node from the path stack
            pathToMatch.Pop();
            
            // return an instance of the results struct
            return new Search_Results(resultCells, pathList);

        }
    }
}
