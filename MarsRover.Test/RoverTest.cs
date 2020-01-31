using System;
using MarsRover.Coordinates;
using MarsRover.Directions;
using MarsRover.Locations;
using MarsRover.Plateaus;
using MarsRover.Rovers;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace MarsRover.Test
{
    [TestFixture]
    public class RoverTest : TestBase
    {
        #region .setup

        private ILocation _location;
        private IDirection _direction;
        private IPlateau _plateau;
        private IRover _rover;

        protected override void SetUp()
        {
            _direction = Substitute.For<Direction>();
            _plateau = Substitute.For<Plateau>();
            _location = new Location(_plateau);
            _rover = new Rover(_location,_direction);
            base.SetUp();
        }

        #endregion

        [Test, Category("Unit")]
        public void Rover_GIVENLocation_WHENIsNotValid_THENItShouldBeThrowsException()
        {
            _plateau.SetSize(new Coordinate(2, 2));
            _location.SetLocation(new Coordinate(1, 2));
            Assert.Throws<Exception>(() => _rover.SetLocation(new Coordinate(3, 3)));
        }

        [Test, Category("Unit")]
        public void Rover_GIVENInputs_WHENTurnLeft_THENItBecomesSuccessfully()
        {
            _plateau.SetSize(new Coordinate(5, 5));
            _location.SetLocation(new Coordinate(2, 3));
            _rover.TurnDirection(DirectionType.South);
            _rover.GiveCommand("L");

            _rover.GetCurrentPosition().ShouldBe("2 3 East");
        }

        [Test, Category("Unit")]
        public void Rover_GIVENInputs_WHENTurnRight_THENItBecomesSuccessfully()
        {
            _plateau.SetSize(new Coordinate(5, 5));
            _location.SetLocation(new Coordinate(2, 3));
            _rover.TurnDirection(DirectionType.South);
            _rover.GiveCommand("R");

            _rover.GetCurrentPosition().ShouldBe("2 3 West");
        }

        [Test, Category("Unit")]
        public void Rover_GIVENInputs_WHENMoveOnGrid_THENItBecomesSuccessfully()
        {
            _plateau.SetSize(new Coordinate(5, 5));
            _location.SetLocation(new Coordinate(2, 3));
            _rover.TurnDirection(DirectionType.South);
            _rover.GiveCommand("M");

            _rover.GetCurrentPosition().ShouldBe("2 2 South");
        }

        [Test, Category("Unit")]
        public void Rover_GIVENInputs_WHENExecuted_THENItBecomesSuccessfully()
        {
            _plateau.SetSize(new Coordinate(5, 5));
            _location.SetLocation(new Coordinate(2, 3));
            _rover.TurnDirection(DirectionType.South);
            _rover.GiveCommand("LMLMLMLMM");

            _rover.GetCurrentPosition().ShouldBe("2 2 South");
        }

    }
}
