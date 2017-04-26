using System.Collections.Generic;

namespace Wpf
{
	public class HistoryCommand
	{
		private readonly List<string> historyList = new List<string>();
		public int Index { get; private set; }

		public int Size => historyList.Count;

		public HistoryCommand()
		{
			Index = -1;
		}

		public void Add(string cmd)
		{
			if(GetCurrent() != cmd) historyList.Add(cmd);
			Index = historyList.Count;
		}

		public string GetItem(int position)
		{
			if (position < 0 || position > Size - 1)
			{
				return null;
			}

			return historyList[position];
		}

		public string GetCurrent()
		{
			return GetItem(Index);
		}

		public string SelectPreviuos()
		{
			string cmd = null;

			if (Index >= 1)
			{
				Index -= 1;
				cmd = GetCurrent();
			}

			return cmd;
		}

		public string SelectNext()
		{
			string cmd = null;

			if (Index <= Size - 2)
			{
				Index += 1;
				cmd = GetCurrent();
			}

			return cmd;
		}
	}
}