using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LogicIO;
namespace EvoGame
{
    [Serializable]
    public enum ControlMode
    {
        NONE,
        SMITE,
        FEED
    }

    public partial class GameForm : Form
    {
        public static int M_WIDTH = 1100;
        public static int M_HEIGHT = 600;

        private Graphics mBufferGfx;
        private Graphics mOldGfx;
        private Graphics mFormGfx;
        private Timer mPulser;
        private DateTime mLastPulse;

        private static int M_MATURITY_AGE = 200;
        private static int M_MAX_ENTITIES = 200;
        private static int M_TICK_INTERVAL = 50;
        private static int M_DAY_INTERVAL = 30;
        
        private GameState me;
        

        public GameForm()
        {
            InitializeComponent();
            me = new GameState();
            this.gfxPanel.Width = M_WIDTH;
            this.gfxPanel.Height = M_HEIGHT;
            this.Paint += new PaintEventHandler(GameForm_Paint);
            AIEntity.InitImage();
            me.mBuffer = new Bitmap(M_WIDTH, M_HEIGHT, PixelFormat.Format32bppArgb);
            me.mOldBuffer = (Bitmap)me.mBuffer.Clone();

            
            me.mFoodLocationsR = new List<Point>();
            me.mPoisonLocations = new List<Point>();
            me.mEntities = new List<AIEntity>();
            me.mAvgGen = new Point(0, 0);
            for (int i = 0; i < M_MAX_ENTITIES; i++)
                AddEntity(new AIEntity(Buffer));

            for (int ii = 0; ii < 400; ii++)
                me.mFoodLocationsR.Add(new Point(GameState.RAND.Next(0, Width), GameState.RAND.Next(0, Height)));

            InitGraphics();

            int num = 150;
            for (double r = num - 1; r >= 0; r -= 0.2)
            {
                int val = (int)Math.Round(((double)r / num) * 255);
                mOldGfx.DrawEllipse(new Pen(Color.FromArgb(val, val, val)), (int)Math.Round(M_WIDTH / 2 - r / 2 - 100), (int)Math.Round(M_HEIGHT / 2 - r / 2), (int)Math.Round(r), (int)Math.Round(r));
            }

            for (double r = num - 1; r >= 0; r -= 0.2)
            {
                int val = (int)Math.Round(((double)r / num) * 255);
                mOldGfx.DrawEllipse(new Pen(Color.FromArgb(val, val, val)), (int)Math.Round(M_WIDTH / 2 - r / 2 + 100), (int)Math.Round(M_HEIGHT / 2 - r / 2), (int)Math.Round(r), (int)Math.Round(r));
            }

            for (double r = num - 1; r >= 0; r -= 0.2)
            {
                int val = (int)Math.Round(((double)r / num) * 255);
                mOldGfx.DrawEllipse(new Pen(Color.FromArgb(val, val, val)), (int)Math.Round(M_WIDTH / 2 - r / 2 - 210), (int)Math.Round(M_HEIGHT / 2 - r / 2 + 100), (int)Math.Round(r), (int)Math.Round(r));
            }

            for (double r = num - 1; r >= 0; r -= 0.2)
            {
                int val = (int)Math.Round(((double)r / num) * 255);
                mOldGfx.DrawEllipse(new Pen(Color.FromArgb(val, val, val)), (int)Math.Round(M_WIDTH / 2 - r / 2 + 230), (int)Math.Round(M_HEIGHT / 2 - r / 2 - 100), (int)Math.Round(r), (int)Math.Round(r));
            }
            

            InitGame();



            gfxPanel.Click += new EventHandler(gfxPanel_Click);
        }

        private void InitGame()
        {
            gfxPanel_Paint(null, null);
            mPulser = new Timer();
            mPulser.Interval = M_TICK_INTERVAL;
            mPulser.Tick += new EventHandler(mPulser_Tick);
            numDayInt.Value = M_DAY_INTERVAL;
            mPulser.Start();
        }

        private void InitGraphics()
        {
            mOldGfx = Graphics.FromImage(me.mOldBuffer);
            mBufferGfx = Graphics.FromImage(me.mBuffer);
            mFormGfx = gfxPanel.CreateGraphics();
            mOldGfx.FillRectangle(Brushes.White, new Rectangle(0, 0, M_WIDTH, M_HEIGHT));
        }

        void gfxPanel_Click(object sender, EventArgs e)
        {
            if (me.mMode != ControlMode.NONE)
            {
                AIEntity ent = EntityAtPoint(new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
                switch (me.mMode)
                {
                    case ControlMode.SMITE:
                        if (ent != null)
                        {
                            for (int i = 0; i < 10; i++)
                                ent.Mutate();
                        }
                        break;
                    case ControlMode.FEED:
                        if (ent != null)
                            ent.Feed();
                        break;
                }
                me.mMode = ControlMode.NONE;
                Cursor = Cursors.Arrow;
                Draw();
                gfxPanel_Paint(sender, e);
                GameForm_Paint(sender, e);
            }
            
        }

        void mPulser_Tick(object sender, EventArgs e)
        {
            long pulses = me.mRunTimeMS / M_TICK_INTERVAL;
            double ratio = -1;
            if (pulses % 10 == 0 && mLastPulse != null)
            {
                TimeSpan span0 = DateTime.Now.Subtract(mLastPulse);
                ratio = ((double)M_TICK_INTERVAL) / span0.TotalMilliseconds;
                mLastPulse = DateTime.Now;
                txtSpeed.Text = (ratio * 100).ToString("0.0");
            }

            double avgGen = 0;

            if (me.mAvgGen.X != 0)
                avgGen = ((double)me.mAvgGen.Y) / me.mAvgGen.X;

            txtAvgGen.Text = avgGen.ToString("0.000");

            if (pulses > 500 * M_DAY_INTERVAL && pulses % (2 * M_DAY_INTERVAL) == M_DAY_INTERVAL)
            {
                me.mDayTime = !me.mDayTime;
                if (!me.mDayTime)
                    mOldGfx.FillRectangle(Brushes.Black, new Rectangle(0, 0, M_WIDTH, M_HEIGHT));
                else
                    mOldGfx.FillRectangle(Brushes.White, new Rectangle(0, 0, M_WIDTH, M_HEIGHT));
            }

            RefreshFood();
            if (GameState.RAND.NextDouble() < 0.05 && me.mEntities.Count < M_MAX_ENTITIES)
            {
                int indexMut = GameState.RAND.Next(0, me.mEntities.Count);
                if (me.mEntities.Count > 0 && me.mEntities[indexMut].Age >= M_MATURITY_AGE)
                {
                    AddEntity(((AIEntity)me.mEntities[indexMut].Clone()).Mutate());
                }
            }

            for (int iii = 0; iii < me.mEntities.Count; iii++)
            {
                bool passValue = false;

                if (me.mDayTime)
                {
                    for (int iiii = 0; iiii < me.mFoodLocationsR.Count; iiii++)
                    {
                        Point lpnt = me.mFoodLocationsR[iiii];
                        if (Math.Abs(lpnt.X - me.mEntities[iii].Position.X) <= 20
                         && Math.Abs(lpnt.Y - me.mEntities[iii].Position.Y) <= 20)
                        {
                            passValue = true;
                            me.mFoodLocationsR.RemoveAt(iiii);
                            iiii--;
                        }
                    }
                }
                

                bool poisonValue = false;
                for (int iiii = 0; iiii < me.mPoisonLocations.Count; iiii++)
                {
                    Point lpnt = me.mPoisonLocations[iiii];
                    if (Math.Abs(lpnt.X - me.mEntities[iii].Position.X) <= 20
                     && Math.Abs(lpnt.Y - me.mEntities[iii].Position.Y) <= 20)
                    {
                        poisonValue = true;
                        me.mPoisonLocations.RemoveAt(iiii);
                        iiii--;
                    }
                }

                bool val = me.mEntities[iii].StepTime(passValue, poisonValue);

                if (!val)
                {
                    RemoveEntityAt(iii);
                    iii--;
                }
            }

            entCountVal.Text = me.mEntities.Count.ToString();

            Draw();
            gfxPanel_Paint(sender, e);
            GameForm_Paint(sender, e);

            TimeSpan span = TimeSpan.FromMilliseconds(me.mRunTimeMS);
            timeVal.Text = String.Format("{0}:{1}:{2}", span.Hours, span.Minutes, span.Seconds);
            me.mRunTimeMS += M_TICK_INTERVAL;
        }

        private AIEntity EntityAtPoint(Point aPoint)
        {
            foreach (AIEntity lEnt in me.mEntities)
            {
                RectangleF rect = new RectangleF(new PointF(lEnt.Position.X - AIEntity.M_WIDTH/2, lEnt.Position.Y - AIEntity.M_HEIGHT/2), new SizeF(AIEntity.M_WIDTH, AIEntity.M_HEIGHT));
                if (rect.Contains(aPoint))
                {
                    return lEnt;
                }
            }

            return null;
        }

        private void Draw()
        {
            mBufferGfx.Clear(Color.FromArgb(235, 235, 235));
            mBufferGfx.DrawImage(me.mOldBuffer, 0, 0);

            if (me.mDayTime)
            {
                foreach (Point lpnt in me.mFoodLocationsR)
                {
                    mBufferGfx.FillRectangle(Brushes.DarkRed, lpnt.X, lpnt.Y, 5, 5);
                }

                foreach (Point lpnt in me.mPoisonLocations)
                {
                    mBufferGfx.FillRectangle(Brushes.HotPink, lpnt.X, lpnt.Y, 5, 5);
                }
            }

            foreach (AIEntity lent in me.mEntities)
            {
                lent.Draw();
            }
        }

        private void RefreshFood()
        {
            for (int i = 0; i < 5; i++)
            {
                if (GameState.RAND.NextDouble() < 0.25 && me.mFoodLocationsR.Count > 0)
                    me.mFoodLocationsR.RemoveAt(GameState.RAND.Next(0, me.mFoodLocationsR.Count));
                else if (me.mFoodLocationsR.Count < 400)
                {
                    me.mFoodLocationsR.Add(new Point(GameState.RAND.Next(5, M_WIDTH), GameState.RAND.Next(0, M_HEIGHT)));
                }
            }
        }

        private void AddEntity(AIEntity aEntity)
        {
            me.mEntities.Add(aEntity);
            me.mAvgGen.X++;
            me.mAvgGen.Y += aEntity.Generation;
        }

        private void RemoveEntityAt(int aIndex)
        {
            me.mAvgGen.X--;
            me.mAvgGen.Y -= me.mEntities[aIndex].Generation;
            me.mEntities.RemoveAt(aIndex);
        }

        private void GameForm_Paint(object sender, EventArgs e)
        {
            mFormGfx.DrawImage(me.mBuffer, 0, 0);
        }

        private void gfxPanel_Paint(object sender, EventArgs e)
        {
            mFormGfx.DrawImage(me.mBuffer, 0, 0);
        }

        public Bitmap Buffer
        {
            get { return me.mBuffer; }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void numDayInt_ValueChanged(object sender, EventArgs e)
        {
            M_DAY_INTERVAL = (int)numDayInt.Value;
        }

        private void pauseSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPulser.Stop();
        }

        private void continueSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPulser.Start();
        }

        private void smiteEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stre = Assembly.GetExecutingAssembly().GetManifestResourceStream("EvoGame.skull.cur");
            me.mMode = ControlMode.SMITE;
            Cursor = new Cursor(stre);
        }

        private void startNewSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPulser.Stop();
            InitGame();
            InitGraphics();
        }

        private void serializeToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = dlgSerialize.ShowDialog();
            if (res == DialogResult.OK)
            {
                using (Stream stre = dlgSerialize.OpenFile())
                {
                    BinaryFormatter fmt = new BinaryFormatter();

                    fmt.Serialize(stre, me);
                    stre.Flush();
                    stre.Close();
                }
            }

        }

        private void deserializeFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mPulser.Stop();
            mPulser = null;
            DialogResult res = dlgDeserialize.ShowDialog();
            if (res == DialogResult.OK)
            {
                using (Stream stre = dlgDeserialize.OpenFile())
                {
                    BinaryFormatter fmt = new BinaryFormatter();

                    me = (GameState)fmt.Deserialize(stre);
                    InitGraphics();
                    InitGame();
                }
            }
        }

        private void feedEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stre = Assembly.GetExecutingAssembly().GetManifestResourceStream("EvoGame.plus.cur");
            me.mMode = ControlMode.FEED;
            Cursor = new Cursor(stre);
        }

        private void btnNuke_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < me.mEntities.Count - 1; i++)
                me.mEntities[i].Smite();
        }

        private void entitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntitiesView view = new EntitiesView(me);
            view.Show();
        }
    }
}
