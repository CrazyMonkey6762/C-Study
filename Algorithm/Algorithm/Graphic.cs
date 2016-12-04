using System;
using System.Collections.Generic;

namespace Algorithm
{
    /// <summary>
    ///   图及图的一些操作
    /// </summary>
    public class Graphic
    {
        private int _scale;
        private int[,] Map;
        private const int NOEDGE = int.MaxValue;

        /// <summary>
        ///   返回图规模
        /// </summary>
        public int Scale
        {
            get
            {
                return _scale;
            }
        }

        private Graphic() { }
        public Graphic(int[,] map)
        {
            this.Map = map;
            this._scale = (int)Math.Sqrt(map.Length);
        }

        public int GetDistance(int source, int dist)
        {
            try
            {
                return Map[source , dist];
            }
            catch (Exception ex)
            {
                throw new Exception("Graphic--GetDistance:" + ex.Message);
            }
        }

        public int[] GetWay(int curr)
        {
            int[] temp = new int[Scale];
            try
            {
                for (int i = 0; i < Scale; i++)
                {
                    temp[i] = Map[curr - 1, i];
                }
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception("Graphic--GetWay:" + ex.Message);
            }
        }
    }
}
