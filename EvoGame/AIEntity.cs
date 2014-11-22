using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LogicIO;
using LogicIO.Gates;
using System.Windows.Forms;
namespace EvoGame
{
    [Serializable]
    public class AIEntity : ICloneable, IMutatable<AIEntity>
    {
        private Brain mBrain;

        // inputs are thresholds -- values really only cause variation in output in a small range
        public static int M_INPUTS = 15;
        public static int M_OUTPUTS = 15;
        public static int M_WIDTH = 40;
        public static int M_HEIGHT = 40;
        
        public static int M_MAX_ENERGY = 6050;
        public static int M_ENERGY_INCREMENT = 1050;
        public static int M_LIFE_COST = 30;

        public static Bitmap BITMAP; // TODO: Remove

        private double mDTAngle = 0.0;
        private double mAngle = 0.0;
        private PointF mPosition;
        private double mVelocityScalar;
        private Bitmap mParent;
        private double mEnergy = 0.0;
        private Bitmap mSelfImage;
        private long mAge = 0;
        private int mGeneration = 0;

        public static void InitImage()
        {
            BITMAP = new Bitmap(M_WIDTH + 2, M_HEIGHT + 2);
            Graphics surface = Graphics.FromImage(BITMAP);
            surface.DrawRectangle(Pens.Black, 1, 1, M_WIDTH, M_HEIGHT);
            surface.FillRectangle(Brushes.GreenYellow, 2, 2, M_WIDTH - 1, M_HEIGHT - 1);
        }

        public AIEntity()
        {
            mSelfImage = (Bitmap)BITMAP.Clone();
            mVelocityScalar = 0.0;
            mEnergy = M_MAX_ENERGY;
        }

        public AIEntity(Bitmap cParent) : this()
        {
            mParent = cParent;

            mBrain = new MeshBrain(M_INPUTS, M_OUTPUTS);

            for (int ii = 0; ii < 100; ii++)
                mBrain.Mutate();

            mPosition = new PointF(GameState.RAND.Next(5, GameForm.M_WIDTH - 5), GameState.RAND.Next(20, 580));
        }

        /// <summary>
        ///  StepTime calculates the inputs for an entity and flushes them, 
        ///  getting the outputs, and acting on them
        /// </summary>
        /// <param name="fooded">true if the organism has access to food</param>
        /// <param name="poisoned">true if the organism is poisoned</param>
        /// <returns>true if organism is still alive at the end of the turn</returns>
        public bool StepTime(bool fooded, bool poisoned)
        {
            mBrain.ForwardProp();
            double percentFull = mEnergy / M_MAX_ENERGY;
            Graphics gfxImg = Graphics.FromImage(mSelfImage);
            gfxImg.Clear(Color.Transparent);
            gfxImg.DrawRectangle(Pens.Black, 1, 1, M_WIDTH, M_HEIGHT);
            gfxImg.FillRectangle(Brushes.LightBlue, 2, 2, M_WIDTH - 1, M_HEIGHT - 1);
            gfxImg.FillRectangle(Brushes.Pink, 2 + (int)Math.Round(M_WIDTH / 2.0 - percentFull * M_WIDTH / 2.0), 2 + (int)Math.Round(M_HEIGHT / 2.0 - percentFull * M_HEIGHT / 2.0),
                (int)Math.Round(percentFull * M_WIDTH) - 1, (int)Math.Round(percentFull * M_HEIGHT) - 1);
            
            if (fooded && mEnergy < M_MAX_ENERGY - M_ENERGY_INCREMENT)
                mEnergy += M_ENERGY_INCREMENT;
            
            if (poisoned)
                mEnergy -= 6000;
            
            mAngle += mDTAngle;
            mPosition.X += (float)(Math.Cos(mAngle) * mVelocityScalar);
            mPosition.Y -= (float)(Math.Sin(mAngle) * mVelocityScalar);
            
            // Written-out, long way of modding position
            /*if (mPosition.X < 0)
                mPosition.X = GameForm.M_WIDTH + mPosition.X;
            else if (mPosition.X > GameForm.M_WIDTH)
                mPosition.X = mPosition.X - GameForm.M_WIDTH;

            if (mPosition.Y < 0)
                mPosition.Y = GameForm.M_HEIGHT + mPosition.Y;
            else if (mPosition.Y > GameForm.M_HEIGHT)
                mPosition.Y = mPosition.Y - GameForm.M_HEIGHT;*/

            // Energy Costs
            mEnergy -= M_LIFE_COST;
            mEnergy -= Math.Pow(1.6, Math.Abs(mVelocityScalar)) / 2;
            mEnergy -= Math.Abs(mDTAngle / 3);
            
            // You have died
            if (mEnergy <= 0)
                return false;
            
            double[] sight = See();

            for (int i = 0; i < sight.Length; i+=2)
            {
                mBrain.Inputs[i].BitState = sight[i / 2];
                mBrain.Inputs[i + 1].BitState = sight[i / 2] / 10;
            }

            mBrain.Inputs[5].BitState = percentFull;
            mBrain.Inputs[6].BitState = LogicIO.Toolbox.NORM.NextDouble();
            mBrain.Inputs[7].BitState = mVelocityScalar;
            mBrain.Inputs[8].BitState = 0.9 * mBrain.Outputs[12].BitState;
            mBrain.Inputs[9].BitState = mBrain.Outputs[13].BitState;
            mBrain.Inputs[10].BitState = mBrain.Outputs[10].BitState;
            mBrain.Inputs[11].BitState = mBrain.Outputs[11].BitState;
            mBrain.Inputs[12].BitState = Math.Abs(mDTAngle);
            mBrain.Inputs[13].BitState = (mDTAngle < 0) ? 0.75 : 0;
            mBrain.Inputs[mBrain.Inputs.Length - 1].BitState = 0.9 * mBrain.Outputs[10].BitState;

            mBrain.ForwardProp();

            double velDel = mBrain.Outputs[0].BitState * 100;
            
            if (mBrain.Outputs[5].BitState > 0)
                velDel *= -1;
            if (velDel < 0 && mVelocityScalar > 0)
                Console.WriteLine();

            if (mBrain.Outputs[3].BitState > 0.5)
                velDel += mBrain.Outputs[4].BitState * -1;
            else
                velDel += mBrain.Outputs[4].BitState;

            if (mBrain.Outputs[6].BitState > 0.5)
                velDel += mBrain.Outputs[7].BitState * -1;
            else
                velDel += mBrain.Outputs[7].BitState;

            velDel /= 1000;

            if (Math.Abs(mVelocityScalar) <= 10000) 
                mVelocityScalar += velDel;

            double angDel = mBrain.Outputs[1].BitState / 10;
            if (mBrain.Outputs[2].BitState > 0.5)
                angDel *= -1;

            mDTAngle = angDel;

            mBrain.ResetPorts();

            mAge++;
            mBrain.Step++;

            return true;
        }

        /// <summary>
        /// Draws the current AIEntity to it's own bitmap
        /// </summary>
        public void Draw()
        {
            Graphics surface = Graphics.FromImage(mParent);
            
            surface.DrawImage(mSelfImage, mPosition.X - M_WIDTH / 2, mPosition.Y - M_HEIGHT / 2);
            surface.DrawString(String.Format("{0}\n{1:0.00}", mBrain.ID, mVelocityScalar), SystemFonts.MenuFont, Brushes.Black, mPosition.X - 8, mPosition.Y - 8);
            surface.DrawLine(Pens.Red, (float)mPosition.X, (float)mPosition.Y, (float)mPosition.X + (float)(45 * Math.Cos(mAngle)), (float)mPosition.Y - (float)(45 * Math.Sin(mAngle)));
        }

        /// <summary>
        /// See returns an array of doubles corresponding to the color values of a pixel
        /// an arbitrary distance away.
        /// </summary>
        /// <returns></returns>
        private double[] See()
        {
            double[] bitdata = new double[3] { 0.0, 0.0, 0.0 };
            int magnitude = 60;
            int dy = (int)Math.Round(Math.Sin(mAngle) * magnitude);
            int dx = (int)Math.Round(Math.Cos(mAngle) * magnitude);
            int x = (int)mPosition.X + dx + 1;
            int y = (int)mPosition.Y - dy + 1;

            if (x < 0)
                x = GameForm.M_WIDTH + x;
            else if (x > GameForm.M_WIDTH)
                x = x - GameForm.M_WIDTH;

            if (y < 0)
                y = GameForm.M_HEIGHT + y;
            else if (y > GameForm.M_HEIGHT)
                y = y - GameForm.M_HEIGHT;

            if (x > 0 && x < mParent.Width && y > 0 && y < mParent.Height)
            {
                Color result = mParent.GetPixel(x, y);
                Graphics gfxImg = Graphics.FromImage(mSelfImage);
                gfxImg.FillRectangle(new SolidBrush(result), 5, 5, 5, 5);
                bitdata[0] = (double)result.R / 255.0;
                bitdata[1] = (double)result.R / 255.0;
                bitdata[2] = (double)result.R / 255.0;
            }
            else
            {
                Graphics gfxImg = Graphics.FromImage(mSelfImage);
                gfxImg.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), 5, 5, 5, 5);
                bitdata[0] = 0.0;
                bitdata[1] = 0.0;
                bitdata[2] = 0.0;
            }

            return bitdata;
        }

        public object Clone()
        {
            AIEntity newEntity = new AIEntity();
            newEntity.mParent = mParent;
            newEntity.mPosition = new PointF(mPosition.X, mPosition.Y);
            newEntity.mBrain = (Brain)mBrain.Clone();
            newEntity.mGeneration = mGeneration + 1;
            return newEntity;
        }

        public AIEntity Mutate()
        {
            mBrain.Mutate();
            return this;
        }

        public void Feed()
        {
            mEnergy = M_MAX_ENERGY;
        }

        public void Smite()
        {
            mEnergy = 0;
        }

        public Port[] Inputs
        {
            get { return mBrain.Inputs; }
        }

        public Port[] Outputs
        {
            get { return mBrain.Outputs; }
        }

        public int ID
        {
            get { return mBrain.ID; }
        }

        public PointF Position
        {
            get { return mPosition; }
            set { mPosition = value; }
        }

        public Brain ParentBrain
        {
            get { return mBrain; }
        }

        public long Age
        {
            get { return mAge; }
        }

        public int Generation
        {
            get { return mGeneration; }
        }
    }
}
