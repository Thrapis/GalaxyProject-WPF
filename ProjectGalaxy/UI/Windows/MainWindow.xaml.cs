using ProjectGalaxy.Models.Generaton;
using ProjectGalaxy.Models.Space;
using ProjectGalaxy.Models.Transformation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectGalaxy.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double CanvasWidth = 750;
        static double CanvasHeight = 400;

        Vector CurrentMoveOffset;
        double CurrentZoom = 1;
        double MaxZoom = 16;
        double MinZoom = 1;

        double MoveSensivity = 1;
        double RotateSensivity = 1;
        double WheelSensivity = 0.4;
        bool LeftHold = false;
        bool RightHold = false;
        Point LeftStart;
        Point LeftStartCanvas;
        Point RightStart;
        TransformGroup CanvasTransform = new TransformGroup();

        public Star CenterBlackHole { get; private set; }
        public CompositeCollection Space { get; private set; }
        public ObservableCollection<Star> Stars { get; private set; }
        public ObservableCollection<HyperCorridor> HyperCorridors { get; private set; }

        public MainWindow()
        {
            Space = new CompositeCollection();
            Stars = new ObservableCollection<Star>();
            HyperCorridors = new ObservableCollection<HyperCorridor>();
            CenterBlackHole = new Star(StarType.TypeBlackHole, 20, CanvasWidth / 2, CanvasHeight / 2);
            GenerateGalaxy();
            InitializeComponent();
            DataContext = this;
            SpaceField.RenderTransform = CanvasTransform;
        }

        public void UpdateGalaxy(object sender, RoutedEventArgs e)
        {
            GenerateGalaxy(int.Parse(StarsCount.Text), float.Parse(ArmsDistance.Text));
        }

        public void GenerateGalaxy(int starsCount = 1000, float armsDistance = 3.3f)
        {
            Stars = new ObservableCollection<Star>();
            HyperCorridors = new ObservableCollection<HyperCorridor>();
            CenterBlackHole = new Star(StarType.TypeBlackHole, 20, CanvasWidth / 2, CanvasHeight / 2);

            GenerationOptions options =
                new GenerationOptions(CenterBlackHole.Position, CenterBlackHole.Diameter, 400, starsCount, armsDistance, 0.02f, 0.09f, 10f);
            Point[] points = GalaxyGenerator.GenerateGalaxy(options);
            foreach (var point in points)
            {
                var star = new Star(StarType.RandomSimpleType, 1, point);
                bool canInsert = true;
                foreach (var selStar in Stars)
                {
                    if (star.GetDistanceTo(selStar) <= 3)
                    {
                        canInsert = false;
                        break;
                    }
                }
                if (canInsert) Stars.Add(star);
            }

            Space.Clear();
            Space.Add(new CollectionContainer() { Collection = HyperCorridors });
            Space.Add(new CollectionContainer() { Collection = Stars });
            Space.Add(new CollectionContainer() { Collection = new ObservableCollection<Star>() { CenterBlackHole } });
        }

        private void MouseLeftButtonDownCanvas(object sender, MouseButtonEventArgs e) {
            LeftHold = true; LeftStart = e.GetPosition(CanvasBack); LeftStartCanvas = CanvasTransform.Transform(e.GetPosition(CanvasBack));
        }
        private void MouseRightButtonDownCanvas(object sender, MouseButtonEventArgs e) { RightHold = true; RightStart = e.GetPosition(CanvasBack); }
        private void MouseLeaveCanvas(object sender, MouseEventArgs e) { LeftHold = false; RightHold = false; }
        private void MouseLeftButtonUpCanvas(object sender, MouseButtonEventArgs e) => LeftHold = false;
        private void MouseRightButtonUpCanvas(object sender, MouseButtonEventArgs e) => RightHold = false;
        private void MouseMoveCanvas(object sender, MouseEventArgs e)
        {
            if (LeftHold)
            {
                
                Point next = e.GetPosition(CanvasBack);
                Point nextCanvas = CanvasTransform.Transform(e.GetPosition(CanvasBack));
                double xOffset = (next.X - LeftStart.X) * MoveSensivity;
                double yOffset = (next.Y - LeftStart.Y) * MoveSensivity;

                CurrentMoveOffset = new Vector(CurrentMoveOffset.X + xOffset, CurrentMoveOffset.Y + yOffset);

                var transform = new MoveAction(xOffset, yOffset).GetTransform();
                CanvasTransform.Children.Add(transform);

                LeftStart = next;
                LeftStartCanvas = nextCanvas;
            }
            if (RightHold)
            {
                Point next = e.GetPosition(CanvasBack);
                var center = CanvasTransform.Transform(CenterBlackHole.Position);
                double beforeAngle =
                    Math.Atan2(RightStart.Y - center.Y, RightStart.X - center.X) * 180 / Math.PI;
                double afterAngle = 
                    Math.Atan2(next.Y - center.Y, next.X - center.X) * 180 / Math.PI;
                double angle = RotateSensivity * (afterAngle - beforeAngle);
                var transform = new RotateAction(center, angle).GetTransform();
                CanvasTransform.Children.Add(transform);
                RightStart = next;
            }
        }
        private void MouseWheelCanvas(object sender, MouseWheelEventArgs e)
        {
            double delta = CurrentZoom * WheelSensivity * e.Delta / Math.Abs(e.Delta);
            if (CurrentZoom + delta > MaxZoom) delta -= CurrentZoom + delta - MaxZoom;
            if (CurrentZoom + delta < MinZoom) delta -= CurrentZoom + delta - MinZoom;
            Point location = e.GetPosition(CanvasBack);
            double zoom = (CurrentZoom + delta) / CurrentZoom;
            var transform = new ZoomAction(location, zoom).GetTransform();
            CanvasTransform.Children.Add(transform);
            CurrentZoom += delta;
            //TextUI2.Text = $"Zoom: {CurrentZoom} (+{delta})";
        }
    }
}
