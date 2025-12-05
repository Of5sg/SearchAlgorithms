using System;

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
            
            Node startnode = TreeFactory.CreateNodeTree(6, characters, numbers);
            
            // Console.WriteLine(startnode.Value + "\n" + startnode.Character);
            //
            // Console.WriteLine("Down Left:\n\t" + startnode.Children[0].Value + "\n\t" + startnode.Children[0].Character);
            // Console.WriteLine("Down Right:\n\t" + startnode.Children[1].Value + "\n\t" + startnode.Children[1].Character);
            
            Cell[] result = DFS(startnode, [12]);
            
            foreach (Cell item in result) {
                Console.Write("Cell: " + item.NodeID + " \tCharacter: " + item.Character + "\n");
            }
            
            return 0;
        }
        
        private static char[] BFS(Node startPoint, int[] searchInts) {

            char[] resultChars = new char[0];
            
            // 3 12 72 = cat

            return resultChars;
        }

        private static Cell[] DFS(Node startPoint, int[] searchInts) {
            
            Cell[] resultCells = [];
            
            Console.WriteLine("NodeID: " + startPoint.NodeID);
            Console.WriteLine("Character: " + startPoint.Character + "\n");
            
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
            
            for (int i = 0; i < searchInts.Length; i++) {
                if (startPoint.Value == searchInts[i]) {
                    Array.Resize(ref resultCells, resultCells.Length + 1);
                    resultCells[resultCells.Length - 1] = new Cell(startPoint.NodeID, startPoint.Character);
                }
            }
            
            // 3 12 72 = cat

            return resultCells;

        }
    }
}
