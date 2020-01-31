using System;
using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Locations;
using MarsRover.Plateaus;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace MarsRover.Test
{
    [TestFixture]
    public class LocationTest : TestBase
    {
        #region .setup

        private ILocation _location;
        private IPlateau _plateau;

        protected override void SetUp()
        {
            _plateau = Substitute.For<Plateau>();
            _location = new Location(_plateau);
            base.SetUp();
        }

        #endregion

        [Test]
        public void Location_GIVENEnterInvalidCoordinate_WHENIsNotValid_THENItShouldBeThrowsException()
        {
            CreatePlateau();
            Assert.Throws<Exception>(() => _location.SetLocation(new Coordinate(3, 3)));
        }

        [Test]
        public void Location_GIVENEnterValidCoordinate_WHENSetSizeValid_ShouldBeSuccess()
        {
            CreatePlateau();
            _location.SetLocation(new Coordinate(1,1));
            _location.X.ShouldBe(1);
            _location.Y.ShouldBe(1);
        }

        [Test]
        public void Location_GIVENChangeDirection_WHENIsNotValid_THENItShouldBeThrowsException()
        {
            CreatePlateau();
            _location.SetLocation(new Coordinate(1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => _location.ChangeLocation((DirectionType)4));
        }

        [Test]
        public void Location_GIVENChangeDirection_WHENChange_ShouldBeSuccess()
        {
            CreatePlateau();
            _location.SetLocation(new Coordinate(1,1));
            _location.ChangeLocation(DirectionType.South);
            _location.X.ShouldBe(1);
            _location.Y.ShouldBe(0);
        }

        private void CreatePlateau()
        {
            _plateau.SetSize(new Coordinate(1, 2));
            _plateau.X.ShouldBe(1);
            _plateau.Y.ShouldBe(2);
        }
    }
}
