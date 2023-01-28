using System;
using System.ComponentModel;
using System.Windows.Shapes;
using NUnit.Framework;
using WPF_Design.ViewModels;

namespace WPF_Design.Tests.ViewModelsTests
{
    public class DrawingViewModelTests
    {
        private DrawingViewModel _drawingViewModel=new();

        [Test]
        public void SelectedObjectShouldRaiseEvent()
        {
            Assert.That(_drawingViewModel.SelectedObject, Is.Null, "SelectedObject should return false now.");

            bool eventIsCorrect = false;
            _drawingViewModel.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "SelectedObject";
                };

            _drawingViewModel.SelectedObject = new object();

            Assert.Multiple(() =>
            {
                Assert.That(
                  eventIsCorrect, Is.True,
                  "Setting SelectedObject to true did not raise PropertyChanged event correctly.");

                Assert.That(_drawingViewModel.SelectedObject, Is.TypeOf(typeof(object)) , "SelectedObject should return true now.");
            });
        }
    }
}
