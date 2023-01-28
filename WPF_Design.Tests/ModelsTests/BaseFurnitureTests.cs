using NUnit.Framework;
using System.ComponentModel;
using WPF_Design.Models;

namespace WPF_Design.Tests.ModelsTests
{
    public class BaseFurnitureTests
    {
        private BaseFurniture _baseFurniture;

        public BaseFurnitureTests()
        {
            _baseFurniture = new Chair();
        }

        [Test]
        public void IdPropertyShouldRaiseEventWhenChanged()
        {
            Assert.That(_baseFurniture.Id, Is.EqualTo(0));

            bool eventIsCorrect = false;
            _baseFurniture.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "Id";
                };

            _baseFurniture.Id = 1;

            Assert.Multiple(() =>
            {
                Assert.That(eventIsCorrect, Is.True);

                Assert.That(_baseFurniture.Id, Is.EqualTo(1));
            });
        }

        [Test]
        public void NamePropertyShouldRaiseEventWhenChanged()
        {
            Assert.That(_baseFurniture.Name, Is.EqualTo("Chair"));

            bool eventIsCorrect = false;
            _baseFurniture.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "Name";
                };

            _baseFurniture.Name = "New Chair";

            Assert.Multiple(() =>
            {
                Assert.That(eventIsCorrect, Is.True);

                Assert.That(_baseFurniture.Name, Is.EqualTo("New Chair"));
            });
        }

        [Test]
        public void DescriptionPropertyShouldRaiseEventWhenChanged()
        {
            Assert.That(_baseFurniture.Description, Is.EqualTo("A chair."));

            bool eventIsCorrect = false;
            _baseFurniture.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "Description";
                };

            _baseFurniture.Description = "A chair description.";

            Assert.Multiple(() =>
            {
                Assert.That(eventIsCorrect, Is.True);

                Assert.That(_baseFurniture.Description, Is.EqualTo("A chair description."));
            });
        }

        [Test]
        public void ColorPropertyShouldRaiseEventWhenChanged()
        {
            Assert.That(_baseFurniture.Color, Is.EqualTo("Black"));

            bool eventIsCorrect = false;
            _baseFurniture.PropertyChanged +=
                delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventIsCorrect = e.PropertyName == "Color";
                };

            _baseFurniture.Color = "Brown";

            Assert.Multiple(() =>
            {
                Assert.That(eventIsCorrect, Is.True);

                Assert.That(_baseFurniture.Color, Is.EqualTo("Brown"));
            });
        }
    }
}
