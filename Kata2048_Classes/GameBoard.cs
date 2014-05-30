using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Kata2048_Classes
{
    public class GameBoard
    {
        public enum MovementType
        {
            TOP,
            RIGHT,
            BOTTOM,
            LEFT
        }

        private const int WIN_VALUE = 2048;
        public int Score = 0;
        private bool _isGameOver = false;

        public readonly int numRows;
        public readonly int numColumns;

        public int[,] listaCeldas;

        public GameBoard(int[,] boardSample)
        {
            this.numRows = 4;
            this.numColumns = 4;
            this.listaCeldas = boardSample;
        }

        public GameBoard(int numRows, int numColumns)
        {
            this.numRows = numRows;
            this.numColumns = numColumns;
            this.listaCeldas = new int[this.numRows, this.numColumns];
            Reset();
        }

        public void Reset()
        {
            this._isGameOver = false;
            this.Score = 0;

            for (int r = 0; r < this.numRows;r++ )
                for (int c = 0; c < this.numColumns; c++)
                    this.listaCeldas[r,c] = 0;
        }

        public void Initialize()
        {
            Initialize(2);
        }

        /// <summary>
        /// Inicialize the board with the number of numbers to display.
        /// </summary>
        /// <param name="countNumbersToDisplay">Number of numbers to display.</param>
        public void Initialize(int countNumbersToDisplay)
        {
            List<int> countPositions = GetRandomInitialPositions(countNumbersToDisplay);

            int _cont = 0;
            for(int r = 0; r < this.numRows; r++)
            {
                for (int c = 0; c < this.numColumns; c++)
                {
                    if (countPositions.Contains(_cont))
                        this.listaCeldas[r, c] = 2; // Minimal Value

                    _cont++;
                }
            }
        }

        private List<int> GetRandomInitialPositions(int countPositionsToDisplay)
        {
            List<int> nums = new List<int>();

            // Números comprendidos entre 1 y Rows X Columns
            while (nums.Count < countPositionsToDisplay)
            {
                Random rnd = new Random();
                int n = rnd.Next(1, this.numRows * this.numColumns);

                if (!nums.Contains(n))
                {
                    nums.Add(n);
                    System.Threading.Thread.Sleep(n);
                }
            }

            return nums;
        }

        #region MOVE TO TOP
        /// <summary>
        /// OPTIMIZE: Move the cells in TOP direction.
        /// </summary>
        /// <returns>Return if cells are moved.</returns>
        public bool MoveToTop()
        {
            #region Move To TOP
            Debug.WriteLine("----- TOP -----");

            bool result = false;
            bool isMoved = true;
            bool isAcum = true;
            
            isMoved = moveValuesToTop();
            isAcum = acumulateValuesToTop();
            if (isAcum)
                isMoved = moveValuesToTop();

            if (isMoved || isAcum)
            {
                result = true;
                generateRandomValueInEmptyCell();
            }

            return result;
            #endregion
        }

        private bool moveValuesToTop()
        {
            #region moveValuesToTop
            bool result = false;
            bool isMoved = true;

            while (isMoved)
            {
                isMoved = false;
                for (int r = this.numRows-1; r >= 0; r--)
                {
                    for (int c = 0; c < this.numColumns; c++)
                    {
                        if (r > 0) // Dont try the first row
                        {
                            int numberCurrent = this.listaCeldas[r, c];
                            if ((numberCurrent > 0) && (this.listaCeldas[r - 1, c] == 0))
                            {
                                // Move the number up one row.
                                this.listaCeldas[r - 1, c] = numberCurrent;
                                // Reset the current cell.
                                this.listaCeldas[r, c] = 0;
                                isMoved = true;
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
            #endregion
        }

        private bool acumulateValuesToTop()
        {
            #region acumulateValuesToTop
            bool result = false;
            for (int c = 0; c < this.numColumns;c++ )
            {
                for (int r = 1; r < this.numRows; r++)
                {
                    if((this.listaCeldas[r,c] == this.listaCeldas[r-1,c]) && (this.listaCeldas[r, c] > 0))
                    {
                        // Acumulate the values.
                        this.listaCeldas[r - 1, c] = this.listaCeldas[r - 1, c] + this.listaCeldas[r, c];
                        // Add value to the Score
                        AddScore(this.listaCeldas[r - 1, c]);
                        // Empty the cell.
                        this.listaCeldas[r, c] = 0;
                        result = true;
                    }
                }
            }
            return result;
            #endregion
        }

        #endregion

        #region MOVE TO RIGHT
        public bool MoveToRight()
        {
            #region Move To RIGHT
            Debug.WriteLine("----- RIGHT -----");

            bool result = false;
            bool isMoved = true;
            bool isAcum = true;

            isMoved = moveValuesToRight();
            isAcum = acumulateValuesToRight();
            if (isAcum)
                isMoved = moveValuesToRight();

            if (isMoved || isAcum)
            {
                result = true;
                generateRandomValueInEmptyCell();
            }

            return result;
            #endregion
        }

        private bool moveValuesToRight()
        {
            #region moveValuesToRight
            bool result = false;
            bool isMoved = true;

            while (isMoved)
            {
                isMoved = false;
                for (int r = 0; r < this.numRows; r++)
                {
                    for (int c = 0; c < this.numColumns; c++)
                    {
                        if (c < this.numColumns - 1) // Dont try the last column
                        {
                            int numberCurrent = this.listaCeldas[r, c];
                            if ((numberCurrent > 0) && (this.listaCeldas[r, c + 1] == 0))
                            {
                                // Move the number to right one column.
                                this.listaCeldas[r, c + 1] = numberCurrent;
                                // Reset the current cell.
                                this.listaCeldas[r, c] = 0;
                                isMoved = true;
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
            #endregion
        }

        private bool acumulateValuesToRight()
        {
            #region acumulateValuesToRight
            bool result = false;
            for (int r = 0; r < this.numRows; r++)
            {
                for (int c = this.numColumns-1; c > 0; c--)
                {
                    if ((this.listaCeldas[r, c] == this.listaCeldas[r, c - 1]) && (this.listaCeldas[r, c] > 0))
                    {
                        // Acumulate the values.
                        this.listaCeldas[r, c] = this.listaCeldas[r, c - 1] + this.listaCeldas[r, c];
                        // Add value to the Score
                        AddScore(this.listaCeldas[r, c]);
                        // Empty the cell.
                        this.listaCeldas[r, c - 1] = 0;
                        result = true;
                    }
                }
            }
            return result;
            #endregion
        }
        #endregion

        #region MOVE TO BOTTOM
        /// <summary>
        /// OPTIMIZE: Move the cells in BOTTOM direction.
        /// </summary>
        /// <returns>Return if cells are moved.</returns>
        public bool MoveToBottom()
        {
            #region Move To BOTTOM
            Debug.WriteLine("---- BOTTOM ----");

            bool result = false;
            bool isMoved = true;
            bool isAcum = true;

            isMoved = moveValuesToBottom();
            isAcum = acumulateValuesToBottom();
            if (isAcum)
                isMoved = moveValuesToBottom();

            if (isMoved || isAcum)
            {
                result = true;
                generateRandomValueInEmptyCell();
            }

            return result;
            #endregion
        }

        private bool moveValuesToBottom()
        {
            #region moveValuesToBottom
            bool result = false;
            bool isMoved = true;

            while (isMoved)
            {
                isMoved = false;
                for (int r = this.numRows - 1; r >= 0; r--)
                {
                    for (int c = 0; c < this.numColumns; c++)
                    {
                        if (r < this.numRows-1) // Dont try the last row
                        {
                            int numberCurrent = this.listaCeldas[r, c];
                            if ((numberCurrent > 0) && (this.listaCeldas[r + 1, c] == 0))
                            {
                                // Move the number down one row.
                                this.listaCeldas[r + 1, c] = numberCurrent;
                                // Reset the current cell.
                                this.listaCeldas[r, c] = 0;
                                isMoved = true;
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
            #endregion
        }

        private bool acumulateValuesToBottom()
        {
            #region acumulateValuesToBottom
            bool result = false;
            for (int r = this.numRows-1; r > 0; r--)
            {
                for (int c = 0; c < this.numColumns; c++)
                {
                    if ((this.listaCeldas[r, c] == this.listaCeldas[r - 1, c]) && (this.listaCeldas[r, c] > 0))
                    {
                        // Acumulate the values.
                        this.listaCeldas[r, c] = this.listaCeldas[r - 1, c] + this.listaCeldas[r, c];
                        // Add value to the Score
                        AddScore(this.listaCeldas[r, c]);
                        // Empty the cell.
                        this.listaCeldas[r - 1, c] = 0;
                        result = true;
                    }
                }
            }
            return result;
            #endregion
        }
        #endregion

        #region MOVE TO LEFT
        public bool MoveToLeft()
        {
            #region Move To LEFT
            Debug.WriteLine("----- LEFT -----");

            bool result = false;
            bool isMoved = true;
            bool isAcum = true;

            isMoved = moveValuesToLeft();
            isAcum = acumulateValuesToLeft();
            if (isAcum)
                isMoved = moveValuesToLeft();

            if (isMoved || isAcum)
            {
                result = true;
                generateRandomValueInEmptyCell();
            }

            return result;
            #endregion
        }

        private bool moveValuesToLeft()
        {
            #region moveValuesToLeft
            bool result = false;
            bool isMoved = true;

            while (isMoved)
            {
                isMoved = false;
                for (int r = 0; r < this.numRows; r++)
                {
                    for (int c = this.numColumns-1; c > 0; c--)
                    {
                        if (c > 0) // Dont try the first column
                        {
                            int numberCurrent = this.listaCeldas[r, c];
                            if ((numberCurrent > 0) && (this.listaCeldas[r, c - 1] == 0))
                            {
                                // Move the number to left one column.
                                this.listaCeldas[r, c - 1] = numberCurrent;
                                // Reset the current cell.
                                this.listaCeldas[r, c] = 0;
                                isMoved = true;
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
            #endregion
        }

        private bool acumulateValuesToLeft()
        {
            #region acumulateValuesToLeft
            bool result = false;
            for (int r = 0; r < this.numRows; r++)
            {
                for (int c = 1; c < this.numColumns; c++)
                {
                    if ((this.listaCeldas[r, c - 1] == this.listaCeldas[r, c]) && (this.listaCeldas[r, c] > 0))
                    {
                        // Acumulate the values.
                        this.listaCeldas[r, c - 1] = this.listaCeldas[r, c - 1] + this.listaCeldas[r, c];
                        // Add value to the Score
                        AddScore(this.listaCeldas[r, c - 1]);
                        // Empty the cell.
                        this.listaCeldas[r, c] = 0;
                        result = true;
                    }
                }
            }
            return result;
            #endregion
        }
        #endregion

        /// <summary>
        /// Generate number, 2 or 4, in empty cell, 95% => 2 and 5% => 4
        /// </summary>
        private void generateRandomValueInEmptyCell()
        {
            List<Tuple<int, int>> listEmptyCells = new List<Tuple<int, int>>();

            #region Get list the empty cells
            for (int r= 0;r<this.numRows;r++)
            {
                for (int c = 0; c < this.numColumns; c++)
                {
                    if(this.listaCeldas[r,c] == 0)
                    {
                        listEmptyCells.Add(new Tuple<int, int>(r, c));
                    }
                }
            }
            #endregion

            #region Get random number between 1 and listEmptyCells.Count
            Random rnd = new Random(DateTime.Now.Millisecond);

            int num = rnd.Next(0, listEmptyCells.Count);
            #endregion

            // Generate the new value
            int newValue = getNewValue();

            // Set the new value in empty cells generated random
            this.listaCeldas[listEmptyCells[num].Item1, listEmptyCells[num].Item2] = newValue;
        }

        /// <summary>
        /// Generate a number, 95% times get a 2, and 5% times get a 4.
        /// </summary>
        private int getNewValue()
        {
            int result = 0;
            Random rnd = new Random(DateTime.Now.Millisecond);
            int v = rnd.Next(1, 100);
            if (v < 95)
                result = 2;
            else
                result = 4;

            return result;
        }

        /// <summary>
        /// Get the number of the cells contain a values greater than zero.
        /// </summary>
        /// <returns></returns>
        public int PopulationValuesCount()
        {
            int result = 0;
            for (int r = 0; r < this.numRows; r++)
            {
                for (int c = 0; c < this.numColumns; c++)
                {
                    if (this.listaCeldas[r, c] > 0)
                        result++;
                }
            }
            return result;
        }

        public void Print()
        {
            for (int r = 0; r < this.numRows; r++)
            {
                for (int c = 0; c < this.numColumns; c++)
                {
                    Debug.Write(this.listaCeldas[r, c].ToString().PadLeft(4, ' ').PadRight(4, ' '));
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("-------------------");
        }

        public bool IsGameOver()
        {
            bool result = true;
            bool isPosibleAcum = false;
            
            if(PopulationValuesCount() == this.numRows * this.numColumns)
            {
                for (int r = 0; r < this.numRows; r++) 
                {
                    for (int c = 0; c < this.numColumns; c++)
                    {
                        if(r == 0)
                        {
                            if(c == 0)
                            {
                                // View values = RIGHT, BOTTOM
                                bool rr = IsEqualValue(r, c, GameBoard.MovementType.RIGHT);
                                bool bb = IsEqualValue(r, c, GameBoard.MovementType.BOTTOM);
                                isPosibleAcum = (rr || bb);
                            }
                            else if(c == this.numColumns - 1)
                            {
                                // View values = LEFT, BOTTOM
                                bool ll = IsEqualValue(r, c, GameBoard.MovementType.LEFT);
                                bool bb = IsEqualValue(r, c, GameBoard.MovementType.BOTTOM);
                                isPosibleAcum = (ll || bb);
                            }
                            else
                            {
                                // View values = LEFT, RIGHT, BOTTOM
                                bool ll = IsEqualValue(r, c, GameBoard.MovementType.LEFT);
                                bool rr = IsEqualValue(r, c, GameBoard.MovementType.RIGHT);
                                bool bb = IsEqualValue(r, c, GameBoard.MovementType.BOTTOM);
                                isPosibleAcum = (ll || rr || bb);
                            }
                        }
                        else if(r == this.numRows - 1)
                        {
                            if (c == 0)
                            {
                                // View values = TOP, RIGHT
                                bool tt = IsEqualValue(r, c, GameBoard.MovementType.TOP);
                                bool rr = IsEqualValue(r, c, GameBoard.MovementType.RIGHT);
                                isPosibleAcum = (tt || rr);
                            }
                            else if (c == this.numColumns - 1)
                            {
                                // View values = TOP, LEFT
                                bool tt = IsEqualValue(r, c, GameBoard.MovementType.TOP);
                                bool ll = IsEqualValue(r, c, GameBoard.MovementType.LEFT);
                                isPosibleAcum = (tt || ll);
                            }
                            else
                            {
                                // View values = TOP, LEFT, RIGHT
                                bool tt = IsEqualValue(r, c, GameBoard.MovementType.TOP);
                                bool ll = IsEqualValue(r, c, GameBoard.MovementType.LEFT);
                                bool rr = IsEqualValue(r, c, GameBoard.MovementType.RIGHT);
                                isPosibleAcum = (tt || ll || rr);
                            }
                        }
                        else
                        {
                            // View values = TOP, RIGHT, BOTTOM, LEFT
                            bool tt = IsEqualValue(r, c, GameBoard.MovementType.TOP);
                            bool rr = IsEqualValue(r, c, GameBoard.MovementType.RIGHT);
                            bool bb = IsEqualValue(r, c, GameBoard.MovementType.BOTTOM);                            
                            bool ll = IsEqualValue(r, c, GameBoard.MovementType.LEFT);
                            isPosibleAcum = (tt || rr || bb || ll);
                        }

                        if (isPosibleAcum)
                            result = false;
                    }
                }
            }
            return result;
        }

        private bool IsEqualValue(int row, int column, MovementType movementType)
        {
            bool result = false;
            switch (movementType)
            {
                case MovementType.TOP:
                    if(row > 0)
                        result = (this.listaCeldas[row, column] == this.listaCeldas[row - 1, column]);
                    break;
                case MovementType.RIGHT:
                    if(column < this.numColumns - 1)
                        result = (this.listaCeldas[row, column] == this.listaCeldas[row, column + 1]);
                    break;
                case MovementType.BOTTOM:
                    if(row < this.numRows - 1)
                        result = (this.listaCeldas[row, column] == this.listaCeldas[row + 1, column]);
                    break;
                case MovementType.LEFT:
                    if(column > 0)
                        result = (this.listaCeldas[row, column] == this.listaCeldas[row, column - 1]);
                    break;
            }
            return result;
        }

        public bool HasWin()
        {
            for (int r = 0; r < this.numRows; r++)
            {
                for (int c = 0; c < this.numColumns; c++)
                {
                    if (this.listaCeldas[r, c] == WIN_VALUE)
                        return true;
                }
            }
            return false;
        }

        public void AddScore(int value)
        {
            this.Score += value;
        }
    }
}