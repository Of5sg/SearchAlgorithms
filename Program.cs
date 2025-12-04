

namespace SearchAlgorithms {

    class Program {

        public static int Main() {

            char[] characters = ['a', 'b', 'c'];

            Node startnode = TreeFactory.CreateNodeTree(2, characters);
            
            Console.WriteLine(startnode.Value);
            
            Console.WriteLine(startnode.Connections["dl"].Value);
            Console.WriteLine(startnode.Connections["dr"].Value);
            

            return 0;
        }
        
        // private static void BFS() {
        //       
        // }
        
        
        
        
    }
    
    
}