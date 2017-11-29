using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace gameMenu
{
    class Spawner
    {
        private List<Image> ImageList = new List<Image>();
        private List<Minion> MinionList = new List<Minion>();
        private Canvas canvas;

        private void GetSpawnLocation(SpawnLocation sp, out double X, out double Y)
        {
            X = -1;
            Y = -1;
            switch (sp)
            {
                case SpawnLocation.LEFT:
                    X = 50;
                    Y = 375;
                    break;
                case SpawnLocation.DOWN:
                    X = 375;
                    Y = 700;
                    break;
                case SpawnLocation.RIGHT:
                    X = 700;
                    Y = 375;
                    break;
                case SpawnLocation.UP:
                    Y = 50;
                    X = 375;
                    break;

            } 
        }
        private Minion GetEnemyType(EnemyType et)
        {
            var min = new object();
            switch (et)
            {
                case EnemyType.IMP:
                    min = new Imp(1, StaticURIs.Imp_BitMaps);
                    break;
            }
            return (Minion)min;
        }
        public void InitSpawner(ref Canvas gcanvas)
        {
            canvas = gcanvas;
        }

        public Spawner(List<Image> imList, List<Minion> minList)
        {
            ImageList = imList;
            MinionList = minList;
        }

        public void Add(Image image, Minion minion)
        {
            ImageList.Add(image);
            MinionList.Add(minion);
        }

        public void Spawn()
        {
            Lottery<EnemyType> lottery = new Lottery<EnemyType>();
            lottery.Add(EnemyType.IMP);


            Lottery<SpawnLocation> lotteryS = new Lottery<SpawnLocation>();
            lotteryS.Add(SpawnLocation.DOWN);
            lotteryS.Add(SpawnLocation.LEFT);
            lotteryS.Add(SpawnLocation.RIGHT);
            lotteryS.Add(SpawnLocation.UP);

            SpawnLocation spawn = lotteryS.GetWinner();
            EnemyType enemy = lottery.GetWinner();

            var getMinion = GetEnemyType(enemy);
            double x, y;
            GetSpawnLocation(spawn, out x, out y);
            Image image = new Image();

            image.Height = image.Width = 50;            
            canvas.Children.Add(image);
            Canvas.SetLeft(image, x);
            Canvas.SetTop(image, y);

            getMinion.InitMinion(ref image, ref canvas);
            image.Source = getMinion.GetStandby();
            getMinion.SetLocation(x, y);

            Add(image, getMinion);
        }

    }
    enum SpawnLocation
    {
        UP, LEFT, DOWN, RIGHT
    }
    enum EnemyType
    {
        IMP
    }

    public class Waves
    {
        public List<int> DefinedWaves = new List<int>();
        public Waves()
        {
           // DefinedWaves.Add(1);
            DefinedWaves.Add(12);
            DefinedWaves.Add(4);
            DefinedWaves.Add(6);
            DefinedWaves.Add(8);
            DefinedWaves.Add(10);
            DefinedWaves.Add(12);
        }
        public void AddWaveExp()
        {
            int LastWaveCount = DefinedWaves[DefinedWaves.Count - 1];
            DefinedWaves.Add(LastWaveCount * 2);
        }
        public int Count() => DefinedWaves.Count;
        public int this[int index]
        {
            get { return DefinedWaves[0]; }
        }
    }
}
