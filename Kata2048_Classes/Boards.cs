using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata2048
{
    public class Boards
    {
        #region Boards
        public static int[,] BOARD_01 = new int[4, 4]
                                              {
                                                  { 2, 4, 0, 0 },
                                                  { 0, 0, 0, 2 },
                                                  { 0, 0, 2, 0 },
                                                  { 0, 2, 0, 0 }
                                              };

        public static int[,] BOARD_01_MOVE_WITH_ACUMULATE = new int[4, 4]
                                                                      { { 2, 0, 0, 2 },
                                                                        { 2, 4, 0, 4 },
                                                                        { 2, 2, 2, 2 },
                                                                        { 2, 0, 2, 2 } };

        public static int[,] BOARD_02_NO_MOVE_TOP = new int[4, 4] { { 2, 4, 2, 4 }, 
                                                                    { 0, 0, 0, 0 }, 
                                                                    { 0, 0, 0, 0 }, 
                                                                    { 0, 0, 0, 0 } };

        public static int[,] BOARD_02_NO_MOVE_RIGHT = new int[4, 4] { { 0, 0, 0, 2 }, 
                                                                      { 0, 0, 0, 2 }, 
                                                                      { 0, 0, 0, 2 }, 
                                                                      { 0, 0, 0, 2 } };

        public static int[,] BOARD_02_NO_MOVE_BOTTOM = new int[4, 4] { { 0, 0, 0, 0 }, 
                                                                       { 0, 0, 0, 0 }, 
                                                                       { 0, 0, 0, 0 }, 
                                                                       { 2, 4, 4, 2 } };

        public static int[,] BOARD_02_NO_MOVE_LEFT = new int[4, 4] { { 4, 0, 0, 0 }, 
                                                                     { 2, 4, 0, 0 }, 
                                                                     { 4, 0, 0, 0 }, 
                                                                     { 2, 2, 4, 0 } };
        #endregion
    }
}
