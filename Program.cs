class Program {
  public static void Main(string[] args) {
    Graph g = new Graph();

    g.CreateNode("a", 0);
    g.CreateNode("b", 0);
    g.CreateNode("c", 0);
    g.CreateNode("d", 0);
    g.CreateNode("e", 0);
    g.CreateNode("f", 0);
    g.CreateNode("g", 0);
    g.CreateNode("h", 0);
    g.CreateNode("i", 0);

    g.ConnectBoth("a", "b", 2);
    g.ConnectBoth("a", "g", 4);
    g.ConnectBoth("c", "d", 3);
    g.ConnectBoth("c", "b", 4);
    g.ConnectBoth("d", "b", 2);
    g.ConnectBoth("b", "g", 6);
    g.ConnectBoth("d", "e", 5);
    g.ConnectBoth("d", "f", 3);
    g.ConnectBoth("g", "f", 10);
    g.ConnectBoth("g", "i", 2);
    g.ConnectBoth("h", "i", 3);
    g.ConnectBoth("h", "f", 4);
    g.ConnectBoth("f", "e", 3);
    g.ConnectBoth("e", "h", 4);

    Graph mst = new PrimMST(g, "e").GetMST();

    Console.WriteLine(mst);
    mst.DFS("a", (Node n) => Console.Write(n.name + " "));
    Console.WriteLine("\nTotal Weights: " + mst.GetTotalWeight() / 2);
  }
}
