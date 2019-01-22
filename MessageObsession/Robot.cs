namespace PrimitiveAndMessageObsession.MessageObsession
{
	public class Robot
	{
		private int xCoordinate;
		private int yCoordinate;

		public void MoveSouth()
		{
			xCoordinate = 0;
			yCoordinate = 1;

			// do something ...
		}

		public void MoveNorth()
		{
			xCoordinate = -1;
			yCoordinate = 0;

			// do something ...
		}

		public void Move(Direction direction)
		{
			// do something ...
		}
	}

	public class Direction
	{
		private int _xCoordinate;
		private int _yCoordinate;

		public Direction(int xCoordinate, int yCoordinate)
		{
			this._xCoordinate = xCoordinate;
			this._yCoordinate = yCoordinate;
		}

		public void Inverse()
		{
			// do something 
		}

		public void RotatedClockwise()
		{
			// do something 
		}
	}
}