namespace PrimitiveAndMessageObsession.MessageObsession
{
	public class RobotService
	{
		private Robot robot = new Robot();

		public void MoveCommand()
		{
			// Message obsession leads to code like this
			robot.MoveSouth();
			robot.MoveNorth();


			// and what we want is to code look like this:

			// direction constants
			var north = new Direction(xCoordinate: 0, yCoordinate: -1);
			var east = new Direction(1, 0);
			var south = new Direction(0, 1);
			var west = new Direction(-1, 0);

			robot.Move(north);
			robot.Move(south);
		}
	}

	// Symptoms caused by this smell include...
	// class hierarchies that mirror the direction methods

	interface IMoveCommand
	{
		void ApplyTo(Robot robot);
	}

	public class MoveNorth : IMoveCommand
	{
		public void ApplyTo(Robot robot) => robot.MoveNorth();
	}

	public class MoveSouth : IMoveCommand
	{
		public void ApplyTo(Robot robot) => robot.MoveSouth();
	}
}