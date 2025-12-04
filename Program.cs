

namespace SearchAlgorithms {

    class Program {

        public static int Main() {

            char[] characters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];

            int[] numbers = [12, 4, 3, 6, 7, 5, 8, 2, 11, 14, 67, 54, 32, 89, 71, 93, 42, 41, 63, 72, 75, 76, 82, 83];
            
            Node startnode = TreeFactory.CreateNodeTree(2, characters, numbers);
            
            Console.WriteLine(startnode.Value + "\n" + startnode.Character);
            
            Console.WriteLine("Down Left:\n\t" + startnode.Connections["dl"].Value + "\n\t" + startnode.Connections["dl"].Character);
            Console.WriteLine("Down Right:\n\t" + startnode.Connections["dr"].Value + "\n\t" + startnode.Connections["dr"].Character);
            

            return 0;
        }
        
        private static void BFS(Node starPoint) {
            
        }
        
    }
    
}