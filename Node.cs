class Node {
  public double value;
  public string name;
  public bool is_visited = false;
  public List<Edge> edges = new List<Edge>();

  public Node(string name, double value) {
    this.name = name;
    this.value = value;
  }

  public void ConnectTo(Node other, double weight) {
    this.edges.Add(new Edge(this, other, weight));
  }
}
