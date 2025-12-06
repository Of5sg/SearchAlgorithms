using System;
using System.Collections.Generic;

namespace SearchAlgorithms {
    
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

    public class DepthFirstSearch(Node startNode) {
        
        private readonly Node _StartNode = startNode;
        private readonly Stack<Cell> _CurrentPath = new();
        private readonly List<Cell[]> _MatchingPaths = new();
        private readonly List<Cell> _MatchingCells = new();
        
        public void Search(int[] searchInts) {
            
            _CurrentPath.Clear();
            _MatchingCells.Clear();
            _MatchingPaths.Clear();
            
            DFS(_StartNode, searchInts);
        }
        
        public void Search(char[] searchChars) {
            
            _CurrentPath.Clear();
            _MatchingCells.Clear();
            _MatchingPaths.Clear();
            
            DFS(_StartNode, searchChars);
        }
        
        private void DFS(Node startPoint, int[] searchInts) {
            
            // adding current node to the stack
            _CurrentPath.Push(new Cell(startPoint.NodeID, startPoint.Character, startPoint.Value));

            for (int i = 0; i < searchInts.Length; i++) {
                
                if (startPoint.Value == searchInts[i]) {
                    // on match, add new Cell for current node
                    _MatchingCells.Add(
                        new Cell(
                            startPoint.NodeID, 
                            startPoint.Character, 
                            startPoint.Value
                        )
                    );
                    
                    // on match copy current path to array
                    Cell[] resultingPath = new Cell[_CurrentPath.Count];
                    _CurrentPath.CopyTo(resultingPath, 0);
                    Array.Reverse(resultingPath);
                    
                    // add array to list of matching paths
                    _MatchingPaths.Add(resultingPath);
                }
            }
            
            foreach (Node child in startPoint.Children) {
                DFS(child, searchInts);
            }
            
            // removing current node from the path stack
            _CurrentPath.Pop();
            
        }
        
        private void DFS(Node startPoint, char[] searchChars) {
            
            
            // adding current node to the stack
            _CurrentPath.Push(new Cell(startPoint.NodeID, startPoint.Character, startPoint.Value));

            for (int i = 0; i < searchChars.Length; i++) {
                
                if (startPoint.Character == searchChars[i]) {
                    // on match, add new Cell for current node
                    _MatchingCells.Add(
                        new Cell(
                            startPoint.NodeID, 
                            startPoint.Character, 
                            startPoint.Value
                        )
                    );
                    
                    // on match copy current path to array
                    Cell[] resultingPath = new Cell[_CurrentPath.Count];
                    _CurrentPath.CopyTo(resultingPath, 0);
                    Array.Reverse(resultingPath);
                    
                    // add array to list of matching paths
                    _MatchingPaths.Add(resultingPath);
                }
            }
            
            foreach (Node child in startPoint.Children) {
                DFS(child, searchChars);
            }
            
            // removing current node from the path stack
            _CurrentPath.Pop();
            
        }
        
        public void DFSLogger() {
            
            // Logging results of Depth-first search
            Console.WriteLine("DFS:");
            
            for (int i = 0; i < _MatchingCells.Count ; i++) {
                
                // Logging data for matching node
                Console.Write("\tNode: " + _MatchingCells[i].NodeID + 
                              "\n\tCharacter: " + _MatchingCells[i].Character + 
                              "\n\tNumber: " + _MatchingCells[i].Value + "\n");
                
                // Logging the path to the answer
                Console.Write("\tPath to Node: ");
                
                foreach (Cell entry in _MatchingPaths[i]) {
                    Console.Write("-" + entry.NodeID);
                }
                
                Console.Write("\n\n");
                
            }
        }
    }
    
    public class BreadtFirstSearch(Node startnode) {
        
        private readonly Node _startNode = startnode;
        private readonly List<Cell> _MatchedNodes = new();
        private readonly Queue<Node> _NodeQueue = new();
        
        
        
        public void Search(int[] searchInts) {
            _MatchedNodes.Clear();
            BFS(searchInts);
        }
        
        
        
        public void Search(char[] searchChars) {
            _MatchedNodes.Clear();
            BFS(searchChars);
        }
        
        
        
        private void BFS(int[] searchInts) {
            
            _NodeQueue.Enqueue(_startNode);
            
            Node currentNode;
            
            do {

                currentNode = _NodeQueue.Dequeue();
                
                for (int i = 0; i < searchInts.Length; i++) {

                    if (currentNode.Value == searchInts[i]) {
                        _MatchedNodes.Add(new Cell(currentNode.NodeID, currentNode.Character, currentNode.Value));
                    }

                }

                foreach (Node child in currentNode.Children) {
                    
                    _NodeQueue.Enqueue(child);
                    
                }

            } while (_NodeQueue.Count > 0);

        }
        
        
        
        
        private void BFS(char[] searchChars) {

            _NodeQueue.Enqueue(_startNode);
            
            Node currentNode;
            
            do {

                currentNode = _NodeQueue.Dequeue();
                
                for (int i = 0; i < searchChars.Length; i++) {

                    if (currentNode.Character == searchChars[i]) {
                        _MatchedNodes.Add(new Cell(currentNode.NodeID, currentNode.Character, currentNode.Value));
                    }

                }

                foreach (Node child in currentNode.Children) {
                    
                    _NodeQueue.Enqueue(child);
                    
                }

            } while (_NodeQueue.Count > 0);
            
        }
        
        
        
        
        public void BFSLogger() {
            
            Console.WriteLine("BFS:");
            
            foreach (Cell item in _MatchedNodes) {
                Console.Write("\tNode: " + item.NodeID + " \tCharacter: " + item.Character + "\tNumber: " + item.Value + "\n");
            }
            
        }
        
    }
    
}