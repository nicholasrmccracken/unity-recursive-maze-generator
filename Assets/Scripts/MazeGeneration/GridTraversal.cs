using System.Collections.Generic;

namespace ShareefSoftware
{
    /// Utility class to traverse a grid.
    public class GridTraversal<T>
    {
        private bool[,] visited;
        private readonly IGridGraph<T> grid;

        /// Constructor
        public GridTraversal(IGridGraph<T> grid)
        {
            this.grid = grid;
        }
        /// Depth First Search Enumeration
        public IEnumerable<((int Row, int Column) From, (int Row, int Column) To)> DepthFirst(int startRow, int startColumn)
        {
            visited = new bool[grid.NumberOfRows, grid.NumberOfColumns];
            return TraverseComponentRecursively((startRow, startColumn));
        }

        private IEnumerable<((int Row, int Column) From, (int Row, int Column) To)> TraverseComponentRecursively((int Row, int Column) cell)
        {
            if (!visited[cell.Row, cell.Column])
            {
                visited[cell.Row, cell.Column] = true;
                foreach (var neighbor in grid.Neighbors(cell.Row, cell.Column))
                {
                    if (!visited[neighbor.Row,neighbor.Column])
                    {
                        foreach (var edge in TraverseComponentRecursively(neighbor))
                            yield return edge;
                        yield return ((cell.Row, cell.Column),neighbor);
                    }
                }
            }
        }
    }
}