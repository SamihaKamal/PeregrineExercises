namespace DjikstraSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DirectedWeightGraph g = new DirectedWeightGraph();

            g.InsertVertex("Zero");
            g.InsertVertex("One");
            g.InsertVertex("Two");
            g.InsertVertex("Three");
            g.InsertVertex("Four");
            g.InsertVertex("Five");
            g.InsertVertex("Six");
            g.InsertVertex("Seven");
            g.InsertVertex("Eight");
            

            g.InsertEdge("Zero", "One",2);
            g.InsertEdge("Zero", "Three",5);
            g.InsertEdge("One", "Two",8);
            g.InsertEdge("One", "Four",2);
            g.InsertEdge("One", "Five",3);
            g.InsertEdge("Two", "Three",4);
            g.InsertEdge("Two", "Five",7);
            g.InsertEdge("Three", "Six",8);
            g.InsertEdge("Four", "Five",9);
            g.InsertEdge("Four", "Seven",4);
            g.InsertEdge("Five", "Six",6);
            g.InsertEdge("Five", "Eight",9);
            g.InsertEdge("Six", "Eight",5);
            g.InsertEdge("Seven", "Eight",3);
           

            g.FindPaths("Zero");
            Console.ReadLine();
        }
    }
}
