using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Design.BusinessLogicLayer
{
    public class DistanceManipulation
    {
        public static double CalculateDistance(Point startPoint, Point endPoint)
        {
            return Math.Sqrt(Math.Pow((endPoint.X - startPoint.X), 2) +
                Math.Pow((endPoint.Y - startPoint.Y), 2)) * 0.264583d;
        }

        public static Label DisplayDistance(Point startPoint, Point endPoint, double distance)
        {
            Label label = new()
            {
                Content = Math.Round(distance, 2).ToString() + " mm",
                Foreground = new SolidColorBrush(Colors.White),
                Background = new SolidColorBrush(Colors.Red),
                Margin = new Thickness((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2, 0, 0)
            };
            return label;
        }
    }
}
