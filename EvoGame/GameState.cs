using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EvoGame
{
    [Serializable]
    public class GameState
    {
        public Bitmap mBuffer;
        public Bitmap mOldBuffer;
        public List<AIEntity> mEntities;
        public long mRunTimeMS;
        public bool mDayTime = true;
        public ControlMode mMode = ControlMode.NONE;
        public static Random RAND = new Random();
        public Point mAvgGen;
        public List<Point> mFoodLocationsR;
        public List<Point> mPoisonLocations;
    }
}
