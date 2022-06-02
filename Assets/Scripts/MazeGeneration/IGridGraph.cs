using System.Collections.Generic;

namespace ShareefSoftware
{
    public interface IGridGraph<T> : IEnumerable<(int Row, int Column, T NodeValue)>
    {
        int NumberOfRows { get; }
        int NumberOfColumns { get; }

        T GetCellValue(int row, int column);
        IEnumerable<(int Row, int Column)> Neighbors(int row, int column);
    }
}
