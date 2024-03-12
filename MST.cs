class PrimMST {
  private Graph mst;
  private List<Edge> edges;

  public PrimMST(Graph graph, string start_node_name) {
    this.mst = new Graph();
    this.edges = new List<Edge>();

    Node start_node = graph.nodes[start_node_name];
    graph.ClearVisit(start_node);

    this.VisitNode(start_node);
    this.Parse();
  }

  private void Parse() {
    while (this.edges.Count > 0) {
      Edge min_edge = this.FindMinEdge();
      Node next_node = min_edge.next_node;

      this.VisitNode(next_node);
      this.mst.ConnectBoth(min_edge.current_node.name, next_node.name,
                           min_edge.weight);
      this.RemoveVisitedEdges();
    }
  }

  private void VisitNode(Node node) {
    this.AddEdgesFromNode(node);
    this.mst.CopyNode(node);
    node.is_visited = true;
  }

  private void AddEdgesFromNode(Node node) { this.edges.AddRange(node.edges); }

  private void RemoveVisitedEdges() {
    this.edges = this.edges.Where(edge => !edge.IsVisited()).ToList();
  }

  private Edge FindMinEdge() {
    return this.edges.Aggregate(
        this.edges[0],
        (min_edge, current_edge) =>
            current_edge.weight < min_edge.weight ? current_edge : min_edge);
  }

  public Graph GetMST() { return this.mst; }
}
