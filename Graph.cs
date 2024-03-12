class Graph {
  public Dictionary<string, Node> nodes = new Dictionary<string, Node>();

  public Graph() {}

  public void CreateNode(string node_name, double value) {
    this.nodes[node_name] = new Node(node_name, value);
  }

  public void ConnectTo(string a_name, string b_name, double weight) {
    Node a = this.nodes[a_name];
    Node b = this.nodes[b_name];
    a.ConnectTo(b, weight);
  }

  public void ConnectBoth(string a_name, string b_name, double weight) {
    this.ConnectTo(a_name, b_name, weight);
    this.ConnectTo(b_name, a_name, weight);
  }

  public void CopyNode(Node node) {
    this.nodes[node.name] = new Node(node.name, node.value);
  }

  public void DFS(string start_node_name, Action<Node> func) {
    Node start_node = this.nodes[start_node_name];
    this.ClearVisit(start_node);
    this.DFS(start_node, func);
  }

  private void DFS(Node node, Action<Node> func) {
    if (node.is_visited)
      return;
    func(node);
    node.is_visited = true;
    var edges = node.edges;
    foreach (var edge in edges)
      this.DFS(edge.next_node, func);
  }

  public double GetTotalWeight() {
    double total = 0;
    foreach (var (node_name, node) in this.nodes)
      foreach (var edge in node.edges)
        total += edge.weight;
    return total;
  }

  public void ClearVisit(Node node) {
    if (!node.is_visited)
      return;
    node.is_visited = false;
    var edges = node.edges;
    foreach (var edge in edges)
      this.ClearVisit(edge.next_node);
  }

  public override string ToString() {
    string str = "";
    foreach (var (node_name, node) in this.nodes) {
      str += node_name + " -> ";
      List<Edge> edges = node.edges;
      foreach (var edge in edges)
        str += edge.next_node.name + ":" + edge.weight + " ";
      str += "\n";
    }
    return str;
  }
}
