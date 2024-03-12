class Edge {
  public Node current_node;
  public Node next_node;
  public double weight = 0;

  public Edge(Node current_node, Node next_node, double weight) {
    this.current_node = current_node;
    this.next_node = next_node;
    this.weight = weight;
  }

  public bool IsVisited() {
    return this.current_node.is_visited && this.next_node.is_visited;
  }
}
